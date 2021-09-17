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
|                       Method | Count |         Mean |      Error |    StdDev |          Ratio | RatioSD |   Gen 0 | Allocated |
|----------------------------- |------ |-------------:|-----------:|----------:|---------------:|--------:|--------:|----------:|
|                      ForLoop |   100 |    321.95 ns |   1.550 ns |  1.450 ns |       baseline |         |  0.5660 |   1,184 B |
|                  ForeachLoop |   100 |    326.29 ns |   1.492 ns |  1.323 ns |   1.01x slower |   0.00x |  0.5660 |   1,184 B |
|                         Linq |   100 |    331.92 ns |   2.248 ns |  2.103 ns |   1.03x slower |   0.01x |  0.2408 |     504 B |
|                   LinqFaster |   100 |    303.40 ns |   0.497 ns |  0.388 ns |   1.06x faster |   0.01x |  0.4206 |     880 B |
|              LinqFaster_SIMD |   100 |    144.91 ns |   0.951 ns |  0.890 ns |   2.22x faster |   0.02x |  0.4208 |     880 B |
|                 LinqFasterer |   100 |    308.72 ns |   1.974 ns |  1.750 ns |   1.04x faster |   0.01x |  0.4206 |     880 B |
|                       LinqAF |   100 |    579.03 ns |   3.071 ns |  2.722 ns |   1.80x slower |   0.01x |  0.5655 |   1,184 B |
|                LinqOptimizer |   100 | 36,156.14 ns | 112.555 ns | 87.875 ns | 112.24x slower |   0.60x | 13.5498 |  28,340 B |
|                     SpanLinq |   100 |    393.70 ns |   1.690 ns |  1.581 ns |   1.22x slower |   0.01x |  0.2179 |     456 B |
|                      Streams |   100 |  1,522.78 ns |   7.476 ns |  6.993 ns |   4.73x slower |   0.02x |  0.7534 |   1,576 B |
|                   StructLinq |   100 |    274.04 ns |   0.569 ns |  0.444 ns |   1.18x faster |   0.01x |  0.2484 |     520 B |
|     StructLinq_ValueDelegate |   100 |    206.17 ns |   1.528 ns |  1.355 ns |   1.56x faster |   0.01x |  0.2370 |     496 B |
|                    Hyperlinq |   100 |    268.53 ns |   0.691 ns |  0.539 ns |   1.20x faster |   0.01x |  0.2179 |     456 B |
|      Hyperlinq_ValueDelegate |   100 |    130.22 ns |   2.441 ns |  2.164 ns |   2.47x faster |   0.04x |  0.2179 |     456 B |
|               Hyperlinq_SIMD |   100 |    105.53 ns |   0.727 ns |  0.680 ns |   3.05x faster |   0.02x |  0.2180 |     456 B |
| Hyperlinq_ValueDelegate_SIMD |   100 |     71.88 ns |   0.717 ns |  0.636 ns |   4.48x faster |   0.04x |  0.2180 |     456 B |
