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

BenchmarkDotNet=v0.12.1.1527-nightly, OS=Windows 10.0.19043
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.3.21202.5
  [Host]   : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT
  .NET 5.0 : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT

Job=.NET 5.0  Runtime=.NET 5.0  

```
|               Method | Count |         Mean |      Error |     StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |-------------:|-----------:|-----------:|------:|--------:|-------:|------:|------:|----------:|
|              **ForLoop** |    **10** |     **5.387 ns** |  **0.0245 ns** |  **0.0217 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |    10 |     6.334 ns |  0.0584 ns |  0.0546 ns |  1.18 |    0.01 |      - |     - |     - |         - |
|                 Linq |    10 |     8.886 ns |  0.0391 ns |  0.0347 ns |  1.65 |    0.01 |      - |     - |     - |         - |
|           StructLinq |    10 |    30.837 ns |  0.1640 ns |  0.1370 ns |  5.72 |    0.04 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |    10 |    19.394 ns |  0.1094 ns |  0.1023 ns |  3.60 |    0.03 |      - |     - |     - |         - |
|            Hyperlinq |    10 |    13.339 ns |  0.0403 ns |  0.0337 ns |  2.48 |    0.01 |      - |     - |     - |         - |
|       Hyperlinq_SIMD |    10 |    22.620 ns |  0.2859 ns |  0.2675 ns |  4.20 |    0.06 |      - |     - |     - |         - |
|                      |       |              |            |            |       |         |        |       |       |           |
|              **ForLoop** |  **1000** |   **544.293 ns** |  **4.0884 ns** |  **3.6243 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |  1000 |   541.307 ns |  3.7467 ns |  3.3214 ns |  0.99 |    0.01 |      - |     - |     - |         - |
|                 Linq |  1000 |   237.002 ns |  1.3452 ns |  1.1925 ns |  0.44 |    0.00 |      - |     - |     - |         - |
|           StructLinq |  1000 | 1,914.673 ns | 11.0052 ns | 10.2943 ns |  3.52 |    0.03 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |  1000 | 1,872.187 ns |  9.0083 ns |  8.4263 ns |  3.44 |    0.02 |      - |     - |     - |         - |
|            Hyperlinq |  1000 |   240.999 ns |  0.6922 ns |  0.5780 ns |  0.44 |    0.00 |      - |     - |     - |         - |
|       Hyperlinq_SIMD |  1000 |   119.781 ns |  0.4842 ns |  0.4293 ns |  0.22 |    0.00 |      - |     - |     - |         - |
