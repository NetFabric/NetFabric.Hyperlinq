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

        public static CodeBuilder GeneratedCodeMethodAttributes(this CodeBuilder builder)
            => builder.IsUnitTest 
                ? builder // do nothing
                : builder.Line($"[GeneratedCode(\"{assemblyName}\", \"{assemblyVersion}\")]")
                    .Line("[DebuggerNonUserCode]")
                    .Line("[ExcludeFromCodeCoverage]")
                    .Line("[EditorBrowsable(EditorBrowsableState.Never)]");

        public static CodeBuilder AggressiveInliningAttribute(this CodeBuilder builder)
            => builder.Line("[MethodImpl(MethodImplOptions.AggressiveInlining)]");
    }
}
