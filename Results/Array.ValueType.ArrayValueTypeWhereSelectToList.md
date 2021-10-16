## Array.ValueType.ArrayValueTypeWhereSelectToList

### Source
[ArrayValueTypeWhereSelectToList.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhereSelectToList.cs)

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
|                   Method | Count |      Mean |     Error |    StdDev |         Ratio | RatioSD |   Gen 0 |  Gen 1 | Allocated |
|------------------------- |------ |----------:|----------:|----------:|--------------:|--------:|--------:|-------:|----------:|
|                  ForLoop |   100 |  1.224 μs | 0.0101 μs | 0.0094 μs |      baseline |         |  3.8605 |      - |      8 KB |
|              ForeachLoop |   100 |  1.314 μs | 0.0099 μs | 0.0093 μs |  1.07x slower |   0.01x |  3.8605 |      - |      8 KB |
|                     Linq |   100 |  1.774 μs | 0.0097 μs | 0.0091 μs |  1.45x slower |   0.01x |  3.9673 |      - |      8 KB |
|               LinqFaster |   100 |  1.885 μs | 0.0109 μs | 0.0096 μs |  1.54x slower |   0.01x |  6.4087 |      - |     13 KB |
|             LinqFasterer |   100 |  3.152 μs | 0.0175 μs | 0.0163 μs |  2.58x slower |   0.03x |  9.0332 |      - |     18 KB |
|                   LinqAF |   100 |  2.558 μs | 0.0174 μs | 0.0154 μs |  2.09x slower |   0.02x |  3.8605 |      - |      8 KB |
|            LinqOptimizer |   100 | 59.973 μs | 0.3825 μs | 0.3578 μs | 49.01x slower |   0.51x | 76.4771 | 1.0986 |    157 KB |
|                 SpanLinq |   100 |  2.012 μs | 0.0082 μs | 0.0072 μs |  1.64x slower |   0.01x |  3.8605 |      - |      8 KB |
|                  Streams |   100 |  2.852 μs | 0.0200 μs | 0.0187 μs |  2.33x slower |   0.02x |  4.1275 |      - |      8 KB |
|               StructLinq |   100 |  1.570 μs | 0.0094 μs | 0.0088 μs |  1.28x slower |   0.01x |  1.7281 |      - |      4 KB |
| StructLinq_ValueDelegate |   100 |  1.158 μs | 0.0052 μs | 0.0049 μs |  1.06x faster |   0.01x |  1.6804 |      - |      3 KB |
|                Hyperlinq |   100 |  1.865 μs | 0.0148 μs | 0.0131 μs |  1.52x slower |   0.02x |  1.6804 |      - |      3 KB |
|  Hyperlinq_ValueDelegate |   100 |  1.435 μs | 0.0072 μs | 0.0064 μs |  1.17x slower |   0.01x |  1.6804 |      - |      3 KB |
