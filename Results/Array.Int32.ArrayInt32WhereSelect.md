## Array.Int32.ArrayInt32WhereSelect

### Source
[ArrayInt32WhereSelect.cs](../LinqBenchmarks/Array/Int32/ArrayInt32WhereSelect.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqFasterer: [2.1.0](https://www.nuget.org/packages/LinqFasterer/2.1.0)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- LinqOptimizer.CSharp: [](https://www.nuget.org/packages/LinqOptimizer.CSharp/)
- Streams.CSharp: [0.6.0](https://www.nuget.org/packages/Streams.CSharp/0.6.0)
- StructLinq.BCL: [0.26.0](https://www.nuget.org/packages/StructLinq/0.26.0)
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)

### Results:
``` ini

BenchmarkDotNet=v0.12.1.1527-nightly, OS=Windows 10.0.19043
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.4.21227.6
  [Host] : .NET 5.0.4 (5.0.421.11614), X64 RyuJIT
  .NET 6 : .NET 6.0.0 (6.0.21.22210), X64 RyuJIT

Job=.NET 6  EnvironmentVariables=COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1  Runtime=.NET 6.0  

```
|                   Method | Count |         Mean |      Error |     StdDev |  Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |------ |-------------:|-----------:|-----------:|-------:|--------:|--------:|------:|------:|----------:|
|                  ForLoop |   100 |     67.39 ns |   0.327 ns |   0.290 ns |   1.00 |    0.00 |       - |     - |     - |         - |
|              ForeachLoop |   100 |     67.70 ns |   0.490 ns |   0.434 ns |   1.00 |    0.01 |       - |     - |     - |         - |
|                     Linq |   100 |    554.09 ns |   4.484 ns |   3.975 ns |   8.22 |    0.07 |  0.0496 |     - |     - |     104 B |
|               LinqFaster |   100 |    364.89 ns |   2.571 ns |   2.279 ns |   5.41 |    0.03 |  0.3171 |     - |     - |     664 B |
|             LinqFasterer |   100 |    957.84 ns |   4.145 ns |   3.461 ns |  14.21 |    0.07 |  0.3967 |     - |     - |     832 B |
|                   LinqAF |   100 |    453.68 ns |   8.131 ns |   6.789 ns |   6.73 |    0.10 |       - |     - |     - |         - |
|            LinqOptimizer |   100 | 43,569.05 ns | 163.843 ns | 145.243 ns | 646.53 |    3.79 | 14.0991 |     - |     - |  29,775 B |
|                  Streams |   100 |  1,464.98 ns |   5.625 ns |   4.986 ns |  21.74 |    0.11 |  0.3510 |     - |     - |     736 B |
|               StructLinq |   100 |    322.04 ns |   1.734 ns |   1.537 ns |   4.78 |    0.03 |  0.0305 |     - |     - |      64 B |
| StructLinq_ValueDelegate |   100 |    182.35 ns |   0.850 ns |   0.753 ns |   2.71 |    0.02 |       - |     - |     - |         - |
|                Hyperlinq |   100 |    339.71 ns |   1.472 ns |   1.229 ns |   5.04 |    0.03 |       - |     - |     - |         - |
|  Hyperlinq_ValueDelegate |   100 |    213.25 ns |   0.470 ns |   0.440 ns |   3.16 |    0.02 |       - |     - |     - |         - |
