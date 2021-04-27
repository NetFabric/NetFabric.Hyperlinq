## Enumerable.Int32.EnumerableInt32SkipTakeWhere

### Source
[EnumerableInt32SkipTakeWhere.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32SkipTakeWhere.cs)

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
|               Method |    Job |                                                   EnvironmentVariables |  Runtime | Skip | Count |      Mean |     Error |    StdDev | Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------- |----------------------------------------------------------------------- |--------- |----- |------ |----------:|----------:|----------:|------:|--------:|--------:|------:|------:|----------:|
|          ForeachLoop | .NET 5 |                                                                  Empty | .NET 5.0 | 1000 |   100 |  3.076 μs | 0.0096 μs | 0.0085 μs |  1.00 |    0.00 |  0.0191 |     - |     - |      40 B |
|                 Linq | .NET 5 |                                                                  Empty | .NET 5.0 | 1000 |   100 |  4.703 μs | 0.0157 μs | 0.0139 μs |  1.53 |    0.01 |  0.0992 |     - |     - |     208 B |
|               LinqAF | .NET 5 |                                                                  Empty | .NET 5.0 | 1000 |   100 |  5.088 μs | 0.0108 μs | 0.0096 μs |  1.65 |    0.00 |  0.0153 |     - |     - |      40 B |
|        LinqOptimizer | .NET 5 |                                                                  Empty | .NET 5.0 | 1000 |   100 | 62.050 μs | 0.3646 μs | 0.3232 μs | 20.17 |    0.09 | 16.1133 |     - |     - |  33,896 B |
|              Streams | .NET 5 |                                                                  Empty | .NET 5.0 | 1000 |   100 | 11.219 μs | 0.0648 μs | 0.0574 μs |  3.65 |    0.02 |  0.4272 |     - |     - |     920 B |
|           StructLinq | .NET 5 |                                                                  Empty | .NET 5.0 | 1000 |   100 |  3.724 μs | 0.0153 μs | 0.0135 μs |  1.21 |    0.01 |  0.0610 |     - |     - |     128 B |
| StructLinq_IFunction | .NET 5 |                                                                  Empty | .NET 5.0 | 1000 |   100 |  3.679 μs | 0.0094 μs | 0.0083 μs |  1.20 |    0.00 |  0.0191 |     - |     - |      40 B |
|            Hyperlinq | .NET 5 |                                                                  Empty | .NET 5.0 | 1000 |   100 |  3.544 μs | 0.0087 μs | 0.0072 μs |  1.15 |    0.00 |  0.0191 |     - |     - |      40 B |
|  Hyperlinq_IFunction | .NET 5 |                                                                  Empty | .NET 5.0 | 1000 |   100 |  3.534 μs | 0.0236 μs | 0.0210 μs |  1.15 |    0.01 |  0.0191 |     - |     - |      40 B |
|                      |        |                                                                        |          |      |       |           |           |           |       |         |         |       |       |           |
|          ForeachLoop | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 | 1000 |   100 |  2.777 μs | 0.0055 μs | 0.0048 μs |  1.00 |    0.00 |  0.0191 |     - |     - |      40 B |
|                 Linq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 | 1000 |   100 |  3.170 μs | 0.0144 μs | 0.0135 μs |  1.14 |    0.00 |  0.0992 |     - |     - |     208 B |
|               LinqAF | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 | 1000 |   100 |  3.492 μs | 0.0099 μs | 0.0088 μs |  1.26 |    0.00 |  0.0191 |     - |     - |      40 B |
|        LinqOptimizer | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 | 1000 |   100 | 54.476 μs | 0.2928 μs | 0.2595 μs | 19.62 |    0.11 | 15.9912 |     - |     - |  33,453 B |
|              Streams | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 | 1000 |   100 |  8.147 μs | 0.0198 μs | 0.0155 μs |  2.93 |    0.01 |  0.4272 |     - |     - |     920 B |
|           StructLinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 | 1000 |   100 |  2.461 μs | 0.0069 μs | 0.0064 μs |  0.89 |    0.00 |  0.0610 |     - |     - |     128 B |
| StructLinq_IFunction | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 | 1000 |   100 |  2.424 μs | 0.0160 μs | 0.0142 μs |  0.87 |    0.01 |  0.0191 |     - |     - |      40 B |
|            Hyperlinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 | 1000 |   100 |  3.735 μs | 0.0199 μs | 0.0166 μs |  1.34 |    0.01 |  0.0191 |     - |     - |      40 B |
|  Hyperlinq_IFunction | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 | 1000 |   100 |  3.410 μs | 0.0106 μs | 0.0094 μs |  1.23 |    0.00 |  0.0191 |     - |     - |      40 B |
