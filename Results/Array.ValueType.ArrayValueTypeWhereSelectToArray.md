## Array.ValueType.ArrayValueTypeWhereSelectToArray

### Source
[ArrayValueTypeWhereSelectToArray.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhereSelectToArray.cs)

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
|                   Method | Count |      Mean |     Error |     StdDev |    Median |         Ratio | RatioSD |   Gen 0 | Allocated |
|------------------------- |------ |----------:|----------:|-----------:|----------:|--------------:|--------:|--------:|----------:|
|                  ForLoop |   100 |  1.543 μs | 0.0097 μs |  0.0090 μs |  1.546 μs |      baseline |         |  5.5237 |     11 KB |
|              ForeachLoop |   100 |  1.690 μs | 0.0204 μs |  0.0181 μs |  1.686 μs |  1.10x slower |   0.01x |  5.5237 |     11 KB |
|                     Linq |   100 |  2.625 μs | 0.3063 μs |  0.8740 μs |  2.312 μs |  1.54x slower |   0.55x |  3.9291 |      8 KB |
|               LinqFaster |   100 |  2.118 μs | 0.1718 μs |  0.5038 μs |  1.976 μs |  1.27x slower |   0.24x |  4.7264 |     10 KB |
|             LinqFasterer |   100 |  4.477 μs | 0.4401 μs |  1.2907 μs |  4.322 μs |  2.69x slower |   1.13x |  6.0043 |     12 KB |
|                   LinqAF |   100 | 20.579 μs | 1.1463 μs |  3.0795 μs | 20.209 μs | 13.85x slower |   2.48x |       - |     11 KB |
|            LinqOptimizer |   100 | 76.840 μs | 6.5411 μs | 18.4493 μs | 69.470 μs | 53.89x slower |  10.49x | 73.9746 |    153 KB |
|                 SpanLinq |   100 |  4.079 μs | 0.5246 μs |  1.5468 μs |  3.449 μs |  2.01x slower |   0.51x |  5.5237 |     11 KB |
|                  Streams |   100 |  2.914 μs | 0.1353 μs |  0.3816 μs |  2.791 μs |  1.81x slower |   0.19x |  5.7716 |     12 KB |
|               StructLinq |   100 |  2.114 μs | 0.1727 μs |  0.5091 μs |  1.914 μs |  1.32x slower |   0.27x |  1.7052 |      3 KB |
| StructLinq_ValueDelegate |   100 |  1.245 μs | 0.0613 μs |  0.1697 μs |  1.177 μs |  1.10x faster |   0.16x |  1.6556 |      3 KB |
|                Hyperlinq |   100 |  1.907 μs | 0.0367 μs |  0.0893 μs |  1.865 μs |  1.25x slower |   0.06x |  1.6575 |      3 KB |
|  Hyperlinq_ValueDelegate |   100 |  1.382 μs | 0.0112 μs |  0.0105 μs |  1.381 μs |  1.12x faster |   0.01x |  1.6575 |      3 KB |
