## Array.Int32.ArrayInt32WhereCount

### Source
[ArrayInt32WhereCount.cs](../LinqBenchmarks/Array/Int32/ArrayInt32WhereCount.cs)

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
|              **ForLoop** |    **10** |     **6.851 ns** |  **0.0425 ns** |  **0.0377 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |    10 |     6.807 ns |  0.0360 ns |  0.0301 ns |  0.99 |    0.01 |      - |     - |     - |         - |
|                 Linq |    10 |    68.871 ns |  0.2080 ns |  0.1844 ns | 10.05 |    0.06 | 0.0153 |     - |     - |      32 B |
|           LinqFaster |    10 |    24.402 ns |  0.0840 ns |  0.0786 ns |  3.56 |    0.03 |      - |     - |     - |         - |
|               LinqAF |    10 |    35.669 ns |  0.0695 ns |  0.0651 ns |  5.21 |    0.03 |      - |     - |     - |         - |
|           StructLinq |    10 |    48.873 ns |  0.1984 ns |  0.1759 ns |  7.13 |    0.04 | 0.0306 |     - |     - |      64 B |
| StructLinq_IFunction |    10 |    22.152 ns |  0.0514 ns |  0.0430 ns |  3.23 |    0.02 |      - |     - |     - |         - |
|            Hyperlinq |    10 |    29.569 ns |  0.0559 ns |  0.0495 ns |  4.32 |    0.02 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |    10 |    21.093 ns |  0.0301 ns |  0.0251 ns |  3.08 |    0.02 |      - |     - |     - |         - |
|                      |       |              |            |            |       |         |        |       |       |           |
|              **ForLoop** |  **1000** |   **728.166 ns** |  **2.3004 ns** |  **2.0393 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |  1000 |   728.926 ns |  1.6646 ns |  1.5571 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|                 Linq |  1000 | 8,713.938 ns | 21.5308 ns | 19.0865 ns | 11.97 |    0.05 | 0.0153 |     - |     - |      32 B |
|           LinqFaster |  1000 | 3,147.126 ns | 16.9269 ns | 14.1348 ns |  4.32 |    0.02 |      - |     - |     - |         - |
|               LinqAF |  1000 | 3,691.229 ns | 17.3009 ns | 15.3368 ns |  5.07 |    0.02 |      - |     - |     - |         - |
|           StructLinq |  1000 | 3,344.862 ns | 11.4350 ns | 10.6963 ns |  4.59 |    0.02 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction |  1000 |   693.169 ns |  4.3449 ns |  4.0643 ns |  0.95 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq |  1000 | 1,566.739 ns |  4.8642 ns |  4.3119 ns |  2.15 |    0.01 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |  1000 |   643.544 ns |  4.6425 ns |  4.1155 ns |  0.88 |    0.01 |      - |     - |     - |         - |
