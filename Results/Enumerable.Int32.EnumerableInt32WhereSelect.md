## Enumerable.Int32.EnumerableInt32WhereSelect

### Source
[EnumerableInt32WhereSelect.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32WhereSelect.cs)

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
|              ForeachLoop |   100 |    310.5 ns |   1.57 ns |   1.31 ns |   1.00 |    0.00 |  0.0191 |     - |     - |      40 B |
|                     Linq |   100 |    867.3 ns |   5.45 ns |   5.10 ns |   2.80 |    0.02 |  0.0763 |     - |     - |     160 B |
|                   LinqAF |   100 |    725.7 ns |   3.25 ns |   2.72 ns |   2.34 |    0.01 |  0.0191 |     - |     - |      40 B |
|            LinqOptimizer |   100 | 47,776.9 ns | 151.94 ns | 134.69 ns | 153.89 |    0.84 | 14.8926 |     - |     - |  31,276 B |
|                  Streams |   100 |  1,790.1 ns |   4.98 ns |   4.41 ns |   5.77 |    0.03 |  0.3548 |     - |     - |     744 B |
|               StructLinq |   100 |    607.3 ns |   2.87 ns |   2.54 ns |   1.96 |    0.01 |  0.0458 |     - |     - |      96 B |
| StructLinq_ValueDelegate |   100 |    354.8 ns |   1.56 ns |   1.39 ns |   1.14 |    0.01 |  0.0191 |     - |     - |      40 B |
|                Hyperlinq |   100 |    661.0 ns |   3.58 ns |   3.35 ns |   2.13 |    0.01 |  0.0191 |     - |     - |      40 B |
|  Hyperlinq_ValueDelegate |   100 |    433.4 ns |   1.44 ns |   1.27 ns |   1.40 |    0.01 |  0.0191 |     - |     - |      40 B |
