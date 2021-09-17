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
|                   Method | Count |      Mean |     Error |    StdDev |         Ratio | RatioSD |   Gen 0 | Allocated |
|------------------------- |------ |----------:|----------:|----------:|--------------:|--------:|--------:|----------:|
|                  ForLoop |   100 |  1.501 μs | 0.0119 μs | 0.0112 μs |      baseline |         |  5.5237 |     11 KB |
|              ForeachLoop |   100 |  1.616 μs | 0.0108 μs | 0.0101 μs |  1.08x slower |   0.01x |  5.5237 |     11 KB |
|                     Linq |   100 |  1.826 μs | 0.0116 μs | 0.0109 μs |  1.22x slower |   0.01x |  3.9291 |      8 KB |
|               LinqFaster |   100 |  1.541 μs | 0.0099 μs | 0.0088 μs |  1.03x slower |   0.01x |  4.7264 |     10 KB |
|             LinqFasterer |   100 |  2.583 μs | 0.0177 μs | 0.0157 μs |  1.72x slower |   0.01x |  6.0043 |     12 KB |
|                   LinqAF |   100 |  2.888 μs | 0.0271 μs | 0.0254 μs |  1.92x slower |   0.02x |  5.5122 |     11 KB |
|            LinqOptimizer |   100 | 57.139 μs | 0.2758 μs | 0.2303 μs | 38.09x slower |   0.30x | 74.0356 |    153 KB |
|                 SpanLinq |   100 |  2.366 μs | 0.0224 μs | 0.0209 μs |  1.58x slower |   0.02x |  5.5237 |     11 KB |
|                  Streams |   100 |  2.626 μs | 0.0169 μs | 0.0150 μs |  1.75x slower |   0.01x |  5.7716 |     12 KB |
|               StructLinq |   100 |  1.559 μs | 0.0175 μs | 0.0164 μs |  1.04x slower |   0.01x |  1.7052 |      3 KB |
| StructLinq_ValueDelegate |   100 |  1.108 μs | 0.0088 μs | 0.0082 μs |  1.35x faster |   0.01x |  1.6575 |      3 KB |
|                Hyperlinq |   100 |  1.789 μs | 0.0110 μs | 0.0098 μs |  1.19x slower |   0.01x |  1.6632 |      3 KB |
|  Hyperlinq_ValueDelegate |   100 |  1.375 μs | 0.0171 μs | 0.0160 μs |  1.09x faster |   0.02x |  1.6632 |      3 KB |
