## Array.Int32.ArrayInt32WhereSelect

### Source
[ArrayInt32WhereSelect.cs](../LinqBenchmarks/Array/Int32/ArrayInt32WhereSelect.cs)

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
|               Method | Count |         Mean |      Error |     StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |-------------:|-----------:|-----------:|------:|--------:|-------:|------:|------:|----------:|
|              **ForLoop** |    **10** |     **6.860 ns** |  **0.0213 ns** |  **0.0178 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |    10 |     6.630 ns |  0.0306 ns |  0.0271 ns |  0.97 |    0.00 |      - |     - |     - |         - |
|                 Linq |    10 |    99.535 ns |  0.5956 ns |  0.5280 ns | 14.51 |    0.10 | 0.0497 |     - |     - |     104 B |
|           LinqFaster |    10 |    44.568 ns |  0.3584 ns |  0.3352 ns |  6.51 |    0.05 | 0.0459 |     - |     - |      96 B |
|               LinqAF |    10 |    61.790 ns |  0.3453 ns |  0.3061 ns |  9.01 |    0.04 |      - |     - |     - |         - |
|           StructLinq |    10 |    59.780 ns |  0.7821 ns |  0.6933 ns |  8.72 |    0.10 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction |    10 |    52.650 ns |  0.2195 ns |  0.2053 ns |  7.68 |    0.04 |      - |     - |     - |         - |
|            Hyperlinq |    10 |    53.178 ns |  0.1731 ns |  0.1535 ns |  7.75 |    0.03 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |    10 |    51.187 ns |  0.2518 ns |  0.2355 ns |  7.46 |    0.03 |      - |     - |     - |         - |
|                      |       |              |            |            |       |         |        |       |       |           |
|              **ForLoop** |  **1000** |   **641.771 ns** | **12.1665 ns** | **11.9491 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |  1000 |   640.593 ns | 12.2812 ns | 13.1407 ns |  1.00 |    0.03 |      - |     - |     - |         - |
|                 Linq |  1000 | 8,661.507 ns | 50.3201 ns | 42.0195 ns | 13.52 |    0.27 | 0.0458 |     - |     - |     104 B |
|           LinqFaster |  1000 | 4,758.854 ns | 22.0975 ns | 19.5889 ns |  7.41 |    0.13 | 2.8915 |     - |     - |   6,064 B |
|               LinqAF |  1000 | 6,566.278 ns | 34.0188 ns | 30.1568 ns | 10.23 |    0.20 |      - |     - |     - |         - |
|           StructLinq |  1000 | 5,446.863 ns | 45.7548 ns | 42.7991 ns |  8.49 |    0.18 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction |  1000 | 1,632.764 ns | 24.5421 ns | 22.9567 ns |  2.55 |    0.06 |      - |     - |     - |         - |
|            Hyperlinq |  1000 | 5,240.289 ns | 23.8070 ns | 19.8799 ns |  8.18 |    0.16 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |  1000 | 2,205.353 ns | 42.6834 ns | 43.8327 ns |  3.44 |    0.10 |      - |     - |     - |         - |
