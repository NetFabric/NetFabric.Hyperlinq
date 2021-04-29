## ImmutableArray.Int32.ImmutableArrayInt32Select

### Source
[ImmutableArrayInt32Select.cs](../LinqBenchmarks/ImmutableArray/Int32/ImmutableArrayInt32Select.cs)

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
|                  ForLoop |   100 |     57.74 ns |   0.829 ns |   0.735 ns |   1.00 |    0.00 |       - |     - |     - |         - |
|              ForeachLoop |   100 |     56.53 ns |   0.269 ns |   0.238 ns |   0.98 |    0.01 |       - |     - |     - |         - |
|                     Linq |   100 |    488.19 ns |   4.695 ns |   4.162 ns |   8.46 |    0.15 |  0.0229 |     - |     - |      48 B |
|            LinqOptimizer |   100 | 45,651.71 ns | 294.810 ns | 261.342 ns | 790.82 |   12.93 | 13.6108 |     - |     - |  28,583 B |
|                  Streams |   100 |  1,661.42 ns |  10.694 ns |  10.003 ns |  28.79 |    0.38 |  0.2899 |     - |     - |     608 B |
|               StructLinq |   100 |    213.71 ns |   0.778 ns |   0.728 ns |   3.70 |    0.05 |  0.0153 |     - |     - |      32 B |
| StructLinq_ValueDelegate |   100 |    161.13 ns |   1.011 ns |   0.946 ns |   2.79 |    0.03 |       - |     - |     - |         - |
|                Hyperlinq |   100 |    234.34 ns |   0.888 ns |   0.741 ns |   4.05 |    0.02 |       - |     - |     - |         - |
|  Hyperlinq_ValueDelegate |   100 |    185.31 ns |   0.601 ns |   0.532 ns |   3.21 |    0.04 |       - |     - |     - |         - |
