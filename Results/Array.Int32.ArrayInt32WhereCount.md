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

BenchmarkDotNet=v0.12.1.1517-nightly, OS=Windows 10.0.19043
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.1.21103.13
  [Host]   : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT
  .NET 5.0 : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT

Job=.NET 5.0  Runtime=.NET 5.0  

```
|               Method | Count |         Mean |      Error |     StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |-------------:|-----------:|-----------:|------:|--------:|-------:|------:|------:|----------:|
|              **ForLoop** |    **10** |     **6.899 ns** |  **0.1050 ns** |  **0.0876 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |    10 |     6.843 ns |  0.0801 ns |  0.0710 ns |  0.99 |    0.01 |      - |     - |     - |         - |
|                 Linq |    10 |    70.414 ns |  0.3001 ns |  0.2506 ns | 10.21 |    0.14 | 0.0153 |     - |     - |      32 B |
|           LinqFaster |    10 |    24.500 ns |  0.0653 ns |  0.0579 ns |  3.55 |    0.05 |      - |     - |     - |         - |
|               LinqAF |    10 |    36.479 ns |  0.2099 ns |  0.1753 ns |  5.29 |    0.06 |      - |     - |     - |         - |
|           StructLinq |    10 |    49.011 ns |  0.1478 ns |  0.1311 ns |  7.10 |    0.09 | 0.0306 |     - |     - |      64 B |
| StructLinq_IFunction |    10 |    22.155 ns |  0.0293 ns |  0.0244 ns |  3.21 |    0.04 |      - |     - |     - |         - |
|            Hyperlinq |    10 |    28.923 ns |  0.0922 ns |  0.0862 ns |  4.20 |    0.06 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |    10 |    22.512 ns |  0.0247 ns |  0.0231 ns |  3.26 |    0.04 |      - |     - |     - |         - |
|                      |       |              |            |            |       |         |        |       |       |           |
|              **ForLoop** |  **1000** |   **785.951 ns** |  **2.7813 ns** |  **2.3225 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |  1000 |   786.797 ns |  2.3007 ns |  1.9212 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|                 Linq |  1000 | 8,992.900 ns | 19.7535 ns | 18.4775 ns | 11.44 |    0.04 | 0.0153 |     - |     - |      32 B |
|           LinqFaster |  1000 | 3,149.558 ns | 12.7678 ns | 11.9430 ns |  4.01 |    0.02 |      - |     - |     - |         - |
|               LinqAF |  1000 | 3,683.095 ns | 12.5446 ns | 10.4753 ns |  4.69 |    0.02 |      - |     - |     - |         - |
|           StructLinq |  1000 | 3,063.928 ns | 11.0241 ns |  9.7726 ns |  3.90 |    0.02 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction |  1000 |   694.307 ns |  4.3643 ns |  4.0824 ns |  0.88 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq |  1000 | 1,573.694 ns |  2.5038 ns |  2.2196 ns |  2.00 |    0.01 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |  1000 |   646.840 ns |  3.8139 ns |  3.3809 ns |  0.82 |    0.01 |      - |     - |     - |         - |
