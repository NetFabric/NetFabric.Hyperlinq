## Range.RangeToArray

### Source
[RangeToArray.cs](../LinqBenchmarks/Range/RangeToArray.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)

### Results:
``` ini

BenchmarkDotNet=v0.12.1.1527-nightly, OS=Windows 10.0.19043
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.3.21202.5
  [Host]   : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT
  .NET 5.0 : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT

Job=.NET 5.0  Runtime=.NET 5.0  

```
|                    Method | Start | Count |        Mean |     Error |     StdDev |       Median | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|-------------------------- |------ |------ |------------:|----------:|-----------:|-------------:|------:|--------:|-------:|------:|------:|----------:|
|        **ValueLinq_Standard** |     **0** |    **10** |    **82.81 ns** |  **0.626 ns** |   **0.555 ns** |    **82.965 ns** |  **5.76** |    **0.06** | **0.0305** |     **-** |     **-** |      **64 B** |
|           ValueLinq_Stack |     0 |    10 |    43.83 ns |  0.407 ns |   0.317 ns |    43.719 ns |  3.06 |    0.04 | 0.0306 |     - |     - |      64 B |
| ValueLinq_SharedPool_Push |     0 |    10 |   168.66 ns |  0.863 ns |   0.765 ns |   168.472 ns | 11.74 |    0.11 | 0.0305 |     - |     - |      64 B |
| ValueLinq_SharedPool_Pull |     0 |    10 |   181.90 ns |  0.947 ns |   0.886 ns |   181.682 ns | 12.66 |    0.12 | 0.0305 |     - |     - |      64 B |
|                   ForLoop |     0 |    10 |    14.37 ns |  0.122 ns |   0.108 ns |    14.386 ns |  1.00 |    0.00 | 0.0306 |     - |     - |      64 B |
|                      Linq |     0 |    10 |    27.39 ns |  0.622 ns |   1.703 ns |    26.278 ns |  2.03 |    0.06 | 0.0497 |     - |     - |     104 B |
|                LinqFaster |     0 |    10 |    10.27 ns |  0.313 ns |   0.922 ns |     9.603 ns |  0.72 |    0.07 | 0.0306 |     - |     - |      64 B |
|           LinqFaster_SIMD |     0 |    10 |    14.90 ns |  0.115 ns |   0.102 ns |    14.905 ns |  1.04 |    0.01 | 0.0306 |     - |     - |      64 B |
|                    LinqAF |     0 |    10 |    55.91 ns |  0.470 ns |   0.439 ns |    55.941 ns |  3.89 |    0.04 | 0.0306 |     - |     - |      64 B |
|                StructLinq |     0 |    10 |    13.66 ns |  0.130 ns |   0.115 ns |    13.659 ns |  0.95 |    0.01 | 0.0306 |     - |     - |      64 B |
|                 Hyperlinq |     0 |    10 |    17.42 ns |  0.421 ns |   1.138 ns |    16.732 ns |  1.26 |    0.07 | 0.0306 |     - |     - |      64 B |
|                           |       |       |             |           |            |              |       |         |        |       |       |           |
|        **ValueLinq_Standard** |     **0** |  **1000** | **2,013.01 ns** | **18.322 ns** |  **17.139 ns** | **2,007.661 ns** |  **1.56** |    **0.02** | **1.9226** |     **-** |     **-** |   **4,024 B** |
|           ValueLinq_Stack |     0 |  1000 | 2,737.26 ns | 57.381 ns | 169.189 ns | 2,814.312 ns |  2.19 |    0.10 | 3.9177 |     - |     - |   8,200 B |
| ValueLinq_SharedPool_Push |     0 |  1000 | 2,485.81 ns | 13.598 ns |  10.617 ns | 2,484.497 ns |  1.93 |    0.02 | 1.9226 |     - |     - |   4,024 B |
| ValueLinq_SharedPool_Pull |     0 |  1000 | 2,528.23 ns | 22.151 ns |  20.720 ns | 2,521.371 ns |  1.96 |    0.03 | 1.9226 |     - |     - |   4,024 B |
|                   ForLoop |     0 |  1000 | 1,286.97 ns | 16.183 ns |  15.137 ns | 1,284.494 ns |  1.00 |    0.00 | 1.9226 |     - |     - |   4,024 B |
|                      Linq |     0 |  1000 |   692.14 ns | 14.412 ns |  42.494 ns |   716.511 ns |  0.55 |    0.03 | 1.9417 |     - |     - |   4,064 B |
|                LinqFaster |     0 |  1000 |   661.10 ns | 11.432 ns |  10.693 ns |   661.427 ns |  0.51 |    0.01 | 1.9226 |     - |     - |   4,024 B |
|           LinqFaster_SIMD |     0 |  1000 |   296.36 ns |  4.431 ns |   4.145 ns |   298.115 ns |  0.23 |    0.00 | 1.9226 |     - |     - |   4,024 B |
|                    LinqAF |     0 |  1000 | 2,443.30 ns |  8.574 ns |   8.020 ns | 2,442.327 ns |  1.90 |    0.02 | 1.9226 |     - |     - |   4,024 B |
|                StructLinq |     0 |  1000 | 1,145.19 ns | 22.909 ns |  37.639 ns | 1,154.477 ns |  0.87 |    0.04 | 1.9226 |     - |     - |   4,024 B |
|                 Hyperlinq |     0 |  1000 |   301.43 ns |  5.776 ns |   6.180 ns |   302.644 ns |  0.23 |    0.01 | 1.9226 |     - |     - |   4,024 B |
