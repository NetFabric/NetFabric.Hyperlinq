## Array.ValueType.ArrayValueTypeSkipTakeSelect

### Source
[ArrayValueTypeSkipTakeSelect.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeSkipTakeSelect.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqFasterer: [2.1.0](https://www.nuget.org/packages/LinqFasterer/2.1.0)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- LinqOptimizer.CSharp: [0.7.0](https://www.nuget.org/packages/LinqOptimizer.CSharp/0.7.0)
- SpanLinq: [0.0.1](https://www.nuget.org/packages/SpanLinq/0.0.1)
- Streams.CSharp: [0.6.0](https://www.nuget.org/packages/Streams.CSharp/0.6.0)
- StructLinq.BCL: [0.27.0](https://www.nuget.org/packages/StructLinq/0.27.0)
- NetFabric.Hyperlinq: [3.0.0-beta46](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta46)
- System.Linq.Async: [5.0.0](https://www.nuget.org/packages/System.Linq.Async/5.0.0)

### Results:
``` ini

BenchmarkDotNet=v0.13.1, OS=macOS Catalina 10.15.7 (19H1417) [Darwin 19.6.0]
Intel Core i5-7360U CPU 2.30GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-rc.1.21458.32
  [Host]     : .NET 5.0.6 (5.0.621.22011), X64 RyuJIT
  .NET 6 PGO : .NET 6.0.0 (6.0.21.45113), X64 RyuJIT

Job=.NET 6 PGO  EnvironmentVariables=COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1  Runtime=.NET 6.0  

```
|                   Method | Skip | Count |      Mean |     Error |    StdDev |    Median |         Ratio | RatioSD |   Gen 0 |   Gen 1 | Allocated |
|------------------------- |----- |------ |----------:|----------:|----------:|----------:|--------------:|--------:|--------:|--------:|----------:|
|                  ForLoop | 1000 |   100 |  1.540 μs | 0.0005 μs | 0.0005 μs |  1.540 μs |      baseline |         |       - |       - |         - |
|                     Linq | 1000 |   100 |  2.553 μs | 0.0018 μs | 0.0017 μs |  2.553 μs |  1.66x slower |   0.00x |  0.1526 |       - |     320 B |
|               LinqFaster | 1000 |   100 |  3.476 μs | 0.0155 μs | 0.0138 μs |  3.479 μs |  2.26x slower |   0.01x |  9.2010 |       - |  19,272 B |
|             LinqFasterer | 1000 |   100 |  3.449 μs | 0.0037 μs | 0.0035 μs |  3.449 μs |  2.24x slower |   0.00x |  6.1531 |       - |  12,880 B |
|                   LinqAF | 1000 |   100 | 20.992 μs | 0.4192 μs | 0.8933 μs | 20.637 μs | 13.86x slower |   0.57x |       - |       - |     672 B |
|            LinqOptimizer | 1000 |   100 | 58.668 μs | 0.1862 μs | 0.1651 μs | 58.662 μs | 38.09x slower |   0.11x | 72.6929 | 18.0054 | 160,809 B |
|                 SpanLinq | 1000 |   100 |  2.222 μs | 0.0021 μs | 0.0018 μs |  2.221 μs |  1.44x slower |   0.00x |       - |       - |         - |
|                  Streams | 1000 |   100 | 10.010 μs | 0.0122 μs | 0.0108 μs | 10.008 μs |  6.50x slower |   0.01x |  0.5493 |       - |   1,152 B |
|               StructLinq | 1000 |   100 |  1.933 μs | 0.0013 μs | 0.0011 μs |  1.933 μs |  1.26x slower |   0.00x |  0.0458 |       - |      96 B |
| StructLinq_ValueDelegate | 1000 |   100 |  1.708 μs | 0.0011 μs | 0.0009 μs |  1.708 μs |  1.11x slower |   0.00x |       - |       - |         - |
|                Hyperlinq | 1000 |   100 |  1.925 μs | 0.0006 μs | 0.0005 μs |  1.925 μs |  1.25x slower |   0.00x |       - |       - |         - |
|  Hyperlinq_ValueDelegate | 1000 |   100 |  1.844 μs | 0.0041 μs | 0.0038 μs |  1.843 μs |  1.20x slower |   0.00x |       - |       - |         - |
