## List.ValueType.ListValueTypeWhereSelectToList

### Source
[ListValueTypeWhereSelectToList.cs](../LinqBenchmarks/List/ValueType/ListValueTypeWhereSelectToList.cs)

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
|                   Method | Count |      Mean |     Error |    StdDev |         Ratio | RatioSD |   Gen 0 |   Gen 1 | Allocated |
|------------------------- |------ |----------:|----------:|----------:|--------------:|--------:|--------:|--------:|----------:|
|                  ForLoop |   100 |  1.356 μs | 0.0090 μs | 0.0084 μs |      baseline |         |  3.8605 |       - |      8 KB |
|              ForeachLoop |   100 |  1.503 μs | 0.0073 μs | 0.0064 μs |  1.11x slower |   0.01x |  3.8605 |       - |      8 KB |
|                     Linq |   100 |  1.779 μs | 0.0094 μs | 0.0088 μs |  1.31x slower |   0.01x |  4.0455 |       - |      8 KB |
|               LinqFaster |   100 |  2.123 μs | 0.0080 μs | 0.0063 μs |  1.56x slower |   0.01x |  5.5428 |       - |     11 KB |
|             LinqFasterer |   100 |  2.453 μs | 0.0131 μs | 0.0122 μs |  1.81x slower |   0.01x |  8.0643 |       - |     16 KB |
|                   LinqAF |   100 |  2.704 μs | 0.0277 μs | 0.0231 μs |  1.99x slower |   0.02x |  3.8605 |       - |      8 KB |
|            LinqOptimizer |   100 | 62.365 μs | 0.5139 μs | 0.4556 μs | 45.97x slower |   0.43x | 76.7822 | 19.1650 |    158 KB |
|                 SpanLinq |   100 |  2.020 μs | 0.0207 μs | 0.0183 μs |  1.49x slower |   0.02x |  3.8605 |       - |      8 KB |
|                  Streams |   100 |  3.101 μs | 0.0181 μs | 0.0160 μs |  2.29x slower |   0.02x |  4.1275 |       - |      8 KB |
|               StructLinq |   100 |  1.501 μs | 0.0063 μs | 0.0059 μs |  1.11x slower |   0.01x |  1.7300 |       - |      4 KB |
| StructLinq_ValueDelegate |   100 |  1.135 μs | 0.0057 μs | 0.0053 μs |  1.19x faster |   0.01x |  1.6804 |       - |      3 KB |
|                Hyperlinq |   100 |  1.843 μs | 0.0073 μs | 0.0064 μs |  1.36x slower |   0.01x |  1.6804 |       - |      3 KB |
|  Hyperlinq_ValueDelegate |   100 |  1.396 μs | 0.0122 μs | 0.0108 μs |  1.03x slower |   0.01x |  1.6804 |       - |      3 KB |
