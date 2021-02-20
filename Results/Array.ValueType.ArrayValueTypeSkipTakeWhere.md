## Array.ValueType.ArrayValueTypeSkipTakeWhere

### Source
[ArrayValueTypeSkipTakeWhere.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeSkipTakeWhere.cs)

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
|               Method | Skip | Count |         Mean |      Error |     StdDev |  Ratio | RatioSD |    Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |----- |------ |-------------:|-----------:|-----------:|-------:|--------:|---------:|------:|------:|----------:|
|              **ForLoop** | **1000** |    **10** |     **43.97 ns** |   **0.098 ns** |   **0.082 ns** |   **1.00** |    **0.00** |        **-** |     **-** |     **-** |         **-** |
|          ForeachLoop | 1000 |    10 |  2,446.07 ns |   7.184 ns |   5.999 ns |  55.63 |    0.17 |   0.0153 |     - |     - |      32 B |
|                 Linq | 1000 |    10 |    270.05 ns |   1.173 ns |   1.040 ns |   6.14 |    0.03 |   0.1526 |     - |     - |     320 B |
|           LinqFaster | 1000 |    10 |    222.50 ns |   0.971 ns |   0.861 ns |   5.06 |    0.02 |   1.1170 |     - |     - |    2336 B |
|               LinqAF | 1000 |    10 |  5,161.02 ns |  95.151 ns | 166.649 ns | 120.09 |    3.72 |        - |     - |     - |         - |
|           StructLinq | 1000 |    10 |    116.66 ns |   0.335 ns |   0.280 ns |   2.65 |    0.01 |   0.0459 |     - |     - |      96 B |
| StructLinq_IFunction | 1000 |    10 |     76.57 ns |   0.238 ns |   0.211 ns |   1.74 |    0.01 |        - |     - |     - |         - |
|            Hyperlinq | 1000 |    10 |     80.90 ns |   0.163 ns |   0.144 ns |   1.84 |    0.01 |        - |     - |     - |         - |
|  Hyperlinq_IFunction | 1000 |    10 |     67.71 ns |   0.179 ns |   0.167 ns |   1.54 |    0.00 |        - |     - |     - |         - |
|                      |      |       |              |            |            |        |         |          |       |       |           |
|              **ForLoop** | **1000** |  **1000** |  **4,352.58 ns** |  **15.208 ns** |  **14.226 ns** |   **1.00** |    **0.00** |        **-** |     **-** |     **-** |         **-** |
|          ForeachLoop | 1000 |  1000 |  5,719.73 ns |  15.221 ns |  13.493 ns |   1.31 |    0.01 |   0.0153 |     - |     - |      32 B |
|                 Linq | 1000 |  1000 | 20,061.31 ns |  43.373 ns |  40.571 ns |   4.61 |    0.02 |   0.1526 |     - |     - |     320 B |
|           LinqFaster | 1000 |  1000 | 20,904.95 ns | 103.839 ns |  86.710 ns |   4.80 |    0.02 | 105.2551 |     - |     - |  223520 B |
|               LinqAF | 1000 |  1000 | 29,978.50 ns | 559.351 ns | 549.357 ns |   6.89 |    0.14 |        - |     - |     - |         - |
|           StructLinq | 1000 |  1000 |  7,733.15 ns |  18.797 ns |  17.583 ns |   1.78 |    0.01 |   0.0458 |     - |     - |      96 B |
| StructLinq_IFunction | 1000 |  1000 |  5,022.79 ns |  17.337 ns |  15.369 ns |   1.15 |    0.00 |        - |     - |     - |         - |
|            Hyperlinq | 1000 |  1000 |  7,017.71 ns |  38.907 ns |  36.394 ns |   1.61 |    0.01 |        - |     - |     - |         - |
|  Hyperlinq_IFunction | 1000 |  1000 |  4,800.96 ns |  17.197 ns |  15.245 ns |   1.10 |    0.01 |        - |     - |     - |         - |
