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
.NET SDK=6.0.100-preview.4.21227.6
  [Host] : .NET 5.0.4 (5.0.421.11614), X64 RyuJIT
  .NET 5 : .NET 5.0.4 (5.0.421.11614), X64 RyuJIT
  .NET 6 : .NET 6.0.0 (6.0.21.22210), X64 RyuJIT


```
|               Method |    Job |                                                   EnvironmentVariables |  Runtime | Duplicates | Count |      Mean |     Error |    StdDev |    Median | Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------- |----------------------------------------------------------------------- |--------- |----------- |------ |----------:|----------:|----------:|----------:|------:|--------:|--------:|------:|------:|----------:|
|              ForLoop | .NET 5 |                                                                  Empty | .NET 5.0 |          4 |   100 | 12.908 μs | 0.1003 μs | 0.0938 μs | 12.884 μs |  1.00 |    0.00 | 12.8174 |     - |     - |  26,984 B |
|          ForeachLoop | .NET 5 |                                                                  Empty | .NET 5.0 |          4 |   100 | 14.718 μs | 0.0593 μs | 0.0554 μs | 14.726 μs |  1.14 |    0.01 | 12.8174 |     - |     - |  26,984 B |
|                 Linq | .NET 5 |                                                                  Empty | .NET 5.0 |          4 |   100 | 17.267 μs | 0.0630 μs | 0.0559 μs | 17.272 μs |  1.34 |    0.01 |  9.0027 |     - |     - |  18,928 B |
|               LinqAF | .NET 5 |                                                                  Empty | .NET 5.0 |          4 |   100 | 79.244 μs | 0.7198 μs | 0.6011 μs | 79.064 μs |  6.14 |    0.04 | 19.8975 |     - |     - |  41,872 B |
|           StructLinq | .NET 5 |                                                                  Empty | .NET 5.0 |          4 |   100 | 14.230 μs | 0.0729 μs | 0.0609 μs | 14.238 μs |  1.10 |    0.01 |  0.0153 |     - |     - |      56 B |
| StructLinq_IFunction | .NET 5 |                                                                  Empty | .NET 5.0 |          4 |   100 |  4.871 μs | 0.0457 μs | 0.0427 μs |  4.871 μs |  0.38 |    0.00 |       - |     - |     - |         - |
|            Hyperlinq | .NET 5 |                                                                  Empty | .NET 5.0 |          4 |   100 | 12.779 μs | 0.1577 μs | 0.1317 μs | 12.727 μs |  0.99 |    0.01 |       - |     - |     - |         - |
|                      |        |                                                                        |          |            |       |           |           |           |           |       |         |         |       |       |           |
|              ForLoop | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |          4 |   100 | 12.581 μs | 0.0353 μs | 0.0295 μs | 12.578 μs |  1.00 |    0.00 | 12.8174 |     - |     - |  26,976 B |
|          ForeachLoop | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |          4 |   100 | 14.063 μs | 0.2775 μs | 0.5853 μs | 14.324 μs |  1.05 |    0.04 | 12.8174 |     - |     - |  26,976 B |
|                 Linq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |          4 |   100 | 15.610 μs | 0.1740 μs | 0.1453 μs | 15.601 μs |  1.24 |    0.01 | 12.8174 |     - |     - |  26,848 B |
|               LinqAF | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |          4 |   100 | 82.056 μs | 0.4030 μs | 0.3573 μs | 82.061 μs |  6.52 |    0.03 | 20.0195 |     - |     - |  42,090 B |
|           StructLinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |          4 |   100 | 14.906 μs | 0.0310 μs | 0.0259 μs | 14.912 μs |  1.18 |    0.00 |  0.0153 |     - |     - |      56 B |
| StructLinq_IFunction | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |          4 |   100 |  4.956 μs | 0.0510 μs | 0.0477 μs |  4.947 μs |  0.39 |    0.00 |       - |     - |     - |         - |
|            Hyperlinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |          4 |   100 | 13.295 μs | 0.0437 μs | 0.0409 μs | 13.283 μs |  1.06 |    0.00 |       - |     - |     - |         - |
