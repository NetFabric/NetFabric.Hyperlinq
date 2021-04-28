## Array.Int32.ArrayInt32Distinct

### Source
[ArrayInt32Distinct.cs](../LinqBenchmarks/Array/Int32/ArrayInt32Distinct.cs)

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
|               Method |    Job |                                                   EnvironmentVariables |  Runtime | Duplicates | Count |     Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------- |----------------------------------------------------------------------- |--------- |----------- |------ |---------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop | .NET 5 |                                                                  Empty | .NET 5.0 |          4 |   100 | 3.070 μs | 0.0186 μs | 0.0174 μs |  1.00 |    0.00 | 2.8687 |     - |     - |   6,008 B |
|          ForeachLoop | .NET 5 |                                                                  Empty | .NET 5.0 |          4 |   100 | 3.063 μs | 0.0148 μs | 0.0123 μs |  1.00 |    0.00 | 2.8687 |     - |     - |   6,008 B |
|                 Linq | .NET 5 |                                                                  Empty | .NET 5.0 |          4 |   100 | 6.609 μs | 0.0415 μs | 0.0346 μs |  2.15 |    0.02 | 2.0599 |     - |     - |   4,312 B |
|               LinqAF | .NET 5 |                                                                  Empty | .NET 5.0 |          4 |   100 | 8.400 μs | 0.0266 μs | 0.0222 μs |  2.74 |    0.01 | 5.9204 |     - |     - |  12,400 B |
|           StructLinq | .NET 5 |                                                                  Empty | .NET 5.0 |          4 |   100 | 3.370 μs | 0.0118 μs | 0.0110 μs |  1.10 |    0.01 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction | .NET 5 |                                                                  Empty | .NET 5.0 |          4 |   100 | 3.727 μs | 0.0120 μs | 0.0113 μs |  1.21 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq | .NET 5 |                                                                  Empty | .NET 5.0 |          4 |   100 | 3.487 μs | 0.0111 μs | 0.0098 μs |  1.14 |    0.01 |      - |     - |     - |         - |
|                      |        |                                                                        |          |            |       |          |           |           |       |         |        |       |       |           |
|              ForLoop | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |          4 |   100 | 3.476 μs | 0.0185 μs | 0.0154 μs |  1.00 |    0.00 | 2.8648 |     - |     - |   6,000 B |
|          ForeachLoop | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |          4 |   100 | 3.489 μs | 0.0175 μs | 0.0164 μs |  1.00 |    0.01 | 2.8648 |     - |     - |   6,000 B |
|                 Linq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |          4 |   100 | 4.196 μs | 0.0155 μs | 0.0137 μs |  1.21 |    0.01 | 2.8610 |     - |     - |   5,992 B |
|               LinqAF | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |          4 |   100 | 8.044 μs | 0.1151 μs | 0.0961 μs |  2.31 |    0.03 | 5.9204 |     - |     - |  12,400 B |
|           StructLinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |          4 |   100 | 3.338 μs | 0.0122 μs | 0.0114 μs |  0.96 |    0.01 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |          4 |   100 | 3.520 μs | 0.0102 μs | 0.0095 μs |  1.01 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |          4 |   100 | 3.532 μs | 0.0071 μs | 0.0059 μs |  1.02 |    0.00 |      - |     - |     - |         - |
