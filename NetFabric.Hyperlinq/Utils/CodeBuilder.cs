using System;
using System.IO;
using System.Reflection;
using System.Text;

namespace NetFabric.Hyperlinq.SourceGenerator
{
    class CodeBuilder
    {
        const string indentation = "    ";

        readonly StringBuilder builder = new();
        int currentLevel = 0;

        public bool IsUnitTest { get; init; } = false;

        StringBuilder AppendIndents()
        {
            for (var level = 0; level < currentLevel; level++)
                _ = builder.Append(indentation);

            return builder;
        }

        public CodeBuilder Indent()
        {
            _ = builder.Append(indentation);
            return this;
        }

        public CodeBuilder Line()
        {
            _ = builder.AppendLine();
            return this;
        }

        public CodeBuilder Line(char text)
        {
            _ = AppendIndents().Append(text).AppendLine();
            return this;
        }

        public CodeBuilder Line(string text)
        {
            _ = AppendIndents().AppendLine(text);
            return this;
        }

        public CodeBuilder Line(Action<StringBuilder> line)
        {
            _ = AppendIndents();
            line(builder);
            _ = Line();
            return this;
        }

        public IDisposable Block()
        {
            _ = Line('{');
            currentLevel++;
            // ReSharper disable once HeapView.ObjectAllocation.Evident
            return new CloseBlock(this);
        }

        public IDisposable Block(string text) 
            => Line(text).Block();

        public CodeBuilder MethodBlock(string header, Action<CodeBuilder> block)
        {
            using (Block(header))
            {
                block(this);
            }
            return this;
        }

        public CodeBuilder IfBlock(string condition, Action<CodeBuilder> block)
        {
            using (Block($"if ({condition})"))
            {
                block(this);
            }
            return this;
        }

        public CodeBuilder IfBlock(string condition, Action<CodeBuilder> trueBlock, Action<CodeBuilder> falseBlock)
        {
            using (Block($"if ({condition})"))
            {
                trueBlock(this);
            }
            using (Block("else"))
            {
                falseBlock(this);
            }
            return this;
        }

        public CodeBuilder ForEachBlock(string text, Action<CodeBuilder> block)
        {
            using (Block($"foreach ({text})"))
            {
                block(this);
            }
            return this;
        }

        public CodeBuilder ForBlock(string text, Action<CodeBuilder> block)
        {
            using (Block($"for ({text})"))
            {
                block(this);
            }
            return this;
        }

        public CodeBuilder WhileBlock(string text, Action<CodeBuilder> block)
        {
            using (Block($"while ({text})"))
            {
                block(this);
            }
            return this;
        }

        public CodeBuilder CheckedBlock(Action<CodeBuilder> block)
        {
            using (Block("checked"))
            {
                block(this);
            }
            return this;
        }

        class CloseBlock : IDisposable
        {
            readonly CodeBuilder builder;

            public CloseBlock(CodeBuilder builder) 
                => this.builder = builder;

            public void Dispose()
            {
                builder.currentLevel--;
                _ = builder.Line('}');
            }
        }

        public override string ToString() 
            => builder.ToString();
    }
}
