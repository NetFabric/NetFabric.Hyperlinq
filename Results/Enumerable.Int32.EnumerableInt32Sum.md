## Enumerable.Int32.EnumerableInt32Sum

### Source
[EnumerableInt32Sum.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32Sum.cs)

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
|          **ForeachLoop** |    **10** |    **57.15 ns** |  **0.499 ns** |  **0.442 ns** |  **1.00** | **0.0191** |     **-** |     **-** |      **40 B** |
|                 Linq |    10 |    61.98 ns |  0.290 ns |  0.242 ns |  1.08 | 0.0191 |     - |     - |      40 B |
|               LinqAF |    10 |    79.52 ns |  0.387 ns |  0.323 ns |  1.39 | 0.0191 |     - |     - |      40 B |
|           StructLinq |    10 |    78.27 ns |  0.371 ns |  0.310 ns |  1.37 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction |    10 |    62.33 ns |  0.368 ns |  0.326 ns |  1.09 | 0.0191 |     - |     - |      40 B |
|            Hyperlinq |    10 |    59.02 ns |  0.378 ns |  0.354 ns |  1.03 | 0.0191 |     - |     - |      40 B |
|                      |       |             |           |           |       |        |       |       |           |
|          **ForeachLoop** |  **1000** | **4,830.85 ns** | **17.368 ns** | **14.503 ns** |  **1.00** | **0.0153** |     **-** |     **-** |      **40 B** |
|                 Linq |  1000 | 4,327.98 ns | 20.762 ns | 17.337 ns |  0.90 | 0.0153 |     - |     - |      40 B |
|               LinqAF |  1000 | 4,885.73 ns | 26.790 ns | 22.371 ns |  1.01 | 0.0153 |     - |     - |      40 B |
|           StructLinq |  1000 | 4,367.31 ns | 22.099 ns | 19.590 ns |  0.90 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction |  1000 | 4,843.76 ns | 24.890 ns | 22.064 ns |  1.00 | 0.0153 |     - |     - |      40 B |
|            Hyperlinq |  1000 | 4,329.32 ns | 28.600 ns | 25.353 ns |  0.90 | 0.0153 |     - |     - |      40 B |
