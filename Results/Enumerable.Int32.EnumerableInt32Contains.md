## Enumerable.Int32.EnumerableInt32Contains

### Source
[EnumerableInt32Contains.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32Contains.cs)

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
|               Method | Count |        Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |------------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|          **ForeachLoop** |    **10** |    **64.86 ns** |  **0.273 ns** |  **0.228 ns** |  **1.00** |    **0.00** | **0.0191** |     **-** |     **-** |      **40 B** |
|                 Linq |    10 |    80.26 ns |  0.584 ns |  0.518 ns |  1.24 |    0.01 | 0.0191 |     - |     - |      40 B |
|               LinqAF |    10 |   113.72 ns |  1.034 ns |  0.864 ns |  1.75 |    0.01 | 0.0191 |     - |     - |      40 B |
|           StructLinq |    10 |    82.01 ns |  1.401 ns |  1.170 ns |  1.26 |    0.02 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction |    10 |    70.19 ns |  0.491 ns |  0.436 ns |  1.08 |    0.01 | 0.0191 |     - |     - |      40 B |
|            Hyperlinq |    10 |    86.95 ns |  0.443 ns |  0.392 ns |  1.34 |    0.01 | 0.0191 |     - |     - |      40 B |
|                      |       |             |           |           |       |         |        |       |       |           |
|          **ForeachLoop** |  **1000** | **4,443.58 ns** | **12.778 ns** | **10.670 ns** |  **1.00** |    **0.00** | **0.0153** |     **-** |     **-** |      **40 B** |
|                 Linq |  1000 | 4,990.42 ns | 19.345 ns | 17.149 ns |  1.12 |    0.00 | 0.0153 |     - |     - |      40 B |
|               LinqAF |  1000 | 5,770.07 ns | 17.127 ns | 15.183 ns |  1.30 |    0.01 | 0.0153 |     - |     - |      40 B |
|           StructLinq |  1000 | 4,707.54 ns | 12.157 ns | 10.777 ns |  1.06 |    0.00 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction |  1000 | 4,521.10 ns | 18.876 ns | 17.656 ns |  1.02 |    0.00 | 0.0153 |     - |     - |      40 B |
|            Hyperlinq |  1000 | 5,662.63 ns | 13.373 ns | 11.855 ns |  1.27 |    0.00 | 0.0153 |     - |     - |      40 B |
