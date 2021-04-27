## List.ValueType.ListValueTypeDistinct

### Source
[ListValueTypeDistinct.cs](../LinqBenchmarks/List/ValueType/ListValueTypeDistinct.cs)

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
|               Method |    Job |                                                   EnvironmentVariables |  Runtime | Duplicates | Count |      Mean |     Error |    StdDev |    Median | Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------- |----------------------------------------------------------------------- |--------- |----------- |------ |----------:|----------:|----------:|----------:|------:|--------:|--------:|------:|------:|----------:|
|              ForLoop | .NET 5 |                                                                  Empty | .NET 5.0 |          4 |   100 | 14.102 μs | 0.1019 μs | 0.1132 μs | 14.079 μs |  1.00 |    0.00 | 12.8174 |     - |     - |  26,984 B |
|          ForeachLoop | .NET 5 |                                                                  Empty | .NET 5.0 |          4 |   100 | 15.370 μs | 0.3046 μs | 0.6812 μs | 14.918 μs |  1.10 |    0.06 | 12.8174 |     - |     - |  26,984 B |
|                 Linq | .NET 5 |                                                                  Empty | .NET 5.0 |          4 |   100 | 17.952 μs | 0.0977 μs | 0.0763 μs | 17.917 μs |  1.27 |    0.01 |  9.0332 |     - |     - |  18,992 B |
|           LinqFaster | .NET 5 |                                                                  Empty | .NET 5.0 |          4 |   100 |  2.866 μs | 0.0071 μs | 0.0063 μs |  2.866 μs |  0.20 |    0.00 |  0.0114 |     - |     - |      24 B |
|               LinqAF | .NET 5 |                                                                  Empty | .NET 5.0 |          4 |   100 | 61.605 μs | 0.2325 μs | 0.2061 μs | 61.590 μs |  4.36 |    0.04 | 20.3247 |     - |     - |  42,536 B |
|           StructLinq | .NET 5 |                                                                  Empty | .NET 5.0 |          4 |   100 | 14.844 μs | 0.1457 μs | 0.1292 μs | 14.906 μs |  1.05 |    0.01 |  0.0305 |     - |     - |      64 B |
| StructLinq_IFunction | .NET 5 |                                                                  Empty | .NET 5.0 |          4 |   100 |  4.881 μs | 0.0947 μs | 0.0930 μs |  4.870 μs |  0.35 |    0.01 |       - |     - |     - |         - |
|            Hyperlinq | .NET 5 |                                                                  Empty | .NET 5.0 |          4 |   100 | 13.294 μs | 0.0412 μs | 0.0344 μs | 13.286 μs |  0.94 |    0.01 |       - |     - |     - |         - |
|                      |        |                                                                        |          |            |       |           |           |           |           |       |         |         |       |       |           |
|              ForLoop | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |          4 |   100 | 15.379 μs | 0.0691 μs | 0.0647 μs | 15.386 μs |  1.00 |    0.00 | 12.8174 |     - |     - |  26,976 B |
|          ForeachLoop | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |          4 |   100 | 14.713 μs | 0.0896 μs | 0.0699 μs | 14.733 μs |  0.96 |    0.01 | 12.8174 |     - |     - |  26,976 B |
|                 Linq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |          4 |   100 | 16.564 μs | 0.0458 μs | 0.0406 μs | 16.561 μs |  1.08 |    0.00 | 12.8174 |     - |     - |  26,912 B |
|           LinqFaster | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |          4 |   100 |  3.257 μs | 0.0069 μs | 0.0058 μs |  3.255 μs |  0.21 |    0.00 |  0.0114 |     - |     - |      24 B |
|               LinqAF | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |          4 |   100 | 51.142 μs | 0.2809 μs | 0.2490 μs | 51.147 μs |  3.33 |    0.02 | 20.5688 |     - |     - |  43,072 B |
|           StructLinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |          4 |   100 | 14.911 μs | 0.0329 μs | 0.0292 μs | 14.910 μs |  0.97 |    0.00 |  0.0305 |     - |     - |      64 B |
| StructLinq_IFunction | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |          4 |   100 |  4.937 μs | 0.0100 μs | 0.0088 μs |  4.934 μs |  0.32 |    0.00 |       - |     - |     - |         - |
|            Hyperlinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |          4 |   100 | 19.614 μs | 0.2172 μs | 0.1926 μs | 19.685 μs |  1.28 |    0.01 |       - |     - |     - |         - |
