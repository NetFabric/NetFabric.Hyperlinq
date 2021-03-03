## Array.Int32.ArrayInt32WhereSelect

### Source
[ArrayInt32WhereSelect.cs](../LinqBenchmarks/Array/Int32/ArrayInt32WhereSelect.cs)

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
|              **ForLoop** |    **10** |     **7.614 ns** |  **0.0247 ns** |  **0.0207 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |    10 |     6.810 ns |  0.0413 ns |  0.0386 ns |  0.89 |    0.01 |      - |     - |     - |         - |
|                 Linq |    10 |    86.445 ns |  0.5668 ns |  0.5301 ns | 11.36 |    0.07 | 0.0497 |     - |     - |     104 B |
|           LinqFaster |    10 |    45.383 ns |  0.1658 ns |  0.1385 ns |  5.96 |    0.03 | 0.0459 |     - |     - |      96 B |
|               LinqAF |    10 |    61.497 ns |  0.1642 ns |  0.1536 ns |  8.08 |    0.02 |      - |     - |     - |         - |
|           StructLinq |    10 |    57.004 ns |  0.1592 ns |  0.1489 ns |  7.49 |    0.03 | 0.0306 |     - |     - |      64 B |
| StructLinq_IFunction |    10 |    50.238 ns |  0.0677 ns |  0.0633 ns |  6.60 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq |    10 |    50.400 ns |  0.0993 ns |  0.0880 ns |  6.62 |    0.02 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |    10 |    47.879 ns |  0.0829 ns |  0.0692 ns |  6.29 |    0.02 |      - |     - |     - |         - |
|                      |       |              |            |            |       |         |        |       |       |           |
|              **ForLoop** |  **1000** | **1,089.396 ns** |  **5.1453 ns** |  **4.5612 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |  1000 | 1,080.317 ns | 10.3327 ns |  9.1597 ns |  0.99 |    0.01 |      - |     - |     - |         - |
|                 Linq |  1000 | 7,908.545 ns | 13.6868 ns | 12.8026 ns |  7.26 |    0.03 | 0.0458 |     - |     - |     104 B |
|           LinqFaster |  1000 | 5,099.771 ns | 18.1240 ns | 16.9532 ns |  4.68 |    0.02 | 2.8915 |     - |     - |   6,064 B |
|               LinqAF |  1000 | 6,996.038 ns | 12.3333 ns | 10.9332 ns |  6.42 |    0.03 |      - |     - |     - |         - |
|           StructLinq |  1000 | 5,226.083 ns | 16.5533 ns | 14.6740 ns |  4.80 |    0.03 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction |  1000 | 1,510.768 ns |  7.0488 ns |  6.5935 ns |  1.39 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq |  1000 | 5,265.267 ns | 18.7479 ns | 16.6196 ns |  4.83 |    0.02 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |  1000 | 1,915.721 ns |  5.7108 ns |  5.0625 ns |  1.76 |    0.01 |      - |     - |     - |         - |
