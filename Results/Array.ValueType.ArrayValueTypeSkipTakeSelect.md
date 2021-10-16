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
- NetFabric.Hyperlinq: [3.0.0-beta48](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta48)
- System.Linq.Async: [5.0.0](https://www.nuget.org/packages/System.Linq.Async/5.0.0)

### Results:
``` ini

BenchmarkDotNet=v0.13.1, OS=macOS Catalina 10.15.7 (19H1419) [Darwin 19.6.0]
Intel Core i5-7360U CPU 2.30GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-rc.2.21505.57
  [Host]     : .NET 5.0.6 (5.0.621.22011), X64 RyuJIT
  .NET 6 PGO : .NET 6.0.0 (6.0.21.48005), X64 RyuJIT

Job=.NET 6 PGO  EnvironmentVariables=COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1  Runtime=.NET 6.0  

```
|                   Method | Skip | Count |      Mean |     Error |    StdDev |         Ratio | RatioSD |   Gen 0 |   Gen 1 | Allocated |
|------------------------- |----- |------ |----------:|----------:|----------:|--------------:|--------:|--------:|--------:|----------:|
|                  ForLoop | 1000 |   100 |  1.540 μs | 0.0011 μs | 0.0011 μs |      baseline |         |       - |       - |         - |
|                     Linq | 1000 |   100 |  2.560 μs | 0.0020 μs | 0.0018 μs |  1.66x slower |   0.00x |  0.1526 |       - |     320 B |
|               LinqFaster | 1000 |   100 |  3.460 μs | 0.0123 μs | 0.0115 μs |  2.25x slower |   0.01x |  9.2010 |       - |  19,272 B |
|             LinqFasterer | 1000 |   100 |  3.451 μs | 0.0071 μs | 0.0059 μs |  2.24x slower |   0.00x |  6.1531 |       - |  12,880 B |
|                   LinqAF | 1000 |   100 |  7.928 μs | 0.0177 μs | 0.0166 μs |  5.15x slower |   0.01x |       - |       - |         - |
|            LinqOptimizer | 1000 |   100 | 59.250 μs | 0.6111 μs | 0.5716 μs | 38.46x slower |   0.37x | 72.6929 | 18.0054 | 160,809 B |
|                 SpanLinq | 1000 |   100 |  2.231 μs | 0.0019 μs | 0.0016 μs |  1.45x slower |   0.00x |       - |       - |         - |
|                  Streams | 1000 |   100 | 10.045 μs | 0.0181 μs | 0.0169 μs |  6.52x slower |   0.01x |  0.5493 |       - |   1,152 B |
|               StructLinq | 1000 |   100 |  1.910 μs | 0.0020 μs | 0.0018 μs |  1.24x slower |   0.00x |  0.0458 |       - |      96 B |
| StructLinq_ValueDelegate | 1000 |   100 |  1.653 μs | 0.0008 μs | 0.0007 μs |  1.07x slower |   0.00x |       - |       - |         - |
|                Hyperlinq | 1000 |   100 |  1.922 μs | 0.0016 μs | 0.0013 μs |  1.25x slower |   0.00x |       - |       - |         - |
|  Hyperlinq_ValueDelegate | 1000 |   100 |  1.811 μs | 0.0017 μs | 0.0014 μs |  1.18x slower |   0.00x |       - |       - |         - |
