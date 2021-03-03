## Enumerable.Int32.EnumerableInt32WhereCount

### Source
[EnumerableInt32WhereCount.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32WhereCount.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta42](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta42)

### Results:
``` ini

BenchmarkDotNet=v0.12.1.1516-nightly, OS=Windows 10.0.19042.844 (20H2/October2020Update)
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.1.21103.13
  [Host]   : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT
  .NET 5.0 : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT

Job=.NET 5.0  Runtime=.NET 5.0  

```
|               Method | Count |        Mean |     Error |    StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |------------:|----------:|----------:|------:|-------:|------:|------:|----------:|
|          **ForeachLoop** |    **10** |    **61.66 ns** |  **0.192 ns** |  **0.170 ns** |  **1.00** | **0.0191** |     **-** |     **-** |      **40 B** |
|                 Linq |    10 |    85.70 ns |  0.262 ns |  0.232 ns |  1.39 | 0.0191 |     - |     - |      40 B |
|               LinqAF |    10 |   103.77 ns |  0.209 ns |  0.185 ns |  1.68 | 0.0191 |     - |     - |      40 B |
|           StructLinq |    10 |   117.50 ns |  0.382 ns |  0.358 ns |  1.91 | 0.0458 |     - |     - |      96 B |
| StructLinq_IFunction |    10 |    69.89 ns |  0.272 ns |  0.241 ns |  1.13 | 0.0191 |     - |     - |      40 B |
|            Hyperlinq |    10 |    83.40 ns |  0.196 ns |  0.164 ns |  1.35 | 0.0191 |     - |     - |      40 B |
|  Hyperlinq_IFunction |    10 |    61.55 ns |  0.201 ns |  0.178 ns |  1.00 | 0.0191 |     - |     - |      40 B |
|                      |       |             |           |           |       |        |       |       |           |
|          **ForeachLoop** |  **1000** | **4,714.53 ns** |  **9.284 ns** |  **7.752 ns** |  **1.00** | **0.0153** |     **-** |     **-** |      **40 B** |
|                 Linq |  1000 | 5,742.92 ns | 17.590 ns | 15.593 ns |  1.22 | 0.0153 |     - |     - |      40 B |
|               LinqAF |  1000 | 6,386.42 ns | 26.921 ns | 45.715 ns |  1.35 | 0.0153 |     - |     - |      40 B |
|           StructLinq |  1000 | 6,346.74 ns | 17.168 ns | 15.219 ns |  1.35 | 0.0458 |     - |     - |      96 B |
| StructLinq_IFunction |  1000 | 4,620.40 ns | 26.939 ns | 23.881 ns |  0.98 | 0.0153 |     - |     - |      40 B |
|            Hyperlinq |  1000 | 5,501.47 ns | 55.606 ns | 46.433 ns |  1.17 | 0.0153 |     - |     - |      40 B |
|  Hyperlinq_IFunction |  1000 | 4,445.62 ns | 17.214 ns | 15.260 ns |  0.94 | 0.0153 |     - |     - |      40 B |
