## Range.RangeSelectToList

### Source
[RangeSelectToList.cs](../LinqBenchmarks/Range/RangeSelectToList.cs)

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
|                       Method | Start | Count |      Mean |    Error |    StdDev |    Median |        Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|----------------------------- |------ |------ |----------:|---------:|----------:|----------:|-------------:|--------:|-------:|------:|------:|----------:|
|                      ForLoop |     0 |   100 | 335.47 ns | 7.810 ns | 22.284 ns | 346.41 ns |     baseline |         | 0.5660 |     - |     - |   1,184 B |
|                         Linq |     0 |   100 | 299.47 ns | 3.101 ns |  2.749 ns | 299.47 ns | 1.15x faster |   0.07x | 0.2599 |     - |     - |     544 B |
|                   LinqFaster |     0 |   100 | 365.81 ns | 3.681 ns |  3.444 ns | 364.79 ns | 1.06x slower |   0.06x | 0.6232 |     - |     - |   1,304 B |
|                       LinqAF |     0 |   100 | 767.80 ns | 7.224 ns |  6.404 ns | 765.83 ns | 2.24x slower |   0.13x | 0.5655 |     - |     - |   1,184 B |
|                   StructLinq |     0 |   100 | 281.45 ns | 1.690 ns |  1.319 ns | 281.73 ns | 1.21x faster |   0.07x | 0.2446 |     - |     - |     512 B |
|     StructLinq_ValueDelegate |     0 |   100 | 116.48 ns | 1.992 ns |  1.864 ns | 116.34 ns | 2.97x faster |   0.18x | 0.2179 |     - |     - |     456 B |
|                    Hyperlinq |     0 |   100 | 266.04 ns | 1.891 ns |  1.676 ns | 266.72 ns | 1.30x faster |   0.08x | 0.2179 |     - |     - |     456 B |
|      Hyperlinq_ValueDelegate |     0 |   100 | 153.74 ns | 2.321 ns |  1.938 ns | 153.09 ns | 2.23x faster |   0.13x | 0.2179 |     - |     - |     456 B |
|               Hyperlinq_SIMD |     0 |   100 |  99.88 ns | 1.634 ns |  2.639 ns |  98.95 ns | 3.48x faster |   0.21x | 0.2180 |     - |     - |     456 B |
| Hyperlinq_ValueDelegate_SIMD |     0 |   100 |  76.42 ns | 0.768 ns |  0.681 ns |  76.42 ns | 4.51x faster |   0.27x | 0.2180 |     - |     - |     456 B |
