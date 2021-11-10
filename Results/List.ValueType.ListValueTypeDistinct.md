## List.ValueType.ListValueTypeDistinct

### Source
[ListValueTypeDistinct.cs](../LinqBenchmarks/List/ValueType/ListValueTypeDistinct.cs)

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
|                   Method |           Job |                                                EnvironmentVariables |       Runtime | Duplicates | Count |      Mean |     Error |    StdDev |        Ratio | RatioSD |   Gen 0 | Allocated |
|------------------------- |-------------- |-------------------------------------------------------------------- |-------------- |----------- |------ |----------:|----------:|----------:|-------------:|--------:|--------:|----------:|
|                  ForLoop |        .NET 6 |                                                               Empty |      .NET 6.0 |          4 |   100 | 14.737 μs | 0.0254 μs | 0.0226 μs |     baseline |         | 12.8784 |  26,976 B |
|              ForeachLoop |        .NET 6 |                                                               Empty |      .NET 6.0 |          4 |   100 | 15.366 μs | 0.0651 μs | 0.0577 μs | 1.04x slower |   0.00x | 12.8784 |  26,976 B |
|                     Linq |        .NET 6 |                                                               Empty |      .NET 6.0 |          4 |   100 | 18.015 μs | 0.0325 μs | 0.0304 μs | 1.22x slower |   0.00x | 12.8174 |  26,912 B |
|               LinqFaster |        .NET 6 |                                                               Empty |      .NET 6.0 |          4 |   100 |  2.915 μs | 0.0029 μs | 0.0026 μs | 5.06x faster |   0.01x |  0.0114 |      24 B |
|             LinqFasterer |        .NET 6 |                                                               Empty |      .NET 6.0 |          4 |   100 | 18.376 μs | 0.0322 μs | 0.0269 μs | 1.25x slower |   0.00x | 34.8816 |  73,168 B |
|                   LinqAF |        .NET 6 |                                                               Empty |      .NET 6.0 |          4 |   100 | 86.739 μs | 0.1342 μs | 0.1121 μs | 5.89x slower |   0.01x | 19.8975 |  41,936 B |
|               StructLinq |        .NET 6 |                                                               Empty |      .NET 6.0 |          4 |   100 | 16.128 μs | 0.0370 μs | 0.0328 μs | 1.09x slower |   0.00x |  0.0305 |      64 B |
| StructLinq_ValueDelegate |        .NET 6 |                                                               Empty |      .NET 6.0 |          4 |   100 |  5.049 μs | 0.0151 μs | 0.0141 μs | 2.92x faster |   0.01x |       - |         - |
|                Hyperlinq |        .NET 6 |                                                               Empty |      .NET 6.0 |          4 |   100 | 13.835 μs | 0.0383 μs | 0.0320 μs | 1.07x faster |   0.00x |       - |         - |
|                          |               |                                                                     |               |            |       |           |           |           |              |         |         |           |
|                  ForLoop |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |          4 |   100 | 12.761 μs | 0.1386 μs | 0.1229 μs |     baseline |         | 12.8784 |  26,976 B |
|              ForeachLoop |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |          4 |   100 | 13.152 μs | 0.0400 μs | 0.0355 μs | 1.03x slower |   0.01x | 12.8784 |  26,976 B |
|                     Linq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |          4 |   100 | 14.581 μs | 0.0404 μs | 0.0358 μs | 1.14x slower |   0.01x | 12.8174 |  26,912 B |
|               LinqFaster |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |          4 |   100 |  2.746 μs | 0.0008 μs | 0.0007 μs | 4.65x faster |   0.04x |  0.0114 |      24 B |
|             LinqFasterer |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |          4 |   100 | 17.149 μs | 0.1072 μs | 0.0950 μs | 1.34x slower |   0.02x | 34.8816 |  73,168 B |
|                   LinqAF |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |          4 |   100 | 80.631 μs | 0.2253 μs | 0.1997 μs | 6.32x slower |   0.07x | 19.8975 |  41,936 B |
|               StructLinq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |          4 |   100 | 12.365 μs | 0.0253 μs | 0.0211 μs | 1.03x faster |   0.01x |  0.0305 |      64 B |
| StructLinq_ValueDelegate |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |          4 |   100 |  5.144 μs | 0.0091 μs | 0.0085 μs | 2.48x faster |   0.03x |       - |         - |
|                Hyperlinq |    .NET 6 PGO | DOTNET_ReadyToRun=0,DOTNET_TC_QuickJitForLoops=1,DOTNET_TieredPGO=1 |      .NET 6.0 |          4 |   100 | 11.456 μs | 0.0207 μs | 0.0194 μs | 1.11x faster |   0.01x |       - |         - |
|                          |               |                                                                     |               |            |       |           |           |           |              |         |         |           |
|                  ForLoop | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |          4 |   100 | 18.291 μs | 0.0817 μs | 0.0683 μs |     baseline |         | 12.8784 |  26,976 B |
|              ForeachLoop | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |          4 |   100 | 19.628 μs | 0.1950 μs | 0.1729 μs | 1.07x slower |   0.01x | 12.8784 |  26,976 B |
|                     Linq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |          4 |   100 | 22.364 μs | 0.0805 μs | 0.0714 μs | 1.22x slower |   0.01x |  9.0637 |  18,992 B |
|               LinqFaster | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |          4 |   100 |  3.294 μs | 0.0028 μs | 0.0026 μs | 5.55x faster |   0.02x |  0.0114 |      24 B |
|             LinqFasterer | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |          4 |   100 | 22.809 μs | 0.1056 μs | 0.0988 μs | 1.25x slower |   0.01x | 34.8816 |  73,168 B |
|                   LinqAF | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |          4 |   100 | 90.828 μs | 0.3628 μs | 0.3029 μs | 4.97x slower |   0.02x | 20.0195 |  42,025 B |
|               StructLinq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |          4 |   100 | 17.922 μs | 0.0232 μs | 0.0217 μs | 1.02x faster |   0.00x |  0.0305 |      64 B |
| StructLinq_ValueDelegate | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |          4 |   100 |  5.385 μs | 0.0098 μs | 0.0087 μs | 3.40x faster |   0.01x |       - |         - |
|                Hyperlinq | .NET Core 3.1 |                                                               Empty | .NET Core 3.1 |          4 |   100 | 15.629 μs | 0.0081 μs | 0.0068 μs | 1.17x faster |   0.00x |       - |         - |
