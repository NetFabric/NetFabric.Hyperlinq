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

BenchmarkDotNet=v0.12.1.1517-nightly, OS=Windows 10.0.19043
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.1.21103.13
  [Host]   : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT
  .NET 5.0 : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT

Job=.NET 5.0  Runtime=.NET 5.0  

```
|               Method | Count |        Mean |     Error |    StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |------------:|----------:|----------:|------:|-------:|------:|------:|----------:|
|          **ForeachLoop** |    **10** |    **59.18 ns** |  **0.276 ns** |  **0.258 ns** |  **1.00** | **0.0191** |     **-** |     **-** |      **40 B** |
|                 Linq |    10 |    61.72 ns |  0.171 ns |  0.160 ns |  1.04 | 0.0191 |     - |     - |      40 B |
|               LinqAF |    10 |    96.49 ns |  0.218 ns |  0.204 ns |  1.63 | 0.0191 |     - |     - |      40 B |
|           StructLinq |    10 |    70.49 ns |  0.192 ns |  0.170 ns |  1.19 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction |    10 |    59.50 ns |  0.209 ns |  0.196 ns |  1.01 | 0.0191 |     - |     - |      40 B |
|            Hyperlinq |    10 |    83.45 ns |  0.213 ns |  0.199 ns |  1.41 | 0.0191 |     - |     - |      40 B |
|                      |       |             |           |           |       |        |       |       |           |
|          **ForeachLoop** |  **1000** | **4,458.05 ns** | **10.011 ns** |  **8.874 ns** |  **1.00** | **0.0153** |     **-** |     **-** |      **40 B** |
|                 Linq |  1000 | 4,214.39 ns | 24.011 ns | 20.050 ns |  0.95 | 0.0153 |     - |     - |      40 B |
|               LinqAF |  1000 | 5,502.96 ns | 12.451 ns | 11.647 ns |  1.23 | 0.0153 |     - |     - |      40 B |
|           StructLinq |  1000 | 4,203.98 ns | 10.882 ns | 10.179 ns |  0.94 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction |  1000 | 4,186.97 ns |  9.759 ns |  8.149 ns |  0.94 | 0.0153 |     - |     - |      40 B |
|            Hyperlinq |  1000 | 5,740.43 ns | 11.264 ns |  9.406 ns |  1.29 | 0.0153 |     - |     - |      40 B |
