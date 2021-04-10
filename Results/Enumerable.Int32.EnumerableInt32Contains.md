## Enumerable.Int32.EnumerableInt32Contains

### Source
[EnumerableInt32Contains.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32Contains.cs)

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
|               Method | Count |        Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |------------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|          **ForeachLoop** |    **10** |    **61.95 ns** |  **0.510 ns** |  **0.452 ns** |  **1.00** |    **0.00** | **0.0191** |     **-** |     **-** |      **40 B** |
|                 Linq |    10 |    70.37 ns |  1.397 ns |  1.816 ns |  1.12 |    0.03 | 0.0191 |     - |     - |      40 B |
|               LinqAF |    10 |   100.50 ns |  0.348 ns |  0.290 ns |  1.62 |    0.01 | 0.0191 |     - |     - |      40 B |
|           StructLinq |    10 |    73.46 ns |  0.443 ns |  0.370 ns |  1.19 |    0.01 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction |    10 |    65.40 ns |  0.487 ns |  0.455 ns |  1.06 |    0.01 | 0.0191 |     - |     - |      40 B |
|            Hyperlinq |    10 |    87.27 ns |  0.879 ns |  0.686 ns |  1.41 |    0.02 | 0.0191 |     - |     - |      40 B |
|                      |       |             |           |           |       |         |        |       |       |           |
|          **ForeachLoop** |  **1000** | **4,574.05 ns** | **18.698 ns** | **17.490 ns** |  **1.00** |    **0.00** | **0.0153** |     **-** |     **-** |      **40 B** |
|                 Linq |  1000 | 4,341.20 ns | 24.257 ns | 21.503 ns |  0.95 |    0.01 | 0.0153 |     - |     - |      40 B |
|               LinqAF |  1000 | 5,679.25 ns | 49.371 ns | 43.766 ns |  1.24 |    0.01 | 0.0153 |     - |     - |      40 B |
|           StructLinq |  1000 | 4,406.94 ns | 33.847 ns | 30.005 ns |  0.96 |    0.01 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction |  1000 | 4,309.61 ns | 14.484 ns | 12.840 ns |  0.94 |    0.00 | 0.0153 |     - |     - |      40 B |
|            Hyperlinq |  1000 | 5,705.92 ns | 21.177 ns | 17.683 ns |  1.25 |    0.01 | 0.0153 |     - |     - |      40 B |
