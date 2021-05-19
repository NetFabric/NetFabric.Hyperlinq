## Enumerable.Int32.EnumerableInt32WhereCount

### Source
[EnumerableInt32WhereCount.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32WhereCount.cs)

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
|                   Method | Count |        Mean |     Error |    StdDev |  Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |------ |------------:|----------:|----------:|-------:|--------:|-------:|------:|------:|----------:|
|              ForeachLoop |   100 |    254.9 ns |   1.63 ns |   1.45 ns |   1.00 |    0.00 | 0.0191 |     - |     - |      40 B |
|                     Linq |   100 |    387.5 ns |   1.70 ns |   1.51 ns |   1.52 |    0.01 | 0.0191 |     - |     - |      40 B |
|                   LinqAF |   100 |    435.3 ns |   4.68 ns |   4.15 ns |   1.71 |    0.02 | 0.0191 |     - |     - |      40 B |
|            LinqOptimizer |   100 | 37,444.4 ns | 433.09 ns | 361.65 ns | 146.91 |    1.88 | 9.7656 |     - |     - |  20,501 B |
|                  Streams |   100 |    805.8 ns |   5.74 ns |   5.37 ns |   3.16 |    0.03 | 0.1907 |     - |     - |     400 B |
|               StructLinq |   100 |    401.2 ns |   2.15 ns |   1.80 ns |   1.57 |    0.01 | 0.0458 |     - |     - |      96 B |
| StructLinq_ValueDelegate |   100 |    371.4 ns |   3.81 ns |   3.56 ns |   1.46 |    0.01 | 0.0191 |     - |     - |      40 B |
|                Hyperlinq |   100 |    366.8 ns |   1.92 ns |   1.60 ns |   1.44 |    0.01 | 0.0191 |     - |     - |      40 B |
|  Hyperlinq_ValueDelegate |   100 |    322.1 ns |   2.51 ns |   2.35 ns |   1.26 |    0.01 | 0.0191 |     - |     - |      40 B |
