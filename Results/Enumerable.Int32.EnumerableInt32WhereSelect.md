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
|              ForeachLoop |   100 |    254.9 ns |   0.75 ns |   0.71 ns |   1.00 |    0.00 |  0.0191 |     - |     - |      40 B |
|                     Linq |   100 |    855.5 ns |   4.71 ns |   4.41 ns |   3.36 |    0.01 |  0.0763 |     - |     - |     160 B |
|                   LinqAF |   100 |    743.8 ns |   4.67 ns |   4.37 ns |   2.92 |    0.02 |  0.0191 |     - |     - |      40 B |
|            LinqOptimizer |   100 | 47,047.9 ns | 197.05 ns | 174.68 ns | 184.52 |    0.72 | 14.8926 |     - |     - |  31,276 B |
|                  Streams |   100 |  1,770.6 ns |   8.25 ns |   6.89 ns |   6.94 |    0.03 |  0.3548 |     - |     - |     744 B |
|               StructLinq |   100 |    566.0 ns |   1.40 ns |   1.24 ns |   2.22 |    0.01 |  0.0458 |     - |     - |      96 B |
| StructLinq_ValueDelegate |   100 |    360.2 ns |   2.75 ns |   2.29 ns |   1.41 |    0.01 |  0.0191 |     - |     - |      40 B |
|                Hyperlinq |   100 |    677.0 ns |   3.42 ns |   2.86 ns |   2.65 |    0.01 |  0.0191 |     - |     - |      40 B |
|  Hyperlinq_ValueDelegate |   100 |    428.5 ns |   1.31 ns |   1.16 ns |   1.68 |    0.01 |  0.0191 |     - |     - |      40 B |
