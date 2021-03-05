## ImmutableArray.Int32.ImmutableArrayInt32Contains

### Source
[ImmutableArrayInt32Contains.cs](../LinqBenchmarks/ImmutableArray/Int32/ImmutableArrayInt32Contains.cs)

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
|              **ForLoop** |    **10** |     **5.025 ns** |  **0.0250 ns** |  **0.0208 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |    10 |     9.728 ns |  0.0375 ns |  0.0313 ns |  1.94 |    0.01 |      - |     - |     - |         - |
|                 Linq |    10 |    10.863 ns |  0.0494 ns |  0.0438 ns |  2.16 |    0.01 |      - |     - |     - |         - |
|           StructLinq |    10 |    28.430 ns |  0.0896 ns |  0.0838 ns |  5.66 |    0.03 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |    10 |    20.812 ns |  0.0459 ns |  0.0384 ns |  4.14 |    0.02 |      - |     - |     - |         - |
|            Hyperlinq |    10 |    13.469 ns |  0.0828 ns |  0.0692 ns |  2.68 |    0.02 |      - |     - |     - |         - |
|       Hyperlinq_SIMD |    10 |    16.927 ns |  0.0442 ns |  0.0413 ns |  3.37 |    0.02 |      - |     - |     - |         - |
|                      |       |              |            |            |       |         |        |       |       |           |
|              **ForLoop** |  **1000** |   **350.109 ns** |  **0.9966 ns** |  **0.8834 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |  1000 | 1,034.600 ns |  2.7172 ns |  2.4087 ns |  2.96 |    0.01 |      - |     - |     - |         - |
|                 Linq |  1000 |   239.188 ns |  0.9852 ns |  0.8733 ns |  0.68 |    0.00 |      - |     - |     - |         - |
|           StructLinq |  1000 | 1,864.383 ns |  4.7369 ns |  4.1992 ns |  5.33 |    0.02 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |  1000 | 1,832.230 ns | 31.0729 ns | 29.0656 ns |  5.24 |    0.09 |      - |     - |     - |         - |
|            Hyperlinq |  1000 |   238.510 ns |  0.8319 ns |  0.7782 ns |  0.68 |    0.00 |      - |     - |     - |         - |
|       Hyperlinq_SIMD |  1000 |   109.196 ns |  0.9753 ns |  0.9123 ns |  0.31 |    0.00 |      - |     - |     - |         - |
