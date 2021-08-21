## List.Int32.ListInt32SkipTakeWhere

### Source
[ListInt32SkipTakeWhere.cs](../LinqBenchmarks/List/Int32/ListInt32SkipTakeWhere.cs)

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
|                   Method | Skip | Count |         Mean |      Error |     StdDev |          Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |----- |------ |-------------:|-----------:|-----------:|---------------:|--------:|--------:|------:|------:|----------:|
|                  ForLoop | 1000 |   100 |     79.23 ns |   0.149 ns |   0.140 ns |       baseline |         |       - |     - |     - |         - |
|                     Linq | 1000 |   100 |    733.82 ns |   2.858 ns |   2.674 ns |   9.26x slower |   0.04x |  0.0725 |     - |     - |     152 B |
|               LinqFaster | 1000 |   100 |    983.54 ns |   3.230 ns |   2.863 ns |  12.41x slower |   0.04x |  0.7458 |     - |     - |   1,560 B |
|             LinqFasterer | 1000 |   100 |    760.90 ns |   1.341 ns |   1.047 ns |   9.60x slower |   0.03x |  2.4424 |     - |     - |   5,112 B |
|                   LinqAF | 1000 |   100 |  3,960.37 ns |   6.027 ns |   5.637 ns |  49.99x slower |   0.14x |       - |     - |     - |         - |
|            LinqOptimizer | 1000 |   100 | 64,795.76 ns | 177.869 ns | 157.676 ns | 817.85x slower |   2.68x | 15.6250 |     - |     - |  32,741 B |
|                 SpanLinq | 1000 |   100 |    290.05 ns |   0.149 ns |   0.124 ns |   3.66x slower |   0.01x |       - |     - |     - |         - |
|                  Streams | 1000 |   100 |  6,889.44 ns |   4.690 ns |   3.662 ns |  86.95x slower |   0.17x |  0.4425 |     - |     - |     936 B |
|               StructLinq | 1000 |   100 |    323.60 ns |   6.523 ns |   6.699 ns |   4.09x slower |   0.09x |  0.0458 |     - |     - |      96 B |
| StructLinq_ValueDelegate | 1000 |   100 |    180.59 ns |   0.157 ns |   0.131 ns |   2.28x slower |   0.00x |       - |     - |     - |         - |
|                Hyperlinq | 1000 |   100 |    506.69 ns |   3.120 ns |   2.918 ns |   6.40x slower |   0.04x |       - |     - |     - |         - |
|  Hyperlinq_ValueDelegate | 1000 |   100 |    237.79 ns |   0.177 ns |   0.166 ns |   3.00x slower |   0.01x |       - |     - |     - |         - |
