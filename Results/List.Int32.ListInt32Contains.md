## List.Int32.ListInt32Contains

### Source
[ListInt32Contains.cs](../LinqBenchmarks/List/Int32/ListInt32Contains.cs)

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
|               Method | Count |         Mean |     Error |    StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |-------------:|----------:|----------:|------:|-------:|------:|------:|----------:|
|              **ForLoop** |    **10** |    **10.466 ns** | **0.0351 ns** | **0.0293 ns** |  **1.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |    10 |    25.245 ns | 0.1241 ns | 0.1100 ns |  2.41 |      - |     - |     - |         - |
|                 Linq |    10 |    11.839 ns | 0.0403 ns | 0.0336 ns |  1.13 |      - |     - |     - |         - |
|           LinqFaster |    10 |     8.011 ns | 0.0296 ns | 0.0262 ns |  0.77 |      - |     - |     - |         - |
|               LinqAF |    10 |     7.873 ns | 0.0468 ns | 0.0415 ns |  0.75 |      - |     - |     - |         - |
|           StructLinq |    10 |    16.500 ns | 0.1037 ns | 0.0919 ns |  1.58 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |    10 |    10.342 ns | 0.0315 ns | 0.0294 ns |  0.99 |      - |     - |     - |         - |
|            Hyperlinq |    10 |    12.700 ns | 0.0358 ns | 0.0317 ns |  1.21 |      - |     - |     - |         - |
|       Hyperlinq_SIMD |    10 |    17.613 ns | 0.0674 ns | 0.0631 ns |  1.68 |      - |     - |     - |         - |
|                      |       |              |           |           |       |        |       |       |           |
|              **ForLoop** |  **1000** | **1,060.422 ns** | **3.5154 ns** | **3.2883 ns** |  **1.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |  1000 | 2,139.363 ns | 8.8461 ns | 7.3869 ns |  2.02 |      - |     - |     - |         - |
|                 Linq |  1000 |   239.532 ns | 2.0219 ns | 1.8913 ns |  0.23 |      - |     - |     - |         - |
|           LinqFaster |  1000 |   245.128 ns | 1.7577 ns | 1.5581 ns |  0.23 |      - |     - |     - |         - |
|               LinqAF |  1000 |   234.206 ns | 0.7888 ns | 0.6993 ns |  0.22 |      - |     - |     - |         - |
|           StructLinq |  1000 |   550.844 ns | 2.6162 ns | 2.4472 ns |  0.52 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |  1000 |   801.424 ns | 1.4445 ns | 1.2062 ns |  0.76 |      - |     - |     - |         - |
|            Hyperlinq |  1000 |   246.232 ns | 0.6050 ns | 0.5659 ns |  0.23 |      - |     - |     - |         - |
|       Hyperlinq_SIMD |  1000 |   112.153 ns | 0.2875 ns | 0.2549 ns |  0.11 |      - |     - |     - |         - |
