## Enumerable.Int32.EnumerableInt32Where

### Source
[EnumerableInt32Where.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32Where.cs)

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
|               Method | Count |        Mean |      Error |    StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |------------:|-----------:|----------:|------:|-------:|------:|------:|----------:|
|                 **Linq** |    **10** |   **144.51 ns** |   **0.455 ns** |  **0.403 ns** |  **1.00** | **0.0458** |     **-** |     **-** |      **96 B** |
|               LinqAF |    10 |   124.38 ns |   1.295 ns |  1.211 ns |  0.86 | 0.0191 |     - |     - |      40 B |
|           StructLinq |    10 |   100.50 ns |   0.229 ns |  0.203 ns |  0.70 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction |    10 |    74.42 ns |   0.253 ns |  0.211 ns |  0.52 | 0.0191 |     - |     - |      40 B |
|            Hyperlinq |    10 |    91.63 ns |   0.266 ns |  0.236 ns |  0.63 | 0.0191 |     - |     - |      40 B |
|  Hyperlinq_IFunction |    10 |    73.37 ns |   0.184 ns |  0.143 ns |  0.51 | 0.0191 |     - |     - |      40 B |
|                      |       |             |            |           |       |        |       |       |           |
|                 **Linq** |  **1000** | **8,730.41 ns** |  **34.143 ns** | **30.267 ns** |  **1.00** | **0.0458** |     **-** |     **-** |      **96 B** |
|               LinqAF |  1000 | 7,625.90 ns |  35.263 ns | 31.260 ns |  0.87 | 0.0153 |     - |     - |      40 B |
|           StructLinq |  1000 | 6,976.24 ns | 102.800 ns | 85.842 ns |  0.80 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction |  1000 | 5,354.80 ns |  19.561 ns | 17.340 ns |  0.61 | 0.0153 |     - |     - |      40 B |
|            Hyperlinq |  1000 | 6,402.65 ns |  16.468 ns | 15.405 ns |  0.73 | 0.0153 |     - |     - |      40 B |
|  Hyperlinq_IFunction |  1000 | 5,418.96 ns |  19.502 ns | 16.285 ns |  0.62 | 0.0153 |     - |     - |      40 B |
