## Array.Int32.ArrayInt32Contains

### Source
[ArrayInt32Contains.cs](../LinqBenchmarks/Array/Int32/ArrayInt32Contains.cs)

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
|               Method |    Job |                                                   EnvironmentVariables |  Runtime | Count |      Mean |    Error |   StdDev |    Median | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------- |----------------------------------------------------------------------- |--------- |------ |----------:|---------:|---------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  40.90 ns | 0.132 ns | 0.111 ns |  40.90 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  41.43 ns | 0.162 ns | 0.144 ns |  41.43 ns |  1.01 |    0.00 |      - |     - |     - |         - |
|                 Linq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  33.78 ns | 0.340 ns | 0.284 ns |  33.67 ns |  0.83 |    0.01 |      - |     - |     - |         - |
|           LinqFaster | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  29.00 ns | 0.060 ns | 0.056 ns |  29.00 ns |  0.71 |    0.00 |      - |     - |     - |         - |
|      LinqFaster_SIMD | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  12.92 ns | 0.045 ns | 0.040 ns |  12.91 ns |  0.32 |    0.00 |      - |     - |     - |         - |
|               LinqAF | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  27.77 ns | 0.149 ns | 0.116 ns |  27.76 ns |  0.68 |    0.00 |      - |     - |     - |         - |
|           StructLinq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  71.74 ns | 0.136 ns | 0.121 ns |  71.75 ns |  1.75 |    0.01 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction | .NET 5 |                                                                  Empty | .NET 5.0 |   100 | 110.33 ns | 0.547 ns | 0.457 ns | 110.14 ns |  2.70 |    0.02 |      - |     - |     - |         - |
|            Hyperlinq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  31.97 ns | 0.092 ns | 0.086 ns |  31.95 ns |  0.78 |    0.00 |      - |     - |     - |         - |
|       Hyperlinq_SIMD | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  25.27 ns | 0.068 ns | 0.057 ns |  25.28 ns |  0.62 |    0.00 |      - |     - |     - |         - |
|                      |        |                                                                        |          |       |           |          |          |           |       |         |        |       |       |           |
|              ForLoop | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  40.28 ns | 0.778 ns | 1.965 ns |  39.29 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  38.94 ns | 0.203 ns | 0.356 ns |  38.88 ns |  0.95 |    0.05 |      - |     - |     - |         - |
|                 Linq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  37.16 ns | 0.227 ns | 0.201 ns |  37.04 ns |  0.86 |    0.05 |      - |     - |     - |         - |
|           LinqFaster | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  32.03 ns | 0.239 ns | 0.212 ns |  31.98 ns |  0.74 |    0.04 |      - |     - |     - |         - |
|      LinqFaster_SIMD | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  12.36 ns | 0.047 ns | 0.039 ns |  12.35 ns |  0.28 |    0.02 |      - |     - |     - |         - |
|               LinqAF | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  37.20 ns | 0.109 ns | 0.102 ns |  37.15 ns |  0.87 |    0.05 |      - |     - |     - |         - |
|           StructLinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  72.08 ns | 0.361 ns | 0.302 ns |  72.06 ns |  1.66 |    0.09 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  58.36 ns | 0.168 ns | 0.131 ns |  58.37 ns |  1.33 |    0.06 |      - |     - |     - |         - |
|            Hyperlinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  35.43 ns | 0.092 ns | 0.077 ns |  35.44 ns |  0.81 |    0.04 |      - |     - |     - |         - |
|       Hyperlinq_SIMD | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  23.09 ns | 0.425 ns | 0.355 ns |  23.23 ns |  0.53 |    0.02 |      - |     - |     - |         - |
