## List.Int32.ListInt32Sum

### Source
[ListInt32Sum.cs](../LinqBenchmarks/List/Int32/ListInt32Sum.cs)

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
|               Method | Count |         Mean |      Error |     StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |-------------:|-----------:|-----------:|------:|--------:|-------:|------:|------:|----------:|
|              **ForLoop** |    **10** |    **10.704 ns** |  **0.0609 ns** |  **0.0540 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |    10 |    31.884 ns |  0.1882 ns |  0.1668 ns |  2.98 |    0.02 |      - |     - |     - |         - |
|                 Linq |    10 |   100.299 ns |  1.2094 ns |  2.1809 ns |  9.39 |    0.32 | 0.0191 |     - |     - |      40 B |
|           LinqFaster |    10 |     8.813 ns |  0.0207 ns |  0.0173 ns |  0.82 |    0.00 |      - |     - |     - |         - |
|               LinqAF |    10 |    71.033 ns |  0.3783 ns |  0.3159 ns |  6.64 |    0.05 |      - |     - |     - |         - |
|           StructLinq |    10 |    18.964 ns |  0.1616 ns |  0.1512 ns |  1.77 |    0.02 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |    10 |     6.730 ns |  0.0313 ns |  0.0278 ns |  0.63 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq |    10 |    15.914 ns |  0.0727 ns |  0.0645 ns |  1.49 |    0.01 |      - |     - |     - |         - |
|                      |       |              |            |            |       |         |        |       |       |           |
|              **ForLoop** |  **1000** | **1,332.154 ns** |  **3.9718 ns** |  **3.3166 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |  1000 | 2,967.477 ns | 14.9472 ns | 12.4816 ns |  2.23 |    0.01 |      - |     - |     - |         - |
|                 Linq |  1000 | 6,525.312 ns | 50.1964 ns | 44.4978 ns |  4.90 |    0.03 | 0.0153 |     - |     - |      40 B |
|           LinqFaster |  1000 |   805.768 ns |  2.7357 ns |  2.5590 ns |  0.60 |    0.00 |      - |     - |     - |         - |
|               LinqAF |  1000 | 4,602.493 ns | 24.3369 ns | 19.0007 ns |  3.45 |    0.01 |      - |     - |     - |         - |
|           StructLinq |  1000 |   704.494 ns |  4.0268 ns |  3.5697 ns |  0.53 |    0.00 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |  1000 |   562.146 ns |  2.2483 ns |  1.9930 ns |  0.42 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq |  1000 |    85.494 ns |  0.4271 ns |  0.3786 ns |  0.06 |    0.00 |      - |     - |     - |         - |
