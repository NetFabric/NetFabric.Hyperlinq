## Array.ValueType.ArrayValueTypeSelectSum

### Source
[ArrayValueTypeSelectSum.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeSelectSum.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- LinqOptimizer.CSharp: [](https://www.nuget.org/packages/LinqOptimizer.CSharp/)
- Streams.CSharp: [0.6.0](https://www.nuget.org/packages/Streams.CSharp/0.6.0)
- StructLinq.BCL: [0.26.0](https://www.nuget.org/packages/StructLinq/0.26.0)
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)

### Results:
``` ini

BenchmarkDotNet=v0.12.1.1527-nightly, OS=Windows 10.0.19043
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.4.21227.6
  [Host] : .NET 5.0.4 (5.0.421.11614), X64 RyuJIT
  .NET 5 : .NET 5.0.4 (5.0.421.11614), X64 RyuJIT
  .NET 6 : .NET 6.0.0 (6.0.21.22210), X64 RyuJIT


```
|               Method |    Job |                                                   EnvironmentVariables |  Runtime | Count |         Mean |        Error |       StdDev |       Median |  Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------- |----------------------------------------------------------------------- |--------- |------ |-------------:|-------------:|-------------:|-------------:|-------:|--------:|-------:|------:|------:|----------:|
|              ForLoop | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |     64.56 ns |     0.223 ns |     0.198 ns |     64.50 ns |   1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    143.47 ns |     0.759 ns |     0.710 ns |    143.34 ns |   2.22 |    0.01 |      - |     - |     - |         - |
|                 Linq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    678.36 ns |     3.452 ns |     3.060 ns |    677.54 ns |  10.51 |    0.05 | 0.0153 |     - |     - |      32 B |
|           LinqFaster | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    301.17 ns |     0.788 ns |     0.737 ns |    300.85 ns |   4.67 |    0.01 |      - |     - |     - |         - |
|               LinqAF | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    697.60 ns |    13.292 ns |    14.223 ns |    699.91 ns |  10.80 |    0.25 |      - |     - |     - |         - |
|        LinqOptimizer | .NET 5 |                                                                  Empty | .NET 5.0 |   100 | 33,324.09 ns |   140.878 ns |   124.885 ns | 33,313.61 ns | 516.21 |    2.39 | 9.0942 |     - |     - |  19,018 B |
|              Streams | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    557.87 ns |     3.285 ns |     2.912 ns |    557.71 ns |   8.64 |    0.06 | 0.1717 |     - |     - |     360 B |
|           StructLinq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    207.02 ns |     2.795 ns |     2.478 ns |    208.29 ns |   3.21 |    0.04 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |     76.22 ns |     0.248 ns |     0.220 ns |     76.21 ns |   1.18 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    474.65 ns |     1.376 ns |     1.219 ns |    474.24 ns |   7.35 |    0.03 |      - |     - |     - |         - |
|  Hyperlinq_IFunction | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    327.23 ns |     1.075 ns |     1.006 ns |    327.51 ns |   5.07 |    0.02 |      - |     - |     - |         - |
|                      |        |                                                                        |          |       |              |              |              |              |        |         |        |       |       |           |
|              ForLoop | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |     66.73 ns |     0.178 ns |     0.158 ns |     66.75 ns |   1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    143.68 ns |     0.487 ns |     0.456 ns |    143.67 ns |   2.15 |    0.01 |      - |     - |     - |         - |
|                 Linq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    540.04 ns |     7.578 ns |     6.718 ns |    542.37 ns |   8.09 |    0.10 | 0.0153 |     - |     - |      32 B |
|           LinqFaster | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    306.11 ns |     1.478 ns |     1.310 ns |    305.89 ns |   4.59 |    0.02 |      - |     - |     - |         - |
|               LinqAF | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    670.41 ns |    13.160 ns |    25.355 ns |    669.75 ns |   9.83 |    0.32 |      - |     - |     - |         - |
|        LinqOptimizer | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 | 31,679.37 ns | 1,120.145 ns | 3,141.007 ns | 29,785.36 ns | 512.80 |   22.65 | 9.0332 |     - |     - |  18,930 B |
|              Streams | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    569.48 ns |     4.052 ns |     3.592 ns |    568.78 ns |   8.53 |    0.04 | 0.1717 |     - |     - |     360 B |
|           StructLinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    207.78 ns |     2.513 ns |     1.962 ns |    207.17 ns |   3.11 |    0.03 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |     80.91 ns |     0.243 ns |     0.216 ns |     80.92 ns |   1.21 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    477.42 ns |     1.638 ns |     1.532 ns |    477.28 ns |   7.15 |    0.02 |      - |     - |     - |         - |
|  Hyperlinq_IFunction | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    332.83 ns |     1.084 ns |     0.961 ns |    332.54 ns |   4.99 |    0.02 |      - |     - |     - |         - |
