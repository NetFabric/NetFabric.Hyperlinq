## Array.Int32.ArrayInt32WhereSelectToList

### Source
[ArrayInt32WhereSelectToList.cs](../LinqBenchmarks/Array/Int32/ArrayInt32WhereSelectToList.cs)

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
|               Method |    Job |                                                   EnvironmentVariables |  Runtime | Count |        Mean |       Error |      StdDev |      Median |  Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------- |----------------------------------------------------------------------- |--------- |------ |------------:|------------:|------------:|------------:|-------:|--------:|--------:|------:|------:|----------:|
|              ForLoop | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    239.5 ns |     4.87 ns |    10.16 ns |    234.0 ns |   1.00 |    0.00 |  0.3095 |     - |     - |     648 B |
|          ForeachLoop | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    234.5 ns |     2.02 ns |     1.79 ns |    234.0 ns |   0.92 |    0.03 |  0.3095 |     - |     - |     648 B |
|                 Linq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    578.2 ns |    11.44 ns |    14.47 ns |    583.8 ns |   2.35 |    0.15 |  0.3595 |     - |     - |     752 B |
|           LinqFaster | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    380.6 ns |     1.50 ns |     1.17 ns |    380.4 ns |   1.48 |    0.02 |  0.4473 |     - |     - |     936 B |
|               LinqAF | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    744.6 ns |     3.64 ns |     3.22 ns |    744.2 ns |   2.93 |    0.09 |  0.3090 |     - |     - |     648 B |
|        LinqOptimizer | .NET 5 |                                                                  Empty | .NET 5.0 |   100 | 54,995.4 ns | 1,529.35 ns | 4,509.31 ns | 52,081.3 ns | 228.93 |   21.22 | 14.8315 |     - |     - |  31,050 B |
|              Streams | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  1,259.9 ns |     5.08 ns |     3.96 ns |  1,260.6 ns |   4.90 |    0.06 |  0.5684 |     - |     - |   1,192 B |
|           StructLinq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    549.5 ns |     3.84 ns |     3.41 ns |    549.6 ns |   2.16 |    0.07 |  0.1755 |     - |     - |     368 B |
| StructLinq_IFunction | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    327.5 ns |     6.58 ns |    10.05 ns |    332.0 ns |   1.35 |    0.10 |  0.1297 |     - |     - |     272 B |
|            Hyperlinq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    608.5 ns |     2.64 ns |     2.34 ns |    608.1 ns |   2.39 |    0.08 |  0.1297 |     - |     - |     272 B |
|  Hyperlinq_IFunction | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |    418.6 ns |     8.32 ns |    10.82 ns |    424.7 ns |   1.71 |    0.12 |  0.1297 |     - |     - |     272 B |
|                      |        |                                                                        |          |       |             |             |             |             |        |         |         |       |       |           |
|              ForLoop | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    218.7 ns |     1.28 ns |     1.00 ns |    218.7 ns |   1.00 |    0.00 |  0.3095 |     - |     - |     648 B |
|          ForeachLoop | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    220.7 ns |     1.41 ns |     1.25 ns |    220.6 ns |   1.01 |    0.01 |  0.3097 |     - |     - |     648 B |
|                 Linq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    460.0 ns |     2.22 ns |     1.73 ns |    459.4 ns |   2.10 |    0.01 |  0.3595 |     - |     - |     752 B |
|           LinqFaster | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    384.0 ns |     2.16 ns |     3.30 ns |    383.4 ns |   1.76 |    0.02 |  0.4473 |     - |     - |     936 B |
|               LinqAF | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    593.3 ns |     2.43 ns |     2.03 ns |    593.3 ns |   2.71 |    0.01 |  0.3090 |     - |     - |     648 B |
|        LinqOptimizer | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 | 54,079.5 ns |   250.87 ns |   222.39 ns | 54,128.1 ns | 247.30 |    1.54 | 14.6484 |     - |     - |  30,792 B |
|              Streams | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  1,228.9 ns |     3.84 ns |     3.00 ns |  1,228.3 ns |   5.62 |    0.03 |  0.5684 |     - |     - |   1,192 B |
|           StructLinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    558.1 ns |     5.73 ns |     4.78 ns |    556.8 ns |   2.55 |    0.02 |  0.1755 |     - |     - |     368 B |
| StructLinq_IFunction | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    317.0 ns |     1.63 ns |     1.44 ns |    317.1 ns |   1.45 |    0.01 |  0.1297 |     - |     - |     272 B |
|            Hyperlinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    664.7 ns |     9.68 ns |     8.08 ns |    667.5 ns |   3.04 |    0.04 |  0.1297 |     - |     - |     272 B |
|  Hyperlinq_IFunction | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |    347.0 ns |     5.97 ns |     5.59 ns |    344.6 ns |   1.58 |    0.02 |  0.1297 |     - |     - |     272 B |
