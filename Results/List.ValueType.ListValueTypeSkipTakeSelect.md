## List.ValueType.ListValueTypeSkipTakeSelect

### Source
[ListValueTypeSkipTakeSelect.cs](../LinqBenchmarks/List/ValueType/ListValueTypeSkipTakeSelect.cs)

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
|                      Method |    Job |  Runtime | Skip | Count |      Mean |    Error |   StdDev |    Median | Ratio | RatioSD |   Gen 0 |   Gen 1 | Gen 2 | Allocated |
|---------------------------- |------- |--------- |----- |------ |----------:|---------:|---------:|----------:|------:|--------:|--------:|--------:|------:|----------:|
|                     ForLoop | .NET 5 | .NET 5.0 | 1000 |  1000 |  18.28 μs | 0.058 μs | 0.052 μs |  18.29 μs |  1.00 |    0.00 |       - |       - |     - |         - |
|                 ForeachLoop | .NET 5 | .NET 5.0 | 1000 |  1000 |  23.20 μs | 0.077 μs | 0.064 μs |  23.20 μs |  1.27 |    0.01 |  0.0305 |       - |     - |      96 B |
|                        Linq | .NET 5 | .NET 5.0 | 1000 |  1000 |  26.05 μs | 0.083 μs | 0.073 μs |  26.05 μs |  1.42 |    0.01 |  0.1526 |       - |     - |     320 B |
|                  LinqFaster | .NET 5 | .NET 5.0 | 1000 |  1000 |  51.02 μs | 1.013 μs | 2.740 μs |  49.68 μs |  2.76 |    0.08 | 90.8813 |       - |     - | 192,168 B |
|                      LinqAF | .NET 5 | .NET 5.0 | 1000 |  1000 |  51.78 μs | 0.792 μs | 0.741 μs |  51.89 μs |  2.83 |    0.04 |       - |       - |     - |         - |
|               LinqOptimizer | .NET 5 | .NET 5.0 | 1000 |  1000 | 108.34 μs | 1.133 μs | 1.060 μs | 108.03 μs |  5.92 |    0.07 | 95.2148 | 23.6816 |     - | 219,938 B |
|                     Streams | .NET 5 | .NET 5.0 | 1000 |  1000 | 131.33 μs | 2.583 μs | 4.022 μs | 132.63 μs |  7.04 |    0.25 |  0.4883 |       - |     - |   1,176 B |
|                  StructLinq | .NET 5 | .NET 5.0 | 1000 |  1000 |  18.80 μs | 0.033 μs | 0.026 μs |  18.80 μs |  1.03 |    0.00 |  0.0305 |       - |     - |     120 B |
|        StructLinq_IFunction | .NET 5 | .NET 5.0 | 1000 |  1000 |  18.08 μs | 0.061 μs | 0.051 μs |  18.07 μs |  0.99 |    0.00 |       - |       - |     - |         - |
|           Hyperlinq_Foreach | .NET 5 | .NET 5.0 | 1000 |  1000 |  19.71 μs | 0.069 μs | 0.061 μs |  19.70 μs |  1.08 |    0.01 |       - |       - |     - |         - |
| Hyperlinq_Foreach_IFunction | .NET 5 | .NET 5.0 | 1000 |  1000 |  17.31 μs | 0.083 μs | 0.074 μs |  17.32 μs |  0.95 |    0.00 |       - |       - |     - |         - |
|               Hyperlinq_For | .NET 5 | .NET 5.0 | 1000 |  1000 |  19.56 μs | 0.044 μs | 0.036 μs |  19.55 μs |  1.07 |    0.00 |       - |       - |     - |         - |
|     Hyperlinq_For_IFunction | .NET 5 | .NET 5.0 | 1000 |  1000 |  17.30 μs | 0.043 μs | 0.038 μs |  17.29 μs |  0.95 |    0.00 |       - |       - |     - |         - |
|                             |        |          |      |       |           |          |          |           |       |         |         |         |       |           |
|                     ForLoop | .NET 6 | .NET 6.0 | 1000 |  1000 |  18.02 μs | 0.106 μs | 0.094 μs |  18.02 μs |  1.00 |    0.00 |       - |       - |     - |         - |
|                 ForeachLoop | .NET 6 | .NET 6.0 | 1000 |  1000 |  23.10 μs | 0.111 μs | 0.093 μs |  23.10 μs |  1.28 |    0.01 |  0.0305 |       - |     - |      96 B |
|                        Linq | .NET 6 | .NET 6.0 | 1000 |  1000 |  23.72 μs | 0.106 μs | 0.083 μs |  23.70 μs |  1.32 |    0.01 |  0.1526 |       - |     - |     320 B |
|                  LinqFaster | .NET 6 | .NET 6.0 | 1000 |  1000 |  51.27 μs | 1.021 μs | 2.524 μs |  50.43 μs |  2.74 |    0.08 | 90.8813 |       - |     - | 192,168 B |
|                      LinqAF | .NET 6 | .NET 6.0 | 1000 |  1000 |  58.94 μs | 1.068 μs | 0.999 μs |  59.20 μs |  3.28 |    0.03 |       - |       - |     - |         - |
|               LinqOptimizer | .NET 6 | .NET 6.0 | 1000 |  1000 | 126.23 μs | 1.184 μs | 1.108 μs | 126.17 μs |  7.01 |    0.07 | 95.9473 | 19.0430 |     - | 219,476 B |
|                     Streams | .NET 6 | .NET 6.0 | 1000 |  1000 | 120.71 μs | 0.784 μs | 0.655 μs | 120.62 μs |  6.70 |    0.05 |  0.4883 |       - |     - |   1,177 B |
|                  StructLinq | .NET 6 | .NET 6.0 | 1000 |  1000 |  18.58 μs | 0.059 μs | 0.052 μs |  18.57 μs |  1.03 |    0.01 |  0.0305 |       - |     - |     120 B |
|        StructLinq_IFunction | .NET 6 | .NET 6.0 | 1000 |  1000 |  18.15 μs | 0.073 μs | 0.068 μs |  18.15 μs |  1.01 |    0.01 |       - |       - |     - |         - |
|           Hyperlinq_Foreach | .NET 6 | .NET 6.0 | 1000 |  1000 |  19.72 μs | 0.193 μs | 0.161 μs |  19.67 μs |  1.09 |    0.01 |       - |       - |     - |         - |
| Hyperlinq_Foreach_IFunction | .NET 6 | .NET 6.0 | 1000 |  1000 |  17.45 μs | 0.065 μs | 0.057 μs |  17.44 μs |  0.97 |    0.01 |       - |       - |     - |         - |
|               Hyperlinq_For | .NET 6 | .NET 6.0 | 1000 |  1000 |  19.79 μs | 0.056 μs | 0.053 μs |  19.78 μs |  1.10 |    0.00 |       - |       - |     - |         - |
|     Hyperlinq_For_IFunction | .NET 6 | .NET 6.0 | 1000 |  1000 |  17.39 μs | 0.069 μs | 0.061 μs |  17.41 μs |  0.96 |    0.01 |       - |       - |     - |         - |
