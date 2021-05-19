## List.Int32.ListInt32Select

### Source
[ListInt32Select.cs](../LinqBenchmarks/List/Int32/ListInt32Select.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqFasterer: [2.1.0](https://www.nuget.org/packages/LinqFasterer/2.1.0)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- LinqOptimizer.CSharp: [0.7.0](https://www.nuget.org/packages/LinqOptimizer.CSharp/0.7.0)
- SpanLinq: [1.0.0](https://www.nuget.org/packages/SpanLinq/1.0.0)
- Streams.CSharp: [0.6.0](https://www.nuget.org/packages/Streams.CSharp/0.6.0)
- StructLinq.BCL: [0.26.0](https://www.nuget.org/packages/StructLinq/0.26.0)
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)
- System.Linq.Async: [5.0.0](https://www.nuget.org/packages/System.Linq.Async/5.0.0)

### Results:
``` ini

BenchmarkDotNet=v0.12.1.1538-nightly, OS=Windows 10.0.19043
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.4.21227.6
  [Host] : .NET 5.0.6 (5.0.621.22011), X64 RyuJIT
  .NET 6 : .NET 6.0.0 (6.0.21.22210), X64 RyuJIT

Job=.NET 6  EnvironmentVariables=COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1  Runtime=.NET 6.0  

```
|                   Method | Count |        Mean |     Error |    StdDev |      Median |  Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |------ |------------:|----------:|----------:|------------:|-------:|--------:|--------:|------:|------:|----------:|
|                  ForLoop |   100 |    110.0 ns |   0.39 ns |   0.34 ns |    110.0 ns |   1.00 |    0.00 |       - |     - |     - |         - |
|              ForeachLoop |   100 |    137.6 ns |   0.48 ns |   0.43 ns |    137.5 ns |   1.25 |    0.00 |       - |     - |     - |         - |
|                     Linq |   100 |    646.1 ns |   6.97 ns |   5.82 ns |    644.0 ns |   5.87 |    0.05 |  0.0343 |     - |     - |      72 B |
|               LinqFaster |   100 |    376.9 ns |   3.09 ns |   4.72 ns |    375.5 ns |   3.43 |    0.06 |  0.2179 |     - |     - |     456 B |
|             LinqFasterer |   100 |    447.6 ns |   8.91 ns |  18.21 ns |    437.8 ns |   4.28 |    0.17 |  0.4206 |     - |     - |     880 B |
|                   LinqAF |   100 |    786.3 ns |   4.05 ns |   3.59 ns |    785.8 ns |   7.15 |    0.05 |       - |     - |     - |         - |
|            LinqOptimizer |   100 | 45,129.1 ns | 618.25 ns | 578.31 ns | 45,059.3 ns | 409.70 |    5.03 | 13.4277 |     - |     - |  28,183 B |
|                  Streams |   100 |  1,350.4 ns |   7.36 ns |   6.52 ns |  1,349.8 ns |  12.27 |    0.08 |  0.2899 |     - |     - |     608 B |
|               StructLinq |   100 |    209.1 ns |   1.01 ns |   0.89 ns |    209.0 ns |   1.90 |    0.01 |  0.0153 |     - |     - |      32 B |
| StructLinq_ValueDelegate |   100 |    178.4 ns |   0.90 ns |   0.79 ns |    178.1 ns |   1.62 |    0.01 |       - |     - |     - |         - |
|                Hyperlinq |   100 |    213.2 ns |   2.33 ns |   2.07 ns |    213.2 ns |   1.94 |    0.02 |       - |     - |     - |         - |
|  Hyperlinq_ValueDelegate |   100 |    203.1 ns |   1.98 ns |   1.85 ns |    203.4 ns |   1.85 |    0.01 |       - |     - |     - |         - |
