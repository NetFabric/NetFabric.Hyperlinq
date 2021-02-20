## Enumerable.Int32.EnumerableInt32Where

### Source
[EnumerableInt32Where.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32Where.cs)

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
|               Method | Count |         Mean |      Error |       StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |-------------:|-----------:|-------------:|------:|--------:|-------:|------:|------:|----------:|
|                 **Linq** |    **10** |    **211.20 ns** |   **3.933 ns** |     **4.529 ns** |  **1.00** |    **0.00** | **0.0458** |     **-** |     **-** |      **96 B** |
|               LinqAF |    10 |    151.09 ns |   1.288 ns |     1.205 ns |  0.71 |    0.01 | 0.0191 |     - |     - |      40 B |
|           StructLinq |    10 |    115.06 ns |   0.440 ns |     0.390 ns |  0.54 |    0.01 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction |    10 |     78.20 ns |   0.248 ns |     0.207 ns |  0.37 |    0.01 | 0.0191 |     - |     - |      40 B |
|            Hyperlinq |    10 |    107.74 ns |   0.311 ns |     0.291 ns |  0.51 |    0.01 | 0.0191 |     - |     - |      40 B |
|  Hyperlinq_IFunction |    10 |     73.46 ns |   0.359 ns |     0.318 ns |  0.35 |    0.01 | 0.0191 |     - |     - |      40 B |
|                      |       |              |            |              |       |         |        |       |       |           |
|                 **Linq** |  **1000** | **17,625.99 ns** | **487.077 ns** | **1,428.513 ns** |  **1.00** |    **0.00** | **0.0305** |     **-** |     **-** |      **96 B** |
|               LinqAF |  1000 |  8,078.94 ns |  22.872 ns |    20.276 ns |  0.48 |    0.04 | 0.0153 |     - |     - |      40 B |
|           StructLinq |  1000 |  7,442.26 ns |  19.221 ns |    17.039 ns |  0.44 |    0.03 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction |  1000 |  5,378.45 ns |  25.577 ns |    21.358 ns |  0.31 |    0.02 | 0.0153 |     - |     - |      40 B |
|            Hyperlinq |  1000 |  7,778.46 ns |  32.315 ns |    28.646 ns |  0.46 |    0.03 | 0.0153 |     - |     - |      40 B |
|  Hyperlinq_IFunction |  1000 |  5,521.98 ns |  14.808 ns |    13.127 ns |  0.33 |    0.02 | 0.0153 |     - |     - |      40 B |
