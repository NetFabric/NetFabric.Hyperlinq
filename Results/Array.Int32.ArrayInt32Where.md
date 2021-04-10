## Array.Int32.ArrayInt32Where

### Source
[ArrayInt32Where.cs](../LinqBenchmarks/Array/Int32/ArrayInt32Where.cs)

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
|              **ForLoop** |    **10** |     **7.059 ns** |  **0.0416 ns** |  **0.0347 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |    10 |     7.102 ns |  0.0343 ns |  0.0321 ns |  1.01 |    0.01 |      - |     - |     - |         - |
|                 Linq |    10 |    62.072 ns |  0.2905 ns |  0.2426 ns |  8.79 |    0.06 | 0.0229 |     - |     - |      48 B |
|           LinqFaster |    10 |    40.164 ns |  0.4240 ns |  0.3966 ns |  5.68 |    0.04 | 0.0459 |     - |     - |      96 B |
|               LinqAF |    10 |    51.355 ns |  0.2492 ns |  0.2209 ns |  7.28 |    0.05 |      - |     - |     - |         - |
|           StructLinq |    10 |    44.837 ns |  0.9126 ns |  1.0863 ns |  6.30 |    0.18 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |    10 |    36.837 ns |  0.1243 ns |  0.1038 ns |  5.22 |    0.03 |      - |     - |     - |         - |
|            Hyperlinq |    10 |    45.948 ns |  0.4293 ns |  0.3806 ns |  6.50 |    0.06 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |    10 |    41.191 ns |  0.2717 ns |  0.2409 ns |  5.84 |    0.04 |      - |     - |     - |         - |
|                      |       |              |            |            |       |         |        |       |       |           |
|              **ForLoop** |  **1000** |   **658.977 ns** | **12.6094 ns** | **15.4855 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |  1000 |   840.314 ns | 15.4260 ns | 14.4294 ns |  1.27 |    0.03 |      - |     - |     - |         - |
|                 Linq |  1000 | 6,315.431 ns | 66.9944 ns | 62.6666 ns |  9.55 |    0.26 | 0.0229 |     - |     - |      48 B |
|           LinqFaster |  1000 | 3,929.691 ns | 29.5182 ns | 36.2511 ns |  5.97 |    0.14 | 2.8915 |     - |     - |   6,064 B |
|               LinqAF |  1000 | 6,388.699 ns | 29.5143 ns | 26.1637 ns |  9.63 |    0.22 |      - |     - |     - |         - |
|           StructLinq |  1000 | 5,520.027 ns | 26.9521 ns | 22.5062 ns |  8.30 |    0.20 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |  1000 | 1,883.245 ns | 20.8810 ns | 19.5321 ns |  2.85 |    0.07 |      - |     - |     - |         - |
|            Hyperlinq |  1000 | 5,047.903 ns | 35.4484 ns | 33.1584 ns |  7.63 |    0.23 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |  1000 | 2,134.115 ns | 18.2699 ns | 16.1957 ns |  3.22 |    0.08 |      - |     - |     - |         - |
