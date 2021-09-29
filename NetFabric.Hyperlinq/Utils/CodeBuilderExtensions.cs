using System;
using System.Reflection;

namespace NetFabric.Hyperlinq.SourceGenerator
{
    static class CodeBuilderExtensions
    {
        static readonly string assemblyName = typeof(CodeBuilder).Assembly
            .GetName().Name;
        static readonly string assemblyVersion = typeof(CodeBuilder).Assembly
            .GetCustomAttribute<AssemblyInformationalVersionAttribute>()?.InformationalVersion 
            ?? string.Empty;

        public static CodeBuilder AppendGeneratedCodeMethodAttributes(this CodeBuilder builder)
            => builder.IsUnitTest 
                ? builder // do nothing
                : builder.AppendLine($"[GeneratedCode(\"{assemblyName}\", \"{assemblyVersion}\")]")
                    .AppendLine("[DebuggerNonUserCode]")
                    .AppendLine("[ExcludeFromCodeCoverage]")
                    .AppendLine("[EditorBrowsable(EditorBrowsableState.Never)]");
    }
}
