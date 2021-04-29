## List.Int32.ListInt32Select

### Source
[ListInt32Select.cs](../LinqBenchmarks/List/Int32/ListInt32Select.cs)

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
|                   Method | Count |        Mean |    Error |   StdDev |  Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |------ |------------:|---------:|---------:|-------:|--------:|--------:|------:|------:|----------:|
|                  ForLoop |   100 |    111.7 ns |  0.37 ns |  0.29 ns |   1.00 |    0.00 |       - |     - |     - |         - |
|              ForeachLoop |   100 |    139.2 ns |  1.35 ns |  1.26 ns |   1.25 |    0.01 |       - |     - |     - |         - |
|                     Linq |   100 |    677.0 ns |  2.40 ns |  2.25 ns |   6.06 |    0.03 |  0.0343 |     - |     - |      72 B |
|               LinqFaster |   100 |    378.3 ns |  1.55 ns |  1.45 ns |   3.39 |    0.01 |  0.2179 |     - |     - |     456 B |
|             LinqFasterer |   100 |    465.5 ns |  2.15 ns |  2.02 ns |   4.16 |    0.02 |  0.4206 |     - |     - |     880 B |
|                   LinqAF |   100 |    795.4 ns |  2.37 ns |  1.85 ns |   7.12 |    0.03 |       - |     - |     - |         - |
|            LinqOptimizer |   100 | 37,079.2 ns | 92.24 ns | 86.29 ns | 331.96 |    1.52 | 13.4277 |     - |     - |  28,183 B |
|                  Streams |   100 |  1,357.4 ns |  7.22 ns |  6.76 ns |  12.16 |    0.06 |  0.2899 |     - |     - |     608 B |
|               StructLinq |   100 |    232.9 ns |  1.43 ns |  1.27 ns |   2.09 |    0.01 |  0.0153 |     - |     - |      32 B |
| StructLinq_ValueDelegate |   100 |    165.7 ns |  0.73 ns |  0.68 ns |   1.48 |    0.01 |       - |     - |     - |         - |
|                Hyperlinq |   100 |    239.4 ns |  1.89 ns |  1.77 ns |   2.14 |    0.02 |       - |     - |     - |         - |
|  Hyperlinq_ValueDelegate |   100 |    189.0 ns |  0.62 ns |  0.55 ns |   1.69 |    0.01 |       - |     - |     - |         - |
