## Enumerable.Int32.EnumerableInt32WhereCount

### Source
[EnumerableInt32WhereCount.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32WhereCount.cs)

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
|               Method |      Job |  Runtime | Count |        Mean |     Error |     StdDev |      Median | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |--------- |--------- |------ |------------:|----------:|-----------:|------------:|------:|--------:|-------:|------:|------:|----------:|
|          **ForeachLoop** | **.NET 5.0** | **.NET 5.0** |    **10** |    **62.31 ns** |  **0.520 ns** |   **0.461 ns** |    **62.39 ns** |  **1.00** |    **0.00** | **0.0191** |     **-** |     **-** |      **40 B** |
|                 Linq | .NET 5.0 | .NET 5.0 |    10 |    89.65 ns |  0.345 ns |   0.305 ns |    89.65 ns |  1.44 |    0.01 | 0.0191 |     - |     - |      40 B |
|               LinqAF | .NET 5.0 | .NET 5.0 |    10 |    97.92 ns |  0.346 ns |   0.307 ns |    97.97 ns |  1.57 |    0.01 | 0.0191 |     - |     - |      40 B |
|           StructLinq | .NET 5.0 | .NET 5.0 |    10 |   120.17 ns |  2.407 ns |   3.818 ns |   117.93 ns |  1.99 |    0.04 | 0.0459 |     - |     - |      96 B |
| StructLinq_IFunction | .NET 5.0 | .NET 5.0 |    10 |    71.14 ns |  0.285 ns |   0.252 ns |    71.18 ns |  1.14 |    0.01 | 0.0191 |     - |     - |      40 B |
|            Hyperlinq | .NET 5.0 | .NET 5.0 |    10 |    84.24 ns |  0.675 ns |   0.563 ns |    84.06 ns |  1.35 |    0.01 | 0.0191 |     - |     - |      40 B |
|  Hyperlinq_IFunction | .NET 5.0 | .NET 5.0 |    10 |    62.96 ns |  0.320 ns |   0.284 ns |    62.97 ns |  1.01 |    0.01 | 0.0191 |     - |     - |      40 B |
|                      |          |          |       |             |           |            |             |       |         |        |       |       |           |
|          ForeachLoop | .NET 6.0 | .NET 6.0 |    10 |    55.56 ns |  0.346 ns |   0.306 ns |    55.57 ns |  1.00 |    0.00 | 0.0191 |     - |     - |      40 B |
|                 Linq | .NET 6.0 | .NET 6.0 |    10 |    85.30 ns |  0.287 ns |   0.254 ns |    85.26 ns |  1.54 |    0.01 | 0.0191 |     - |     - |      40 B |
|               LinqAF | .NET 6.0 | .NET 6.0 |    10 |    96.47 ns |  1.476 ns |   1.381 ns |    95.82 ns |  1.73 |    0.03 | 0.0191 |     - |     - |      40 B |
|           StructLinq | .NET 6.0 | .NET 6.0 |    10 |   120.11 ns |  0.540 ns |   0.478 ns |   120.02 ns |  2.16 |    0.02 | 0.0458 |     - |     - |      96 B |
| StructLinq_IFunction | .NET 6.0 | .NET 6.0 |    10 |    66.06 ns |  0.251 ns |   0.235 ns |    66.12 ns |  1.19 |    0.01 | 0.0191 |     - |     - |      40 B |
|            Hyperlinq | .NET 6.0 | .NET 6.0 |    10 |    83.09 ns |  1.559 ns |   1.382 ns |    82.49 ns |  1.50 |    0.03 | 0.0191 |     - |     - |      40 B |
|  Hyperlinq_IFunction | .NET 6.0 | .NET 6.0 |    10 |    60.37 ns |  0.594 ns |   0.527 ns |    60.25 ns |  1.09 |    0.01 | 0.0191 |     - |     - |      40 B |
|                      |          |          |       |             |           |            |             |       |         |        |       |       |           |
|          **ForeachLoop** | **.NET 5.0** | **.NET 5.0** |  **1000** | **4,570.98 ns** | **15.424 ns** |  **13.673 ns** | **4,569.88 ns** |  **1.00** |    **0.00** | **0.0153** |     **-** |     **-** |      **40 B** |
|                 Linq | .NET 5.0 | .NET 5.0 |  1000 | 6,540.03 ns | 27.012 ns |  23.946 ns | 6,537.40 ns |  1.43 |    0.01 | 0.0153 |     - |     - |      40 B |
|               LinqAF | .NET 5.0 | .NET 5.0 |  1000 | 6,077.10 ns | 17.812 ns |  14.874 ns | 6,083.25 ns |  1.33 |    0.01 | 0.0153 |     - |     - |      40 B |
|           StructLinq | .NET 5.0 | .NET 5.0 |  1000 | 6,237.11 ns | 21.887 ns |  19.402 ns | 6,228.19 ns |  1.36 |    0.01 | 0.0458 |     - |     - |      96 B |
| StructLinq_IFunction | .NET 5.0 | .NET 5.0 |  1000 | 4,657.57 ns | 18.871 ns |  17.652 ns | 4,662.84 ns |  1.02 |    0.00 | 0.0153 |     - |     - |      40 B |
|            Hyperlinq | .NET 5.0 | .NET 5.0 |  1000 | 5,517.46 ns | 17.024 ns |  14.216 ns | 5,516.34 ns |  1.21 |    0.00 | 0.0153 |     - |     - |      40 B |
|  Hyperlinq_IFunction | .NET 5.0 | .NET 5.0 |  1000 | 4,569.99 ns | 84.879 ns | 191.587 ns | 4,504.02 ns |  1.04 |    0.07 | 0.0153 |     - |     - |      40 B |
|                      |          |          |       |             |           |            |             |       |         |        |       |       |           |
|          ForeachLoop | .NET 6.0 | .NET 6.0 |  1000 | 4,534.70 ns | 24.901 ns |  22.074 ns | 4,535.33 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      40 B |
|                 Linq | .NET 6.0 | .NET 6.0 |  1000 | 9,439.91 ns | 39.709 ns |  35.201 ns | 9,432.72 ns |  2.08 |    0.01 | 0.0153 |     - |     - |      40 B |
|               LinqAF | .NET 6.0 | .NET 6.0 |  1000 | 6,427.13 ns | 39.624 ns |  35.126 ns | 6,422.66 ns |  1.42 |    0.01 | 0.0153 |     - |     - |      40 B |
|           StructLinq | .NET 6.0 | .NET 6.0 |  1000 | 5,769.19 ns | 22.684 ns |  20.108 ns | 5,771.22 ns |  1.27 |    0.01 | 0.0458 |     - |     - |      96 B |
| StructLinq_IFunction | .NET 6.0 | .NET 6.0 |  1000 | 4,943.84 ns | 18.541 ns |  16.436 ns | 4,944.17 ns |  1.09 |    0.01 | 0.0153 |     - |     - |      40 B |
|            Hyperlinq | .NET 6.0 | .NET 6.0 |  1000 | 5,788.73 ns | 23.790 ns |  21.089 ns | 5,784.64 ns |  1.28 |    0.01 | 0.0153 |     - |     - |      40 B |
|  Hyperlinq_IFunction | .NET 6.0 | .NET 6.0 |  1000 | 4,791.92 ns | 27.071 ns |  22.605 ns | 4,787.37 ns |  1.06 |    0.01 | 0.0153 |     - |     - |      40 B |
