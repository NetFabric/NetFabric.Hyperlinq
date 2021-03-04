## ImmutableArray.Int32.ImmutableArrayInt32Sum

### Source
[ImmutableArrayInt32Sum.cs](../LinqBenchmarks/ImmutableArray/Int32/ImmutableArrayInt32Sum.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta43](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta43)

### Results:
``` ini

BenchmarkDotNet=v0.12.1.1516-nightly, OS=Windows 10.0.19043
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.1.21103.13
  [Host]   : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT
  .NET 5.0 : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT

Job=.NET 5.0  Runtime=.NET 5.0  

```
|               Method | Count |         Mean |      Error |     StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |-------------:|-----------:|-----------:|------:|--------:|-------:|------:|------:|----------:|
|              **ForLoop** |    **10** |     **3.356 ns** |  **0.0183 ns** |  **0.0143 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |    10 |     5.858 ns |  0.0315 ns |  0.0295 ns |  1.75 |    0.01 |      - |     - |     - |         - |
|                 Linq |    10 |    59.459 ns |  0.2596 ns |  0.2302 ns | 17.72 |    0.12 | 0.0267 |     - |     - |      56 B |
|           StructLinq |    10 |    28.487 ns |  0.1208 ns |  0.1130 ns |  8.49 |    0.04 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |    10 |    20.515 ns |  0.0864 ns |  0.0808 ns |  6.11 |    0.03 |      - |     - |     - |         - |
|            Hyperlinq |    10 |    22.708 ns |  0.0746 ns |  0.0623 ns |  6.77 |    0.03 |      - |     - |     - |         - |
|                      |       |              |            |            |       |         |        |       |       |           |
|              **ForLoop** |  **1000** |   **394.501 ns** |  **1.3597 ns** |  **1.2053 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |  1000 |   534.784 ns |  2.0204 ns |  1.8899 ns |  1.36 |    0.00 |      - |     - |     - |         - |
|                 Linq |  1000 | 4,068.272 ns | 21.0650 ns | 18.6736 ns | 10.31 |    0.06 | 0.0229 |     - |     - |      56 B |
|           StructLinq |  1000 | 1,882.364 ns |  5.2644 ns |  4.1101 ns |  4.77 |    0.02 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |  1000 | 1,860.066 ns |  6.0760 ns |  5.0738 ns |  4.71 |    0.02 |      - |     - |     - |         - |
|            Hyperlinq |  1000 | 1,859.693 ns |  5.5914 ns |  4.6691 ns |  4.71 |    0.01 |      - |     - |     - |         - |
