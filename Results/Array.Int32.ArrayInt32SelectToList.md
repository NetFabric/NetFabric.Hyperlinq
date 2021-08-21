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
|                       Method | Count |         Mean |     Error |    StdDev |       Median |          Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|----------------------------- |------ |-------------:|----------:|----------:|-------------:|---------------:|--------:|--------:|------:|------:|----------:|
|                      ForLoop |   100 |    319.95 ns |  0.549 ns |  0.514 ns |    319.79 ns |       baseline |         |  0.5660 |     - |     - |   1,184 B |
|                  ForeachLoop |   100 |    326.32 ns |  1.404 ns |  1.096 ns |    326.01 ns |   1.02x slower |   0.00x |  0.5660 |     - |     - |   1,184 B |
|                         Linq |   100 |    313.61 ns |  0.376 ns |  0.333 ns |    313.70 ns |   1.02x faster |   0.00x |  0.2408 |     - |     - |     504 B |
|                   LinqFaster |   100 |    328.03 ns |  0.580 ns |  0.514 ns |    327.92 ns |   1.03x slower |   0.00x |  0.4206 |     - |     - |     880 B |
|              LinqFaster_SIMD |   100 |    147.86 ns |  0.560 ns |  0.524 ns |    147.65 ns |   2.16x faster |   0.01x |  0.4208 |     - |     - |     880 B |
|                 LinqFasterer |   100 |    281.84 ns |  0.618 ns |  0.547 ns |    281.55 ns |   1.14x faster |   0.00x |  0.4206 |     - |     - |     880 B |
|                       LinqAF |   100 |    569.37 ns |  0.860 ns |  0.763 ns |    569.37 ns |   1.78x slower |   0.00x |  0.5655 |     - |     - |   1,184 B |
|                LinqOptimizer |   100 | 36,173.60 ns | 60.717 ns | 50.701 ns | 36,173.10 ns | 113.03x slower |   0.26x | 13.5498 |     - |     - |  28,340 B |
|                     SpanLinq |   100 |    351.64 ns |  1.542 ns |  1.287 ns |    351.44 ns |   1.10x slower |   0.00x |  0.2179 |     - |     - |     456 B |
|                      Streams |   100 |  1,527.13 ns |  2.761 ns |  2.447 ns |  1,526.09 ns |   4.77x slower |   0.01x |  0.7534 |     - |     - |   1,576 B |
|                   StructLinq |   100 |    272.42 ns |  0.393 ns |  0.368 ns |    272.33 ns |   1.17x faster |   0.00x |  0.2484 |     - |     - |     520 B |
|     StructLinq_ValueDelegate |   100 |    204.25 ns |  0.387 ns |  0.362 ns |    204.31 ns |   1.57x faster |   0.00x |  0.2370 |     - |     - |     496 B |
|                    Hyperlinq |   100 |    289.90 ns |  0.493 ns |  0.411 ns |    289.84 ns |   1.10x faster |   0.00x |  0.2179 |     - |     - |     456 B |
|      Hyperlinq_ValueDelegate |   100 |    128.27 ns |  0.236 ns |  0.221 ns |    128.25 ns |   2.49x faster |   0.01x |  0.2179 |     - |     - |     456 B |
|               Hyperlinq_SIMD |   100 |    105.49 ns |  2.190 ns |  3.140 ns |    103.21 ns |   2.97x faster |   0.07x |  0.2180 |     - |     - |     456 B |
| Hyperlinq_ValueDelegate_SIMD |   100 |     68.85 ns |  0.162 ns |  0.143 ns |     68.87 ns |   4.65x faster |   0.01x |  0.2180 |     - |     - |     456 B |
