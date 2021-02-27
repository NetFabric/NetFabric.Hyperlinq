## List.Int32.ListInt32Contains

### Source
[ListInt32Contains.cs](../LinqBenchmarks/List/Int32/ListInt32Contains.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta41](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta41)

### Results:
``` ini

BenchmarkDotNet=v0.12.1.1516-nightly, OS=Windows 10.0.19042.844 (20H2/October2020Update)
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.1.21103.13
  [Host]   : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT
  .NET 5.0 : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT

Job=.NET 5.0  Runtime=.NET 5.0  

```
|               Method | Count |         Mean |     Error |    StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |-------------:|----------:|----------:|------:|-------:|------:|------:|----------:|
|              **ForLoop** |    **10** |    **10.450 ns** | **0.0446 ns** | **0.0395 ns** |  **1.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |    10 |    22.560 ns | 0.1144 ns | 0.0955 ns |  2.16 |      - |     - |     - |         - |
|                 Linq |    10 |    11.961 ns | 0.0914 ns | 0.0810 ns |  1.14 |      - |     - |     - |         - |
|           LinqFaster |    10 |     8.069 ns | 0.0443 ns | 0.0393 ns |  0.77 |      - |     - |     - |         - |
|               LinqAF |    10 |     7.926 ns | 0.0505 ns | 0.0447 ns |  0.76 |      - |     - |     - |         - |
|           StructLinq |    10 |    17.719 ns | 0.1011 ns | 0.0844 ns |  1.70 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |    10 |    10.393 ns | 0.0689 ns | 0.0611 ns |  0.99 |      - |     - |     - |         - |
|            Hyperlinq |    10 |    11.985 ns | 0.0724 ns | 0.0642 ns |  1.15 |      - |     - |     - |         - |
|       Hyperlinq_SIMD |    10 |    17.144 ns | 0.0720 ns | 0.0638 ns |  1.64 |      - |     - |     - |         - |
|                      |       |              |           |           |       |        |       |       |           |
|              **ForLoop** |  **1000** | **1,068.321 ns** | **3.8773 ns** | **3.2377 ns** |  **1.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |  1000 | 2,145.588 ns | 7.1810 ns | 6.3658 ns |  2.01 |      - |     - |     - |         - |
|                 Linq |  1000 |   239.962 ns | 1.3107 ns | 1.1619 ns |  0.22 |      - |     - |     - |         - |
|           LinqFaster |  1000 |   245.854 ns | 1.0512 ns | 0.9318 ns |  0.23 |      - |     - |     - |         - |
|               LinqAF |  1000 |   236.668 ns | 1.5199 ns | 1.3474 ns |  0.22 |      - |     - |     - |         - |
|           StructLinq |  1000 |   554.362 ns | 3.0723 ns | 2.7236 ns |  0.52 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |  1000 |   805.442 ns | 3.3757 ns | 2.9924 ns |  0.75 |      - |     - |     - |         - |
|            Hyperlinq |  1000 |   248.189 ns | 1.8773 ns | 1.4656 ns |  0.23 |      - |     - |     - |         - |
|       Hyperlinq_SIMD |  1000 |   111.199 ns | 0.4159 ns | 0.3687 ns |  0.10 |      - |     - |     - |         - |
