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

BenchmarkDotNet=v0.13.0, OS=Windows 10.0.19043.985 (21H1/May2021Update)
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.4.21227.6
  [Host] : .NET 5.0.6 (5.0.621.22011), X64 RyuJIT
  .NET 6 : .NET 6.0.0 (6.0.21.22210), X64 RyuJIT

Job=.NET 6  EnvironmentVariables=COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1  Runtime=.NET 6.0  

```
|                       Method | Count |         Mean |      Error |     StdDev |          Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|----------------------------- |------ |-------------:|-----------:|-----------:|---------------:|--------:|--------:|------:|------:|----------:|
|                      ForLoop |   100 |    289.07 ns |   1.816 ns |   1.610 ns |       baseline |         |  0.5660 |     - |     - |   1,184 B |
|                  ForeachLoop |   100 |    289.50 ns |   2.920 ns |   2.588 ns |   1.00x slower |   0.01x |  0.5660 |     - |     - |   1,184 B |
|                         Linq |   100 |    253.31 ns |   2.848 ns |   2.224 ns |   1.14x faster |   0.01x |  0.2408 |     - |     - |     504 B |
|                   LinqFaster |   100 |    275.70 ns |   3.085 ns |   2.734 ns |   1.05x faster |   0.01x |  0.4206 |     - |     - |     880 B |
|              LinqFaster_SIMD |   100 |    119.95 ns |   0.944 ns |   0.837 ns |   2.41x faster |   0.02x |  0.4206 |     - |     - |     880 B |
|                 LinqFasterer |   100 |    311.24 ns |   2.728 ns |   2.552 ns |   1.08x slower |   0.01x |  0.4206 |     - |     - |     880 B |
|                       LinqAF |   100 |    888.95 ns |   5.805 ns |   4.847 ns |   3.08x slower |   0.02x |  0.5655 |     - |     - |   1,184 B |
|                LinqOptimizer |   100 | 34,858.89 ns | 317.816 ns | 265.390 ns | 120.64x slower |   1.24x | 13.4888 |     - |     - |  28,340 B |
|                     SpanLinq |   100 |    329.69 ns |   2.858 ns |   2.674 ns |   1.14x slower |   0.01x |  0.2179 |     - |     - |     456 B |
|                      Streams |   100 |  1,416.71 ns |   9.486 ns |   8.409 ns |   4.90x slower |   0.05x |  0.7534 |     - |     - |   1,576 B |
|                   StructLinq |   100 |    254.12 ns |   2.338 ns |   2.187 ns |   1.14x faster |   0.01x |  0.2484 |     - |     - |     520 B |
|     StructLinq_ValueDelegate |   100 |    136.83 ns |   1.228 ns |   1.026 ns |   2.11x faster |   0.02x |  0.2370 |     - |     - |     496 B |
|                    Hyperlinq |   100 |    241.78 ns |   2.236 ns |   1.982 ns |   1.20x faster |   0.01x |  0.2179 |     - |     - |     456 B |
|      Hyperlinq_ValueDelegate |   100 |    119.53 ns |   0.989 ns |   0.826 ns |   2.42x faster |   0.02x |  0.2179 |     - |     - |     456 B |
|               Hyperlinq_SIMD |   100 |     97.41 ns |   1.151 ns |   0.961 ns |   2.97x faster |   0.04x |  0.2180 |     - |     - |     456 B |
| Hyperlinq_ValueDelegate_SIMD |   100 |     67.95 ns |   0.833 ns |   0.738 ns |   4.25x faster |   0.06x |  0.2180 |     - |     - |     456 B |
