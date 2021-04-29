## Enumerable.Int32.EnumerableInt32WhereCount

### Source
[EnumerableInt32WhereCount.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32WhereCount.cs)

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
|                   Method | Count |        Mean |     Error |    StdDev |  Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |------ |------------:|----------:|----------:|-------:|--------:|-------:|------:|------:|----------:|
|              ForeachLoop |   100 |    258.6 ns |   0.99 ns |   0.88 ns |   1.00 |    0.00 | 0.0191 |     - |     - |      40 B |
|                     Linq |   100 |    392.0 ns |   2.25 ns |   2.11 ns |   1.52 |    0.01 | 0.0191 |     - |     - |      40 B |
|                   LinqAF |   100 |    484.1 ns |   2.95 ns |   2.76 ns |   1.87 |    0.01 | 0.0191 |     - |     - |      40 B |
|            LinqOptimizer |   100 | 36,722.3 ns | 231.71 ns | 216.74 ns | 141.95 |    1.03 | 9.7656 |     - |     - |  20,501 B |
|                  Streams |   100 |    811.9 ns |   3.60 ns |   3.19 ns |   3.14 |    0.02 | 0.1907 |     - |     - |     400 B |
|               StructLinq |   100 |    453.5 ns |   2.09 ns |   1.75 ns |   1.75 |    0.01 | 0.0458 |     - |     - |      96 B |
| StructLinq_ValueDelegate |   100 |    369.1 ns |   2.06 ns |   1.93 ns |   1.43 |    0.01 | 0.0191 |     - |     - |      40 B |
|                Hyperlinq |   100 |    421.9 ns |   1.10 ns |   1.03 ns |   1.63 |    0.01 | 0.0191 |     - |     - |      40 B |
|  Hyperlinq_ValueDelegate |   100 |    266.1 ns |   2.57 ns |   2.01 ns |   1.03 |    0.01 | 0.0191 |     - |     - |      40 B |
