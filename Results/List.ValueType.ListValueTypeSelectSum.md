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
|                  ForLoop |   100 |    168.30 ns |   0.681 ns |   0.604 ns |   1.00 |    0.00 |      - |     - |     - |         - |
|              ForeachLoop |   100 |    414.48 ns |   3.880 ns |   3.439 ns |   2.46 |    0.02 |      - |     - |     - |         - |
|                     Linq |   100 |    988.96 ns |   6.885 ns |   5.749 ns |   5.88 |    0.04 | 0.0458 |     - |     - |      96 B |
|               LinqFaster |   100 |    404.27 ns |   1.181 ns |   1.047 ns |   2.40 |    0.01 |      - |     - |     - |         - |
|                   LinqAF |   100 |  1,081.12 ns |  20.915 ns |  28.628 ns |   6.45 |    0.18 |      - |     - |     - |         - |
|            LinqOptimizer |   100 | 35,663.83 ns | 210.473 ns | 357.400 ns | 211.82 |    2.17 | 9.4604 |     - |     - |  19,860 B |
|                  Streams |   100 |    689.17 ns |  10.713 ns |  19.857 ns |   4.18 |    0.15 | 0.1717 |     - |     - |     360 B |
|               StructLinq |   100 |    230.22 ns |   1.189 ns |   1.054 ns |   1.37 |    0.01 | 0.0191 |     - |     - |      40 B |
| StructLinq_ValueDelegate |   100 |     87.96 ns |   0.269 ns |   0.252 ns |   0.52 |    0.00 |      - |     - |     - |         - |
|                Hyperlinq |   100 |    489.82 ns |   2.320 ns |   1.938 ns |   2.91 |    0.02 |      - |     - |     - |         - |
|  Hyperlinq_ValueDelegate |   100 |    340.11 ns |   1.056 ns |   0.936 ns |   2.02 |    0.01 |      - |     - |     - |         - |
