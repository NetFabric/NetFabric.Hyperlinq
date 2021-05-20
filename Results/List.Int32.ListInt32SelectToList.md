## List.Int32.ListInt32SelectToList

### Source
[ListInt32SelectToList.cs](../LinqBenchmarks/List/Int32/ListInt32SelectToList.cs)

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
|                       Method | Count |         Mean |      Error |     StdDev |       Median |          Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|----------------------------- |------ |-------------:|-----------:|-----------:|-------------:|---------------:|--------:|--------:|------:|------:|----------:|
|                      ForLoop |   100 |    363.63 ns |   7.775 ns |  22.926 ns |    350.42 ns |       baseline |         |  0.5660 |     - |     - |   1,184 B |
|                  ForeachLoop |   100 |    343.94 ns |   5.722 ns |   6.360 ns |    344.16 ns |   1.14x faster |   0.05x |  0.5660 |     - |     - |   1,184 B |
|                         Linq |   100 |    353.46 ns |   3.612 ns |   3.378 ns |    353.75 ns |   1.11x faster |   0.04x |  0.2522 |     - |     - |     528 B |
|                   LinqFaster |   100 |    371.38 ns |   2.826 ns |   2.506 ns |    372.17 ns |   1.05x faster |   0.04x |  0.4358 |     - |     - |     912 B |
|                 LinqFasterer |   100 |    310.19 ns |   2.469 ns |   2.062 ns |    309.46 ns |   1.26x faster |   0.04x |  0.6232 |     - |     - |   1,304 B |
|                       LinqAF |   100 |  1,255.95 ns |   8.134 ns |   6.792 ns |  1,256.80 ns |   3.22x slower |   0.12x |  0.5646 |     - |     - |   1,184 B |
|                LinqOptimizer |   100 | 41,837.88 ns | 444.632 ns | 415.909 ns | 41,807.53 ns | 106.96x slower |   4.00x | 13.9771 |     - |     - |  29,360 B |
|                     SpanLinq |   100 |    370.29 ns |   5.148 ns |   4.815 ns |    369.63 ns |   1.06x faster |   0.04x |  0.2179 |     - |     - |     456 B |
|                      Streams |   100 |  1,589.13 ns |  11.761 ns |   9.821 ns |  1,587.49 ns |   4.07x slower |   0.16x |  0.7534 |     - |     - |   1,576 B |
|                   StructLinq |   100 |    264.97 ns |   2.185 ns |   1.937 ns |    265.07 ns |   1.48x faster |   0.05x |  0.2484 |     - |     - |     520 B |
|     StructLinq_ValueDelegate |   100 |    143.58 ns |   0.962 ns |   0.751 ns |    143.63 ns |   2.72x faster |   0.10x |  0.2370 |     - |     - |     496 B |
|                    Hyperlinq |   100 |    251.35 ns |   2.857 ns |   2.673 ns |    250.42 ns |   1.56x faster |   0.06x |  0.2179 |     - |     - |     456 B |
|      Hyperlinq_ValueDelegate |   100 |    121.11 ns |   1.681 ns |   1.573 ns |    120.85 ns |   3.23x faster |   0.12x |  0.2179 |     - |     - |     456 B |
|               Hyperlinq_SIMD |   100 |    105.72 ns |   2.383 ns |   7.027 ns |    103.97 ns |   3.45x faster |   0.31x |  0.2180 |     - |     - |     456 B |
| Hyperlinq_ValueDelegate_SIMD |   100 |     70.89 ns |   1.129 ns |   0.942 ns |     70.79 ns |   5.52x faster |   0.21x |  0.2180 |     - |     - |     456 B |
