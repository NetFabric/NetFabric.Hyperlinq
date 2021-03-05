## Array.ValueType.ArrayValueTypeWhereCount

### Source
[ArrayValueTypeWhereCount.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhereCount.cs)

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
|               Method | Count |          Mean |      Error |     StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |--------------:|-----------:|-----------:|------:|--------:|-------:|------:|------:|----------:|
|              **ForLoop** |    **10** |      **7.615 ns** |  **0.0170 ns** |  **0.0151 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |    10 |     14.081 ns |  0.0407 ns |  0.0361 ns |  1.85 |    0.01 |      - |     - |     - |         - |
|                 Linq |    10 |     79.709 ns |  0.1747 ns |  0.1635 ns | 10.47 |    0.03 | 0.0153 |     - |     - |      32 B |
|           LinqFaster |    10 |     27.933 ns |  0.0423 ns |  0.0375 ns |  3.67 |    0.01 |      - |     - |     - |         - |
|               LinqAF |    10 |     81.940 ns |  1.5581 ns |  1.8549 ns | 10.79 |    0.27 |      - |     - |     - |         - |
|           StructLinq |    10 |     48.992 ns |  0.1258 ns |  0.1115 ns |  6.43 |    0.01 | 0.0306 |     - |     - |      64 B |
| StructLinq_IFunction |    10 |     40.082 ns |  0.0489 ns |  0.0434 ns |  5.26 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq |    10 |     61.991 ns |  0.1559 ns |  0.1382 ns |  8.14 |    0.03 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |    10 |     47.851 ns |  0.0659 ns |  0.0616 ns |  6.28 |    0.01 |      - |     - |     - |         - |
|                      |       |               |            |            |       |         |        |       |       |           |
|              **ForLoop** |  **1000** |    **821.607 ns** |  **2.6486 ns** |  **2.3479 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |  1000 |  2,036.324 ns |  7.1304 ns |  5.9542 ns |  2.48 |    0.01 |      - |     - |     - |         - |
|                 Linq |  1000 | 11,943.333 ns | 41.3671 ns | 34.5434 ns | 14.53 |    0.06 | 0.0153 |     - |     - |      32 B |
|           LinqFaster |  1000 |  4,013.960 ns | 25.5533 ns | 22.6523 ns |  4.89 |    0.03 |      - |     - |     - |         - |
|               LinqAF |  1000 | 11,163.956 ns | 92.4588 ns | 86.4860 ns | 13.60 |    0.11 |      - |     - |     - |         - |
|           StructLinq |  1000 |  4,707.219 ns | 22.2098 ns | 19.6884 ns |  5.73 |    0.03 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction |  1000 |  1,890.769 ns |  7.8072 ns |  6.9209 ns |  2.30 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq |  1000 |  4,754.391 ns | 11.0381 ns |  9.7849 ns |  5.79 |    0.02 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |  1000 |  3,452.510 ns |  7.2120 ns |  6.3933 ns |  4.20 |    0.01 |      - |     - |     - |         - |
