## List.ValueType.ListValueTypeSelectSum

### Source
[ListValueTypeSelectSum.cs](../LinqBenchmarks/List/ValueType/ListValueTypeSelectSum.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqFasterer: [2.1.0](https://www.nuget.org/packages/LinqFasterer/2.1.0)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- LinqOptimizer.CSharp: [0.7.0](https://www.nuget.org/packages/LinqOptimizer.CSharp/0.7.0)
- SpanLinq: [0.0.1](https://www.nuget.org/packages/SpanLinq/0.0.1)
- Streams.CSharp: [0.6.0](https://www.nuget.org/packages/Streams.CSharp/0.6.0)
- StructLinq.BCL: [0.26.0](https://www.nuget.org/packages/StructLinq/0.26.0)
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)
- System.Linq.Async: [5.0.0](https://www.nuget.org/packages/System.Linq.Async/5.0.0)

### Results:
``` ini

BenchmarkDotNet=v0.13.0, OS=macOS Catalina 10.15.7 (19H1323) [Darwin 19.6.0]
Intel Core i5-7360U CPU 2.30GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.7.21379.14
  [Host] : .NET 5.0.6 (5.0.621.22011), X64 RyuJIT
  .NET 6 : .NET 6.0.0 (6.0.21.37719), X64 RyuJIT

Job=.NET 6  EnvironmentVariables=COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1  Runtime=.NET 6.0  

```
|                   Method | Count |         Mean |      Error |     StdDev |          Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |------ |-------------:|-----------:|-----------:|---------------:|--------:|-------:|------:|------:|----------:|
|                  ForLoop |   100 |    164.97 ns |   0.099 ns |   0.083 ns |       baseline |         |      - |     - |     - |         - |
|              ForeachLoop |   100 |    386.50 ns |   0.189 ns |   0.158 ns |   2.34x slower |   0.00x |      - |     - |     - |         - |
|                     Linq |   100 |    756.75 ns |   0.195 ns |   0.173 ns |   4.59x slower |   0.00x | 0.0458 |     - |     - |      96 B |
|               LinqFaster |   100 |    399.98 ns |   0.237 ns |   0.222 ns |   2.42x slower |   0.00x |      - |     - |     - |         - |
|             LinqFasterer |   100 |    694.73 ns |   2.605 ns |   2.437 ns |   4.21x slower |   0.02x | 3.0670 |     - |     - |   6,424 B |
|                   LinqAF |   100 |    955.99 ns |   0.415 ns |   0.388 ns |   5.79x slower |   0.00x |      - |     - |     - |         - |
|            LinqOptimizer |   100 | 37,599.84 ns | 218.654 ns | 170.711 ns | 227.93x slower |   1.04x | 9.4604 |     - |     - |  19,829 B |
|                  Streams |   100 |    839.76 ns |   1.778 ns |   1.484 ns |   5.09x slower |   0.01x | 0.1717 |     - |     - |     360 B |
|               StructLinq |   100 |    242.89 ns |   0.213 ns |   0.199 ns |   1.47x slower |   0.00x | 0.0191 |     - |     - |      40 B |
| StructLinq_ValueDelegate |   100 |     95.42 ns |   0.036 ns |   0.032 ns |   1.73x faster |   0.00x |      - |     - |     - |         - |
|                Hyperlinq |   100 |    617.24 ns |   3.198 ns |   2.835 ns |   3.74x slower |   0.01x |      - |     - |     - |         - |
|  Hyperlinq_ValueDelegate |   100 |    319.04 ns |   0.570 ns |   0.533 ns |   1.93x slower |   0.00x |      - |     - |     - |         - |
