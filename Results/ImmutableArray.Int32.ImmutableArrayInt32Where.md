## ImmutableArray.Int32.ImmutableArrayInt32Where

### Source
[ImmutableArrayInt32Where.cs](../LinqBenchmarks/ImmutableArray/Int32/ImmutableArrayInt32Where.cs)

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
|              **ForLoop** |    **10** |     **7.614 ns** |  **0.0268 ns** |  **0.0237 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |    10 |     7.243 ns |  0.0241 ns |  0.0213 ns |  0.95 |    0.00 |      - |     - |     - |         - |
|                 Linq |    10 |    58.764 ns |  0.2268 ns |  0.2010 ns |  7.72 |    0.03 | 0.0229 |     - |     - |      48 B |
|           StructLinq |    10 |    58.922 ns |  0.1793 ns |  0.1497 ns |  7.74 |    0.02 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |    10 |    45.764 ns |  0.1474 ns |  0.1307 ns |  6.01 |    0.03 |      - |     - |     - |         - |
|            Hyperlinq |    10 |    40.921 ns |  0.0995 ns |  0.0882 ns |  5.37 |    0.02 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |    10 |    39.305 ns |  0.0634 ns |  0.0562 ns |  5.16 |    0.02 |      - |     - |     - |         - |
|                      |       |              |            |            |       |         |        |       |       |           |
|              **ForLoop** |  **1000** |   **744.655 ns** |  **2.9510 ns** |  **2.6160 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |  1000 |   818.997 ns |  2.5521 ns |  2.2624 ns |  1.10 |    0.00 |      - |     - |     - |         - |
|                 Linq |  1000 | 7,169.643 ns | 17.6522 ns | 15.6482 ns |  9.63 |    0.04 | 0.0229 |     - |     - |      48 B |
|           StructLinq |  1000 | 7,125.445 ns | 16.2900 ns | 13.6029 ns |  9.57 |    0.03 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |  1000 | 5,097.296 ns | 12.9542 ns | 11.4835 ns |  6.85 |    0.03 |      - |     - |     - |         - |
|            Hyperlinq |  1000 | 6,013.987 ns | 16.7488 ns | 14.8474 ns |  8.08 |    0.03 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |  1000 | 1,931.411 ns |  6.7850 ns |  5.6658 ns |  2.59 |    0.01 |      - |     - |     - |         - |
