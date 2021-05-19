## List.Int32.ListInt32WhereSelectToArray

### Source
[ListInt32WhereSelectToArray.cs](../LinqBenchmarks/List/Int32/ListInt32WhereSelectToArray.cs)

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
|                  ForLoop |   100 |    277.3 ns |   4.38 ns |   3.42 ns |    277.8 ns |   1.00 |    0.00 |  0.4244 |     - |     - |     888 B |
|              ForeachLoop |   100 |    309.3 ns |   1.45 ns |   1.28 ns |    309.7 ns |   1.12 |    0.01 |  0.4244 |     - |     - |     888 B |
|                     Linq |   100 |    542.2 ns |   4.50 ns |   4.21 ns |    543.0 ns |   1.96 |    0.03 |  0.4015 |     - |     - |     840 B |
|               LinqFaster |   100 |    475.0 ns |   9.58 ns |  22.77 ns |    461.3 ns |   1.84 |    0.03 |  0.4244 |     - |     - |     888 B |
|             LinqFasterer |   100 |    442.1 ns |   7.11 ns |  11.06 ns |    438.4 ns |   1.62 |    0.04 |  0.4320 |     - |     - |     904 B |
|                   LinqAF |   100 |  1,039.0 ns |   6.87 ns |   6.09 ns |  1,038.6 ns |   3.74 |    0.05 |  0.4082 |     - |     - |     856 B |
|            LinqOptimizer |   100 | 51,531.2 ns | 564.22 ns | 692.92 ns | 51,389.2 ns | 185.84 |    1.74 | 15.0757 |     - |     - |  31,651 B |
|                  Streams |   100 |  1,054.3 ns |  20.97 ns |  39.38 ns |  1,068.3 ns |   3.63 |    0.18 |  0.6695 |     - |     - |   1,400 B |
|               StructLinq |   100 |    579.0 ns |   6.04 ns |   5.36 ns |    577.5 ns |   2.09 |    0.03 |  0.1602 |     - |     - |     336 B |
| StructLinq_ValueDelegate |   100 |    345.6 ns |   1.39 ns |   1.16 ns |    345.8 ns |   1.25 |    0.02 |  0.1144 |     - |     - |     240 B |
|                Hyperlinq |   100 |    585.8 ns |   4.81 ns |   4.27 ns |    586.1 ns |   2.12 |    0.03 |  0.1144 |     - |     - |     240 B |
|  Hyperlinq_ValueDelegate |   100 |    362.7 ns |   3.37 ns |   2.98 ns |    362.0 ns |   1.31 |    0.02 |  0.1144 |     - |     - |     240 B |
