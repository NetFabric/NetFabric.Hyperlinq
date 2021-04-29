## Range.RangeSelectToList

### Source
[RangeSelectToList.cs](../LinqBenchmarks/Range/RangeSelectToList.cs)

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
|                       Method | Start | Count |      Mean |    Error |    StdDev |    Median | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|----------------------------- |------ |------ |----------:|---------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|                      ForLoop |     0 |   100 | 296.39 ns | 6.023 ns | 17.087 ns | 288.10 ns |  1.00 |    0.00 | 0.5660 |     - |     - |   1,184 B |
|                  ForeachLoop |     0 |   100 | 604.75 ns | 5.187 ns |  4.050 ns | 604.10 ns |  2.02 |    0.07 | 0.5922 |     - |     - |   1,240 B |
|                         Linq |     0 |   100 | 282.55 ns | 2.277 ns |  2.019 ns | 282.06 ns |  0.94 |    0.04 | 0.2599 |     - |     - |     544 B |
|                   LinqFaster |     0 |   100 | 331.23 ns | 6.713 ns | 16.718 ns | 321.35 ns |  1.11 |    0.04 | 0.6232 |     - |     - |   1,304 B |
|                       LinqAF |     0 |   100 | 789.54 ns | 3.240 ns |  3.030 ns | 789.22 ns |  2.60 |    0.11 | 0.5655 |     - |     - |   1,184 B |
|                   StructLinq |     0 |   100 | 242.00 ns | 0.918 ns |  0.766 ns | 241.74 ns |  0.81 |    0.03 | 0.2446 |     - |     - |     512 B |
|     StructLinq_ValueDelegate |     0 |   100 | 108.52 ns | 1.263 ns |  1.119 ns | 108.48 ns |  0.36 |    0.01 | 0.2180 |     - |     - |     456 B |
|                    Hyperlinq |     0 |   100 | 251.66 ns | 2.245 ns |  1.990 ns | 251.00 ns |  0.83 |    0.03 | 0.2179 |     - |     - |     456 B |
|      Hyperlinq_ValueDelegate |     0 |   100 | 152.67 ns | 3.075 ns |  4.105 ns | 153.75 ns |  0.49 |    0.02 | 0.2179 |     - |     - |     456 B |
|               Hyperlinq_SIMD |     0 |   100 |  96.71 ns | 1.998 ns |  2.138 ns |  96.27 ns |  0.31 |    0.02 | 0.2179 |     - |     - |     456 B |
| Hyperlinq_ValueDelegate_SIMD |     0 |   100 |  70.21 ns | 1.234 ns |  1.030 ns |  70.51 ns |  0.23 |    0.01 | 0.2180 |     - |     - |     456 B |
