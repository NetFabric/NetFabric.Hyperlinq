## Array.ValueType.ArrayValueTypeWhereSelect

### Source
[ArrayValueTypeWhereSelect.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhereSelect.cs)

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
|                   Method | Count |        Mean |     Error |    StdDev |         Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |------ |------------:|----------:|----------:|--------------:|--------:|--------:|------:|------:|----------:|
|                  ForLoop |   100 |    852.5 ns |   0.19 ns |   0.15 ns |      baseline |         |       - |     - |     - |         - |
|              ForeachLoop |   100 |    928.0 ns |   0.69 ns |   0.61 ns |  1.09x slower |   0.00x |       - |     - |     - |         - |
|                     Linq |   100 |  1,470.6 ns |   0.41 ns |   0.35 ns |  1.72x slower |   0.00x |  0.1030 |     - |     - |     216 B |
|               LinqFaster |   100 |  2,121.1 ns |   4.40 ns |   3.90 ns |  2.49x slower |   0.00x |  4.7264 |     - |     - |   9,904 B |
|             LinqFasterer |   100 |  3,627.7 ns |   4.96 ns |   3.87 ns |  4.26x slower |   0.00x |  6.0234 |     - |     - |  12,624 B |
|                   LinqAF |   100 |  2,045.6 ns |   1.75 ns |   1.63 ns |  2.40x slower |   0.00x |       - |     - |     - |         - |
|            LinqOptimizer |   100 | 56,361.0 ns | 328.38 ns | 291.10 ns | 66.11x slower |   0.36x | 74.0356 |     - |     - | 156,327 B |
|                 SpanLinq |   100 |  1,573.7 ns |   1.15 ns |   1.07 ns |  1.85x slower |   0.00x |       - |     - |     - |         - |
|                  Streams |   100 |  2,646.4 ns |   3.87 ns |   3.43 ns |  3.11x slower |   0.00x |  0.4654 |     - |     - |     976 B |
|               StructLinq |   100 |  1,191.5 ns |   0.98 ns |   0.87 ns |  1.40x slower |   0.00x |  0.0305 |     - |     - |      64 B |
| StructLinq_ValueDelegate |   100 |    972.1 ns |   0.34 ns |   0.27 ns |  1.14x slower |   0.00x |       - |     - |     - |         - |
|                Hyperlinq |   100 |  1,620.0 ns |   0.94 ns |   0.84 ns |  1.90x slower |   0.00x |       - |     - |     - |         - |
|  Hyperlinq_ValueDelegate |   100 |  1,299.8 ns |   0.37 ns |   0.35 ns |  1.52x slower |   0.00x |       - |     - |     - |         - |
