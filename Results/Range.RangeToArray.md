## Range.RangeToArray

### Source
[RangeToArray.cs](../LinqBenchmarks/Range/RangeToArray.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- LinqOptimizer.CSharp: [](https://www.nuget.org/packages/LinqOptimizer.CSharp/)
- Streams.CSharp: [0.6.0](https://www.nuget.org/packages/Streams.CSharp/0.6.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)

### Results:
``` ini

BenchmarkDotNet=v0.12.1.1527-nightly, OS=Windows 10.0.19043
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.3.21202.5
  [Host] : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT
  .NET 5 : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT
  .NET 6 : .NET 6.0.0 (6.0.21.20104), X64 RyuJIT

EnvironmentVariables=COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1  

```
|          Method |    Job |  Runtime | Start | Count |         Mean |      Error |     StdDev |       Median | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------- |------- |--------- |------ |------ |-------------:|-----------:|-----------:|-------------:|------:|--------:|-------:|------:|------:|----------:|
|         **ForLoop** | **.NET 5** | **.NET 5.0** |     **0** |    **10** |    **11.468 ns** |  **0.2788 ns** |  **0.2608 ns** |    **11.540 ns** |  **1.00** |    **0.00** | **0.0306** |     **-** |     **-** |      **64 B** |
|            Linq | .NET 5 | .NET 5.0 |     0 |    10 |    28.090 ns |  0.6489 ns |  1.1365 ns |    27.507 ns |  2.48 |    0.12 | 0.0497 |     - |     - |     104 B |
|      LinqFaster | .NET 5 | .NET 5.0 |     0 |    10 |    11.501 ns |  0.3266 ns |  0.3494 ns |    11.472 ns |  1.00 |    0.04 | 0.0306 |     - |     - |      64 B |
| LinqFaster_SIMD | .NET 5 | .NET 5.0 |     0 |    10 |    15.230 ns |  0.2347 ns |  0.2081 ns |    15.170 ns |  1.33 |    0.04 | 0.0306 |     - |     - |      64 B |
|          LinqAF | .NET 5 | .NET 5.0 |     0 |    10 |    55.280 ns |  0.2831 ns |  0.2648 ns |    55.210 ns |  4.82 |    0.12 | 0.0306 |     - |     - |      64 B |
|      StructLinq | .NET 5 | .NET 5.0 |     0 |    10 |    11.652 ns |  0.3150 ns |  0.3234 ns |    11.612 ns |  1.02 |    0.04 | 0.0306 |     - |     - |      64 B |
|       Hyperlinq | .NET 5 | .NET 5.0 |     0 |    10 |    15.977 ns |  0.2111 ns |  0.1871 ns |    16.005 ns |  1.39 |    0.04 | 0.0306 |     - |     - |      64 B |
|                 |        |          |       |       |              |            |            |              |       |         |        |       |       |           |
|         ForLoop | .NET 6 | .NET 6.0 |     0 |    10 |    12.474 ns |  0.1269 ns |  0.1059 ns |    12.475 ns |  1.00 |    0.00 | 0.0306 |     - |     - |      64 B |
|            Linq | .NET 6 | .NET 6.0 |     0 |    10 |    22.676 ns |  0.5411 ns |  0.5314 ns |    22.531 ns |  1.82 |    0.05 | 0.0497 |     - |     - |     104 B |
|      LinqFaster | .NET 6 | .NET 6.0 |     0 |    10 |     9.433 ns |  0.1338 ns |  0.1118 ns |     9.472 ns |  0.76 |    0.01 | 0.0306 |     - |     - |      64 B |
| LinqFaster_SIMD | .NET 6 | .NET 6.0 |     0 |    10 |    15.329 ns |  0.3648 ns |  0.5679 ns |    15.152 ns |  1.24 |    0.07 | 0.0306 |     - |     - |      64 B |
|          LinqAF | .NET 6 | .NET 6.0 |     0 |    10 |    45.960 ns |  0.2424 ns |  0.2268 ns |    45.940 ns |  3.68 |    0.03 | 0.0306 |     - |     - |      64 B |
|      StructLinq | .NET 6 | .NET 6.0 |     0 |    10 |    11.461 ns |  0.3230 ns |  0.3021 ns |    11.367 ns |  0.92 |    0.03 | 0.0306 |     - |     - |      64 B |
|       Hyperlinq | .NET 6 | .NET 6.0 |     0 |    10 |    16.067 ns |  0.2149 ns |  0.1794 ns |    16.086 ns |  1.29 |    0.02 | 0.0306 |     - |     - |      64 B |
|                 |        |          |       |       |              |            |            |              |       |         |        |       |       |           |
|         **ForLoop** | **.NET 5** | **.NET 5.0** |     **0** |  **1000** | **1,397.000 ns** | **15.2458 ns** | **13.5150 ns** | **1,394.323 ns** |  **1.00** |    **0.00** | **1.9226** |     **-** |     **-** |   **4,024 B** |
|            Linq | .NET 5 | .NET 5.0 |     0 |  1000 |   644.253 ns | 11.5573 ns | 10.8107 ns |   643.793 ns |  0.46 |    0.01 | 1.9417 |     - |     - |   4,064 B |
|      LinqFaster | .NET 5 | .NET 5.0 |     0 |  1000 |   605.170 ns |  3.8166 ns |  3.5700 ns |   604.752 ns |  0.43 |    0.01 | 1.9226 |     - |     - |   4,024 B |
| LinqFaster_SIMD | .NET 5 | .NET 5.0 |     0 |  1000 |   278.692 ns |  2.7204 ns |  2.5447 ns |   278.202 ns |  0.20 |    0.00 | 1.9226 |     - |     - |   4,024 B |
|          LinqAF | .NET 5 | .NET 5.0 |     0 |  1000 | 1,821.226 ns | 12.4785 ns | 11.6724 ns | 1,816.641 ns |  1.30 |    0.02 | 1.9226 |     - |     - |   4,024 B |
|      StructLinq | .NET 5 | .NET 5.0 |     0 |  1000 |   717.119 ns |  5.4424 ns |  4.5446 ns |   717.273 ns |  0.51 |    0.01 | 1.9226 |     - |     - |   4,024 B |
|       Hyperlinq | .NET 5 | .NET 5.0 |     0 |  1000 |   284.327 ns |  2.0635 ns |  1.9302 ns |   283.750 ns |  0.20 |    0.00 | 1.9226 |     - |     - |   4,024 B |
|                 |        |          |       |       |              |            |            |              |       |         |        |       |       |           |
|         ForLoop | .NET 6 | .NET 6.0 |     0 |  1000 |   726.759 ns | 11.0869 ns | 10.3707 ns |   727.603 ns |  1.00 |    0.00 | 1.9226 |     - |     - |   4,024 B |
|            Linq | .NET 6 | .NET 6.0 |     0 |  1000 |   605.436 ns |  8.1422 ns |  7.6162 ns |   607.674 ns |  0.83 |    0.01 | 1.9417 |     - |     - |   4,064 B |
|      LinqFaster | .NET 6 | .NET 6.0 |     0 |  1000 |   607.744 ns |  3.7126 ns |  3.4728 ns |   607.254 ns |  0.84 |    0.01 | 1.9226 |     - |     - |   4,024 B |
| LinqFaster_SIMD | .NET 6 | .NET 6.0 |     0 |  1000 |   280.489 ns |  4.8522 ns |  4.5388 ns |   281.625 ns |  0.39 |    0.01 | 1.9226 |     - |     - |   4,024 B |
|          LinqAF | .NET 6 | .NET 6.0 |     0 |  1000 | 1,639.847 ns | 31.7869 ns | 28.1783 ns | 1,627.723 ns |  2.25 |    0.04 | 1.9226 |     - |     - |   4,024 B |
|      StructLinq | .NET 6 | .NET 6.0 |     0 |  1000 |   717.585 ns |  6.3916 ns |  5.3373 ns |   718.042 ns |  0.98 |    0.01 | 1.9226 |     - |     - |   4,024 B |
|       Hyperlinq | .NET 6 | .NET 6.0 |     0 |  1000 |   282.289 ns |  5.6760 ns | 10.9358 ns |   280.526 ns |  0.39 |    0.01 | 1.9226 |     - |     - |   4,024 B |
