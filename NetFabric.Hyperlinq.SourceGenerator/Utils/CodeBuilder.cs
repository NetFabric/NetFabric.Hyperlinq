using System;
using System.Text;

namespace NetFabric.Hyperlinq.SourceGenerator
{
    class CodeBuilder
    {
        static readonly string identation = "    ";

        readonly StringBuilder builder = new();
        int currentLevel = 0;

        StringBuilder Indent()
        {
            for (var level = 0; level < currentLevel; level++)
                _ = builder.Append(identation);

            return builder;
        }

        public CodeBuilder AppendIdentation()
        {
            _ = builder.Append(identation);
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
