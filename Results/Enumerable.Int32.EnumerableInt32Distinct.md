## Enumerable.Int32.EnumerableInt32Distinct

### Source
[EnumerableInt32Distinct.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32Distinct.cs)

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
|               Method |    Job |                                                   EnvironmentVariables |  Runtime | Count |       Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------- |----------------------------------------------------------------------- |--------- |------ |-----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|          ForeachLoop | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |   979.9 ns | 11.60 ns | 10.28 ns |  1.00 |    0.00 | 0.1030 |     - |     - |     216 B |
|                 Linq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 | 1,498.2 ns | 20.64 ns | 18.29 ns |  1.53 |    0.03 | 0.1526 |     - |     - |     320 B |
|               LinqAF | .NET 5 |                                                                  Empty | .NET 5.0 |   100 | 2,073.9 ns | 10.82 ns |  9.04 ns |  2.12 |    0.03 | 1.2512 |     - |     - |   2,624 B |
|           StructLinq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 | 1,088.4 ns |  4.06 ns |  3.79 ns |  1.11 |    0.01 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |   956.6 ns |  4.57 ns |  3.82 ns |  0.98 |    0.01 | 0.0191 |     - |     - |      40 B |
|            Hyperlinq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 | 1,106.2 ns |  7.78 ns |  6.90 ns |  1.13 |    0.01 | 0.0191 |     - |     - |      40 B |
|                      |        |                                                                        |          |       |            |          |          |       |         |        |       |       |           |
|          ForeachLoop | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |   942.5 ns |  5.33 ns |  4.72 ns |  1.00 |    0.00 | 0.0992 |     - |     - |     208 B |
|                 Linq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |   931.8 ns |  4.07 ns |  3.60 ns |  0.99 |    0.01 | 0.1602 |     - |     - |     336 B |
|               LinqAF | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 | 1,855.8 ns | 12.21 ns | 10.20 ns |  1.97 |    0.01 | 1.2512 |     - |     - |   2,624 B |
|           StructLinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |   884.2 ns |  5.75 ns |  5.38 ns |  0.94 |    0.01 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |   837.6 ns |  2.40 ns |  2.01 ns |  0.89 |    0.00 | 0.0191 |     - |     - |      40 B |
|            Hyperlinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 | 1,028.1 ns |  9.57 ns |  7.99 ns |  1.09 |    0.01 | 0.0191 |     - |     - |      40 B |
