## Enumerable.Int32.EnumerableInt32Where

### Source
[EnumerableInt32Where.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32Where.cs)

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
|                 **Linq** |    **10** |   **144.93 ns** |  **0.501 ns** |  **0.418 ns** |  **1.00** | **0.0458** |     **-** |     **-** |      **96 B** |
|               LinqAF |    10 |   131.22 ns |  0.480 ns |  0.401 ns |  0.91 | 0.0191 |     - |     - |      40 B |
|           StructLinq |    10 |    95.33 ns |  0.340 ns |  0.302 ns |  0.66 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction |    10 |    77.48 ns |  0.290 ns |  0.257 ns |  0.53 | 0.0191 |     - |     - |      40 B |
|            Hyperlinq |    10 |    94.41 ns |  0.406 ns |  0.360 ns |  0.65 | 0.0191 |     - |     - |      40 B |
|  Hyperlinq_IFunction |    10 |    70.30 ns |  0.196 ns |  0.164 ns |  0.49 | 0.0191 |     - |     - |      40 B |
|                      |       |             |           |           |       |        |       |       |           |
|                 **Linq** |  **1000** | **8,363.70 ns** | **21.403 ns** | **18.974 ns** |  **1.00** | **0.0458** |     **-** |     **-** |      **96 B** |
|               LinqAF |  1000 | 7,930.16 ns | 31.042 ns | 25.921 ns |  0.95 | 0.0153 |     - |     - |      40 B |
|           StructLinq |  1000 | 6,421.21 ns | 32.953 ns | 30.824 ns |  0.77 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction |  1000 | 5,364.25 ns | 22.985 ns | 20.376 ns |  0.64 | 0.0153 |     - |     - |      40 B |
|            Hyperlinq |  1000 | 6,628.11 ns | 11.949 ns | 10.592 ns |  0.79 | 0.0153 |     - |     - |      40 B |
|  Hyperlinq_IFunction |  1000 | 5,500.86 ns | 13.775 ns | 11.502 ns |  0.66 | 0.0153 |     - |     - |      40 B |
