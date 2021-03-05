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

BenchmarkDotNet=v0.12.1.1517-nightly, OS=Windows 10.0.19043
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.1.21103.13
  [Host]   : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT
  .NET 5.0 : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT

Job=.NET 5.0  Runtime=.NET 5.0  

```
|               Method | Count |        Mean |      Error |     StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |------------:|-----------:|-----------:|------:|--------:|-------:|------:|------:|----------:|
|          **ForeachLoop** |    **10** |    **61.09 ns** |   **0.301 ns** |   **0.266 ns** |  **1.00** |    **0.00** | **0.0191** |     **-** |     **-** |      **40 B** |
|                 Linq |    10 |    85.82 ns |   0.322 ns |   0.285 ns |  1.40 |    0.01 | 0.0191 |     - |     - |      40 B |
|               LinqAF |    10 |    99.39 ns |   0.313 ns |   0.293 ns |  1.63 |    0.01 | 0.0191 |     - |     - |      40 B |
|           StructLinq |    10 |   117.83 ns |   2.327 ns |   2.177 ns |  1.93 |    0.04 | 0.0459 |     - |     - |      96 B |
| StructLinq_IFunction |    10 |    71.02 ns |   0.350 ns |   0.292 ns |  1.16 |    0.01 | 0.0191 |     - |     - |      40 B |
|            Hyperlinq |    10 |    89.10 ns |   0.257 ns |   0.215 ns |  1.46 |    0.01 | 0.0191 |     - |     - |      40 B |
|  Hyperlinq_IFunction |    10 |    61.20 ns |   0.248 ns |   0.220 ns |  1.00 |    0.01 | 0.0191 |     - |     - |      40 B |
|                      |       |             |            |            |       |         |        |       |       |           |
|          **ForeachLoop** |  **1000** | **4,500.94 ns** |  **15.551 ns** |  **13.786 ns** |  **1.00** |    **0.00** | **0.0153** |     **-** |     **-** |      **40 B** |
|                 Linq |  1000 | 6,078.10 ns | 110.589 ns | 196.572 ns |  1.37 |    0.07 | 0.0153 |     - |     - |      40 B |
|               LinqAF |  1000 | 6,523.20 ns |  19.380 ns |  17.180 ns |  1.45 |    0.01 | 0.0153 |     - |     - |      40 B |
|           StructLinq |  1000 | 6,111.49 ns |  23.146 ns |  19.328 ns |  1.36 |    0.00 | 0.0458 |     - |     - |      96 B |
| StructLinq_IFunction |  1000 | 4,641.35 ns |  17.602 ns |  16.465 ns |  1.03 |    0.00 | 0.0153 |     - |     - |      40 B |
|            Hyperlinq |  1000 | 5,999.32 ns |  21.903 ns |  19.417 ns |  1.33 |    0.01 | 0.0153 |     - |     - |      40 B |
|  Hyperlinq_IFunction |  1000 | 4,446.07 ns |  10.100 ns |   8.953 ns |  0.99 |    0.00 | 0.0153 |     - |     - |      40 B |
