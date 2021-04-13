## Enumerable.Int32.EnumerableInt32SkipTakeSelect

### Source
[EnumerableInt32SkipTakeSelect.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32SkipTakeSelect.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- LinqOptimizer.CSharp: [](https://www.nuget.org/packages/LinqOptimizer.CSharp/)
- Streams.CSharp: [0.6.0](https://www.nuget.org/packages/Streams.CSharp/0.6.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)

### Results:
``` ini

BenchmarkDotNet=v0.12.1.1527-nightly, OS=Windows 10.0.19043
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.3.21202.5
  [Host] : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT
  .NET 5 : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT
  .NET 6 : .NET 6.0.0 (6.0.21.20104), X64 RyuJIT

EnvironmentVariables=COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1  

```
|               Method |    Job |  Runtime | Skip | Count |      Mean |     Error |    StdDev | Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------- |--------- |----- |------ |----------:|----------:|----------:|------:|--------:|--------:|------:|------:|----------:|
|          **ForeachLoop** | **.NET 5** | **.NET 5.0** | **1000** |    **10** |  **2.618 μs** | **0.0098 μs** | **0.0087 μs** |  **1.00** |    **0.00** |  **0.0191** |     **-** |     **-** |      **40 B** |
|                 Linq | .NET 5 | .NET 5.0 | 1000 |    10 |  2.885 μs | 0.0145 μs | 0.0136 μs |  1.10 |    0.01 |  0.0992 |     - |     - |     208 B |
|               LinqAF | .NET 5 | .NET 5.0 | 1000 |    10 |  3.070 μs | 0.0120 μs | 0.0112 μs |  1.17 |    0.01 |  0.0191 |     - |     - |      40 B |
|        LinqOptimizer | .NET 5 | .NET 5.0 | 1000 |    10 | 53.142 μs | 0.1576 μs | 0.1316 μs | 20.30 |    0.07 | 15.5029 |     - |     - |  32,497 B |
|              Streams | .NET 5 | .NET 5.0 | 1000 |    10 |  9.813 μs | 0.0385 μs | 0.0341 μs |  3.75 |    0.02 |  0.4272 |     - |     - |     920 B |
|           StructLinq | .NET 5 | .NET 5.0 | 1000 |    10 |  2.990 μs | 0.0120 μs | 0.0113 μs |  1.14 |    0.00 |  0.0610 |     - |     - |     128 B |
| StructLinq_IFunction | .NET 5 | .NET 5.0 | 1000 |    10 |  2.708 μs | 0.0115 μs | 0.0102 μs |  1.03 |    0.01 |  0.0191 |     - |     - |      40 B |
|            Hyperlinq | .NET 5 | .NET 5.0 | 1000 |    10 |  2.967 μs | 0.0103 μs | 0.0086 μs |  1.13 |    0.01 |  0.0191 |     - |     - |      40 B |
|  Hyperlinq_IFunction | .NET 5 | .NET 5.0 | 1000 |    10 |  2.707 μs | 0.0116 μs | 0.0109 μs |  1.03 |    0.00 |  0.0191 |     - |     - |      40 B |
|                      |        |          |      |       |           |           |           |       |         |         |       |       |           |
|          ForeachLoop | .NET 6 | .NET 6.0 | 1000 |    10 |  2.346 μs | 0.0081 μs | 0.0072 μs |  1.00 |    0.00 |  0.0191 |     - |     - |      40 B |
|                 Linq | .NET 6 | .NET 6.0 | 1000 |    10 |  2.016 μs | 0.0086 μs | 0.0076 μs |  0.86 |    0.00 |  0.0992 |     - |     - |     208 B |
|               LinqAF | .NET 6 | .NET 6.0 | 1000 |    10 |  3.060 μs | 0.0116 μs | 0.0108 μs |  1.30 |    0.00 |  0.0191 |     - |     - |      40 B |
|        LinqOptimizer | .NET 6 | .NET 6.0 | 1000 |    10 | 47.168 μs | 0.1198 μs | 0.1001 μs | 20.10 |    0.06 | 15.3198 |     - |     - |  32,057 B |
|              Streams | .NET 6 | .NET 6.0 | 1000 |    10 |  6.781 μs | 0.0257 μs | 0.0240 μs |  2.89 |    0.01 |  0.4349 |     - |     - |     920 B |
|           StructLinq | .NET 6 | .NET 6.0 | 1000 |    10 |  2.182 μs | 0.0093 μs | 0.0087 μs |  0.93 |    0.01 |  0.0610 |     - |     - |     128 B |
| StructLinq_IFunction | .NET 6 | .NET 6.0 | 1000 |    10 |  2.164 μs | 0.0103 μs | 0.0097 μs |  0.92 |    0.01 |  0.0191 |     - |     - |      40 B |
|            Hyperlinq | .NET 6 | .NET 6.0 | 1000 |    10 |  2.696 μs | 0.0255 μs | 0.0199 μs |  1.15 |    0.01 |  0.0191 |     - |     - |      40 B |
|  Hyperlinq_IFunction | .NET 6 | .NET 6.0 | 1000 |    10 |  2.873 μs | 0.0072 μs | 0.0067 μs |  1.22 |    0.01 |  0.0191 |     - |     - |      40 B |
|                      |        |          |      |       |           |           |           |       |         |         |       |       |           |
|          **ForeachLoop** | **.NET 5** | **.NET 5.0** | **1000** |  **1000** |  **4.946 μs** | **0.0224 μs** | **0.0209 μs** |  **1.00** |    **0.00** |  **0.0153** |     **-** |     **-** |      **40 B** |
|                 Linq | .NET 5 | .NET 5.0 | 1000 |  1000 | 16.416 μs | 0.0682 μs | 0.0638 μs |  3.32 |    0.02 |  0.0916 |     - |     - |     208 B |
|               LinqAF | .NET 5 | .NET 5.0 | 1000 |  1000 | 13.300 μs | 0.0990 μs | 0.0878 μs |  2.69 |    0.02 |  0.0153 |     - |     - |      40 B |
|        LinqOptimizer | .NET 5 | .NET 5.0 | 1000 |  1000 | 64.090 μs | 0.3650 μs | 0.3414 μs | 12.96 |    0.09 | 17.3340 |     - |     - |  36,467 B |
|              Streams | .NET 5 | .NET 5.0 | 1000 |  1000 | 30.501 μs | 0.1595 μs | 0.1414 μs |  6.17 |    0.04 |  0.4272 |     - |     - |     920 B |
|           StructLinq | .NET 5 | .NET 5.0 | 1000 |  1000 |  9.103 μs | 0.0321 μs | 0.0300 μs |  1.84 |    0.01 |  0.0610 |     - |     - |     128 B |
| StructLinq_IFunction | .NET 5 | .NET 5.0 | 1000 |  1000 |  8.578 μs | 0.0364 μs | 0.0322 μs |  1.74 |    0.01 |  0.0153 |     - |     - |      40 B |
|            Hyperlinq | .NET 5 | .NET 5.0 | 1000 |  1000 |  9.718 μs | 0.0401 μs | 0.0355 μs |  1.97 |    0.01 |  0.0153 |     - |     - |      40 B |
|  Hyperlinq_IFunction | .NET 5 | .NET 5.0 | 1000 |  1000 |  8.651 μs | 0.0440 μs | 0.0367 μs |  1.75 |    0.01 |  0.0153 |     - |     - |      40 B |
|                      |        |          |      |       |           |           |           |       |         |         |       |       |           |
|          ForeachLoop | .NET 6 | .NET 6.0 | 1000 |  1000 |  2.679 μs | 0.0168 μs | 0.0158 μs |  1.00 |    0.00 |  0.0191 |     - |     - |      40 B |
|                 Linq | .NET 6 | .NET 6.0 | 1000 |  1000 | 11.313 μs | 0.0451 μs | 0.0422 μs |  4.22 |    0.02 |  0.0916 |     - |     - |     208 B |
|               LinqAF | .NET 6 | .NET 6.0 | 1000 |  1000 | 12.094 μs | 0.0337 μs | 0.0299 μs |  4.51 |    0.02 |  0.0153 |     - |     - |      40 B |
|        LinqOptimizer | .NET 6 | .NET 6.0 | 1000 |  1000 | 57.078 μs | 0.2049 μs | 0.1816 μs | 21.29 |    0.14 | 17.2119 |     - |     - |  36,027 B |
|              Streams | .NET 6 | .NET 6.0 | 1000 |  1000 | 21.734 μs | 0.0632 μs | 0.0591 μs |  8.11 |    0.05 |  0.4272 |     - |     - |     920 B |
|           StructLinq | .NET 6 | .NET 6.0 | 1000 |  1000 |  7.317 μs | 0.0334 μs | 0.0279 μs |  2.73 |    0.02 |  0.0610 |     - |     - |     128 B |
| StructLinq_IFunction | .NET 6 | .NET 6.0 | 1000 |  1000 |  7.019 μs | 0.0335 μs | 0.0313 μs |  2.62 |    0.02 |  0.0153 |     - |     - |      40 B |
|            Hyperlinq | .NET 6 | .NET 6.0 | 1000 |  1000 |  7.846 μs | 0.0495 μs | 0.0439 μs |  2.93 |    0.02 |  0.0153 |     - |     - |      40 B |
|  Hyperlinq_IFunction | .NET 6 | .NET 6.0 | 1000 |  1000 |  7.539 μs | 0.0410 μs | 0.0343 μs |  2.81 |    0.02 |  0.0153 |     - |     - |      40 B |
