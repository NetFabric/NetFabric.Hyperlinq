using NetFabric.Hyperlinq.SourceGenerator.Utils;
using System;
using System.Text;

namespace NetFabric.Hyperlinq.SourceGenerator
{
    class CodeBuilder : IDisposable
    {
        static readonly string tab = "    ";

        readonly StringBuilder builder = StringBuilderPool.Get();
        int currentLevel = 0;

        void AppendSpaces()
        {
            for (var level = 0; level < currentLevel; level++)
                _ = builder.Append(tab);
        }

        public void AppendLine()
            => builder.AppendLine();

        public void AppendLine(char line)
        {
            AppendSpaces();
            _ = builder.Append(line);
            _ = builder.AppendLine();
        }

        public void AppendLine(string line)
        {
            AppendSpaces();
            _ = builder.AppendLine(line);
        }

        public IDisposable AppendBlock(string line)
        {
            AppendLine(line);
            AppendLine('{');
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
                builder.AppendLine('}');
            }
        }

        public override string ToString() 
            => builder.ToString();

        public void Dispose()
            => StringBuilderPool.Return(builder);
    }
}
