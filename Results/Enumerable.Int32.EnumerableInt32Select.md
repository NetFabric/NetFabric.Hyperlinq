## Enumerable.Int32.EnumerableInt32Select

### Source
[EnumerableInt32Select.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32Select.cs)

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
|                   Method | Count |        Mean |     Error |    StdDev |  Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |------ |------------:|----------:|----------:|-------:|--------:|--------:|------:|------:|----------:|
|              ForeachLoop |   100 |    337.3 ns |   1.81 ns |   1.41 ns |   1.00 |    0.00 |  0.0191 |     - |     - |      40 B |
|                     Linq |   100 |    610.3 ns |   2.61 ns |   2.44 ns |   1.81 |    0.01 |  0.0458 |     - |     - |      96 B |
|                   LinqAF |   100 |    553.4 ns |   3.25 ns |   2.88 ns |   1.64 |    0.01 |  0.0191 |     - |     - |      40 B |
|            LinqOptimizer |   100 | 36,542.5 ns | 183.57 ns | 162.73 ns | 108.39 |    0.62 | 13.5498 |     - |     - |  28,431 B |
|                  Streams |   100 |  1,569.7 ns |   6.77 ns |   6.00 ns |   4.65 |    0.03 |  0.2823 |     - |     - |     592 B |
|               StructLinq |   100 |    422.7 ns |   1.28 ns |   1.13 ns |   1.25 |    0.01 |  0.0305 |     - |     - |      64 B |
| StructLinq_ValueDelegate |   100 |    296.7 ns |   1.12 ns |   0.93 ns |   0.88 |    0.00 |  0.0191 |     - |     - |      40 B |
|                Hyperlinq |   100 |    366.0 ns |   1.19 ns |   0.99 ns |   1.09 |    0.00 |  0.0191 |     - |     - |      40 B |
|  Hyperlinq_ValueDelegate |   100 |    369.7 ns |   2.47 ns |   2.31 ns |   1.10 |    0.01 |  0.0191 |     - |     - |      40 B |
