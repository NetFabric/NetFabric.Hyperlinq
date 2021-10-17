## Array.Int32.ArrayInt32SelectToList

### Source
[ArrayInt32SelectToList.cs](../LinqBenchmarks/Array/Int32/ArrayInt32SelectToList.cs)

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
|                       Method | Count |        Mean |     Error |    StdDev |        Ratio | RatioSD |  Gen 0 | Allocated |
|----------------------------- |------ |------------:|----------:|----------:|-------------:|--------:|-------:|----------:|
|                      ForLoop |   100 |   321.79 ns |  1.935 ns |  1.715 ns |     baseline |         | 0.5660 |   1,184 B |
|                  ForeachLoop |   100 |   324.36 ns |  2.177 ns |  2.036 ns | 1.01x slower |   0.01x | 0.5660 |   1,184 B |
|                         Linq |   100 |   332.34 ns |  1.706 ns |  1.596 ns | 1.03x slower |   0.01x | 0.2408 |     504 B |
|                   LinqFaster |   100 |   306.10 ns |  1.447 ns |  1.283 ns | 1.05x faster |   0.01x | 0.4206 |     880 B |
|              LinqFaster_SIMD |   100 |   146.50 ns |  2.056 ns |  1.923 ns | 2.20x faster |   0.03x | 0.4208 |     880 B |
|                 LinqFasterer |   100 |   282.21 ns |  1.009 ns |  0.788 ns | 1.14x faster |   0.01x | 0.4206 |     880 B |
|                       LinqAF |   100 |   614.17 ns |  1.216 ns |  0.950 ns | 1.91x slower |   0.01x | 0.5655 |   1,184 B |
|                LinqOptimizer |   100 | 1,695.39 ns | 12.322 ns | 11.526 ns | 5.27x slower |   0.04x | 4.4365 |   9,290 B |
|                     SpanLinq |   100 |   354.41 ns |  2.288 ns |  2.028 ns | 1.10x slower |   0.01x | 0.2179 |     456 B |
|                      Streams |   100 | 1,458.98 ns |  6.741 ns |  6.306 ns | 4.53x slower |   0.03x | 0.7534 |   1,576 B |
|                   StructLinq |   100 |   275.43 ns |  1.506 ns |  1.335 ns | 1.17x faster |   0.01x | 0.2484 |     520 B |
|     StructLinq_ValueDelegate |   100 |   204.42 ns |  1.127 ns |  0.880 ns | 1.58x faster |   0.01x | 0.2370 |     496 B |
|                    Hyperlinq |   100 |   266.72 ns |  1.770 ns |  1.656 ns | 1.21x faster |   0.01x | 0.2179 |     456 B |
|      Hyperlinq_ValueDelegate |   100 |   124.43 ns |  0.836 ns |  0.741 ns | 2.59x faster |   0.02x | 0.2179 |     456 B |
|               Hyperlinq_SIMD |   100 |   110.31 ns |  0.539 ns |  0.504 ns | 2.92x faster |   0.02x | 0.2180 |     456 B |
| Hyperlinq_ValueDelegate_SIMD |   100 |    69.89 ns |  0.411 ns |  0.384 ns | 4.60x faster |   0.04x | 0.2180 |     456 B |
