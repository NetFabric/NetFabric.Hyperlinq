## Array.ValueType.ArrayValueTypeWhereSelectToList

### Source
[ArrayValueTypeWhereSelectToList.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhereSelectToList.cs)

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
|               Method |    Job |                                                   EnvironmentVariables |  Runtime | Count |      Mean |     Error |    StdDev | Ratio | RatioSD |   Gen 0 |  Gen 1 | Gen 2 | Allocated |
|--------------------- |------- |----------------------------------------------------------------------- |--------- |------ |----------:|----------:|----------:|------:|--------:|--------:|-------:|------:|----------:|
|              ForLoop | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  1.191 μs | 0.0229 μs | 0.0225 μs |  1.00 |    0.00 |  3.8605 |      - |     - |      8 KB |
|          ForeachLoop | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  1.328 μs | 0.0254 μs | 0.0250 μs |  1.12 |    0.03 |  3.8605 |      - |     - |      8 KB |
|                 Linq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  1.779 μs | 0.0166 μs | 0.0147 μs |  1.49 |    0.04 |  3.9673 |      - |     - |      8 KB |
|           LinqFaster | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  1.604 μs | 0.0243 μs | 0.0227 μs |  1.35 |    0.03 |  6.4087 |      - |     - |     13 KB |
|               LinqAF | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  2.536 μs | 0.0445 μs | 0.0394 μs |  2.13 |    0.06 |  3.8605 |      - |     - |      8 KB |
|        LinqOptimizer | .NET 5 |                                                                  Empty | .NET 5.0 |   100 | 61.896 μs | 0.7378 μs | 0.6902 μs | 51.99 |    1.09 | 74.0967 | 3.6621 |     - |    157 KB |
|              Streams | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  7.638 μs | 0.0518 μs | 0.0459 μs |  6.42 |    0.14 |  4.1199 |      - |     - |      8 KB |
|           StructLinq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  1.412 μs | 0.0088 μs | 0.0078 μs |  1.19 |    0.03 |  1.7223 |      - |     - |      4 KB |
| StructLinq_IFunction | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  1.255 μs | 0.0246 μs | 0.0353 μs |  1.05 |    0.04 |  1.6766 |      - |     - |      3 KB |
|            Hyperlinq | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  1.616 μs | 0.0288 μs | 0.0270 μs |  1.36 |    0.04 |  1.6766 |      - |     - |      3 KB |
|  Hyperlinq_IFunction | .NET 5 |                                                                  Empty | .NET 5.0 |   100 |  1.302 μs | 0.0200 μs | 0.0187 μs |  1.09 |    0.03 |  1.6766 |      - |     - |      3 KB |
|                      |        |                                                                        |          |       |           |           |           |       |         |         |        |       |           |
|              ForLoop | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  1.256 μs | 0.0153 μs | 0.0144 μs |  1.00 |    0.00 |  3.8605 |      - |     - |      8 KB |
|          ForeachLoop | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  1.520 μs | 0.0216 μs | 0.0202 μs |  1.21 |    0.02 |  3.8605 |      - |     - |      8 KB |
|                 Linq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  1.631 μs | 0.0236 μs | 0.0209 μs |  1.30 |    0.02 |  3.9673 |      - |     - |      8 KB |
|           LinqFaster | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  1.678 μs | 0.0315 μs | 0.0294 μs |  1.34 |    0.03 |  6.4087 |      - |     - |     13 KB |
|               LinqAF | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  2.831 μs | 0.0500 μs | 0.0444 μs |  2.26 |    0.04 |  3.8605 |      - |     - |      8 KB |
|        LinqOptimizer | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 | 54.374 μs | 0.3094 μs | 0.2743 μs | 43.33 |    0.49 | 71.8994 | 6.7139 |     - |    157 KB |
|              Streams | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  6.917 μs | 0.0312 μs | 0.0260 μs |  5.51 |    0.05 |  4.1199 |      - |     - |      8 KB |
|           StructLinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  1.454 μs | 0.0054 μs | 0.0048 μs |  1.16 |    0.01 |  1.7223 |      - |     - |      4 KB |
| StructLinq_IFunction | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  1.330 μs | 0.0089 μs | 0.0079 μs |  1.06 |    0.01 |  1.6766 |      - |     - |      3 KB |
|            Hyperlinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  1.725 μs | 0.0252 μs | 0.0236 μs |  1.37 |    0.03 |  1.6747 |      - |     - |      3 KB |
|  Hyperlinq_IFunction | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |   100 |  1.901 μs | 0.0114 μs | 0.0107 μs |  1.51 |    0.02 |  1.6766 |      - |     - |      3 KB |
