## List.Int32.ListInt32SelectToList

### Source
[ListInt32SelectToList.cs](../LinqBenchmarks/List/Int32/ListInt32SelectToList.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqFasterer: [2.1.0](https://www.nuget.org/packages/LinqFasterer/2.1.0)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- LinqOptimizer.CSharp: [0.7.0](https://www.nuget.org/packages/LinqOptimizer.CSharp/0.7.0)
- SpanLinq: [1.0.0](https://www.nuget.org/packages/SpanLinq/1.0.0)
- Streams.CSharp: [0.6.0](https://www.nuget.org/packages/Streams.CSharp/0.6.0)
- StructLinq.BCL: [0.26.0](https://www.nuget.org/packages/StructLinq/0.26.0)
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)
- System.Linq.Async: [5.0.0](https://www.nuget.org/packages/System.Linq.Async/5.0.0)

### Results:
``` ini

BenchmarkDotNet=v0.12.1.1538-nightly, OS=Windows 10.0.19043
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.4.21227.6
  [Host] : .NET 5.0.6 (5.0.621.22011), X64 RyuJIT
  .NET 6 : .NET 6.0.0 (6.0.21.22210), X64 RyuJIT

Job=.NET 6  EnvironmentVariables=COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1  Runtime=.NET 6.0  

```
|                       Method | Count |         Mean |      Error |     StdDev |       Median |  Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|----------------------------- |------ |-------------:|-----------:|-----------:|-------------:|-------:|--------:|--------:|------:|------:|----------:|
|                      ForLoop |   100 |    338.78 ns |   2.967 ns |   2.630 ns |    338.14 ns |   1.00 |    0.00 |  0.5660 |     - |     - |   1,184 B |
|                  ForeachLoop |   100 |    358.84 ns |   4.040 ns |   3.581 ns |    358.76 ns |   1.06 |    0.01 |  0.5660 |     - |     - |   1,184 B |
|                         Linq |   100 |    309.37 ns |   3.809 ns |   3.563 ns |    309.44 ns |   0.91 |    0.01 |  0.2522 |     - |     - |     528 B |
|                   LinqFaster |   100 |    361.13 ns |   7.288 ns |  20.074 ns |    350.03 ns |   1.09 |    0.06 |  0.4358 |     - |     - |     912 B |
|                 LinqFasterer |   100 |    356.75 ns |   3.522 ns |   2.749 ns |    355.83 ns |   1.05 |    0.01 |  0.6232 |     - |     - |   1,304 B |
|                       LinqAF |   100 |  1,148.01 ns |  22.717 ns |  45.369 ns |  1,122.97 ns |   3.58 |    0.10 |  0.5646 |     - |     - |   1,184 B |
|                LinqOptimizer |   100 | 39,050.26 ns | 381.097 ns | 356.479 ns | 39,074.46 ns | 115.24 |    1.25 | 13.9771 |     - |     - |  29,359 B |
|                      Streams |   100 |  1,390.14 ns |   6.474 ns |   5.406 ns |  1,392.14 ns |   4.10 |    0.03 |  0.7534 |     - |     - |   1,576 B |
|                   StructLinq |   100 |    309.77 ns |   3.099 ns |   2.588 ns |    310.20 ns |   0.91 |    0.01 |  0.2484 |     - |     - |     520 B |
|     StructLinq_ValueDelegate |   100 |    141.86 ns |   1.496 ns |   1.399 ns |    141.50 ns |   0.42 |    0.01 |  0.2370 |     - |     - |     496 B |
|                    Hyperlinq |   100 |    220.66 ns |   4.476 ns |  11.228 ns |    214.08 ns |   0.67 |    0.03 |  0.2179 |     - |     - |     456 B |
|      Hyperlinq_ValueDelegate |   100 |    129.82 ns |   1.702 ns |   1.592 ns |    129.57 ns |   0.38 |    0.00 |  0.2179 |     - |     - |     456 B |
|               Hyperlinq_SIMD |   100 |    100.55 ns |   1.198 ns |   1.000 ns |    100.19 ns |   0.30 |    0.00 |  0.2180 |     - |     - |     456 B |
| Hyperlinq_ValueDelegate_SIMD |   100 |     69.63 ns |   1.104 ns |   1.033 ns |     69.61 ns |   0.21 |    0.00 |  0.2180 |     - |     - |     456 B |
