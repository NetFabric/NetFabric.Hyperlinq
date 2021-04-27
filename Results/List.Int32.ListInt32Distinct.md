## List.Int32.ListInt32Distinct

### Source
[ListInt32Distinct.cs](../LinqBenchmarks/List/Int32/ListInt32Distinct.cs)

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
.NET SDK=6.0.100-preview.3.21202.5
  [Host] : .NET 5.0.4 (5.0.421.11614), X64 RyuJIT
  .NET 5 : .NET 5.0.4 (5.0.421.11614), X64 RyuJIT
  .NET 6 : .NET 6.0.0 (6.0.21.20104), X64 RyuJIT


```
|               Method |    Job |                                                   EnvironmentVariables |  Runtime | Duplicates | Count |       Mean |    Error |    StdDev |     Median | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------- |----------------------------------------------------------------------- |--------- |----------- |------ |-----------:|---------:|----------:|-----------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop | .NET 5 |                                                                  Empty | .NET 5.0 |          4 |   100 | 3,408.0 ns | 17.96 ns |  15.00 ns | 3,405.9 ns |  1.00 |    0.00 | 2.8687 |     - |     - |   6,008 B |
|          ForeachLoop | .NET 5 |                                                                  Empty | .NET 5.0 |          4 |   100 | 4,365.4 ns | 87.18 ns | 154.97 ns | 4,441.5 ns |  1.23 |    0.04 | 2.8687 |     - |     - |   6,008 B |
|                 Linq | .NET 5 |                                                                  Empty | .NET 5.0 |          4 |   100 | 7,734.5 ns | 32.71 ns |  29.00 ns | 7,733.8 ns |  2.27 |    0.01 | 2.0599 |     - |     - |   4,320 B |
|           LinqFaster | .NET 5 |                                                                  Empty | .NET 5.0 |          4 |   100 |   751.1 ns |  1.94 ns |   1.62 ns |   751.7 ns |  0.22 |    0.00 |      - |     - |     - |         - |
|               LinqAF | .NET 5 |                                                                  Empty | .NET 5.0 |          4 |   100 | 9,920.0 ns | 69.12 ns |  57.72 ns | 9,928.4 ns |  2.91 |    0.02 | 5.9204 |     - |     - |  12,400 B |
|           StructLinq | .NET 5 |                                                                  Empty | .NET 5.0 |          4 |   100 | 3,604.9 ns |  8.66 ns |   7.67 ns | 3,603.2 ns |  1.06 |    0.00 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction | .NET 5 |                                                                  Empty | .NET 5.0 |          4 |   100 | 3,497.9 ns | 18.26 ns |  16.18 ns | 3,490.2 ns |  1.03 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq | .NET 5 |                                                                  Empty | .NET 5.0 |          4 |   100 | 3,544.0 ns |  6.27 ns |   5.56 ns | 3,544.1 ns |  1.04 |    0.00 |      - |     - |     - |         - |
|                      |        |                                                                        |          |            |       |            |          |           |            |       |         |        |       |       |           |
|              ForLoop | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |          4 |   100 | 4,139.8 ns | 82.80 ns | 101.68 ns | 4,176.7 ns |  1.00 |    0.00 | 2.8610 |     - |     - |   6,000 B |
|          ForeachLoop | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |          4 |   100 | 3,869.5 ns | 50.78 ns |  47.50 ns | 3,860.8 ns |  0.94 |    0.03 | 2.8610 |     - |     - |   6,000 B |
|                 Linq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |          4 |   100 | 6,058.3 ns | 15.13 ns |  12.63 ns | 6,054.1 ns |  1.48 |    0.05 | 2.8610 |     - |     - |   6,000 B |
|           LinqFaster | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |          4 |   100 |   577.3 ns |  3.26 ns |   2.89 ns |   576.1 ns |  0.14 |    0.00 |      - |     - |     - |         - |
|               LinqAF | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |          4 |   100 | 9,996.9 ns | 59.33 ns |  52.59 ns | 9,999.3 ns |  2.43 |    0.07 | 5.9204 |     - |     - |  12,400 B |
|           StructLinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |          4 |   100 | 3,508.2 ns |  3.69 ns |   3.08 ns | 3,508.6 ns |  0.85 |    0.03 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |          4 |   100 | 3,426.5 ns |  9.68 ns |   8.58 ns | 3,422.8 ns |  0.83 |    0.03 |      - |     - |     - |         - |
|            Hyperlinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |          4 |   100 | 3,559.5 ns | 14.04 ns |  13.13 ns | 3,556.0 ns |  0.87 |    0.03 |      - |     - |     - |         - |
