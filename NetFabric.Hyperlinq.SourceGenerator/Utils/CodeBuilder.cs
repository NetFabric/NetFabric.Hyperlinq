using System;
using System.Text;

namespace NetFabric.Hyperlinq.SourceGenerator
{
    class CodeBuilder
    {
        static readonly string tab = "    ";

        readonly StringBuilder builder = new();
        int currentLevel = 0;

        StringBuilder AppendIndentation()
        {
            for (var level = 0; level < currentLevel; level++)
                _ = builder.Append(tab);

            return builder;
        }

        public CodeBuilder AppendLine()
        {
            _ = builder.AppendLine();
            return this;
        }

        public CodeBuilder AppendLine(char line)
        {
            _ = AppendIndentation().Append(line).AppendLine();
            return this;
        }

        public CodeBuilder AppendLine(string line)
        {
            _ = AppendIndentation().AppendLine(line);
            return this;
        }

        public CodeBuilder AppendLine(Action<StringBuilder> line)
        {
            _ = AppendIndentation();
            line(builder);
            _ = AppendLine();
            return this;
        }

        public IDisposable AppendBlock(string line) 
        {
            _ = AppendLine(line).AppendLine('{');
            currentLevel++;
            return new CloseBlock(this);
        }

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
