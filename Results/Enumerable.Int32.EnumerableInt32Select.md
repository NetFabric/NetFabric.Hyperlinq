## Enumerable.Int32.EnumerableInt32Select

### Source
[EnumerableInt32Select.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32Select.cs)

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
|                      Method | Count |        Mean |     Error |    StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------- |------ |------------:|----------:|----------:|------:|-------:|------:|------:|----------:|
|                 **ForeachLoop** |    **10** |    **57.67 ns** |  **0.243 ns** |  **0.227 ns** |  **1.00** | **0.0191** |     **-** |     **-** |      **40 B** |
|                        Linq |    10 |   159.64 ns |  0.479 ns |  0.400 ns |  2.77 | 0.0458 |     - |     - |      96 B |
|                      LinqAF |    10 |   131.22 ns |  0.389 ns |  0.364 ns |  2.28 | 0.0191 |     - |     - |      40 B |
|                  StructLinq |    10 |    94.76 ns |  0.169 ns |  0.150 ns |  1.64 | 0.0305 |     - |     - |      64 B |
|        StructLinq_IFunction |    10 |    63.42 ns |  0.199 ns |  0.186 ns |  1.10 | 0.0191 |     - |     - |      40 B |
|           Hyperlinq_Foreach |    10 |    83.88 ns |  0.118 ns |  0.104 ns |  1.45 | 0.0191 |     - |     - |      40 B |
| Hyperlinq_Foreach_IFunction |    10 |    64.69 ns |  0.150 ns |  0.125 ns |  1.12 | 0.0191 |     - |     - |      40 B |
|                             |       |             |           |           |       |        |       |       |           |
|                 **ForeachLoop** |  **1000** | **4,190.60 ns** | **14.452 ns** | **13.518 ns** |  **1.00** | **0.0153** |     **-** |     **-** |      **40 B** |
|                        Linq |  1000 | 9,471.45 ns | 31.365 ns | 29.339 ns |  2.26 | 0.0458 |     - |     - |      96 B |
|                      LinqAF |  1000 | 8,090.48 ns | 18.753 ns | 16.624 ns |  1.93 | 0.0153 |     - |     - |      40 B |
|                  StructLinq |  1000 | 6,366.87 ns | 24.776 ns | 20.689 ns |  1.52 | 0.0305 |     - |     - |      64 B |
|        StructLinq_IFunction |  1000 | 4,714.57 ns | 14.724 ns | 13.052 ns |  1.12 | 0.0153 |     - |     - |      40 B |
|           Hyperlinq_Foreach |  1000 | 5,728.66 ns |  7.867 ns |  6.974 ns |  1.37 | 0.0153 |     - |     - |      40 B |
| Hyperlinq_Foreach_IFunction |  1000 | 4,201.57 ns | 16.492 ns | 14.619 ns |  1.00 | 0.0153 |     - |     - |      40 B |
