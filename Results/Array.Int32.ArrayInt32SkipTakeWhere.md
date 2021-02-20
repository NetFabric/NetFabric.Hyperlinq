## Array.Int32.ArrayInt32SkipTakeWhere

### Source
[ArrayInt32SkipTakeWhere.cs](../LinqBenchmarks/Array/Int32/ArrayInt32SkipTakeWhere.cs)

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
|               Method | Skip | Count |         Mean |      Error |       StdDev |  Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |----- |------ |-------------:|-----------:|-------------:|-------:|--------:|-------:|------:|------:|----------:|
|              **ForLoop** | **1000** |    **10** |     **11.63 ns** |   **0.312 ns** |     **0.530 ns** |   **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop | 1000 |    10 |  4,921.33 ns | 138.615 ns |   406.533 ns | 422.17 |   41.08 | 0.0153 |     - |     - |      32 B |
|                 Linq | 1000 |    10 |    302.68 ns |   6.052 ns |     8.484 ns |  26.24 |    1.43 | 0.0725 |     - |     - |     152 B |
|           LinqFaster | 1000 |    10 |     81.14 ns |   0.197 ns |     0.175 ns |   7.15 |    0.38 | 0.1147 |     - |     - |     240 B |
|               LinqAF | 1000 |    10 |  1,929.76 ns |  14.623 ns |    12.211 ns | 169.81 |    9.17 |      - |     - |     - |         - |
|           StructLinq | 1000 |    10 |     82.39 ns |   0.246 ns |     0.218 ns |   7.25 |    0.38 | 0.0459 |     - |     - |      96 B |
| StructLinq_IFunction | 1000 |    10 |     38.25 ns |   0.061 ns |     0.051 ns |   3.37 |    0.18 |      - |     - |     - |         - |
|            Hyperlinq | 1000 |    10 |     56.08 ns |   0.484 ns |     0.453 ns |   4.92 |    0.25 |      - |     - |     - |         - |
|  Hyperlinq_IFunction | 1000 |    10 |     34.44 ns |   0.075 ns |     0.066 ns |   3.03 |    0.16 |      - |     - |     - |         - |
|                      |      |       |              |            |              |        |         |        |       |       |           |
|              **ForLoop** | **1000** |  **1000** |    **957.50 ns** |   **5.540 ns** |     **4.911 ns** |   **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop | 1000 |  1000 | 10,337.31 ns | 217.639 ns |   631.410 ns |  10.76 |    0.58 | 0.0153 |     - |     - |      32 B |
|                 Linq | 1000 |  1000 | 30,637.96 ns | 611.568 ns | 1,714.902 ns |  31.40 |    1.90 | 0.0610 |     - |     - |     152 B |
|           LinqFaster | 1000 |  1000 |  4,506.90 ns |  19.935 ns |    17.672 ns |   4.71 |    0.02 | 6.7215 |     - |     - |   14064 B |
|               LinqAF | 1000 |  1000 | 20,208.03 ns | 383.249 ns |   358.492 ns |  21.11 |    0.44 |      - |     - |     - |         - |
|           StructLinq | 1000 |  1000 |  4,580.84 ns |  15.499 ns |    12.942 ns |   4.78 |    0.03 | 0.0458 |     - |     - |      96 B |
| StructLinq_IFunction | 1000 |  1000 |  1,461.84 ns |   6.318 ns |     5.910 ns |   1.53 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq | 1000 |  1000 |  4,768.29 ns |  20.100 ns |    16.784 ns |   4.98 |    0.03 |      - |     - |     - |         - |
|  Hyperlinq_IFunction | 1000 |  1000 |  1,901.68 ns |   5.278 ns |     4.937 ns |   1.99 |    0.01 |      - |     - |     - |         - |
