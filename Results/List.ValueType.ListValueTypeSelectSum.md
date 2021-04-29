## List.ValueType.ListValueTypeSelectSum

### Source
[ListValueTypeSelectSum.cs](../LinqBenchmarks/List/ValueType/ListValueTypeSelectSum.cs)

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
|                   Method | Count |         Mean |      Error |     StdDev |  Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |------ |-------------:|-----------:|-----------:|-------:|--------:|-------:|------:|------:|----------:|
|                  ForLoop |   100 |    169.81 ns |   0.567 ns |   0.530 ns |   1.00 |    0.00 |      - |     - |     - |         - |
|              ForeachLoop |   100 |    425.30 ns |   3.414 ns |   2.666 ns |   2.50 |    0.02 |      - |     - |     - |         - |
|                     Linq |   100 |    919.47 ns |   4.575 ns |   4.056 ns |   5.41 |    0.03 | 0.0458 |     - |     - |      96 B |
|               LinqFaster |   100 |    411.16 ns |   1.294 ns |   1.147 ns |   2.42 |    0.01 |      - |     - |     - |         - |
|             LinqFasterer |   100 |    631.53 ns |   5.763 ns |   4.812 ns |   3.72 |    0.03 | 3.0670 |     - |     - |   6,424 B |
|                   LinqAF |   100 |  1,149.39 ns |  22.578 ns |  45.091 ns |   6.86 |    0.22 |      - |     - |     - |         - |
|            LinqOptimizer |   100 | 35,377.08 ns | 258.378 ns | 215.757 ns | 208.28 |    1.39 | 9.4604 |     - |     - |  19,860 B |
|                  Streams |   100 |    715.90 ns |  12.367 ns |  11.568 ns |   4.22 |    0.06 | 0.1717 |     - |     - |     360 B |
|               StructLinq |   100 |    231.17 ns |   0.945 ns |   0.884 ns |   1.36 |    0.01 | 0.0191 |     - |     - |      40 B |
| StructLinq_ValueDelegate |   100 |     88.55 ns |   0.488 ns |   0.407 ns |   0.52 |    0.00 |      - |     - |     - |         - |
|                Hyperlinq |   100 |    496.96 ns |   1.682 ns |   1.405 ns |   2.93 |    0.01 |      - |     - |     - |         - |
|  Hyperlinq_ValueDelegate |   100 |    344.71 ns |   1.337 ns |   1.251 ns |   2.03 |    0.01 |      - |     - |     - |         - |
