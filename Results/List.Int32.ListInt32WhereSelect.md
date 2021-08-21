## List.Int32.ListInt32WhereSelect

### Source
[ListInt32WhereSelect.cs](../LinqBenchmarks/List/Int32/ListInt32WhereSelect.cs)

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
|                   Method | Count |         Mean |     Error |    StdDev |          Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |------ |-------------:|----------:|----------:|---------------:|--------:|--------:|------:|------:|----------:|
|                  ForLoop |   100 |     93.40 ns |  0.094 ns |  0.078 ns |       baseline |         |       - |     - |     - |         - |
|              ForeachLoop |   100 |     90.79 ns |  0.126 ns |  0.098 ns |   1.03x faster |   0.00x |       - |     - |     - |         - |
|                     Linq |   100 |    497.60 ns |  1.141 ns |  0.953 ns |   5.33x slower |   0.01x |  0.0725 |     - |     - |     152 B |
|               LinqFaster |   100 |    561.35 ns |  0.777 ns |  0.649 ns |   6.01x slower |   0.01x |  0.3090 |     - |     - |     648 B |
|             LinqFasterer |   100 |    532.11 ns |  1.186 ns |  1.051 ns |   5.70x slower |   0.01x |  0.4473 |     - |     - |     936 B |
|                   LinqAF |   100 |    441.32 ns |  0.531 ns |  0.496 ns |   4.73x slower |   0.01x |       - |     - |     - |         - |
|            LinqOptimizer |   100 | 51,014.88 ns | 63.779 ns | 56.539 ns | 546.20x slower |   0.73x | 14.7095 |     - |     - |  30,788 B |
|                 SpanLinq |   100 |    452.71 ns |  1.259 ns |  1.178 ns |   4.85x slower |   0.01x |       - |     - |     - |         - |
|                  Streams |   100 |  1,404.03 ns |  1.031 ns |  0.861 ns |  15.03x slower |   0.02x |  0.3624 |     - |     - |     760 B |
|               StructLinq |   100 |    356.63 ns |  0.253 ns |  0.237 ns |   3.82x slower |   0.00x |  0.0305 |     - |     - |      64 B |
| StructLinq_ValueDelegate |   100 |    199.19 ns |  0.109 ns |  0.097 ns |   2.13x slower |   0.00x |       - |     - |     - |         - |
|                Hyperlinq |   100 |    370.61 ns |  0.298 ns |  0.264 ns |   3.97x slower |   0.00x |       - |     - |     - |         - |
|  Hyperlinq_ValueDelegate |   100 |    229.86 ns |  0.104 ns |  0.093 ns |   2.46x slower |   0.00x |       - |     - |     - |         - |
