## Enumerable.Int32.EnumerableInt32SkipTakeWhere

### Source
[EnumerableInt32SkipTakeWhere.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32SkipTakeWhere.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta38](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta38)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.200-preview.21079.7
  [Host]        : .NET Core 5.0.3 (CoreCLR 5.0.321.7212, CoreFX 5.0.321.7212), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.3 (CoreCLR 5.0.321.7212, CoreFX 5.0.321.7212), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|               Method | Skip | Count |         Mean |      Error |     StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |----- |------ |-------------:|-----------:|-----------:|------:|--------:|-------:|------:|------:|----------:|
|          **ForeachLoop** | **1000** |     **0** |  **2,882.60 ns** |  **19.442 ns** |  **18.186 ns** |  **1.00** |    **0.00** | **0.0191** |     **-** |     **-** |      **40 B** |
|                 Linq | 1000 |     0 |     66.54 ns |   0.291 ns |   0.243 ns |  0.02 |    0.00 | 0.0535 |     - |     - |     112 B |
|               LinqAF | 1000 |     0 |     78.74 ns |   0.589 ns |   0.522 ns |  0.03 |    0.00 |      - |     - |     - |         - |
|           StructLinq | 1000 |     0 |     52.19 ns |   0.209 ns |   0.164 ns |  0.02 |    0.00 | 0.0612 |     - |     - |     128 B |
| StructLinq_IFunction | 1000 |     0 |     41.21 ns |   0.180 ns |   0.160 ns |  0.01 |    0.00 | 0.0191 |     - |     - |      40 B |
|            Hyperlinq | 1000 |     0 |  2,805.50 ns |  18.177 ns |  17.003 ns |  0.97 |    0.01 | 0.0191 |     - |     - |      40 B |
|  Hyperlinq_IFunction | 1000 |     0 |  3,134.25 ns |   7.654 ns |   6.785 ns |  1.09 |    0.01 | 0.0191 |     - |     - |      40 B |
|                      |      |       |              |            |            |       |         |        |       |       |           |
|          **ForeachLoop** | **1000** |    **10** |  **2,893.01 ns** |   **7.236 ns** |   **6.769 ns** |  **1.00** |    **0.00** | **0.0191** |     **-** |     **-** |      **40 B** |
|                 Linq | 1000 |    10 |  3,384.67 ns |  12.036 ns |  11.259 ns |  1.17 |    0.00 | 0.0992 |     - |     - |     208 B |
|               LinqAF | 1000 |    10 |  3,627.24 ns |  10.740 ns |   8.968 ns |  1.25 |    0.00 | 0.0191 |     - |     - |      40 B |
|           StructLinq | 1000 |    10 |  2,839.43 ns |  27.093 ns |  21.152 ns |  0.98 |    0.01 | 0.0610 |     - |     - |     128 B |
| StructLinq_IFunction | 1000 |    10 |  2,973.02 ns |   8.265 ns |   6.902 ns |  1.03 |    0.00 | 0.0191 |     - |     - |      40 B |
|            Hyperlinq | 1000 |    10 |  2,971.69 ns |  13.488 ns |  11.957 ns |  1.03 |    0.00 | 0.0191 |     - |     - |      40 B |
|  Hyperlinq_IFunction | 1000 |    10 |  3,225.92 ns |   8.915 ns |   7.903 ns |  1.12 |    0.00 | 0.0191 |     - |     - |      40 B |
|                      |      |       |              |            |            |       |         |        |       |       |           |
|          **ForeachLoop** | **1000** |  **1000** |  **5,185.19 ns** |  **13.068 ns** |  **12.224 ns** |  **1.00** |    **0.00** | **0.0153** |     **-** |     **-** |      **40 B** |
|                 Linq | 1000 |  1000 | 16,308.90 ns | 322.876 ns | 302.018 ns |  3.15 |    0.06 | 0.0916 |     - |     - |     208 B |
|               LinqAF | 1000 |  1000 | 15,549.03 ns |  75.198 ns |  70.341 ns |  3.00 |    0.02 |      - |     - |     - |      40 B |
|           StructLinq | 1000 |  1000 |  9,844.88 ns |  58.664 ns |  52.004 ns |  1.90 |    0.01 | 0.0610 |     - |     - |     128 B |
| StructLinq_IFunction | 1000 |  1000 |  9,061.28 ns |  30.350 ns |  26.905 ns |  1.75 |    0.01 | 0.0153 |     - |     - |      40 B |
|            Hyperlinq | 1000 |  1000 | 11,461.17 ns |  76.034 ns |  67.402 ns |  2.21 |    0.01 | 0.0153 |     - |     - |      40 B |
|  Hyperlinq_IFunction | 1000 |  1000 | 10,432.32 ns |  52.582 ns |  43.909 ns |  2.01 |    0.01 | 0.0153 |     - |     - |      40 B |
