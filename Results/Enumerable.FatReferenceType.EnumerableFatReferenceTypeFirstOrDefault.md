## Enumerable.FatReferenceType.EnumerableFatReferenceTypeFirstOrDefault

### Source
[EnumerableFatReferenceTypeFirstOrDefault.cs](../LinqBenchmarks/Enumerable/FatReferenceType/EnumerableFatReferenceTypeFirstOrDefault.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqFasterer: [2.1.0](https://www.nuget.org/packages/LinqFasterer/2.1.0)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- LinqOptimizer.CSharp: [0.7.0](https://www.nuget.org/packages/LinqOptimizer.CSharp/0.7.0)
- SpanLinq: [0.0.1](https://www.nuget.org/packages/SpanLinq/0.0.1)
- Streams.CSharp: [0.6.0](https://www.nuget.org/packages/Streams.CSharp/0.6.0)
- StructLinq.BCL: [0.27.0](https://www.nuget.org/packages/StructLinq/0.27.0)
- NetFabric.Hyperlinq: [3.0.0-beta48](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta48)
- System.Linq.Async: [5.0.0](https://www.nuget.org/packages/System.Linq.Async/5.0.0)
- Faslinq: [1.0.5](https://www.nuget.org/packages/Faslinq/1.0.5)

### Results:
``` ini

BenchmarkDotNet=v0.13.1, OS=macOS Catalina 10.15.7 (19H1519) [Darwin 19.6.0]
Intel Core i5-7360U CPU 2.30GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100
  [Host]        : .NET Core 3.1.20 (CoreCLR 4.700.21.47003, CoreFX 4.700.21.47101), X64 RyuJIT
  .NET 6        : .NET 6.0.0 (6.0.21.52210), X64 RyuJIT
  .NET 6 PGO    : .NET 6.0.0 (6.0.21.52210), X64 RyuJIT
  .NET Core 3.1 : .NET Core 3.1.20 (CoreCLR 4.700.21.47003, CoreFX 4.700.21.47101), X64 RyuJIT


```
|                   Method |           Job |                                                EnvironmentVariables |       Runtime | Count |     Mean |    Error |   StdDev |        Ratio | RatioSD |  Gen 0 | Allocated |
|------------------------- |-------------- |-------------------------------------------------------------------- |-------------- |------ |---------:|---------:|---------:|-------------:|--------:|-------:|----------:|
|              ForeachLoop |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 | 18.21 ns | 0.077 ns | 0.068 ns |     baseline |         | 0.0229 |      48 B |
|                     Linq |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 | 29.13 ns | 0.139 ns | 0.116 ns | 1.60x slower |   0.01x | 0.0229 |      48 B |
|                   LinqAF |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 | 41.72 ns | 0.106 ns | 0.099 ns | 2.29x slower |   0.01x | 0.0229 |      48 B |
|               StructLinq |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 | 26.79 ns | 0.029 ns | 0.024 ns | 1.47x slower |   0.01x | 0.0344 |      72 B |
| StructLinq_ValueDelegate |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 | 17.45 ns | 0.086 ns | 0.072 ns | 1.04x faster |   0.00x | 0.0229 |      48 B |
|                Hyperlinq |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 | 45.25 ns | 0.066 ns | 0.058 ns | 2.48x slower |   0.01x | 0.0344 |      72 B |
|                          |               |                                                                     |               |       |          |          |          |              |         |        |           |
|              ForeachLoop |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 | 14.62 ns | 0.100 ns | 0.094 ns |     baseline |         | 0.0229 |      48 B |
|                     Linq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 | 22.87 ns | 0.044 ns | 0.039 ns | 1.56x slower |   0.01x | 0.0229 |      48 B |
|                   LinqAF |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 | 40.04 ns | 0.101 ns | 0.084 ns | 2.74x slower |   0.02x | 0.0229 |      48 B |
|               StructLinq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 | 24.94 ns | 0.104 ns | 0.097 ns | 1.71x slower |   0.01x | 0.0344 |      72 B |
| StructLinq_ValueDelegate |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 | 14.39 ns | 0.021 ns | 0.019 ns | 1.02x faster |   0.01x | 0.0229 |      48 B |
|                Hyperlinq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 | 36.22 ns | 0.042 ns | 0.037 ns | 2.48x slower |   0.02x | 0.0344 |      72 B |
|                          |               |                                                                     |               |       |          |          |          |              |         |        |           |
|              ForeachLoop | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 24.54 ns | 0.064 ns | 0.060 ns |     baseline |         | 0.0229 |      48 B |
|                     Linq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 33.78 ns | 0.078 ns | 0.069 ns | 1.38x slower |   0.00x | 0.0229 |      48 B |
|                   LinqAF | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 47.04 ns | 0.080 ns | 0.071 ns | 1.92x slower |   0.01x | 0.0229 |      48 B |
|               StructLinq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 33.01 ns | 0.121 ns | 0.107 ns | 1.35x slower |   0.01x | 0.0344 |      72 B |
| StructLinq_ValueDelegate | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 23.18 ns | 0.046 ns | 0.043 ns | 1.06x faster |   0.00x | 0.0229 |      48 B |
|                Hyperlinq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 47.54 ns | 0.156 ns | 0.138 ns | 1.94x slower |   0.01x | 0.0344 |      72 B |
