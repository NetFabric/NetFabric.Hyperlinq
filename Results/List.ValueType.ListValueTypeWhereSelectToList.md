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
|                   Method | Count |      Mean |     Error |    StdDev |         Ratio | RatioSD |   Gen 0 |   Gen 1 | Allocated |
|------------------------- |------ |----------:|----------:|----------:|--------------:|--------:|--------:|--------:|----------:|
|                  ForLoop |   100 |  1.374 μs | 0.0090 μs | 0.0084 μs |      baseline |         |  3.8605 |       - |      8 KB |
|              ForeachLoop |   100 |  1.471 μs | 0.0107 μs | 0.0084 μs |  1.07x slower |   0.01x |  3.8605 |       - |      8 KB |
|                     Linq |   100 |  1.832 μs | 0.0286 μs | 0.0268 μs |  1.33x slower |   0.02x |  4.0436 |       - |      8 KB |
|               LinqFaster |   100 |  2.244 μs | 0.0290 μs | 0.0257 μs |  1.63x slower |   0.02x |  5.5428 |       - |     11 KB |
|             LinqFasterer |   100 |  2.370 μs | 0.0211 μs | 0.0187 μs |  1.73x slower |   0.02x |  8.0643 |       - |     16 KB |
|                   LinqAF |   100 |  2.693 μs | 0.0263 μs | 0.0233 μs |  1.96x slower |   0.02x |  3.8605 |       - |      8 KB |
|            LinqOptimizer |   100 | 63.619 μs | 0.5836 μs | 0.5459 μs | 46.31x slower |   0.49x | 74.0967 | 16.3574 |    158 KB |
|                 SpanLinq |   100 |  1.983 μs | 0.0074 μs | 0.0062 μs |  1.44x slower |   0.01x |  3.8605 |       - |      8 KB |
|                  Streams |   100 |  3.069 μs | 0.0320 μs | 0.0299 μs |  2.23x slower |   0.03x |  4.1275 |       - |      8 KB |
|               StructLinq |   100 |  1.512 μs | 0.0175 μs | 0.0164 μs |  1.10x slower |   0.01x |  1.7300 |       - |      4 KB |
| StructLinq_ValueDelegate |   100 |  1.139 μs | 0.0069 μs | 0.0058 μs |  1.21x faster |   0.01x |  1.6804 |       - |      3 KB |
|                Hyperlinq |   100 |  1.827 μs | 0.0081 μs | 0.0072 μs |  1.33x slower |   0.01x |  1.6804 |       - |      3 KB |
|  Hyperlinq_ValueDelegate |   100 |  1.431 μs | 0.0107 μs | 0.0101 μs |  1.04x slower |   0.01x |  1.6804 |       - |      3 KB |
