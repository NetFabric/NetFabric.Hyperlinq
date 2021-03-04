## Enumerable.Int32.EnumerableInt32Sum

### Source
[EnumerableInt32Sum.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32Sum.cs)

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
|               Method | Count |        Mean |     Error |     StdDev |      Median | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |------------:|----------:|-----------:|------------:|------:|--------:|-------:|------:|------:|----------:|
|          **ForeachLoop** |    **10** |    **55.97 ns** |  **0.167 ns** |   **0.148 ns** |    **55.97 ns** |  **1.00** |    **0.00** | **0.0191** |     **-** |     **-** |      **40 B** |
|                 Linq |    10 |    58.61 ns |  0.410 ns |   0.384 ns |    58.56 ns |  1.05 |    0.01 | 0.0191 |     - |     - |      40 B |
|               LinqAF |    10 |    77.63 ns |  0.277 ns |   0.259 ns |    77.70 ns |  1.39 |    0.00 | 0.0191 |     - |     - |      40 B |
|           StructLinq |    10 |    75.88 ns |  0.279 ns |   0.248 ns |    75.81 ns |  1.36 |    0.01 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction |    10 |    64.49 ns |  0.459 ns |   0.407 ns |    64.40 ns |  1.15 |    0.01 | 0.0191 |     - |     - |      40 B |
|            Hyperlinq |    10 |    57.42 ns |  0.314 ns |   0.278 ns |    57.36 ns |  1.03 |    0.01 | 0.0191 |     - |     - |      40 B |
|                      |       |             |           |            |             |       |         |        |       |       |           |
|          **ForeachLoop** |  **1000** | **4,813.66 ns** | **28.252 ns** |  **25.045 ns** | **4,800.56 ns** |  **1.00** |    **0.00** | **0.0153** |     **-** |     **-** |      **40 B** |
|                 Linq |  1000 | 4,297.22 ns | 17.157 ns |  14.327 ns | 4,296.33 ns |  0.89 |    0.01 | 0.0153 |     - |     - |      40 B |
|               LinqAF |  1000 | 4,867.45 ns | 25.419 ns |  22.534 ns | 4,865.24 ns |  1.01 |    0.01 | 0.0153 |     - |     - |      40 B |
|           StructLinq |  1000 | 4,959.87 ns | 97.299 ns | 196.548 ns | 4,849.65 ns |  1.04 |    0.04 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction |  1000 | 4,303.52 ns | 18.518 ns |  17.322 ns | 4,297.18 ns |  0.89 |    0.00 | 0.0153 |     - |     - |      40 B |
|            Hyperlinq |  1000 | 4,303.58 ns | 14.073 ns |  12.475 ns | 4,303.48 ns |  0.89 |    0.01 | 0.0153 |     - |     - |      40 B |
