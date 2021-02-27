## Enumerable.Int32.EnumerableInt32Where

### Source
[EnumerableInt32Where.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32Where.cs)

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
|               Method | Count |        Mean |     Error |    StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |------------:|----------:|----------:|------:|-------:|------:|------:|----------:|
|                 **Linq** |    **10** |   **153.89 ns** |  **1.181 ns** |  **1.047 ns** |  **1.00** | **0.0458** |     **-** |     **-** |      **96 B** |
|               LinqAF |    10 |   128.36 ns |  0.807 ns |  0.715 ns |  0.83 | 0.0191 |     - |     - |      40 B |
|           StructLinq |    10 |   105.78 ns |  0.763 ns |  0.714 ns |  0.69 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction |    10 |    77.88 ns |  0.521 ns |  0.487 ns |  0.51 | 0.0191 |     - |     - |      40 B |
|            Hyperlinq |    10 |    95.92 ns |  0.561 ns |  0.497 ns |  0.62 | 0.0191 |     - |     - |      40 B |
|  Hyperlinq_IFunction |    10 |    77.28 ns |  0.318 ns |  0.282 ns |  0.50 | 0.0191 |     - |     - |      40 B |
|                      |       |             |           |           |       |        |       |       |           |
|                 **Linq** |  **1000** | **8,275.12 ns** | **84.499 ns** | **74.906 ns** |  **1.00** | **0.0458** |     **-** |     **-** |      **96 B** |
|               LinqAF |  1000 | 8,026.42 ns | 55.205 ns | 51.638 ns |  0.97 | 0.0153 |     - |     - |      40 B |
|           StructLinq |  1000 | 7,269.84 ns | 71.166 ns | 63.087 ns |  0.88 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction |  1000 | 5,522.84 ns | 28.431 ns | 23.741 ns |  0.67 | 0.0153 |     - |     - |      40 B |
|            Hyperlinq |  1000 | 6,596.65 ns | 25.396 ns | 21.207 ns |  0.80 | 0.0153 |     - |     - |      40 B |
|  Hyperlinq_IFunction |  1000 | 5,613.14 ns | 23.470 ns | 19.599 ns |  0.68 | 0.0153 |     - |     - |      40 B |
