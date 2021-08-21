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
|                   Method | Skip | Count |      Mean |     Error |    StdDev |         Ratio | RatioSD |   Gen 0 |   Gen 1 | Gen 2 | Allocated |
|------------------------- |----- |------ |----------:|----------:|----------:|--------------:|--------:|--------:|--------:|------:|----------:|
|                  ForLoop | 1000 |   100 |  1.539 μs | 0.0006 μs | 0.0005 μs |      baseline |         |       - |       - |     - |         - |
|                     Linq | 1000 |   100 |  2.552 μs | 0.0011 μs | 0.0009 μs |  1.66x slower |   0.00x |  0.1526 |       - |     - |     320 B |
|               LinqFaster | 1000 |   100 |  3.458 μs | 0.0079 μs | 0.0066 μs |  2.25x slower |   0.00x |  9.2010 |       - |     - |  19,272 B |
|             LinqFasterer | 1000 |   100 |  3.448 μs | 0.0035 μs | 0.0033 μs |  2.24x slower |   0.00x |  6.1531 |       - |     - |  12,880 B |
|                   LinqAF | 1000 |   100 |  7.988 μs | 0.0069 μs | 0.0061 μs |  5.19x slower |   0.00x |       - |       - |     - |         - |
|            LinqOptimizer | 1000 |   100 | 59.537 μs | 0.2586 μs | 0.2292 μs | 38.69x slower |   0.15x | 72.6929 | 18.0664 |     - | 160,809 B |
|                 SpanLinq | 1000 |   100 |  2.250 μs | 0.0011 μs | 0.0009 μs |  1.46x slower |   0.00x |       - |       - |     - |         - |
|                  Streams | 1000 |   100 |  9.981 μs | 0.0153 μs | 0.0128 μs |  6.49x slower |   0.01x |  0.5493 |       - |     - |   1,152 B |
|               StructLinq | 1000 |   100 |  1.900 μs | 0.0009 μs | 0.0008 μs |  1.23x slower |   0.00x |  0.0458 |       - |     - |      96 B |
| StructLinq_ValueDelegate | 1000 |   100 |  1.651 μs | 0.0014 μs | 0.0013 μs |  1.07x slower |   0.00x |       - |       - |     - |         - |
|                Hyperlinq | 1000 |   100 |  1.921 μs | 0.0004 μs | 0.0004 μs |  1.25x slower |   0.00x |       - |       - |     - |         - |
|  Hyperlinq_ValueDelegate | 1000 |   100 |  1.838 μs | 0.0010 μs | 0.0009 μs |  1.19x slower |   0.00x |       - |       - |     - |         - |
