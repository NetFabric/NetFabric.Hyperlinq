## Array.ValueType.ArrayValueTypeDistinct

### Source
[ArrayValueTypeDistinct.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeDistinct.cs)

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
|               Method |    Job |                                                   EnvironmentVariables |  Runtime | Duplicates | Count |      Mean |     Error |    StdDev | Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------- |----------------------------------------------------------------------- |--------- |----------- |------ |----------:|----------:|----------:|------:|--------:|--------:|------:|------:|----------:|
|              ForLoop | .NET 5 |                                                                  Empty | .NET 5.0 |          4 |   100 | 12.787 μs | 0.0739 μs | 0.0986 μs |  1.00 |    0.00 | 12.8174 |     - |     - |  26,984 B |
|          ForeachLoop | .NET 5 |                                                                  Empty | .NET 5.0 |          4 |   100 | 13.255 μs | 0.0836 μs | 0.0698 μs |  1.04 |    0.01 | 12.8174 |     - |     - |  26,984 B |
|                 Linq | .NET 5 |                                                                  Empty | .NET 5.0 |          4 |   100 | 18.654 μs | 0.0617 μs | 0.0577 μs |  1.46 |    0.01 |  9.0027 |     - |     - |  18,928 B |
|               LinqAF | .NET 5 |                                                                  Empty | .NET 5.0 |          4 |   100 | 58.522 μs | 0.2259 μs | 0.2113 μs |  4.58 |    0.04 | 20.2637 |     - |     - |  42,424 B |
|           StructLinq | .NET 5 |                                                                  Empty | .NET 5.0 |          4 |   100 | 14.661 μs | 0.0415 μs | 0.0346 μs |  1.15 |    0.01 |  0.0153 |     - |     - |      56 B |
| StructLinq_IFunction | .NET 5 |                                                                  Empty | .NET 5.0 |          4 |   100 |  4.640 μs | 0.0134 μs | 0.0126 μs |  0.36 |    0.00 |       - |     - |     - |         - |
|            Hyperlinq | .NET 5 |                                                                  Empty | .NET 5.0 |          4 |   100 | 14.039 μs | 0.0403 μs | 0.0377 μs |  1.10 |    0.01 |       - |     - |     - |         - |
|                      |        |                                                                        |          |            |       |           |           |           |       |         |         |       |       |           |
|              ForLoop | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |          4 |   100 | 12.186 μs | 0.0925 μs | 0.0773 μs |  1.00 |    0.00 | 12.8174 |     - |     - |  26,976 B |
|          ForeachLoop | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |          4 |   100 | 13.027 μs | 0.1094 μs | 0.0914 μs |  1.07 |    0.01 | 12.8174 |     - |     - |  26,976 B |
|                 Linq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |          4 |   100 | 16.671 μs | 0.0792 μs | 0.0741 μs |  1.37 |    0.01 | 12.8174 |     - |     - |  26,848 B |
|               LinqAF | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |          4 |   100 | 83.361 μs | 1.6295 μs | 2.0012 μs |  6.95 |    0.12 | 20.0195 |     - |     - |  42,088 B |
|           StructLinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |          4 |   100 | 15.078 μs | 0.0536 μs | 0.0501 μs |  1.24 |    0.01 |  0.0153 |     - |     - |      56 B |
| StructLinq_IFunction | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |          4 |   100 |  5.159 μs | 0.0171 μs | 0.0151 μs |  0.42 |    0.00 |       - |     - |     - |         - |
|            Hyperlinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |          4 |   100 | 13.502 μs | 0.2439 μs | 0.2162 μs |  1.11 |    0.02 |       - |     - |     - |         - |
