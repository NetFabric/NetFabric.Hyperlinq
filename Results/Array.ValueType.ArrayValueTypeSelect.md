## Array.ValueType.ArrayValueTypeSelect

### Source
[ArrayValueTypeSelect.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeSelect.cs)

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
|                      Method |    Job |  Runtime | Count |      Mean |    Error |   StdDev |    Median | Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------- |------- |--------- |------ |----------:|---------:|---------:|----------:|------:|--------:|--------:|------:|------:|----------:|
|                     ForLoop | .NET 5 | .NET 5.0 |  1000 |  16.31 μs | 0.024 μs | 0.022 μs |  16.32 μs |  1.00 |    0.00 |       - |     - |     - |         - |
|                 ForeachLoop | .NET 5 | .NET 5.0 |  1000 |  17.65 μs | 0.054 μs | 0.050 μs |  17.66 μs |  1.08 |    0.00 |       - |     - |     - |         - |
|                        Linq | .NET 5 | .NET 5.0 |  1000 |  22.57 μs | 0.077 μs | 0.068 μs |  22.55 μs |  1.38 |    0.00 |  0.0305 |     - |     - |     104 B |
|                  LinqFaster | .NET 5 | .NET 5.0 |  1000 |  25.34 μs | 0.501 μs | 1.140 μs |  24.90 μs |  1.59 |    0.07 | 30.2734 |     - |     - |  64,024 B |
|                      LinqAF | .NET 5 | .NET 5.0 |  1000 |  38.71 μs | 0.080 μs | 0.071 μs |  38.70 μs |  2.37 |    0.01 |       - |     - |     - |         - |
|               LinqOptimizer | .NET 5 | .NET 5.0 |  1000 |  97.62 μs | 0.624 μs | 0.521 μs |  97.75 μs |  5.98 |    0.03 | 99.9756 |     - |     - | 214,521 B |
|                     Streams | .NET 5 | .NET 5.0 |  1000 | 105.02 μs | 0.362 μs | 0.303 μs | 105.01 μs |  6.44 |    0.02 |  0.3662 |     - |     - |     824 B |
|                  StructLinq | .NET 5 | .NET 5.0 |  1000 |  18.50 μs | 0.062 μs | 0.058 μs |  18.47 μs |  1.13 |    0.00 |       - |     - |     - |      32 B |
|        StructLinq_IFunction | .NET 5 | .NET 5.0 |  1000 |  17.55 μs | 0.063 μs | 0.059 μs |  17.53 μs |  1.08 |    0.00 |       - |     - |     - |         - |
|           Hyperlinq_Foreach | .NET 5 | .NET 5.0 |  1000 |  19.63 μs | 0.076 μs | 0.067 μs |  19.62 μs |  1.20 |    0.00 |       - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction | .NET 5 | .NET 5.0 |  1000 |  17.25 μs | 0.181 μs | 0.151 μs |  17.19 μs |  1.06 |    0.01 |       - |     - |     - |         - |
|               Hyperlinq_For | .NET 5 | .NET 5.0 |  1000 |  19.55 μs | 0.040 μs | 0.037 μs |  19.55 μs |  1.20 |    0.00 |       - |     - |     - |         - |
|     Hyperlinq_For_IFunction | .NET 5 | .NET 5.0 |  1000 |  17.41 μs | 0.032 μs | 0.030 μs |  17.41 μs |  1.07 |    0.00 |       - |     - |     - |         - |
|                             |        |          |       |           |          |          |           |       |         |         |       |       |           |
|                     ForLoop | .NET 6 | .NET 6.0 |  1000 |  16.43 μs | 0.052 μs | 0.046 μs |  16.43 μs |  1.00 |    0.00 |       - |     - |     - |         - |
|                 ForeachLoop | .NET 6 | .NET 6.0 |  1000 |  17.96 μs | 0.116 μs | 0.103 μs |  17.93 μs |  1.09 |    0.01 |       - |     - |     - |         - |
|                        Linq | .NET 6 | .NET 6.0 |  1000 |  21.59 μs | 0.038 μs | 0.034 μs |  21.59 μs |  1.31 |    0.00 |  0.0305 |     - |     - |     104 B |
|                  LinqFaster | .NET 6 | .NET 6.0 |  1000 |  24.32 μs | 0.232 μs | 0.205 μs |  24.33 μs |  1.48 |    0.01 | 30.2734 |     - |     - |  64,024 B |
|                      LinqAF | .NET 6 | .NET 6.0 |  1000 |  30.24 μs | 0.160 μs | 0.141 μs |  30.26 μs |  1.84 |    0.01 |       - |     - |     - |         - |
|               LinqOptimizer | .NET 6 | .NET 6.0 |  1000 |  80.87 μs | 1.039 μs | 0.868 μs |  80.95 μs |  4.92 |    0.06 | 99.9756 |     - |     - | 214,273 B |
|                     Streams | .NET 6 | .NET 6.0 |  1000 | 109.21 μs | 0.407 μs | 0.340 μs | 109.23 μs |  6.65 |    0.02 |  0.3662 |     - |     - |     824 B |
|                  StructLinq | .NET 6 | .NET 6.0 |  1000 |  18.52 μs | 0.050 μs | 0.042 μs |  18.51 μs |  1.13 |    0.00 |       - |     - |     - |      32 B |
|        StructLinq_IFunction | .NET 6 | .NET 6.0 |  1000 |  18.27 μs | 0.069 μs | 0.061 μs |  18.27 μs |  1.11 |    0.01 |       - |     - |     - |         - |
|           Hyperlinq_Foreach | .NET 6 | .NET 6.0 |  1000 |  19.65 μs | 0.078 μs | 0.070 μs |  19.67 μs |  1.20 |    0.00 |       - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction | .NET 6 | .NET 6.0 |  1000 |  17.46 μs | 0.045 μs | 0.042 μs |  17.45 μs |  1.06 |    0.00 |       - |     - |     - |         - |
|               Hyperlinq_For | .NET 6 | .NET 6.0 |  1000 |  26.67 μs | 0.109 μs | 0.091 μs |  26.68 μs |  1.62 |    0.01 |       - |     - |     - |         - |
|     Hyperlinq_For_IFunction | .NET 6 | .NET 6.0 |  1000 |  17.39 μs | 0.095 μs | 0.084 μs |  17.38 μs |  1.06 |    0.01 |       - |     - |     - |         - |
