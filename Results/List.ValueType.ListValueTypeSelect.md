## List.ValueType.ListValueTypeSelect

### Source
[ListValueTypeSelect.cs](../LinqBenchmarks/List/ValueType/ListValueTypeSelect.cs)

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
|                      Method |    Job |  Runtime | Count |      Mean |    Error |   StdDev | Ratio | RatioSD |   Gen 0 |   Gen 1 | Gen 2 | Allocated |
|---------------------------- |------- |--------- |------ |----------:|---------:|---------:|------:|--------:|--------:|--------:|------:|----------:|
|                     ForLoop | .NET 5 | .NET 5.0 |  1000 |  17.46 μs | 0.088 μs | 0.078 μs |  1.00 |    0.00 |       - |       - |     - |         - |
|                 ForeachLoop | .NET 5 | .NET 5.0 |  1000 |  19.55 μs | 0.070 μs | 0.065 μs |  1.12 |    0.01 |       - |       - |     - |         - |
|                        Linq | .NET 5 | .NET 5.0 |  1000 |  27.02 μs | 0.083 μs | 0.078 μs |  1.55 |    0.01 |  0.0610 |       - |     - |     184 B |
|                  LinqFaster | .NET 5 | .NET 5.0 |  1000 |  29.32 μs | 0.291 μs | 0.243 μs |  1.68 |    0.01 | 30.2734 |       - |     - |  64,056 B |
|                      LinqAF | .NET 5 | .NET 5.0 |  1000 |  44.99 μs | 0.354 μs | 0.314 μs |  2.58 |    0.03 |       - |       - |     - |         - |
|               LinqOptimizer | .NET 5 | .NET 5.0 |  1000 |  91.66 μs | 0.763 μs | 0.676 μs |  5.25 |    0.04 | 90.8203 | 16.7236 |     - | 215,725 B |
|                     Streams | .NET 5 | .NET 5.0 |  1000 | 108.24 μs | 0.666 μs | 0.590 μs |  6.20 |    0.05 |  0.3662 |       - |     - |     848 B |
|                  StructLinq | .NET 5 | .NET 5.0 |  1000 |  18.65 μs | 0.100 μs | 0.094 μs |  1.07 |    0.01 |       - |       - |     - |      40 B |
|        StructLinq_IFunction | .NET 5 | .NET 5.0 |  1000 |  17.44 μs | 0.044 μs | 0.037 μs |  1.00 |    0.01 |       - |       - |     - |         - |
|           Hyperlinq_Foreach | .NET 5 | .NET 5.0 |  1000 |  19.55 μs | 0.056 μs | 0.053 μs |  1.12 |    0.01 |       - |       - |     - |         - |
| Hyperlinq_Foreach_IFunction | .NET 5 | .NET 5.0 |  1000 |  17.30 μs | 0.052 μs | 0.046 μs |  0.99 |    0.01 |       - |       - |     - |         - |
|               Hyperlinq_For | .NET 5 | .NET 5.0 |  1000 |  19.60 μs | 0.080 μs | 0.071 μs |  1.12 |    0.01 |       - |       - |     - |         - |
|     Hyperlinq_For_IFunction | .NET 5 | .NET 5.0 |  1000 |  17.23 μs | 0.046 μs | 0.041 μs |  0.99 |    0.01 |       - |       - |     - |         - |
|                             |        |          |       |           |          |          |       |         |         |         |       |           |
|                     ForLoop | .NET 6 | .NET 6.0 |  1000 |  17.15 μs | 0.040 μs | 0.033 μs |  1.00 |    0.00 |       - |       - |     - |         - |
|                 ForeachLoop | .NET 6 | .NET 6.0 |  1000 |  19.24 μs | 0.055 μs | 0.049 μs |  1.12 |    0.00 |       - |       - |     - |         - |
|                        Linq | .NET 6 | .NET 6.0 |  1000 |  26.19 μs | 0.110 μs | 0.098 μs |  1.53 |    0.01 |  0.0610 |       - |     - |     184 B |
|                  LinqFaster | .NET 6 | .NET 6.0 |  1000 |  33.50 μs | 0.529 μs | 0.495 μs |  1.95 |    0.03 | 30.2734 |       - |     - |  64,056 B |
|                      LinqAF | .NET 6 | .NET 6.0 |  1000 |  34.44 μs | 0.376 μs | 0.333 μs |  2.01 |    0.02 |       - |       - |     - |         - |
|               LinqOptimizer | .NET 6 | .NET 6.0 |  1000 |  87.24 μs | 1.361 μs | 1.273 μs |  5.09 |    0.08 | 95.8252 |  6.4697 |     - | 215,291 B |
|                     Streams | .NET 6 | .NET 6.0 |  1000 | 114.59 μs | 0.858 μs | 0.760 μs |  6.68 |    0.05 |  0.3662 |       - |     - |     848 B |
|                  StructLinq | .NET 6 | .NET 6.0 |  1000 |  18.50 μs | 0.072 μs | 0.060 μs |  1.08 |    0.00 |       - |       - |     - |      40 B |
|        StructLinq_IFunction | .NET 6 | .NET 6.0 |  1000 |  17.75 μs | 0.055 μs | 0.043 μs |  1.03 |    0.00 |       - |       - |     - |         - |
|           Hyperlinq_Foreach | .NET 6 | .NET 6.0 |  1000 |  19.62 μs | 0.049 μs | 0.043 μs |  1.14 |    0.00 |       - |       - |     - |         - |
| Hyperlinq_Foreach_IFunction | .NET 6 | .NET 6.0 |  1000 |  17.37 μs | 0.267 μs | 0.223 μs |  1.01 |    0.01 |       - |       - |     - |         - |
|               Hyperlinq_For | .NET 6 | .NET 6.0 |  1000 |  19.63 μs | 0.042 μs | 0.039 μs |  1.14 |    0.00 |       - |       - |     - |         - |
|     Hyperlinq_For_IFunction | .NET 6 | .NET 6.0 |  1000 |  17.44 μs | 0.035 μs | 0.033 μs |  1.02 |    0.00 |       - |       - |     - |         - |
