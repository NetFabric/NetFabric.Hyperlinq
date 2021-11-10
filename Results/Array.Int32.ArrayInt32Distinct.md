## Array.Int32.ArrayInt32Distinct

### Source
[ArrayInt32Distinct.cs](../LinqBenchmarks/Array/Int32/ArrayInt32Distinct.cs)

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
|                   Method |           Job |                                                EnvironmentVariables |       Runtime | Duplicates | Count |     Mean |     Error |    StdDev |        Ratio | RatioSD |  Gen 0 | Allocated |
|------------------------- |-------------- |-------------------------------------------------------------------- |-------------- |----------- |------ |---------:|----------:|----------:|-------------:|--------:|-------:|----------:|
|                  ForLoop |        .NET 6 |                                                               Empty |      .NET 6.0 |          4 |   100 | 3.652 μs | 0.0730 μs | 0.0683 μs |     baseline |         | 2.8687 |   6,000 B |
|              ForeachLoop |        .NET 6 |                                                               Empty |      .NET 6.0 |          4 |   100 | 3.588 μs | 0.0523 μs | 0.0463 μs | 1.02x faster |   0.02x | 2.8687 |   6,000 B |
|                     Linq |        .NET 6 |                                                               Empty |      .NET 6.0 |          4 |   100 | 6.016 μs | 0.0187 μs | 0.0156 μs | 1.64x slower |   0.03x | 2.8610 |   5,992 B |
|             LinqFasterer |        .NET 6 |                                                               Empty |      .NET 6.0 |          4 |   100 | 6.171 μs | 0.0427 μs | 0.0400 μs | 1.69x slower |   0.03x | 4.4250 |   9,272 B |
|                   LinqAF |        .NET 6 |                                                               Empty |      .NET 6.0 |          4 |   100 | 8.394 μs | 0.0346 μs | 0.0270 μs | 2.29x slower |   0.04x | 5.9204 |  12,400 B |
|               StructLinq |        .NET 6 |                                                               Empty |      .NET 6.0 |          4 |   100 | 3.848 μs | 0.0042 μs | 0.0039 μs | 1.05x slower |   0.02x | 0.0153 |      32 B |
| StructLinq_ValueDelegate |        .NET 6 |                                                               Empty |      .NET 6.0 |          4 |   100 | 3.783 μs | 0.0061 μs | 0.0054 μs | 1.03x slower |   0.02x |      - |         - |
|                Hyperlinq |        .NET 6 |                                                               Empty |      .NET 6.0 |          4 |   100 | 3.769 μs | 0.0056 μs | 0.0046 μs | 1.03x slower |   0.02x |      - |         - |
|                          |               |                                                                     |               |            |       |          |           |           |              |         |        |           |
|                  ForLoop |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |          4 |   100 | 3.235 μs | 0.0107 μs | 0.0095 μs |     baseline |         | 2.8687 |   6,000 B |
|              ForeachLoop |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |          4 |   100 | 3.231 μs | 0.0100 μs | 0.0088 μs | 1.00x faster |   0.00x | 2.8687 |   6,000 B |
|                     Linq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |          4 |   100 | 4.202 μs | 0.0101 μs | 0.0094 μs | 1.30x slower |   0.01x | 2.8610 |   5,992 B |
|             LinqFasterer |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |          4 |   100 | 4.027 μs | 0.0134 μs | 0.0112 μs | 1.24x slower |   0.00x | 4.4250 |   9,272 B |
|                   LinqAF |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |          4 |   100 | 7.147 μs | 0.0200 μs | 0.0156 μs | 2.21x slower |   0.01x | 5.9280 |  12,400 B |
|               StructLinq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |          4 |   100 | 3.977 μs | 0.0106 μs | 0.0094 μs | 1.23x slower |   0.00x | 0.0153 |      32 B |
| StructLinq_ValueDelegate |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |          4 |   100 | 3.794 μs | 0.0030 μs | 0.0024 μs | 1.17x slower |   0.00x |      - |         - |
|                Hyperlinq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |          4 |   100 | 3.169 μs | 0.0064 μs | 0.0060 μs | 1.02x faster |   0.00x |      - |         - |
|                          |               |                                                                     |               |            |       |          |           |           |              |         |        |           |
|                  ForLoop | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |          4 |   100 | 5.797 μs | 0.0106 μs | 0.0083 μs |     baseline |         | 2.8687 |   6,000 B |
|              ForeachLoop | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |          4 |   100 | 5.906 μs | 0.0133 μs | 0.0118 μs | 1.02x slower |   0.00x | 2.8687 |   6,000 B |
|                     Linq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |          4 |   100 | 8.140 μs | 0.0268 μs | 0.0238 μs | 1.40x slower |   0.00x | 2.0599 |   4,312 B |
|             LinqFasterer | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |          4 |   100 | 8.038 μs | 0.0263 μs | 0.0246 μs | 1.39x slower |   0.00x | 4.4250 |   9,272 B |
|                   LinqAF | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |          4 |   100 | 9.839 μs | 0.0176 μs | 0.0137 μs | 1.70x slower |   0.00x | 5.9204 |  12,400 B |
|               StructLinq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |          4 |   100 | 4.251 μs | 0.0032 μs | 0.0026 μs | 1.36x faster |   0.00x | 0.0153 |      32 B |
| StructLinq_ValueDelegate | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |          4 |   100 | 4.031 μs | 0.0065 μs | 0.0054 μs | 1.44x faster |   0.00x |      - |         - |
|                Hyperlinq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |          4 |   100 | 4.084 μs | 0.0060 μs | 0.0056 μs | 1.42x faster |   0.00x |      - |         - |
