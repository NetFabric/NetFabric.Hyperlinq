## Array.Int32.ArrayInt32WhereCount

### Source
[ArrayInt32WhereCount.cs](../LinqBenchmarks/Array/Int32/ArrayInt32WhereCount.cs)

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
|              **ForLoop** |    **10** |     **6.364 ns** |  **0.0439 ns** |  **0.0366 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |    10 |     6.432 ns |  0.0396 ns |  0.0351 ns |  1.01 |    0.01 |      - |     - |     - |         - |
|                 Linq |    10 |    70.886 ns |  0.4747 ns |  0.4208 ns | 11.13 |    0.07 | 0.0153 |     - |     - |      32 B |
|           LinqFaster |    10 |    23.989 ns |  0.1423 ns |  0.1262 ns |  3.77 |    0.03 |      - |     - |     - |         - |
|               LinqAF |    10 |    36.854 ns |  0.2195 ns |  0.2053 ns |  5.79 |    0.05 |      - |     - |     - |         - |
|           StructLinq |    10 |    57.689 ns |  0.2688 ns |  0.2383 ns |  9.06 |    0.06 | 0.0306 |     - |     - |      64 B |
| StructLinq_IFunction |    10 |    25.227 ns |  0.0605 ns |  0.0505 ns |  3.96 |    0.02 |      - |     - |     - |         - |
|            Hyperlinq |    10 |    31.450 ns |  0.1820 ns |  0.1702 ns |  4.94 |    0.03 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |    10 |    26.771 ns |  0.2579 ns |  0.2412 ns |  4.22 |    0.05 |      - |     - |     - |         - |
|                      |       |              |            |            |       |         |        |       |       |           |
|              **ForLoop** |  **1000** |   **635.512 ns** | **10.9426 ns** | **10.2357 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |  1000 |   652.214 ns | 11.9517 ns | 10.5948 ns |  1.03 |    0.02 |      - |     - |     - |         - |
|                 Linq |  1000 | 9,094.877 ns | 53.9266 ns | 50.4430 ns | 14.31 |    0.23 | 0.0153 |     - |     - |      32 B |
|           LinqFaster |  1000 | 3,163.690 ns | 31.8817 ns | 29.8221 ns |  4.98 |    0.09 |      - |     - |     - |         - |
|               LinqAF |  1000 | 3,793.765 ns | 52.4085 ns | 49.0229 ns |  5.97 |    0.13 |      - |     - |     - |         - |
|           StructLinq |  1000 | 3,303.485 ns | 24.2594 ns | 21.5053 ns |  5.20 |    0.09 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction |  1000 |   839.595 ns | 10.8170 ns |  9.5890 ns |  1.32 |    0.03 |      - |     - |     - |         - |
|            Hyperlinq |  1000 | 1,877.764 ns |  5.7296 ns |  5.3595 ns |  2.96 |    0.05 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |  1000 |   707.539 ns |  2.1159 ns |  1.8757 ns |  1.11 |    0.02 |      - |     - |     - |         - |
