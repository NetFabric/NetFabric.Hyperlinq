## List.Int32.ListInt32WhereSelectToList

### Source
[ListInt32WhereSelectToList.cs](../LinqBenchmarks/List/Int32/ListInt32WhereSelectToList.cs)

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
|                  ForLoop |   100 |    257.0 ns |   2.38 ns |   2.11 ns |    257.2 ns |   1.00 |    0.00 |  0.3095 |     - |     - |     648 B |
|              ForeachLoop |   100 |    247.2 ns |   5.04 ns |  11.99 ns |    243.0 ns |   0.95 |    0.04 |  0.3097 |     - |     - |     648 B |
|                     Linq |   100 |    550.4 ns |   3.99 ns |   3.33 ns |    550.0 ns |   2.14 |    0.02 |  0.3824 |     - |     - |     800 B |
|               LinqFaster |   100 |    506.0 ns |   5.63 ns |   4.70 ns |    504.3 ns |   1.97 |    0.02 |  0.4396 |     - |     - |     920 B |
|             LinqFasterer |   100 |    553.7 ns |   4.40 ns |   3.67 ns |    554.3 ns |   2.16 |    0.02 |  0.5617 |     - |     - |   1,176 B |
|                   LinqAF |   100 |  1,069.0 ns |   7.80 ns |   6.92 ns |  1,068.7 ns |   4.16 |    0.04 |  0.3090 |     - |     - |     648 B |
|            LinqOptimizer |   100 | 51,627.2 ns | 261.52 ns | 218.38 ns | 51,651.6 ns | 201.08 |    1.76 | 15.2588 |     - |     - |  31,924 B |
|                  Streams |   100 |  1,325.5 ns |   8.58 ns |   8.03 ns |  1,323.5 ns |   5.15 |    0.04 |  0.5684 |     - |     - |   1,192 B |
|               StructLinq |   100 |    626.9 ns |   3.35 ns |   2.62 ns |    627.7 ns |   2.44 |    0.02 |  0.1755 |     - |     - |     368 B |
| StructLinq_ValueDelegate |   100 |    361.6 ns |   1.91 ns |   1.69 ns |    361.3 ns |   1.41 |    0.01 |  0.1297 |     - |     - |     272 B |
|                Hyperlinq |   100 |    621.9 ns |   3.26 ns |   2.89 ns |    621.6 ns |   2.42 |    0.02 |  0.1297 |     - |     - |     272 B |
|  Hyperlinq_ValueDelegate |   100 |    347.9 ns |   2.23 ns |   1.86 ns |    347.2 ns |   1.35 |    0.01 |  0.1297 |     - |     - |     272 B |
