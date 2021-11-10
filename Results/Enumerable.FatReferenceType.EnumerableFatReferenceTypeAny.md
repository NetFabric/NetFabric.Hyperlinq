## Enumerable.FatReferenceType.EnumerableFatReferenceTypeAny

### Source
[EnumerableFatReferenceTypeAny.cs](../LinqBenchmarks/Enumerable/FatReferenceType/EnumerableFatReferenceTypeAny.cs)

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
|                   Method |           Job |                                                EnvironmentVariables |       Runtime | Count |     Mean |    Error |   StdDev |   Median |        Ratio | RatioSD |  Gen 0 | Allocated |
|------------------------- |-------------- |-------------------------------------------------------------------- |-------------- |------ |---------:|---------:|---------:|---------:|-------------:|--------:|-------:|----------:|
|              ForeachLoop |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 | 18.13 ns | 0.043 ns | 0.040 ns | 18.12 ns |     baseline |         | 0.0229 |      48 B |
|                     Linq |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 | 27.34 ns | 0.055 ns | 0.046 ns | 27.33 ns | 1.51x slower |   0.00x | 0.0229 |      48 B |
|                   LinqAF |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 | 37.25 ns | 0.086 ns | 0.067 ns | 37.24 ns | 2.05x slower |   0.01x | 0.0229 |      48 B |
|               StructLinq |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 | 25.89 ns | 0.049 ns | 0.041 ns | 25.87 ns | 1.43x slower |   0.00x | 0.0344 |      72 B |
| StructLinq_ValueDelegate |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 | 26.29 ns | 0.256 ns | 0.214 ns | 26.20 ns | 1.45x slower |   0.01x | 0.0344 |      72 B |
|                Hyperlinq |        .NET 6 |                                                               Empty |      .NET 6.0 |   100 | 23.93 ns | 0.026 ns | 0.024 ns | 23.93 ns | 1.32x slower |   0.00x | 0.0229 |      48 B |
|                          |               |                                                                     |               |       |          |          |          |          |              |         |        |           |
|              ForeachLoop |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 | 14.61 ns | 0.024 ns | 0.020 ns | 14.62 ns |     baseline |         | 0.0229 |      48 B |
|                     Linq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 | 24.44 ns | 0.028 ns | 0.022 ns | 24.44 ns | 1.67x slower |   0.00x | 0.0229 |      48 B |
|                   LinqAF |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 | 35.47 ns | 0.564 ns | 1.414 ns | 34.83 ns | 2.62x slower |   0.08x | 0.0229 |      48 B |
|               StructLinq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 | 21.83 ns | 0.089 ns | 0.158 ns | 21.79 ns | 1.49x slower |   0.00x | 0.0344 |      72 B |
| StructLinq_ValueDelegate |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 | 23.48 ns | 0.057 ns | 0.048 ns | 23.48 ns | 1.61x slower |   0.00x | 0.0344 |      72 B |
|                Hyperlinq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |   100 | 21.37 ns | 0.079 ns | 0.070 ns | 21.36 ns | 1.46x slower |   0.00x | 0.0229 |      48 B |
|                          |               |                                                                     |               |       |          |          |          |          |              |         |        |           |
|              ForeachLoop | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 24.44 ns | 0.087 ns | 0.078 ns | 24.46 ns |     baseline |         | 0.0229 |      48 B |
|                     Linq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 21.31 ns | 0.447 ns | 0.459 ns | 21.69 ns | 1.15x faster |   0.03x | 0.0229 |      48 B |
|                   LinqAF | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 51.46 ns | 0.178 ns | 0.149 ns | 51.40 ns | 2.11x slower |   0.01x | 0.0229 |      48 B |
|               StructLinq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 34.41 ns | 0.221 ns | 0.196 ns | 34.35 ns | 1.41x slower |   0.01x | 0.0344 |      72 B |
| StructLinq_ValueDelegate | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 29.77 ns | 0.060 ns | 0.050 ns | 29.77 ns | 1.22x slower |   0.01x | 0.0344 |      72 B |
|                Hyperlinq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |   100 | 29.25 ns | 0.082 ns | 0.064 ns | 29.23 ns | 1.20x slower |   0.00x | 0.0229 |      48 B |
