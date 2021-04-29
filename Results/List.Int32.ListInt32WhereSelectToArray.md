## List.Int32.ListInt32WhereSelectToArray

### Source
[ListInt32WhereSelectToArray.cs](../LinqBenchmarks/List/Int32/ListInt32WhereSelectToArray.cs)

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
|                   Method | Count |        Mean |     Error |    StdDev |      Median |  Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |------ |------------:|----------:|----------:|------------:|-------:|--------:|--------:|------:|------:|----------:|
|                  ForLoop |   100 |    274.8 ns |   2.89 ns |   2.70 ns |    275.7 ns |   1.00 |    0.00 |  0.4244 |     - |     - |     888 B |
|              ForeachLoop |   100 |    265.8 ns |   1.93 ns |   1.80 ns |    265.6 ns |   0.97 |    0.01 |  0.4244 |     - |     - |     888 B |
|                     Linq |   100 |    579.5 ns |   1.99 ns |   1.76 ns |    579.1 ns |   2.11 |    0.02 |  0.4015 |     - |     - |     840 B |
|               LinqFaster |   100 |    475.9 ns |   9.57 ns |  19.99 ns |    462.5 ns |   1.76 |    0.08 |  0.4244 |     - |     - |     888 B |
|                   LinqAF |   100 |  1,199.0 ns |   7.30 ns |   6.83 ns |  1,199.0 ns |   4.36 |    0.06 |  0.4082 |     - |     - |     856 B |
|            LinqOptimizer |   100 | 50,806.2 ns | 313.94 ns | 278.30 ns | 50,837.3 ns | 184.75 |    2.00 | 15.0146 |     - |     - |  31,651 B |
|                  Streams |   100 |    981.8 ns |   3.70 ns |   3.46 ns |    982.2 ns |   3.57 |    0.04 |  0.6695 |     - |     - |   1,400 B |
|               StructLinq |   100 |    594.4 ns |   3.61 ns |   3.37 ns |    594.2 ns |   2.16 |    0.02 |  0.1602 |     - |     - |     336 B |
| StructLinq_ValueDelegate |   100 |    364.1 ns |   1.90 ns |   1.59 ns |    364.1 ns |   1.32 |    0.01 |  0.1144 |     - |     - |     240 B |
|                Hyperlinq |   100 |    590.0 ns |   3.25 ns |   2.71 ns |    590.8 ns |   2.14 |    0.02 |  0.1144 |     - |     - |     240 B |
|  Hyperlinq_ValueDelegate |   100 |    333.9 ns |   2.15 ns |   1.79 ns |    333.5 ns |   1.21 |    0.01 |  0.1144 |     - |     - |     240 B |
