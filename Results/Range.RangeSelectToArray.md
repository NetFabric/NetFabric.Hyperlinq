## Range.RangeSelectToArray

### Source
[RangeSelectToArray.cs](../LinqBenchmarks/Range/RangeSelectToArray.cs)

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
|                       Method | Start | Count |      Mean |    Error |   StdDev |    Median | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|----------------------------- |------ |------ |----------:|---------:|---------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|                      ForLoop |     0 |   100 |  93.57 ns | 1.050 ns | 0.982 ns |  93.62 ns |  1.00 |    0.00 | 0.2027 |     - |     - |     424 B |
|                         Linq |     0 |   100 | 247.14 ns | 1.365 ns | 1.210 ns | 247.12 ns |  2.64 |    0.03 | 0.2446 |     - |     - |     512 B |
|                   LinqFaster |     0 |   100 | 288.56 ns | 2.719 ns | 2.543 ns | 288.91 ns |  3.08 |    0.04 | 0.4053 |     - |     - |     848 B |
|              LinqFaster_SIMD |     0 |   100 | 110.38 ns | 2.607 ns | 7.686 ns | 106.04 ns |  1.29 |    0.04 | 0.4054 |     - |     - |     848 B |
|                       LinqAF |     0 |   100 | 777.58 ns | 5.665 ns | 5.299 ns | 775.38 ns |  8.31 |    0.10 | 0.7534 |     - |     - |   1,576 B |
|                   StructLinq |     0 |   100 | 249.73 ns | 4.956 ns | 8.003 ns | 252.10 ns |  2.62 |    0.11 | 0.2294 |     - |     - |     480 B |
|     StructLinq_ValueDelegate |     0 |   100 |  95.38 ns | 1.954 ns | 2.739 ns |  94.38 ns |  1.04 |    0.03 | 0.2027 |     - |     - |     424 B |
|                    Hyperlinq |     0 |   100 | 255.93 ns | 5.105 ns | 8.097 ns | 257.48 ns |  2.70 |    0.10 | 0.2027 |     - |     - |     424 B |
|      Hyperlinq_ValueDelegate |     0 |   100 | 131.52 ns | 1.323 ns | 1.238 ns | 131.36 ns |  1.41 |    0.02 | 0.2027 |     - |     - |     424 B |
|               Hyperlinq_SIMD |     0 |   100 |  88.00 ns | 1.823 ns | 1.705 ns |  87.59 ns |  0.94 |    0.02 | 0.2027 |     - |     - |     424 B |
| Hyperlinq_ValueDelegate_SIMD |     0 |   100 |  62.25 ns | 1.135 ns | 1.062 ns |  62.49 ns |  0.67 |    0.02 | 0.2027 |     - |     - |     424 B |
