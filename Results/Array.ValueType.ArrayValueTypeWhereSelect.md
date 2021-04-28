## Array.ValueType.ArrayValueTypeWhereSelect

### Source
[ArrayValueTypeWhereSelect.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhereSelect.cs)

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
|               Method |    Job |                                                   EnvironmentVariables |  Runtime | Count |        Mean |     Error |    StdDev | Ratio | RatioSD |   Gen 0 |   Gen 1 | Gen 2 | Allocated |
|--------------------- |------- |----------------------------------------------------------------------- |--------- |------ |------------:|----------:|----------:|------:|--------:|--------:|--------:|------:|----------:|
|              ForLoop | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    906.2 ns |   2.45 ns |   2.17 ns |  1.00 |    0.00 |       - |       - |     - |         - |
|          ForeachLoop | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  1,002.4 ns |   4.09 ns |   3.63 ns |  1.11 |    0.00 |       - |       - |     - |         - |
|                 Linq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  1,677.3 ns |  12.04 ns |  10.05 ns |  1.85 |    0.01 |  0.1030 |       - |     - |     216 B |
|           LinqFaster | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  1,826.1 ns |  16.79 ns |  13.11 ns |  2.02 |    0.02 |  4.7264 |       - |     - |   9,904 B |
|               LinqAF | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  2,224.9 ns |  40.08 ns |  31.29 ns |  2.46 |    0.04 |       - |       - |     - |         - |
|        LinqOptimizer | .NET 5 |                                                                  Empty | .NET 5.0 |   100 | 60,774.8 ns | 830.07 ns | 648.07 ns | 67.08 |    0.75 | 57.6782 | 19.2261 |     - | 156,622 B |
|              Streams | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  7,188.8 ns | 139.03 ns | 154.53 ns |  7.97 |    0.19 |  0.4654 |       - |     - |     976 B |
|           StructLinq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  1,234.8 ns |   4.33 ns |   3.61 ns |  1.36 |    0.01 |  0.0305 |       - |     - |      64 B |
| StructLinq_IFunction | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  1,086.2 ns |   4.59 ns |   3.84 ns |  1.20 |    0.00 |       - |       - |     - |         - |
|            Hyperlinq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  1,536.6 ns |   4.34 ns |   3.85 ns |  1.70 |    0.01 |       - |       - |     - |         - |
|  Hyperlinq_IFunction | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  1,278.5 ns |   4.51 ns |   4.22 ns |  1.41 |    0.01 |       - |       - |     - |         - |
|                      |        |                                                                        |          |       |             |           |           |       |         |         |         |       |           |
|              ForLoop | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    909.0 ns |   1.64 ns |   1.37 ns |  1.00 |    0.00 |       - |       - |     - |         - |
|          ForeachLoop | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  1,016.4 ns |   2.64 ns |   2.47 ns |  1.12 |    0.00 |       - |       - |     - |         - |
|                 Linq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  1,575.3 ns |   7.82 ns |   7.31 ns |  1.73 |    0.01 |  0.1030 |       - |     - |     216 B |
|           LinqFaster | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  1,825.2 ns |  17.63 ns |  16.49 ns |  2.01 |    0.02 |  4.7264 |       - |     - |   9,904 B |
|               LinqAF | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  2,261.9 ns |  39.78 ns |  37.21 ns |  2.49 |    0.05 |       - |       - |     - |         - |
|        LinqOptimizer | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 | 52,579.7 ns | 879.90 ns | 686.97 ns | 57.83 |    0.73 | 73.9746 |       - |     - | 156,351 B |
|              Streams | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  7,182.0 ns |  63.90 ns |  59.77 ns |  7.88 |    0.06 |  0.4654 |       - |     - |     976 B |
|           StructLinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  1,246.7 ns |   8.81 ns |   7.81 ns |  1.37 |    0.01 |  0.0305 |       - |     - |      64 B |
| StructLinq_IFunction | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  1,062.1 ns |   5.90 ns |   5.52 ns |  1.17 |    0.01 |       - |       - |     - |         - |
|            Hyperlinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  1,576.0 ns |   6.92 ns |   6.13 ns |  1.73 |    0.01 |       - |       - |     - |         - |
|  Hyperlinq_IFunction | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  1,299.0 ns |   6.24 ns |   5.21 ns |  1.43 |    0.01 |       - |       - |     - |         - |
