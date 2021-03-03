## Enumerable.Int32.EnumerableInt32Sum

### Source
[EnumerableInt32Sum.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32Sum.cs)

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
|          **ForeachLoop** |    **10** |    **59.81 ns** |  **0.207 ns** |  **0.183 ns** |  **1.00** | **0.0191** |     **-** |     **-** |      **40 B** |
|                 Linq |    10 |    57.02 ns |  0.109 ns |  0.096 ns |  0.95 | 0.0191 |     - |     - |      40 B |
|               LinqAF |    10 |    70.53 ns |  0.157 ns |  0.139 ns |  1.18 | 0.0191 |     - |     - |      40 B |
|           StructLinq |    10 |    68.31 ns |  0.229 ns |  0.203 ns |  1.14 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction |    10 |    55.96 ns |  0.185 ns |  0.144 ns |  0.94 | 0.0191 |     - |     - |      40 B |
|            Hyperlinq |    10 |    58.64 ns |  0.232 ns |  0.205 ns |  0.98 | 0.0191 |     - |     - |      40 B |
|                      |       |             |           |           |       |        |       |       |           |
|          **ForeachLoop** |  **1000** | **4,682.58 ns** |  **6.971 ns** |  **6.180 ns** |  **1.00** | **0.0153** |     **-** |     **-** |      **40 B** |
|                 Linq |  1000 | 4,187.79 ns | 11.196 ns | 10.473 ns |  0.89 | 0.0153 |     - |     - |      40 B |
|               LinqAF |  1000 | 4,192.54 ns | 17.544 ns | 14.650 ns |  0.90 | 0.0153 |     - |     - |      40 B |
|           StructLinq |  1000 | 3,950.99 ns | 16.104 ns | 15.064 ns |  0.84 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction |  1000 | 4,199.83 ns | 48.841 ns | 38.132 ns |  0.90 | 0.0153 |     - |     - |      40 B |
|            Hyperlinq |  1000 | 4,446.19 ns | 16.232 ns | 14.389 ns |  0.95 | 0.0153 |     - |     - |      40 B |
