## List.Int32.ListInt32Sum

### Source
[ListInt32Sum.cs](../LinqBenchmarks/List/Int32/ListInt32Sum.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta42](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta42)

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
|              **ForLoop** |    **10** |    **12.520 ns** |  **0.0286 ns** |  **0.0254 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |    10 |    30.057 ns |  0.0892 ns |  0.0696 ns |  2.40 |    0.01 |      - |     - |     - |         - |
|                 Linq |    10 |    91.829 ns |  0.2391 ns |  0.2237 ns |  7.34 |    0.03 | 0.0191 |     - |     - |      40 B |
|           LinqFaster |    10 |     8.548 ns |  0.0263 ns |  0.0233 ns |  0.68 |    0.00 |      - |     - |     - |         - |
|               LinqAF |    10 |    69.464 ns |  0.4480 ns |  0.3971 ns |  5.55 |    0.03 |      - |     - |     - |         - |
|           StructLinq |    10 |    17.359 ns |  0.0595 ns |  0.0527 ns |  1.39 |    0.01 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |    10 |     6.502 ns |  0.0234 ns |  0.0195 ns |  0.52 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq |    10 |    16.024 ns |  0.0372 ns |  0.0348 ns |  1.28 |    0.00 |      - |     - |     - |         - |
|                      |       |              |            |            |       |         |        |       |       |           |
|              **ForLoop** |  **1000** | **1,295.517 ns** |  **1.8910 ns** |  **1.4764 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |  1000 | 2,843.214 ns |  7.3848 ns |  6.5464 ns |  2.19 |    0.01 |      - |     - |     - |         - |
|                 Linq |  1000 | 5,993.866 ns |  9.1752 ns |  7.6617 ns |  4.63 |    0.01 | 0.0153 |     - |     - |      40 B |
|           LinqFaster |  1000 |   778.232 ns |  1.1149 ns |  1.0428 ns |  0.60 |    0.00 |      - |     - |     - |         - |
|               LinqAF |  1000 | 4,444.085 ns | 22.1851 ns | 19.6665 ns |  3.43 |    0.02 |      - |     - |     - |         - |
|           StructLinq |  1000 |   676.071 ns |  2.0151 ns |  1.8849 ns |  0.52 |    0.00 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |  1000 |   550.803 ns |  3.2706 ns |  2.7311 ns |  0.43 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq |  1000 |    83.128 ns |  0.4508 ns |  0.3996 ns |  0.06 |    0.00 |      - |     - |     - |         - |
