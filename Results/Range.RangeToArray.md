## Range.RangeToArray

### Source
[RangeToArray.cs](../LinqBenchmarks/Range/RangeToArray.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta41](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta41)

### Results:
``` ini

BenchmarkDotNet=v0.12.1.1516-nightly, OS=Windows 10.0.19042.844 (20H2/October2020Update)
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.1.21103.13
  [Host]   : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT
  .NET 5.0 : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT

Job=.NET 5.0  Runtime=.NET 5.0  

```
|                    Method | Start | Count |        Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|-------------------------- |------ |------ |------------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|        **ValueLinq_Standard** |     **0** |    **10** |    **76.22 ns** |  **0.365 ns** |  **0.323 ns** |  **5.00** |    **0.03** | **0.0304** |     **-** |     **-** |      **64 B** |
|           ValueLinq_Stack |     0 |    10 |    44.81 ns |  0.595 ns |  0.528 ns |  2.94 |    0.04 | 0.0306 |     - |     - |      64 B |
| ValueLinq_SharedPool_Push |     0 |    10 |   173.26 ns |  0.734 ns |  0.613 ns | 11.37 |    0.10 | 0.0305 |     - |     - |      64 B |
| ValueLinq_SharedPool_Pull |     0 |    10 |   172.12 ns |  0.933 ns |  0.827 ns | 11.30 |    0.11 | 0.0305 |     - |     - |      64 B |
|                   ForLoop |     0 |    10 |    15.23 ns |  0.110 ns |  0.097 ns |  1.00 |    0.00 | 0.0306 |     - |     - |      64 B |
|                      Linq |     0 |    10 |    27.66 ns |  0.182 ns |  0.142 ns |  1.82 |    0.01 | 0.0497 |     - |     - |     104 B |
|                LinqFaster |     0 |    10 |    11.02 ns |  0.102 ns |  0.091 ns |  0.72 |    0.01 | 0.0306 |     - |     - |      64 B |
|           LinqFaster_SIMD |     0 |    10 |    15.92 ns |  0.146 ns |  0.130 ns |  1.04 |    0.01 | 0.0306 |     - |     - |      64 B |
|                    LinqAF |     0 |    10 |    53.00 ns |  0.264 ns |  0.221 ns |  3.48 |    0.03 | 0.0305 |     - |     - |      64 B |
|                StructLinq |     0 |    10 |    14.74 ns |  0.120 ns |  0.100 ns |  0.97 |    0.01 | 0.0306 |     - |     - |      64 B |
|                 Hyperlinq |     0 |    10 |    17.49 ns |  0.077 ns |  0.068 ns |  1.15 |    0.01 | 0.0306 |     - |     - |      64 B |
|                           |       |       |             |           |           |       |         |        |       |       |           |
|        **ValueLinq_Standard** |     **0** |  **1000** | **1,901.08 ns** | **10.030 ns** |  **7.830 ns** |  **1.21** |    **0.03** | **1.9226** |     **-** |     **-** |   **4,024 B** |
|           ValueLinq_Stack |     0 |  1000 | 2,514.79 ns | 14.447 ns | 12.064 ns |  1.61 |    0.03 | 3.9177 |     - |     - |   8,200 B |
| ValueLinq_SharedPool_Push |     0 |  1000 | 2,585.32 ns | 11.859 ns | 10.513 ns |  1.65 |    0.03 | 1.9226 |     - |     - |   4,024 B |
| ValueLinq_SharedPool_Pull |     0 |  1000 | 2,348.25 ns |  8.954 ns |  6.990 ns |  1.50 |    0.03 | 1.9226 |     - |     - |   4,024 B |
|                   ForLoop |     0 |  1000 | 1,565.57 ns | 29.810 ns | 29.277 ns |  1.00 |    0.00 | 1.9226 |     - |     - |   4,024 B |
|                      Linq |     0 |  1000 |   715.68 ns |  7.971 ns |  7.456 ns |  0.46 |    0.01 | 1.9417 |     - |     - |   4,064 B |
|                LinqFaster |     0 |  1000 |   706.37 ns |  7.544 ns |  7.056 ns |  0.45 |    0.01 | 1.9226 |     - |     - |   4,024 B |
|           LinqFaster_SIMD |     0 |  1000 |   367.24 ns |  6.814 ns |  6.374 ns |  0.23 |    0.01 | 1.9226 |     - |     - |   4,024 B |
|                    LinqAF |     0 |  1000 | 2,531.60 ns | 12.393 ns | 10.986 ns |  1.62 |    0.03 | 1.9226 |     - |     - |   4,024 B |
|                StructLinq |     0 |  1000 | 1,095.07 ns |  8.668 ns |  7.684 ns |  0.70 |    0.01 | 1.9226 |     - |     - |   4,024 B |
|                 Hyperlinq |     0 |  1000 |   368.83 ns |  5.242 ns |  4.903 ns |  0.24 |    0.00 | 1.9226 |     - |     - |   4,024 B |
