## List.Int32.ListInt32SelectToList

### Source
[ListInt32SelectToList.cs](../LinqBenchmarks/List/Int32/ListInt32SelectToList.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqFasterer: [2.1.0](https://www.nuget.org/packages/LinqFasterer/2.1.0)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- LinqOptimizer.CSharp: [](https://www.nuget.org/packages/LinqOptimizer.CSharp/)
- Streams.CSharp: [0.6.0](https://www.nuget.org/packages/Streams.CSharp/0.6.0)
- StructLinq.BCL: [0.26.0](https://www.nuget.org/packages/StructLinq/0.26.0)
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)

### Results:
``` ini

BenchmarkDotNet=v0.12.1.1527-nightly, OS=Windows 10.0.19043
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.4.21227.6
  [Host] : .NET 5.0.4 (5.0.421.11614), X64 RyuJIT
  .NET 6 : .NET 6.0.0 (6.0.21.22210), X64 RyuJIT

Job=.NET 6  EnvironmentVariables=COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1  Runtime=.NET 6.0  

```
|                       Method | Count |         Mean |      Error |     StdDev |       Median |  Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|----------------------------- |------ |-------------:|-----------:|-----------:|-------------:|-------:|--------:|--------:|------:|------:|----------:|
|                      ForLoop |   100 |    340.33 ns |   2.454 ns |   2.049 ns |    340.20 ns |   1.00 |    0.00 |  0.5660 |     - |     - |   1,184 B |
|                  ForeachLoop |   100 |    311.07 ns |   2.954 ns |   4.686 ns |    309.46 ns |   0.92 |    0.01 |  0.5660 |     - |     - |   1,184 B |
|                         Linq |   100 |    330.84 ns |   1.532 ns |   1.433 ns |    330.60 ns |   0.97 |    0.01 |  0.2522 |     - |     - |     528 B |
|                   LinqFaster |   100 |    387.09 ns |   2.221 ns |   1.854 ns |    387.48 ns |   1.14 |    0.01 |  0.4358 |     - |     - |     912 B |
|                       LinqAF |   100 |  1,116.14 ns |  11.681 ns |  10.355 ns |  1,113.12 ns |   3.28 |    0.03 |  0.5646 |     - |     - |   1,184 B |
|                LinqOptimizer |   100 | 38,965.31 ns | 349.611 ns | 309.921 ns | 38,915.38 ns | 114.49 |    1.20 | 13.9771 |     - |     - |  29,359 B |
|                      Streams |   100 |  1,572.56 ns |  30.900 ns |  39.079 ns |  1,586.65 ns |   4.59 |    0.16 |  0.7534 |     - |     - |   1,576 B |
|                   StructLinq |   100 |    250.75 ns |   1.152 ns |   1.077 ns |    250.46 ns |   0.74 |    0.01 |  0.2484 |     - |     - |     520 B |
|     StructLinq_ValueDelegate |   100 |    135.53 ns |   1.262 ns |   1.119 ns |    135.50 ns |   0.40 |    0.00 |  0.2370 |     - |     - |     496 B |
|                    Hyperlinq |   100 |    223.52 ns |   4.536 ns |  10.145 ns |    217.76 ns |   0.68 |    0.03 |  0.2179 |     - |     - |     456 B |
|      Hyperlinq_ValueDelegate |   100 |    115.97 ns |   1.013 ns |   0.791 ns |    116.30 ns |   0.34 |    0.00 |  0.2179 |     - |     - |     456 B |
|               Hyperlinq_SIMD |   100 |     98.46 ns |   0.844 ns |   0.789 ns |     98.63 ns |   0.29 |    0.00 |  0.2180 |     - |     - |     456 B |
| Hyperlinq_ValueDelegate_SIMD |   100 |     65.45 ns |   1.377 ns |   1.288 ns |     65.37 ns |   0.19 |    0.00 |  0.2180 |     - |     - |     456 B |
