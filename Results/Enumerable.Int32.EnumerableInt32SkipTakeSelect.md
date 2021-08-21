## Enumerable.Int32.EnumerableInt32SkipTakeSelect

### Source
[EnumerableInt32SkipTakeSelect.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32SkipTakeSelect.cs)

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
|                   Method | Skip | Count |      Mean |     Error |    StdDev |         Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |----- |------ |----------:|----------:|----------:|--------------:|--------:|--------:|------:|------:|----------:|
|                     Linq | 1000 |   100 |  3.071 μs | 0.0181 μs | 0.0160 μs |      baseline |         |  0.0992 |     - |     - |     208 B |
|                   LinqAF | 1000 |   100 |  3.103 μs | 0.0011 μs | 0.0009 μs |  1.01x slower |   0.01x |  0.0191 |     - |     - |      40 B |
|            LinqOptimizer | 1000 |   100 | 55.090 μs | 0.1880 μs | 0.1759 μs | 17.94x slower |   0.11x | 15.5640 |     - |     - |  32,618 B |
|                  Streams | 1000 |   100 |  7.444 μs | 0.1335 μs | 0.1042 μs |  2.42x slower |   0.03x |  0.4349 |     - |     - |     920 B |
|               StructLinq | 1000 |   100 |  2.668 μs | 0.0158 μs | 0.0132 μs |  1.15x faster |   0.01x |  0.0610 |     - |     - |     128 B |
| StructLinq_ValueDelegate | 1000 |   100 |  2.435 μs | 0.0085 μs | 0.0075 μs |  1.26x faster |   0.01x |  0.0191 |     - |     - |      40 B |
|                Hyperlinq | 1000 |   100 |  3.597 μs | 0.0036 μs | 0.0032 μs |  1.17x slower |   0.01x |  0.0191 |     - |     - |      40 B |
|  Hyperlinq_ValueDelegate | 1000 |   100 |  2.859 μs | 0.0020 μs | 0.0016 μs |  1.07x faster |   0.01x |  0.0191 |     - |     - |      40 B |
