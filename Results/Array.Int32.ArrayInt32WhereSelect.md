## Array.Int32.ArrayInt32WhereSelect

### Source
[ArrayInt32WhereSelect.cs](../LinqBenchmarks/Array/Int32/ArrayInt32WhereSelect.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta39](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta39)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=6.0.100-preview.1.21103.13
  [Host]        : .NET Core 5.0.3 (CoreCLR 5.0.321.7212, CoreFX 5.0.321.7212), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.3 (CoreCLR 5.0.321.7212, CoreFX 5.0.321.7212), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|               Method | Count |         Mean |      Error |     StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |-------------:|-----------:|-----------:|------:|--------:|-------:|------:|------:|----------:|
|              **ForLoop** |    **10** |     **7.426 ns** |  **0.0200 ns** |  **0.0177 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |    10 |     6.659 ns |  0.0534 ns |  0.0473 ns |  0.90 |    0.01 |      - |     - |     - |         - |
|                 Linq |    10 |    90.875 ns |  0.5447 ns |  0.5095 ns | 12.24 |    0.07 | 0.0497 |     - |     - |     104 B |
|           LinqFaster |    10 |    39.961 ns |  0.1561 ns |  0.1384 ns |  5.38 |    0.02 | 0.0459 |     - |     - |      96 B |
|               LinqAF |    10 |    61.139 ns |  0.2502 ns |  0.2218 ns |  8.23 |    0.03 |      - |     - |     - |         - |
|           StructLinq |    10 |    55.925 ns |  0.1695 ns |  0.1415 ns |  7.53 |    0.02 | 0.0306 |     - |     - |      64 B |
| StructLinq_IFunction |    10 |    51.743 ns |  0.1624 ns |  0.1356 ns |  6.97 |    0.03 |      - |     - |     - |         - |
|            Hyperlinq |    10 |    44.944 ns |  0.0883 ns |  0.0783 ns |  6.05 |    0.02 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |    10 |    40.720 ns |  0.0954 ns |  0.0845 ns |  5.48 |    0.01 |      - |     - |     - |         - |
|                      |       |              |            |            |       |         |        |       |       |           |
|              **ForLoop** |  **1000** |   **789.647 ns** | **15.1717 ns** | **16.8633 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |  1000 |   788.290 ns | 12.8822 ns | 17.1973 ns |  1.00 |    0.03 |      - |     - |     - |         - |
|                 Linq |  1000 | 7,563.607 ns | 17.5150 ns | 15.5266 ns |  9.57 |    0.22 | 0.0458 |     - |     - |     104 B |
|           LinqFaster |  1000 | 4,743.697 ns | 20.3610 ns | 18.0495 ns |  6.00 |    0.15 | 2.8915 |     - |     - |    6064 B |
|               LinqAF |  1000 | 6,606.447 ns | 15.2537 ns | 13.5220 ns |  8.36 |    0.19 |      - |     - |     - |         - |
|           StructLinq |  1000 | 5,319.786 ns | 33.6517 ns | 29.8314 ns |  6.73 |    0.16 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction |  1000 | 1,502.173 ns |  4.8098 ns |  4.0164 ns |  1.90 |    0.05 |      - |     - |     - |         - |
|            Hyperlinq |  1000 | 5,074.877 ns | 14.8048 ns | 13.8484 ns |  6.42 |    0.13 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |  1000 | 1,883.967 ns |  6.2801 ns |  5.2442 ns |  2.38 |    0.06 |      - |     - |     - |         - |
