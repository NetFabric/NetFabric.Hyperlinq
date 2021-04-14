## Array.ValueType.ArrayValueTypeSkipTakeSelect

### Source
[ArrayValueTypeSkipTakeSelect.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeSkipTakeSelect.cs)

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
|                      Method |    Job |  Runtime | Skip | Count |      Mean |    Error |   StdDev | Ratio | RatioSD |   Gen 0 |   Gen 1 | Gen 2 | Allocated |
|---------------------------- |------- |--------- |----- |------ |----------:|---------:|---------:|------:|--------:|--------:|--------:|------:|----------:|
|                     ForLoop | .NET 5 | .NET 5.0 | 1000 |  1000 |  16.85 μs | 0.055 μs | 0.046 μs |  1.00 |    0.00 |       - |       - |     - |         - |
|                 ForeachLoop | .NET 5 | .NET 5.0 | 1000 |  1000 |  21.15 μs | 0.143 μs | 0.112 μs |  1.26 |    0.01 |       - |       - |     - |      32 B |
|                        Linq | .NET 5 | .NET 5.0 | 1000 |  1000 |  26.32 μs | 0.065 μs | 0.061 μs |  1.56 |    0.01 |  0.1526 |       - |     - |     320 B |
|                  LinqFaster | .NET 5 | .NET 5.0 | 1000 |  1000 |  33.68 μs | 0.507 μs | 0.474 μs |  2.00 |    0.03 | 90.8813 |       - |     - | 192,072 B |
|                      LinqAF | .NET 5 | .NET 5.0 | 1000 |  1000 |  42.55 μs | 0.532 μs | 0.498 μs |  2.53 |    0.03 |       - |       - |     - |         - |
|               LinqOptimizer | .NET 5 | .NET 5.0 | 1000 |  1000 |  91.68 μs | 0.729 μs | 0.682 μs |  5.43 |    0.04 | 96.6797 | 16.1133 |     - | 218,594 B |
|                     Streams | .NET 5 | .NET 5.0 | 1000 |  1000 | 119.99 μs | 0.466 μs | 0.436 μs |  7.12 |    0.03 |  0.4883 |       - |     - |   1,152 B |
|                  StructLinq | .NET 5 | .NET 5.0 | 1000 |  1000 |  18.58 μs | 0.034 μs | 0.029 μs |  1.10 |    0.00 |  0.0305 |       - |     - |      96 B |
|        StructLinq_IFunction | .NET 5 | .NET 5.0 | 1000 |  1000 |  17.53 μs | 0.041 μs | 0.037 μs |  1.04 |    0.00 |       - |       - |     - |         - |
|           Hyperlinq_Foreach | .NET 5 | .NET 5.0 | 1000 |  1000 |  19.66 μs | 0.103 μs | 0.091 μs |  1.17 |    0.01 |       - |       - |     - |         - |
| Hyperlinq_Foreach_IFunction | .NET 5 | .NET 5.0 | 1000 |  1000 |  17.23 μs | 0.039 μs | 0.035 μs |  1.02 |    0.00 |       - |       - |     - |         - |
|               Hyperlinq_For | .NET 5 | .NET 5.0 | 1000 |  1000 |  19.67 μs | 0.105 μs | 0.094 μs |  1.17 |    0.01 |       - |       - |     - |         - |
|     Hyperlinq_For_IFunction | .NET 5 | .NET 5.0 | 1000 |  1000 |  17.53 μs | 0.065 μs | 0.057 μs |  1.04 |    0.00 |       - |       - |     - |         - |
|                             |        |          |      |       |           |          |          |       |         |         |         |       |           |
|                     ForLoop | .NET 6 | .NET 6.0 | 1000 |  1000 |  16.61 μs | 0.050 μs | 0.047 μs |  1.00 |    0.00 |       - |       - |     - |         - |
|                 ForeachLoop | .NET 6 | .NET 6.0 | 1000 |  1000 |  19.45 μs | 0.047 μs | 0.039 μs |  1.17 |    0.00 |       - |       - |     - |      32 B |
|                        Linq | .NET 6 | .NET 6.0 | 1000 |  1000 |  25.15 μs | 0.122 μs | 0.108 μs |  1.51 |    0.01 |  0.1526 |       - |     - |     320 B |
|                  LinqFaster | .NET 6 | .NET 6.0 | 1000 |  1000 |  37.77 μs | 0.183 μs | 0.143 μs |  2.27 |    0.01 | 90.8813 |       - |     - | 192,072 B |
|                      LinqAF | .NET 6 | .NET 6.0 | 1000 |  1000 |  51.62 μs | 0.248 μs | 0.220 μs |  3.11 |    0.01 |       - |       - |     - |         - |
|               LinqOptimizer | .NET 6 | .NET 6.0 | 1000 |  1000 |  87.02 μs | 0.521 μs | 0.407 μs |  5.24 |    0.03 | 96.6797 | 16.1133 |     - | 218,342 B |
|                     Streams | .NET 6 | .NET 6.0 | 1000 |  1000 | 117.09 μs | 1.204 μs | 1.068 μs |  7.05 |    0.07 |  0.4883 |       - |     - |   1,152 B |
|                  StructLinq | .NET 6 | .NET 6.0 | 1000 |  1000 |  18.65 μs | 0.163 μs | 0.144 μs |  1.12 |    0.01 |  0.0305 |       - |     - |      96 B |
|        StructLinq_IFunction | .NET 6 | .NET 6.0 | 1000 |  1000 |  17.73 μs | 0.055 μs | 0.048 μs |  1.07 |    0.00 |       - |       - |     - |         - |
|           Hyperlinq_Foreach | .NET 6 | .NET 6.0 | 1000 |  1000 |  19.71 μs | 0.081 μs | 0.072 μs |  1.19 |    0.01 |       - |       - |     - |         - |
| Hyperlinq_Foreach_IFunction | .NET 6 | .NET 6.0 | 1000 |  1000 |  17.50 μs | 0.087 μs | 0.073 μs |  1.05 |    0.01 |       - |       - |     - |         - |
|               Hyperlinq_For | .NET 6 | .NET 6.0 | 1000 |  1000 |  19.81 μs | 0.060 μs | 0.054 μs |  1.19 |    0.00 |       - |       - |     - |         - |
|     Hyperlinq_For_IFunction | .NET 6 | .NET 6.0 | 1000 |  1000 |  17.29 μs | 0.045 μs | 0.042 μs |  1.04 |    0.00 |       - |       - |     - |         - |
