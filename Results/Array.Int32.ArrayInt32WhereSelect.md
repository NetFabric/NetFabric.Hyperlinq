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

BenchmarkDotNet=v0.12.1.1517-nightly, OS=Windows 10.0.19043
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.1.21103.13
  [Host]   : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT
  .NET 5.0 : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT

Job=.NET 5.0  Runtime=.NET 5.0  

```
|               Method | Count |         Mean |      Error |     StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |-------------:|-----------:|-----------:|------:|--------:|-------:|------:|------:|----------:|
|              **ForLoop** |    **10** |     **7.599 ns** |  **0.0240 ns** |  **0.0212 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |    10 |     7.602 ns |  0.0275 ns |  0.0244 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|                 Linq |    10 |    85.558 ns |  0.3232 ns |  0.2865 ns | 11.26 |    0.05 | 0.0497 |     - |     - |     104 B |
|           LinqFaster |    10 |    48.100 ns |  0.2423 ns |  0.2266 ns |  6.33 |    0.03 | 0.0459 |     - |     - |      96 B |
|               LinqAF |    10 |    63.072 ns |  0.1734 ns |  0.1537 ns |  8.30 |    0.04 |      - |     - |     - |         - |
|           StructLinq |    10 |    57.266 ns |  0.1812 ns |  0.1607 ns |  7.54 |    0.02 | 0.0306 |     - |     - |      64 B |
| StructLinq_IFunction |    10 |    51.025 ns |  0.1160 ns |  0.1028 ns |  6.71 |    0.03 |      - |     - |     - |         - |
|            Hyperlinq |    10 |    50.960 ns |  0.0807 ns |  0.0715 ns |  6.71 |    0.02 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |    10 |    46.909 ns |  0.0638 ns |  0.0566 ns |  6.17 |    0.02 |      - |     - |     - |         - |
|                      |       |              |            |            |       |         |        |       |       |           |
|              **ForLoop** |  **1000** |   **787.412 ns** |  **3.1779 ns** |  **2.8171 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |  1000 |   783.391 ns |  2.5157 ns |  2.1007 ns |  0.99 |    0.00 |      - |     - |     - |         - |
|                 Linq |  1000 | 7,939.371 ns | 15.2954 ns | 13.5590 ns | 10.08 |    0.04 | 0.0458 |     - |     - |     104 B |
|           LinqFaster |  1000 | 4,701.213 ns | 25.3626 ns | 22.4833 ns |  5.97 |    0.04 | 2.8915 |     - |     - |   6,064 B |
|               LinqAF |  1000 | 6,337.602 ns | 16.0775 ns | 15.0389 ns |  8.05 |    0.04 |      - |     - |     - |         - |
|           StructLinq |  1000 | 5,387.498 ns | 20.0313 ns | 18.7373 ns |  6.84 |    0.03 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction |  1000 | 1,567.827 ns |  8.5153 ns |  7.1106 ns |  1.99 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq |  1000 | 5,264.606 ns | 16.3104 ns | 15.2568 ns |  6.69 |    0.03 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |  1000 | 1,978.286 ns | 18.8380 ns | 15.7306 ns |  2.51 |    0.02 |      - |     - |     - |         - |
