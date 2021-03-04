## ImmutableArray.Int32.ImmutableArrayInt32Contains

### Source
[ImmutableArrayInt32Contains.cs](../LinqBenchmarks/ImmutableArray/Int32/ImmutableArrayInt32Contains.cs)

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
|               Method | Count |         Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |-------------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|              **ForLoop** |    **10** |     **3.366 ns** | **0.0184 ns** | **0.0163 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |    10 |     9.971 ns | 0.0198 ns | 0.0176 ns |  2.96 |    0.01 |      - |     - |     - |         - |
|                 Linq |    10 |    10.529 ns | 0.0348 ns | 0.0291 ns |  3.13 |    0.02 |      - |     - |     - |         - |
|           StructLinq |    10 |    28.909 ns | 0.1446 ns | 0.1352 ns |  8.59 |    0.04 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |    10 |    23.034 ns | 0.0462 ns | 0.0409 ns |  6.84 |    0.03 |      - |     - |     - |         - |
|            Hyperlinq |    10 |    19.338 ns | 0.1056 ns | 0.0936 ns |  5.75 |    0.04 | 0.0115 |     - |     - |      24 B |
|                      |       |              |           |           |       |         |        |       |       |           |
|              **ForLoop** |  **1000** |   **360.167 ns** | **1.1138 ns** | **0.9300 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |  1000 | 1,064.614 ns | 4.5784 ns | 4.2826 ns |  2.96 |    0.01 |      - |     - |     - |         - |
|                 Linq |  1000 |   237.699 ns | 0.7972 ns | 0.7067 ns |  0.66 |    0.00 |      - |     - |     - |         - |
|           StructLinq |  1000 | 1,901.631 ns | 5.5066 ns | 4.8814 ns |  5.28 |    0.02 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |  1000 | 1,861.571 ns | 5.4060 ns | 4.5143 ns |  5.17 |    0.02 |      - |     - |     - |         - |
|            Hyperlinq |  1000 |   256.988 ns | 0.8817 ns | 0.8247 ns |  0.71 |    0.00 | 0.0114 |     - |     - |      24 B |
