## List.Int32.ListInt32Sum

### Source
[ListInt32Sum.cs](../LinqBenchmarks/List/Int32/ListInt32Sum.cs)

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
|               Method | Count |         Mean |      Error |     StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |-------------:|-----------:|-----------:|------:|--------:|-------:|------:|------:|----------:|
|              **ForLoop** |    **10** |    **10.417 ns** |  **0.0266 ns** |  **0.0236 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |    10 |    30.600 ns |  0.0983 ns |  0.0920 ns |  2.94 |    0.01 |      - |     - |     - |         - |
|                 Linq |    10 |    95.236 ns |  0.3705 ns |  0.3094 ns |  9.14 |    0.04 | 0.0191 |     - |     - |      40 B |
|           LinqFaster |    10 |     8.573 ns |  0.0255 ns |  0.0226 ns |  0.82 |    0.00 |      - |     - |     - |         - |
|               LinqAF |    10 |    68.788 ns |  0.2171 ns |  0.1924 ns |  6.60 |    0.03 |      - |     - |     - |         - |
|           StructLinq |    10 |    19.445 ns |  0.0760 ns |  0.0674 ns |  1.87 |    0.01 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |    10 |     6.520 ns |  0.0194 ns |  0.0172 ns |  0.63 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq |    10 |    15.576 ns |  0.0541 ns |  0.0506 ns |  1.50 |    0.01 |      - |     - |     - |         - |
|                      |       |              |            |            |       |         |        |       |       |           |
|              **ForLoop** |  **1000** | **1,299.303 ns** |  **2.5413 ns** |  **2.1221 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |  1000 | 2,092.479 ns |  4.6654 ns |  3.8959 ns |  1.61 |    0.00 |      - |     - |     - |         - |
|                 Linq |  1000 | 6,278.092 ns | 17.4660 ns | 16.3377 ns |  4.83 |    0.02 | 0.0153 |     - |     - |      40 B |
|           LinqFaster |  1000 |   678.111 ns |  3.3924 ns |  3.1733 ns |  0.52 |    0.00 |      - |     - |     - |         - |
|               LinqAF |  1000 | 4,453.944 ns | 12.1071 ns | 10.7326 ns |  3.43 |    0.01 |      - |     - |     - |         - |
|           StructLinq |  1000 |   677.500 ns |  1.8256 ns |  1.6183 ns |  0.52 |    0.00 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |  1000 |   546.828 ns |  1.5710 ns |  1.3926 ns |  0.42 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq |  1000 |    85.046 ns |  0.2245 ns |  0.1875 ns |  0.07 |    0.00 |      - |     - |     - |         - |
