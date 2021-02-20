## Enumerable.Int32.EnumerableInt32Sum

### Source
[EnumerableInt32Sum.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32Sum.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta39](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta39)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=6.0.100-preview.1.21103.13
  [Host]        : .NET Core 5.0.3 (CoreCLR 5.0.321.7212, CoreFX 5.0.321.7212), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.3 (CoreCLR 5.0.321.7212, CoreFX 5.0.321.7212), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|               Method | Count |        Mean |      Error |     StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |------------:|-----------:|-----------:|------:|--------:|-------:|------:|------:|----------:|
|          **ForeachLoop** |    **10** |    **59.24 ns** |   **0.244 ns** |   **0.217 ns** |  **1.00** |    **0.00** | **0.0191** |     **-** |     **-** |      **40 B** |
|                 Linq |    10 |    91.39 ns |   1.862 ns |   2.954 ns |  1.53 |    0.05 | 0.0191 |     - |     - |      40 B |
|               LinqAF |    10 |    92.32 ns |   0.753 ns |   0.629 ns |  1.56 |    0.01 | 0.0191 |     - |     - |      40 B |
|           StructLinq |    10 |    79.88 ns |   0.540 ns |   0.505 ns |  1.35 |    0.01 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction |    10 |    70.42 ns |   0.563 ns |   0.470 ns |  1.19 |    0.01 | 0.0191 |     - |     - |      40 B |
|            Hyperlinq |    10 |    65.13 ns |   0.231 ns |   0.205 ns |  1.10 |    0.00 | 0.0191 |     - |     - |      40 B |
|                      |       |             |            |            |       |         |        |       |       |           |
|          **ForeachLoop** |  **1000** | **4,457.40 ns** |  **29.598 ns** |  **24.716 ns** |  **1.00** |    **0.00** | **0.0153** |     **-** |     **-** |      **40 B** |
|                 Linq |  1000 | 9,587.99 ns | 247.390 ns | 717.723 ns |  2.10 |    0.19 | 0.0153 |     - |     - |      40 B |
|               LinqAF |  1000 | 4,989.86 ns |  15.978 ns |  14.164 ns |  1.12 |    0.01 | 0.0153 |     - |     - |      40 B |
|           StructLinq |  1000 | 4,725.06 ns |  13.465 ns |  11.936 ns |  1.06 |    0.01 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction |  1000 | 4,446.90 ns |   9.771 ns |   9.139 ns |  1.00 |    0.01 | 0.0153 |     - |     - |      40 B |
|            Hyperlinq |  1000 | 4,647.55 ns |   8.213 ns |   7.683 ns |  1.04 |    0.01 | 0.0153 |     - |     - |      40 B |
