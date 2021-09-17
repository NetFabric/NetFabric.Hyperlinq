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
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)
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
|                   Method | Skip | Count |      Mean |     Error |    StdDev |         Ratio | RatioSD |   Gen 0 | Allocated |
|------------------------- |----- |------ |----------:|----------:|----------:|--------------:|--------:|--------:|----------:|
|                  ForLoop | 1000 |   100 |  1.540 μs | 0.0031 μs | 0.0026 μs |      baseline |         |       - |         - |
|                     Linq | 1000 |   100 |  2.549 μs | 0.0024 μs | 0.0018 μs |  1.65x slower |   0.00x |  0.1526 |     320 B |
|               LinqFaster | 1000 |   100 |  3.458 μs | 0.0180 μs | 0.0159 μs |  2.25x slower |   0.01x |  9.2010 |  19,272 B |
|             LinqFasterer | 1000 |   100 |  3.450 μs | 0.0145 μs | 0.0129 μs |  2.24x slower |   0.01x |  6.1531 |  12,880 B |
|                   LinqAF | 1000 |   100 |  7.769 μs | 0.0104 μs | 0.0087 μs |  5.04x slower |   0.01x |       - |         - |
|            LinqOptimizer | 1000 |   100 | 59.175 μs | 0.9339 μs | 0.8735 μs | 38.39x slower |   0.53x | 76.9043 | 160,812 B |
|                 SpanLinq | 1000 |   100 |  2.221 μs | 0.0074 μs | 0.0069 μs |  1.44x slower |   0.00x |       - |         - |
|                  Streams | 1000 |   100 |  9.943 μs | 0.0369 μs | 0.0345 μs |  6.46x slower |   0.03x |  0.5493 |   1,152 B |
|               StructLinq | 1000 |   100 |  1.931 μs | 0.0034 μs | 0.0030 μs |  1.25x slower |   0.00x |  0.0458 |      96 B |
| StructLinq_ValueDelegate | 1000 |   100 |  1.708 μs | 0.0037 μs | 0.0035 μs |  1.11x slower |   0.00x |       - |         - |
|                Hyperlinq | 1000 |   100 |  1.922 μs | 0.0015 μs | 0.0011 μs |  1.25x slower |   0.00x |       - |         - |
|  Hyperlinq_ValueDelegate | 1000 |   100 |  1.840 μs | 0.0034 μs | 0.0030 μs |  1.19x slower |   0.00x |       - |         - |
