## Enumerable.Int32.EnumerableInt32SkipTakeWhere

### Source
[EnumerableInt32SkipTakeWhere.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32SkipTakeWhere.cs)

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
|          **ForeachLoop** | **.NET 5** | **.NET 5.0** | **1000** |    **10** |  **2.874 μs** | **0.0088 μs** | **0.0069 μs** |  **1.00** |    **0.00** |  **0.0191** |     **-** |     **-** |      **40 B** |
|                 Linq | .NET 5 | .NET 5.0 | 1000 |    10 |  2.861 μs | 0.0062 μs | 0.0055 μs |  1.00 |    0.00 |  0.0992 |     - |     - |     208 B |
|               LinqAF | .NET 5 | .NET 5.0 | 1000 |    10 |  3.088 μs | 0.0264 μs | 0.0221 μs |  1.07 |    0.01 |  0.0191 |     - |     - |      40 B |
|        LinqOptimizer | .NET 5 | .NET 5.0 | 1000 |    10 | 58.407 μs | 0.2286 μs | 0.2138 μs | 20.32 |    0.10 | 15.8691 |     - |     - |  33,287 B |
|              Streams | .NET 5 | .NET 5.0 | 1000 |    10 |  9.795 μs | 0.0511 μs | 0.0453 μs |  3.41 |    0.02 |  0.4272 |     - |     - |     920 B |
|           StructLinq | .NET 5 | .NET 5.0 | 1000 |    10 |  3.267 μs | 0.0133 μs | 0.0125 μs |  1.14 |    0.01 |  0.0610 |     - |     - |     128 B |
| StructLinq_IFunction | .NET 5 | .NET 5.0 | 1000 |    10 |  2.967 μs | 0.0100 μs | 0.0094 μs |  1.03 |    0.00 |  0.0191 |     - |     - |      40 B |
|            Hyperlinq | .NET 5 | .NET 5.0 | 1000 |    10 |  3.000 μs | 0.0413 μs | 0.0322 μs |  1.04 |    0.01 |  0.0191 |     - |     - |      40 B |
|  Hyperlinq_IFunction | .NET 5 | .NET 5.0 | 1000 |    10 |  2.713 μs | 0.0091 μs | 0.0085 μs |  0.94 |    0.00 |  0.0191 |     - |     - |      40 B |
|                      |        |          |      |       |           |           |           |       |         |         |       |       |           |
|          ForeachLoop | .NET 6 | .NET 6.0 | 1000 |    10 |  2.343 μs | 0.0098 μs | 0.0091 μs |  1.00 |    0.00 |  0.0191 |     - |     - |      40 B |
|                 Linq | .NET 6 | .NET 6.0 | 1000 |    10 |  2.240 μs | 0.0078 μs | 0.0073 μs |  0.96 |    0.01 |  0.0992 |     - |     - |     208 B |
|               LinqAF | .NET 6 | .NET 6.0 | 1000 |    10 |  3.061 μs | 0.0124 μs | 0.0103 μs |  1.31 |    0.01 |  0.0191 |     - |     - |      40 B |
|        LinqOptimizer | .NET 6 | .NET 6.0 | 1000 |    10 | 52.418 μs | 0.2100 μs | 0.1964 μs | 22.37 |    0.11 | 15.6860 |     - |     - |  32,845 B |
|              Streams | .NET 6 | .NET 6.0 | 1000 |    10 |  7.153 μs | 0.0292 μs | 0.0244 μs |  3.05 |    0.01 |  0.4349 |     - |     - |     920 B |
|           StructLinq | .NET 6 | .NET 6.0 | 1000 |    10 |  2.443 μs | 0.0117 μs | 0.0109 μs |  1.04 |    0.01 |  0.0610 |     - |     - |     128 B |
| StructLinq_IFunction | .NET 6 | .NET 6.0 | 1000 |    10 |  2.677 μs | 0.0101 μs | 0.0094 μs |  1.14 |    0.01 |  0.0191 |     - |     - |      40 B |
|            Hyperlinq | .NET 6 | .NET 6.0 | 1000 |    10 |  2.227 μs | 0.0063 μs | 0.0059 μs |  0.95 |    0.01 |  0.0191 |     - |     - |      40 B |
|  Hyperlinq_IFunction | .NET 6 | .NET 6.0 | 1000 |    10 |  2.718 μs | 0.0130 μs | 0.0122 μs |  1.16 |    0.00 |  0.0191 |     - |     - |      40 B |
|                      |        |          |      |       |           |           |           |       |         |         |       |       |           |
|          **ForeachLoop** | **.NET 5** | **.NET 5.0** | **1000** |  **1000** |  **5.207 μs** | **0.0241 μs** | **0.0226 μs** |  **1.00** |    **0.00** |  **0.0153** |     **-** |     **-** |      **40 B** |
|                 Linq | .NET 5 | .NET 5.0 | 1000 |  1000 | 15.638 μs | 0.0579 μs | 0.0513 μs |  3.00 |    0.01 |  0.0916 |     - |     - |     208 B |
|               LinqAF | .NET 5 | .NET 5.0 | 1000 |  1000 | 14.494 μs | 0.0596 μs | 0.0498 μs |  2.78 |    0.02 |  0.0153 |     - |     - |      40 B |
|        LinqOptimizer | .NET 5 | .NET 5.0 | 1000 |  1000 | 65.846 μs | 0.2462 μs | 0.2303 μs | 12.65 |    0.08 | 16.8457 |     - |     - |  35,265 B |
|              Streams | .NET 5 | .NET 5.0 | 1000 |  1000 | 26.542 μs | 0.0897 μs | 0.0749 μs |  5.10 |    0.02 |  0.4272 |     - |     - |     920 B |
|           StructLinq | .NET 5 | .NET 5.0 | 1000 |  1000 | 10.217 μs | 0.0482 μs | 0.0402 μs |  1.96 |    0.01 |  0.0610 |     - |     - |     128 B |
| StructLinq_IFunction | .NET 5 | .NET 5.0 | 1000 |  1000 |  9.744 μs | 0.0393 μs | 0.0349 μs |  1.87 |    0.01 |  0.0153 |     - |     - |      40 B |
|            Hyperlinq | .NET 5 | .NET 5.0 | 1000 |  1000 | 10.801 μs | 0.0467 μs | 0.0390 μs |  2.07 |    0.01 |  0.0153 |     - |     - |      40 B |
|  Hyperlinq_IFunction | .NET 5 | .NET 5.0 | 1000 |  1000 |  9.447 μs | 0.0461 μs | 0.0360 μs |  1.81 |    0.01 |  0.0153 |     - |     - |      40 B |
|                      |        |          |      |       |           |           |           |       |         |         |       |       |           |
|          ForeachLoop | .NET 6 | .NET 6.0 | 1000 |  1000 |  2.861 μs | 0.0112 μs | 0.0105 μs |  1.00 |    0.00 |  0.0191 |     - |     - |      40 B |
|                 Linq | .NET 6 | .NET 6.0 | 1000 |  1000 | 11.366 μs | 0.0364 μs | 0.0341 μs |  3.97 |    0.01 |  0.0916 |     - |     - |     208 B |
|               LinqAF | .NET 6 | .NET 6.0 | 1000 |  1000 | 10.548 μs | 0.0363 μs | 0.0283 μs |  3.69 |    0.02 |  0.0153 |     - |     - |      40 B |
|        LinqOptimizer | .NET 6 | .NET 6.0 | 1000 |  1000 | 59.526 μs | 0.2229 μs | 0.2085 μs | 20.81 |    0.08 | 16.6016 |     - |     - |  34,822 B |
|              Streams | .NET 6 | .NET 6.0 | 1000 |  1000 | 19.457 μs | 0.1147 μs | 0.1073 μs |  6.80 |    0.05 |  0.4272 |     - |     - |     920 B |
|           StructLinq | .NET 6 | .NET 6.0 | 1000 |  1000 |  6.988 μs | 0.0256 μs | 0.0214 μs |  2.44 |    0.01 |  0.0610 |     - |     - |     128 B |
| StructLinq_IFunction | .NET 6 | .NET 6.0 | 1000 |  1000 |  6.647 μs | 0.0159 μs | 0.0148 μs |  2.32 |    0.01 |  0.0153 |     - |     - |      40 B |
|            Hyperlinq | .NET 6 | .NET 6.0 | 1000 |  1000 |  8.597 μs | 0.0708 μs | 0.0628 μs |  3.01 |    0.03 |  0.0153 |     - |     - |      40 B |
|  Hyperlinq_IFunction | .NET 6 | .NET 6.0 | 1000 |  1000 |  6.270 μs | 0.0351 μs | 0.0329 μs |  2.19 |    0.01 |  0.0153 |     - |     - |      40 B |
