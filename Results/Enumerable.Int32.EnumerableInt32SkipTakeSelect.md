## Enumerable.Int32.EnumerableInt32SkipTakeSelect

### Source
[EnumerableInt32SkipTakeSelect.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32SkipTakeSelect.cs)

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
|          ForeachLoop | .NET 5 |                                                                  Empty | .NET 5.0 | 1000 |   100 |  3.058 μs | 0.0095 μs | 0.0074 μs |  1.00 |    0.00 |  0.0191 |     - |     - |      40 B |
|                 Linq | .NET 5 |                                                                  Empty | .NET 5.0 | 1000 |   100 |  4.744 μs | 0.0125 μs | 0.0105 μs |  1.55 |    0.01 |  0.0992 |     - |     - |     208 B |
|               LinqAF | .NET 5 |                                                                  Empty | .NET 5.0 | 1000 |   100 |  5.002 μs | 0.0111 μs | 0.0087 μs |  1.64 |    0.00 |  0.0153 |     - |     - |      40 B |
|        LinqOptimizer | .NET 5 |                                                                  Empty | .NET 5.0 | 1000 |   100 | 55.587 μs | 0.3061 μs | 0.2713 μs | 18.16 |    0.11 | 15.6860 |     - |     - |  33,090 B |
|              Streams | .NET 5 |                                                                  Empty | .NET 5.0 | 1000 |   100 | 10.802 μs | 0.0339 μs | 0.0301 μs |  3.53 |    0.01 |  0.4272 |     - |     - |     920 B |
|           StructLinq | .NET 5 |                                                                  Empty | .NET 5.0 | 1000 |   100 |  3.358 μs | 0.0138 μs | 0.0129 μs |  1.10 |    0.00 |  0.0610 |     - |     - |     128 B |
| StructLinq_IFunction | .NET 5 |                                                                  Empty | .NET 5.0 | 1000 |   100 |  3.420 μs | 0.0087 μs | 0.0077 μs |  1.12 |    0.00 |  0.0191 |     - |     - |      40 B |
|            Hyperlinq | .NET 5 |                                                                  Empty | .NET 5.0 | 1000 |   100 |  3.643 μs | 0.0084 μs | 0.0079 μs |  1.19 |    0.00 |  0.0191 |     - |     - |      40 B |
|  Hyperlinq_IFunction | .NET 5 |                                                                  Empty | .NET 5.0 | 1000 |   100 |  3.259 μs | 0.0076 μs | 0.0067 μs |  1.07 |    0.00 |  0.0191 |     - |     - |      40 B |
|                      |        |                                                                        |          |      |       |           |           |           |       |         |         |       |       |           |
|          ForeachLoop | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 | 1000 |   100 |  2.697 μs | 0.0113 μs | 0.0100 μs |  1.00 |    0.00 |  0.0191 |     - |     - |      40 B |
|                 Linq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 | 1000 |   100 |  3.651 μs | 0.0106 μs | 0.0099 μs |  1.35 |    0.01 |  0.0992 |     - |     - |     208 B |
|               LinqAF | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 | 1000 |   100 |  3.419 μs | 0.0133 μs | 0.0111 μs |  1.27 |    0.00 |  0.0191 |     - |     - |      40 B |
|        LinqOptimizer | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 | 1000 |   100 | 50.643 μs | 0.2153 μs | 0.1798 μs | 18.77 |    0.07 | 15.5640 |     - |     - |  32,650 B |
|              Streams | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 | 1000 |   100 |  8.494 μs | 0.0461 μs | 0.0409 μs |  3.15 |    0.02 |  0.4272 |     - |     - |     920 B |
|           StructLinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 | 1000 |   100 |  2.722 μs | 0.0147 μs | 0.0131 μs |  1.01 |    0.01 |  0.0610 |     - |     - |     128 B |
| StructLinq_IFunction | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 | 1000 |   100 |  3.388 μs | 0.0103 μs | 0.0092 μs |  1.26 |    0.01 |  0.0191 |     - |     - |      40 B |
|            Hyperlinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 | 1000 |   100 |  2.710 μs | 0.0099 μs | 0.0093 μs |  1.00 |    0.01 |  0.0191 |     - |     - |      40 B |
|  Hyperlinq_IFunction | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 | 1000 |   100 |  2.434 μs | 0.0073 μs | 0.0068 μs |  0.90 |    0.00 |  0.0191 |     - |     - |      40 B |
