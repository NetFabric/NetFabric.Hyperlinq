## List.ValueType.ListValueTypeSelectSum

### Source
[ListValueTypeSelectSum.cs](../LinqBenchmarks/List/ValueType/ListValueTypeSelectSum.cs)

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
|               Method |    Job |                                                   EnvironmentVariables |  Runtime | Count |         Mean |      Error |     StdDev |       Median |  Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------- |----------------------------------------------------------------------- |--------- |------ |-------------:|-----------:|-----------:|-------------:|-------:|--------:|-------:|------:|------:|----------:|
|              ForLoop | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    219.74 ns |   0.687 ns |   0.573 ns |    219.73 ns |   1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    417.57 ns |   2.670 ns |   2.367 ns |    417.44 ns |   1.90 |    0.01 |      - |     - |     - |         - |
|                 Linq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  1,032.76 ns |   5.265 ns |   4.925 ns |  1,034.34 ns |   4.70 |    0.03 | 0.0458 |     - |     - |      96 B |
|           LinqFaster | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    429.15 ns |   1.577 ns |   1.475 ns |    428.75 ns |   1.95 |    0.01 |      - |     - |     - |         - |
|               LinqAF | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    988.71 ns |  19.469 ns |  36.568 ns |    979.54 ns |   4.44 |    0.15 |      - |     - |     - |         - |
|        LinqOptimizer | .NET 5 |                                                                  Empty | .NET 5.0 |   100 | 40,641.85 ns | 409.835 ns | 319.972 ns | 40,629.13 ns | 184.93 |    1.54 | 9.5825 |     - |     - |  20,140 B |
|              Streams | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    714.80 ns |   3.875 ns |   3.435 ns |    714.60 ns |   3.25 |    0.02 | 0.1717 |     - |     - |     360 B |
|           StructLinq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    232.33 ns |   0.763 ns |   0.677 ns |    232.50 ns |   1.06 |    0.01 | 0.0191 |     - |     - |      40 B |
| StructLinq_IFunction | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |     86.87 ns |   0.187 ns |   0.175 ns |     86.90 ns |   0.40 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    488.00 ns |   1.246 ns |   1.166 ns |    487.64 ns |   2.22 |    0.01 |      - |     - |     - |         - |
|  Hyperlinq_IFunction | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    334.46 ns |   1.069 ns |   0.948 ns |    334.39 ns |   1.52 |    0.01 |      - |     - |     - |         - |
|                      |        |                                                                        |          |       |              |            |            |              |        |         |        |       |       |           |
|              ForLoop | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    158.50 ns |   0.693 ns |   0.615 ns |    158.52 ns |   1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    414.13 ns |   2.647 ns |   2.476 ns |    413.49 ns |   2.61 |    0.02 |      - |     - |     - |         - |
|                 Linq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  1,020.65 ns |   9.143 ns |   8.552 ns |  1,016.57 ns |   6.44 |    0.05 | 0.0458 |     - |     - |      96 B |
|           LinqFaster | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    391.36 ns |   1.378 ns |   1.289 ns |    391.20 ns |   2.47 |    0.01 |      - |     - |     - |         - |
|               LinqAF | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  1,033.11 ns |  19.602 ns |  19.252 ns |  1,034.76 ns |   6.50 |    0.13 |      - |     - |     - |         - |
|        LinqOptimizer | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 | 35,750.28 ns | 300.603 ns | 281.184 ns | 35,770.64 ns | 225.47 |    2.02 | 9.4604 |     - |     - |  19,860 B |
|              Streams | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  1,184.92 ns |  65.069 ns | 191.857 ns |  1,252.48 ns |   4.62 |    0.15 | 0.1717 |     - |     - |     360 B |
|           StructLinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    235.12 ns |   1.453 ns |   1.359 ns |    235.26 ns |   1.48 |    0.01 | 0.0191 |     - |     - |      40 B |
| StructLinq_IFunction | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |     86.96 ns |   0.236 ns |   0.184 ns |     86.94 ns |   0.55 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    473.06 ns |   1.025 ns |   0.909 ns |    472.72 ns |   2.98 |    0.01 |      - |     - |     - |         - |
|  Hyperlinq_IFunction | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    331.75 ns |   1.382 ns |   1.154 ns |    331.67 ns |   2.09 |    0.01 |      - |     - |     - |         - |
