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
.NET SDK=6.0.100-preview.4.21227.6
  [Host] : .NET 5.0.4 (5.0.421.11614), X64 RyuJIT
  .NET 5 : .NET 5.0.4 (5.0.421.11614), X64 RyuJIT
  .NET 6 : .NET 6.0.0 (6.0.21.22210), X64 RyuJIT


```
|               Method |    Job |                                                   EnvironmentVariables |  Runtime | Duplicates | Count |      Mean |     Error |    StdDev |    Median | Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------- |----------------------------------------------------------------------- |--------- |----------- |------ |----------:|----------:|----------:|----------:|------:|--------:|--------:|------:|------:|----------:|
|              ForLoop | .NET 5 |                                                                  Empty | .NET 5.0 |          4 |   100 | 14.471 μs | 0.2875 μs | 0.6547 μs | 14.051 μs |  1.00 |    0.00 | 12.8174 |     - |     - |  26,984 B |
|          ForeachLoop | .NET 5 |                                                                  Empty | .NET 5.0 |          4 |   100 | 15.514 μs | 0.0810 μs | 0.0676 μs | 15.510 μs |  1.04 |    0.04 | 12.8174 |     - |     - |  26,984 B |
|                 Linq | .NET 5 |                                                                  Empty | .NET 5.0 |          4 |   100 | 19.421 μs | 0.3848 μs | 0.5877 μs | 19.683 μs |  1.30 |    0.06 |  9.0332 |     - |     - |  18,992 B |
|           LinqFaster | .NET 5 |                                                                  Empty | .NET 5.0 |          4 |   100 |  2.868 μs | 0.0110 μs | 0.0092 μs |  2.865 μs |  0.19 |    0.01 |  0.0114 |     - |     - |      24 B |
|               LinqAF | .NET 5 |                                                                  Empty | .NET 5.0 |          4 |   100 | 62.065 μs | 1.2277 μs | 1.3646 μs | 62.480 μs |  4.12 |    0.10 | 20.2637 |     - |     - |  42,416 B |
|           StructLinq | .NET 5 |                                                                  Empty | .NET 5.0 |          4 |   100 | 14.567 μs | 0.0579 μs | 0.0452 μs | 14.564 μs |  0.98 |    0.04 |  0.0305 |     - |     - |      64 B |
| StructLinq_IFunction | .NET 5 |                                                                  Empty | .NET 5.0 |          4 |   100 |  4.809 μs | 0.0174 μs | 0.0162 μs |  4.806 μs |  0.32 |    0.01 |       - |     - |     - |         - |
|            Hyperlinq | .NET 5 |                                                                  Empty | .NET 5.0 |          4 |   100 | 13.550 μs | 0.0649 μs | 0.0542 μs | 13.539 μs |  0.91 |    0.04 |       - |     - |     - |         - |
|                      |        |                                                                        |          |            |       |           |           |           |           |       |         |         |       |       |           |
|              ForLoop | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |          4 |   100 | 15.388 μs | 0.0689 μs | 0.0611 μs | 15.385 μs |  1.00 |    0.00 | 12.8174 |     - |     - |  26,976 B |
|          ForeachLoop | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |          4 |   100 | 14.543 μs | 0.0749 μs | 0.0664 μs | 14.555 μs |  0.95 |    0.01 | 12.8174 |     - |     - |  26,976 B |
|                 Linq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |          4 |   100 | 16.926 μs | 0.0878 μs | 0.0821 μs | 16.893 μs |  1.10 |    0.01 | 12.8174 |     - |     - |  26,912 B |
|           LinqFaster | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |          4 |   100 |  2.943 μs | 0.0410 μs | 0.0384 μs |  2.954 μs |  0.19 |    0.00 |  0.0114 |     - |     - |      24 B |
|               LinqAF | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |          4 |   100 | 64.047 μs | 0.4601 μs | 0.3592 μs | 63.974 μs |  4.16 |    0.03 | 20.2637 |     - |     - |  42,504 B |
|           StructLinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |          4 |   100 | 14.967 μs | 0.1245 μs | 0.1104 μs | 14.985 μs |  0.97 |    0.01 |  0.0305 |     - |     - |      64 B |
| StructLinq_IFunction | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |          4 |   100 |  4.973 μs | 0.0171 μs | 0.0143 μs |  4.976 μs |  0.32 |    0.00 |       - |     - |     - |         - |
|            Hyperlinq | .NET 6 | COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1 | .NET 6.0 |          4 |   100 | 19.675 μs | 0.0563 μs | 0.0499 μs | 19.681 μs |  1.28 |    0.01 |       - |     - |     - |         - |
