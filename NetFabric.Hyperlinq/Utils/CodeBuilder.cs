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

        StringBuilder Indent()
        {
            for (var level = 0; level < currentLevel; level++)
                _ = builder.Append(indentation);

            return builder;
        }

        public CodeBuilder AppendIndentation()
        {
            _ = builder.Append(indentation);
            return this;
        }

        public CodeBuilder AppendLine()
        {
            _ = builder.AppendLine();
            return this;
        }

        public CodeBuilder AppendLine(char text)
        {
            _ = Indent().Append(text).AppendLine();
            return this;
        }

        public CodeBuilder AppendLine(string text)
        {
            _ = Indent().AppendLine(text);
            return this;
        }

        public CodeBuilder AppendLine(Action<StringBuilder> line)
        {
            _ = Indent();
            line(builder);
            _ = AppendLine();
            return this;
        }

        public IDisposable AppendBlock()
        {
            _ = AppendLine('{');
            currentLevel++;
            // ReSharper disable once HeapView.ObjectAllocation.Evident
            return new CloseBlock(this);
        }

        public IDisposable AppendBlock(string text) 
            => AppendLine(text).AppendBlock();

        class CloseBlock : IDisposable
        {
            readonly CodeBuilder builder;

            public CloseBlock(CodeBuilder builder) 
                => this.builder = builder;

            public void Dispose()
            {
                builder.currentLevel--;
                _ = builder.AppendLine('}');
            }
        }

        public override string ToString() 
            => builder.ToString();
    }
}
