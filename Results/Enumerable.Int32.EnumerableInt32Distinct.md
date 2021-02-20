## Enumerable.Int32.EnumerableInt32Distinct

### Source
[EnumerableInt32Distinct.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32Distinct.cs)

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
|               Method | Count |        Mean |     Error |    StdDev | Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |------------:|----------:|----------:|------:|--------:|--------:|------:|------:|----------:|
|          **ForeachLoop** |    **10** |    **260.2 ns** |   **0.90 ns** |   **0.80 ns** |  **1.00** |    **0.00** |  **0.3405** |     **-** |     **-** |     **712 B** |
|                 Linq |    10 |    364.7 ns |   1.35 ns |   1.19 ns |  1.40 |    0.00 |  0.2942 |     - |     - |     616 B |
|               LinqAF |    10 |    493.2 ns |   2.43 ns |   2.28 ns |  1.90 |    0.01 |  0.2937 |     - |     - |     616 B |
|           StructLinq |    10 |    409.5 ns |   5.31 ns |   4.97 ns |  1.57 |    0.02 |  0.0305 |     - |     - |      64 B |
| StructLinq_IFunction |    10 |    408.8 ns |   4.31 ns |   3.82 ns |  1.57 |    0.01 |  0.0191 |     - |     - |      40 B |
|            Hyperlinq |    10 |    340.9 ns |   5.35 ns |   5.00 ns |  1.31 |    0.02 |  0.0191 |     - |     - |      40 B |
|                      |       |             |           |           |       |         |         |       |       |           |
|          **ForeachLoop** |  **1000** | **17,707.8 ns** |  **91.49 ns** |  **81.11 ns** |  **1.00** |    **0.00** | **27.7710** |     **-** |     **-** |   **58712 B** |
|                 Linq |  1000 | 25,363.3 ns |  54.72 ns |  48.51 ns |  1.43 |    0.01 | 15.7776 |     - |     - |   33112 B |
|               LinqAF |  1000 | 33,588.7 ns | 195.01 ns | 172.87 ns |  1.90 |    0.02 | 19.5923 |     - |     - |   41224 B |
|           StructLinq |  1000 | 18,615.8 ns |  54.57 ns |  45.57 ns |  1.05 |    0.01 |  0.0305 |     - |     - |      64 B |
| StructLinq_IFunction |  1000 | 17,557.2 ns |  61.05 ns |  50.98 ns |  0.99 |    0.01 |       - |     - |     - |      40 B |
|            Hyperlinq |  1000 | 17,106.5 ns |  56.19 ns |  52.56 ns |  0.97 |    0.01 |       - |     - |     - |      40 B |
