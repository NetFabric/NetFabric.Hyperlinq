## Array.Int32.ArrayInt32WhereCount

### Source
[ArrayInt32WhereCount.cs](../LinqBenchmarks/Array/Int32/ArrayInt32WhereCount.cs)

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
|              **ForLoop** |    **10** |     **7.098 ns** |  **0.0486 ns** |  **0.0455 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |    10 |     7.799 ns |  0.0403 ns |  0.0377 ns |  1.10 |    0.01 |      - |     - |     - |         - |
|                 Linq |    10 |    73.119 ns |  0.4049 ns |  0.3381 ns | 10.31 |    0.07 | 0.0153 |     - |     - |      32 B |
|           LinqFaster |    10 |    25.176 ns |  0.0920 ns |  0.0768 ns |  3.55 |    0.03 |      - |     - |     - |         - |
|               LinqAF |    10 |    37.712 ns |  0.2347 ns |  0.1960 ns |  5.32 |    0.06 |      - |     - |     - |         - |
|           StructLinq |    10 |    54.011 ns |  0.4545 ns |  0.4251 ns |  7.61 |    0.06 | 0.0306 |     - |     - |      64 B |
| StructLinq_IFunction |    10 |    22.899 ns |  0.1174 ns |  0.1098 ns |  3.23 |    0.02 |      - |     - |     - |         - |
|            Hyperlinq |    10 |    30.289 ns |  0.3686 ns |  0.3078 ns |  4.27 |    0.04 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |    10 |    22.057 ns |  0.0918 ns |  0.0814 ns |  3.11 |    0.02 |      - |     - |     - |         - |
|                      |       |              |            |            |       |         |        |       |       |           |
|              **ForLoop** |  **1000** |   **826.374 ns** |  **7.3396 ns** |  **6.8654 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |  1000 |   828.928 ns |  8.3521 ns |  7.8126 ns |  1.00 |    0.01 |      - |     - |     - |         - |
|                 Linq |  1000 | 9,049.028 ns | 59.9201 ns | 50.0360 ns | 10.96 |    0.10 | 0.0153 |     - |     - |      32 B |
|           LinqFaster |  1000 | 3,259.996 ns | 31.0957 ns | 29.0870 ns |  3.95 |    0.05 |      - |     - |     - |         - |
|               LinqAF |  1000 | 3,827.091 ns | 35.6080 ns | 29.7343 ns |  4.64 |    0.05 |      - |     - |     - |         - |
|           StructLinq |  1000 | 3,348.398 ns | 19.9298 ns | 18.6423 ns |  4.05 |    0.04 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction |  1000 |   730.792 ns |  5.3592 ns |  5.0130 ns |  0.88 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq |  1000 | 1,882.360 ns | 10.7730 ns |  9.5499 ns |  2.28 |    0.02 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |  1000 |   691.667 ns | 10.2104 ns | 10.0280 ns |  0.84 |    0.01 |      - |     - |     - |         - |
