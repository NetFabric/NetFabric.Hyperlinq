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
.NET SDK=6.0.100-preview.3.21202.5
  [Host] : .NET 5.0.4 (5.0.421.11614), X64 RyuJIT
  .NET 5 : .NET 5.0.4 (5.0.421.11614), X64 RyuJIT
  .NET 6 : .NET 6.0.0 (6.0.21.20104), X64 RyuJIT


```
|               Method |    Job |                                                   EnvironmentVariables |  Runtime | Duplicates | Count |     Mean |     Error |    StdDev |   Median | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------- |----------------------------------------------------------------------- |--------- |----------- |------ |---------:|----------:|----------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop | .NET 5 |                                                                  Empty | .NET 5.0 |          4 |   100 | 3.044 μs | 0.0248 μs | 0.0232 μs | 3.050 μs |  1.00 |    0.00 | 2.8687 |     - |     - |   6,008 B |
|          ForeachLoop | .NET 5 |                                                                  Empty | .NET 5.0 |          4 |   100 | 3.047 μs | 0.0128 μs | 0.0114 μs | 3.045 μs |  1.00 |    0.01 | 2.8687 |     - |     - |   6,008 B |
|                 Linq | .NET 5 |                                                                  Empty | .NET 5.0 |          4 |   100 | 6.550 μs | 0.0145 μs | 0.0135 μs | 6.553 μs |  2.15 |    0.02 | 2.0599 |     - |     - |   4,312 B |
|               LinqAF | .NET 5 |                                                                  Empty | .NET 5.0 |          4 |   100 | 8.712 μs | 0.0512 μs | 0.0479 μs | 8.724 μs |  2.86 |    0.03 | 5.9204 |     - |     - |  12,400 B |
|           StructLinq | .NET 5 |                                                                  Empty | .NET 5.0 |          4 |   100 | 3.379 μs | 0.0087 μs | 0.0077 μs | 3.378 μs |  1.11 |    0.01 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction | .NET 5 |                                                                  Empty | .NET 5.0 |          4 |   100 | 3.733 μs | 0.0105 μs | 0.0087 μs | 3.734 μs |  1.23 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq | .NET 5 |                                                                  Empty | .NET 5.0 |          4 |   100 | 3.478 μs | 0.0074 μs | 0.0069 μs | 3.478 μs |  1.14 |    0.01 |      - |     - |     - |         - |
|                      |        |                                                                        |          |            |       |          |           |           |          |       |         |        |       |       |           |
|              ForLoop | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |          4 |   100 | 3.508 μs | 0.0355 μs | 0.0277 μs | 3.499 μs |  1.00 |    0.00 | 2.8648 |     - |     - |   6,000 B |
|          ForeachLoop | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |          4 |   100 | 3.490 μs | 0.0666 μs | 0.1360 μs | 3.432 μs |  1.04 |    0.06 | 2.8648 |     - |     - |   6,000 B |
|                 Linq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |          4 |   100 | 4.210 μs | 0.0290 μs | 0.0257 μs | 4.214 μs |  1.20 |    0.01 | 2.8610 |     - |     - |   5,992 B |
|               LinqAF | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |          4 |   100 | 8.028 μs | 0.0275 μs | 0.0243 μs | 8.024 μs |  2.29 |    0.02 | 5.9204 |     - |     - |  12,400 B |
|           StructLinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |          4 |   100 | 3.333 μs | 0.0382 μs | 0.0299 μs | 3.322 μs |  0.95 |    0.00 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |          4 |   100 | 3.318 μs | 0.0130 μs | 0.0109 μs | 3.316 μs |  0.95 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |          4 |   100 | 3.600 μs | 0.0133 μs | 0.0118 μs | 3.602 μs |  1.03 |    0.01 |      - |     - |     - |         - |
