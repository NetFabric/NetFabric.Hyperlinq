## List.Int32.ListInt32Sum

### Source
[ListInt32Sum.cs](../LinqBenchmarks/List/Int32/ListInt32Sum.cs)

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
|              **ForLoop** |    **10** |    **12.863 ns** |  **0.0468 ns** |  **0.0415 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |    10 |    25.466 ns |  0.1437 ns |  0.1274 ns |  1.98 |    0.01 |      - |     - |     - |         - |
|                 Linq |    10 |    91.843 ns |  0.4906 ns |  0.4349 ns |  7.14 |    0.04 | 0.0191 |     - |     - |      40 B |
|           LinqFaster |    10 |     8.636 ns |  0.0433 ns |  0.0405 ns |  0.67 |    0.00 |      - |     - |     - |         - |
|               LinqAF |    10 |    72.299 ns |  0.4739 ns |  0.4433 ns |  5.62 |    0.04 |      - |     - |     - |         - |
|           StructLinq |    10 |    18.065 ns |  0.1037 ns |  0.0866 ns |  1.40 |    0.01 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |    10 |     6.707 ns |  0.0372 ns |  0.0330 ns |  0.52 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq |    10 |    17.348 ns |  0.0904 ns |  0.0846 ns |  1.35 |    0.01 |      - |     - |     - |         - |
|                      |       |              |            |            |       |         |        |       |       |           |
|              **ForLoop** |  **1000** | **1,334.881 ns** |  **3.3235 ns** |  **2.7753 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |  1000 | 2,420.573 ns | 11.6531 ns |  9.7308 ns |  1.81 |    0.01 |      - |     - |     - |         - |
|                 Linq |  1000 | 7,084.788 ns | 81.8538 ns | 76.5661 ns |  5.31 |    0.06 | 0.0153 |     - |     - |      40 B |
|           LinqFaster |  1000 |   705.120 ns |  3.2672 ns |  2.8963 ns |  0.53 |    0.00 |      - |     - |     - |         - |
|               LinqAF |  1000 | 4,581.570 ns | 56.8825 ns | 53.2079 ns |  3.44 |    0.04 |      - |     - |     - |         - |
|           StructLinq |  1000 |   699.359 ns |  7.0139 ns |  6.2177 ns |  0.52 |    0.00 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |  1000 |   606.880 ns |  3.9265 ns |  3.6728 ns |  0.46 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq |  1000 |    95.880 ns |  1.0347 ns |  0.9679 ns |  0.07 |    0.00 |      - |     - |     - |         - |
