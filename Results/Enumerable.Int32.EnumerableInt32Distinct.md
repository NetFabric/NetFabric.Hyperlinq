## Enumerable.Int32.EnumerableInt32Distinct

### Source
[EnumerableInt32Distinct.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32Distinct.cs)

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
  .NET 6.0 : .NET 6.0.0 (6.0.21.20104), X64 RyuJIT


```
|               Method |      Job |  Runtime | Count |        Mean |     Error |      StdDev |      Median | Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |--------- |--------- |------ |------------:|----------:|------------:|------------:|------:|--------:|--------:|------:|------:|----------:|
|          **ForeachLoop** | **.NET 5.0** | **.NET 5.0** |    **10** |    **239.3 ns** |   **0.92 ns** |     **0.82 ns** |    **239.3 ns** |  **1.00** |    **0.00** |  **0.3405** |     **-** |     **-** |     **712 B** |
|                 Linq | .NET 5.0 | .NET 5.0 |    10 |    331.8 ns |   1.34 ns |     1.26 ns |    332.0 ns |  1.39 |    0.01 |  0.2942 |     - |     - |     616 B |
|               LinqAF | .NET 5.0 | .NET 5.0 |    10 |    447.6 ns |   8.84 ns |    18.64 ns |    434.7 ns |  1.86 |    0.07 |  0.2942 |     - |     - |     616 B |
|           StructLinq | .NET 5.0 | .NET 5.0 |    10 |    363.2 ns |   3.12 ns |     2.61 ns |    363.2 ns |  1.52 |    0.01 |  0.0305 |     - |     - |      64 B |
| StructLinq_IFunction | .NET 5.0 | .NET 5.0 |    10 |    356.3 ns |   1.39 ns |     1.24 ns |    356.0 ns |  1.49 |    0.01 |  0.0191 |     - |     - |      40 B |
|            Hyperlinq | .NET 5.0 | .NET 5.0 |    10 |    274.8 ns |   1.04 ns |     0.98 ns |    274.6 ns |  1.15 |    0.01 |  0.0191 |     - |     - |      40 B |
|                      |          |          |       |             |           |             |             |       |         |         |       |       |           |
|          ForeachLoop | .NET 6.0 | .NET 6.0 |    10 |    235.1 ns |   1.75 ns |     1.64 ns |    235.0 ns |  1.00 |    0.00 |  0.3366 |     - |     - |     704 B |
|                 Linq | .NET 6.0 | .NET 6.0 |    10 |    306.3 ns |   1.53 ns |     1.43 ns |    305.7 ns |  1.30 |    0.01 |  0.3171 |     - |     - |     664 B |
|               LinqAF | .NET 6.0 | .NET 6.0 |    10 |    435.5 ns |   3.15 ns |     2.79 ns |    434.9 ns |  1.85 |    0.02 |  0.2942 |     - |     - |     616 B |
|           StructLinq | .NET 6.0 | .NET 6.0 |    10 |    346.9 ns |   1.84 ns |     1.72 ns |    347.1 ns |  1.48 |    0.01 |  0.0305 |     - |     - |      64 B |
| StructLinq_IFunction | .NET 6.0 | .NET 6.0 |    10 |    358.3 ns |   2.17 ns |     1.69 ns |    357.7 ns |  1.52 |    0.01 |  0.0191 |     - |     - |      40 B |
|            Hyperlinq | .NET 6.0 | .NET 6.0 |    10 |    273.4 ns |   1.38 ns |     1.15 ns |    273.2 ns |  1.16 |    0.01 |  0.0191 |     - |     - |      40 B |
|                      |          |          |       |             |           |             |             |       |         |         |       |       |           |
|          **ForeachLoop** | **.NET 5.0** | **.NET 5.0** |  **1000** | **16,450.3 ns** |  **86.00 ns** |    **76.24 ns** | **16,453.6 ns** |  **1.00** |    **0.00** | **27.7710** |     **-** |     **-** |  **58,712 B** |
|                 Linq | .NET 5.0 | .NET 5.0 |  1000 | 24,602.5 ns |  60.30 ns |    47.08 ns | 24,617.6 ns |  1.50 |    0.01 | 15.7776 |     - |     - |  33,112 B |
|               LinqAF | .NET 5.0 | .NET 5.0 |  1000 | 33,254.7 ns | 662.79 ns | 1,160.82 ns | 33,777.6 ns |  1.95 |    0.09 | 19.5923 |     - |     - |  41,224 B |
|           StructLinq | .NET 5.0 | .NET 5.0 |  1000 | 18,654.1 ns | 118.73 ns |    99.14 ns | 18,632.7 ns |  1.13 |    0.01 |  0.0305 |     - |     - |      64 B |
| StructLinq_IFunction | .NET 5.0 | .NET 5.0 |  1000 | 18,480.3 ns | 282.26 ns |   250.21 ns | 18,521.2 ns |  1.12 |    0.02 |       - |     - |     - |      40 B |
|            Hyperlinq | .NET 5.0 | .NET 5.0 |  1000 | 16,069.1 ns |  62.94 ns |    55.79 ns | 16,067.6 ns |  0.98 |    0.00 |       - |     - |     - |      40 B |
|                      |          |          |       |             |           |             |             |       |         |         |       |       |           |
|          ForeachLoop | .NET 6.0 | .NET 6.0 |  1000 | 15,798.6 ns | 188.02 ns |   166.67 ns | 15,729.4 ns |  1.00 |    0.00 | 27.7710 |     - |     - |  58,704 B |
|                 Linq | .NET 6.0 | .NET 6.0 |  1000 | 20,929.8 ns | 287.17 ns |   239.80 ns | 20,841.3 ns |  1.32 |    0.01 | 27.7710 |     - |     - |  58,664 B |
|               LinqAF | .NET 6.0 | .NET 6.0 |  1000 | 35,711.8 ns | 289.64 ns |   270.93 ns | 35,686.7 ns |  2.26 |    0.04 | 19.5923 |     - |     - |  41,224 B |
|           StructLinq | .NET 6.0 | .NET 6.0 |  1000 | 17,799.8 ns |  65.63 ns |    61.39 ns | 17,794.2 ns |  1.13 |    0.01 |  0.0305 |     - |     - |      64 B |
| StructLinq_IFunction | .NET 6.0 | .NET 6.0 |  1000 | 17,326.5 ns |  60.52 ns |    53.65 ns | 17,342.1 ns |  1.10 |    0.01 |       - |     - |     - |      40 B |
|            Hyperlinq | .NET 6.0 | .NET 6.0 |  1000 | 16,048.0 ns | 109.97 ns |    97.49 ns | 16,028.4 ns |  1.02 |    0.01 |       - |     - |     - |      40 B |
