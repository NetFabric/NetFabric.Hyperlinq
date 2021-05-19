## Range.RangeSelectToList

### Source
[RangeSelectToList.cs](../LinqBenchmarks/Range/RangeSelectToList.cs)

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
|                       Method | Start | Count |      Mean |    Error |    StdDev |    Median | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|----------------------------- |------ |------ |----------:|---------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|                      ForLoop |     0 |   100 | 314.05 ns | 6.723 ns | 19.824 ns | 306.35 ns |  1.00 |    0.00 | 0.5660 |     - |     - |   1,184 B |
|                         Linq |     0 |   100 | 297.36 ns | 1.391 ns |  1.233 ns | 297.26 ns |  0.92 |    0.05 | 0.2599 |     - |     - |     544 B |
|                   LinqFaster |     0 |   100 | 350.25 ns | 2.189 ns |  1.940 ns | 350.11 ns |  1.09 |    0.06 | 0.6232 |     - |     - |   1,304 B |
|                       LinqAF |     0 |   100 | 729.70 ns | 6.918 ns |  5.777 ns | 728.27 ns |  2.28 |    0.12 | 0.5655 |     - |     - |   1,184 B |
|                   StructLinq |     0 |   100 | 265.21 ns | 5.362 ns |  6.972 ns | 267.16 ns |  0.81 |    0.03 | 0.2446 |     - |     - |     512 B |
|     StructLinq_ValueDelegate |     0 |   100 | 111.25 ns | 0.908 ns |  0.849 ns | 111.10 ns |  0.34 |    0.02 | 0.2179 |     - |     - |     456 B |
|                    Hyperlinq |     0 |   100 | 253.24 ns | 1.494 ns |  1.324 ns | 253.20 ns |  0.79 |    0.04 | 0.2179 |     - |     - |     456 B |
|      Hyperlinq_ValueDelegate |     0 |   100 | 145.86 ns | 1.316 ns |  1.231 ns | 145.93 ns |  0.45 |    0.02 | 0.2179 |     - |     - |     456 B |
|               Hyperlinq_SIMD |     0 |   100 |  98.90 ns | 2.392 ns |  6.863 ns |  94.91 ns |  0.32 |    0.03 | 0.2180 |     - |     - |     456 B |
| Hyperlinq_ValueDelegate_SIMD |     0 |   100 |  72.03 ns | 1.393 ns |  1.163 ns |  71.34 ns |  0.23 |    0.01 | 0.2180 |     - |     - |     456 B |
