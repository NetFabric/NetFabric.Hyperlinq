## List.ValueType.ListValueTypeWhereSelectToArray

### Source
[ListValueTypeWhereSelectToArray.cs](../LinqBenchmarks/List/ValueType/ListValueTypeWhereSelectToArray.cs)

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
|                   Method | Count |      Mean |     Error |    StdDev |         Ratio | RatioSD |   Gen 0 | Allocated |
|------------------------- |------ |----------:|----------:|----------:|--------------:|--------:|--------:|----------:|
|                  ForLoop |   100 |  1.683 μs | 0.0085 μs | 0.0076 μs |      baseline |         |  5.5237 |     11 KB |
|              ForeachLoop |   100 |  1.788 μs | 0.0324 μs | 0.0271 μs |  1.06x slower |   0.02x |  5.5237 |     11 KB |
|                     Linq |   100 |  1.914 μs | 0.0174 μs | 0.0163 μs |  1.14x slower |   0.01x |  4.0016 |      8 KB |
|               LinqFaster |   100 |  2.099 μs | 0.0122 μs | 0.0114 μs |  1.25x slower |   0.01x |  5.5237 |     11 KB |
|             LinqFasterer |   100 |  2.086 μs | 0.0084 μs | 0.0070 μs |  1.24x slower |   0.01x |  6.3934 |     13 KB |
|                   LinqAF |   100 |  3.153 μs | 0.0337 μs | 0.0282 μs |  1.87x slower |   0.02x |  5.5122 |     11 KB |
|            LinqOptimizer |   100 | 63.184 μs | 0.5567 μs | 0.5207 μs | 37.51x slower |   0.36x | 73.9746 |    155 KB |
|                 SpanLinq |   100 |  2.472 μs | 0.0109 μs | 0.0097 μs |  1.47x slower |   0.01x |  5.5237 |     11 KB |
|                  Streams |   100 |  2.879 μs | 0.0536 μs | 0.0697 μs |  1.73x slower |   0.04x |  5.7716 |     12 KB |
|               StructLinq |   100 |  1.533 μs | 0.0079 μs | 0.0074 μs |  1.10x faster |   0.01x |  1.7109 |      4 KB |
| StructLinq_ValueDelegate |   100 |  1.120 μs | 0.0048 μs | 0.0042 μs |  1.50x faster |   0.01x |  1.6575 |      3 KB |
|                Hyperlinq |   100 |  1.854 μs | 0.0107 μs | 0.0095 μs |  1.10x slower |   0.01x |  1.6575 |      3 KB |
|  Hyperlinq_ValueDelegate |   100 |  1.382 μs | 0.0091 μs | 0.0085 μs |  1.22x faster |   0.01x |  1.6575 |      3 KB |
