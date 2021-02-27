## Enumerable.Int32.EnumerableInt32Contains

### Source
[EnumerableInt32Contains.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32Contains.cs)

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
|          **ForeachLoop** |    **10** |    **62.70 ns** |  **0.289 ns** |  **0.256 ns** |  **1.00** | **0.0191** |     **-** |     **-** |      **40 B** |
|                 Linq |    10 |    65.98 ns |  0.318 ns |  0.266 ns |  1.05 | 0.0191 |     - |     - |      40 B |
|               LinqAF |    10 |   100.66 ns |  0.439 ns |  0.366 ns |  1.61 | 0.0191 |     - |     - |      40 B |
|           StructLinq |    10 |    76.00 ns |  0.319 ns |  0.249 ns |  1.21 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction |    10 |    62.53 ns |  0.547 ns |  0.457 ns |  1.00 | 0.0191 |     - |     - |      40 B |
|            Hyperlinq |    10 |    88.09 ns |  0.836 ns |  0.741 ns |  1.41 | 0.0191 |     - |     - |      40 B |
|                      |       |             |           |           |       |        |       |       |           |
|          **ForeachLoop** |  **1000** | **4,602.86 ns** | **23.555 ns** | **18.390 ns** |  **1.00** | **0.0153** |     **-** |     **-** |      **40 B** |
|                 Linq |  1000 | 4,349.01 ns | 19.287 ns | 15.058 ns |  0.94 | 0.0153 |     - |     - |      40 B |
|               LinqAF |  1000 | 5,694.86 ns | 18.855 ns | 15.745 ns |  1.24 | 0.0153 |     - |     - |      40 B |
|           StructLinq |  1000 | 4,339.09 ns | 25.462 ns | 22.571 ns |  0.94 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction |  1000 | 4,327.10 ns | 14.484 ns | 13.548 ns |  0.94 | 0.0153 |     - |     - |      40 B |
|            Hyperlinq |  1000 | 5,699.01 ns | 25.444 ns | 22.556 ns |  1.24 | 0.0153 |     - |     - |      40 B |
