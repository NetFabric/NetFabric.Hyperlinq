## List.ValueType.ListValueTypeContains

### Source
[ListValueTypeContains.cs](../LinqBenchmarks/List/ValueType/ListValueTypeContains.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqFasterer: [2.1.0](https://www.nuget.org/packages/LinqFasterer/2.1.0)
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
  .NET 6 : .NET 6.0.0 (6.0.21.22210), X64 RyuJIT

Job=.NET 6  EnvironmentVariables=COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1  Runtime=.NET 6.0  

```
|                   Method | Count |       Mean |     Error |    StdDev |     Median | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |------ |-----------:|----------:|----------:|-----------:|------:|--------:|-------:|------:|------:|----------:|
|                  ForLoop |   100 |   668.3 ns |   2.02 ns |   1.89 ns |   667.9 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|              ForeachLoop |   100 |   825.2 ns |  14.86 ns |  13.90 ns |   825.3 ns |  1.23 |    0.02 |      - |     - |     - |         - |
|                     Linq |   100 |   174.8 ns |   0.71 ns |   0.63 ns |   174.9 ns |  0.26 |    0.00 |      - |     - |     - |         - |
|               LinqFaster |   100 |   194.7 ns |   0.59 ns |   0.52 ns |   194.8 ns |  0.29 |    0.00 |      - |     - |     - |         - |
|                   LinqAF |   100 |   176.1 ns |   0.96 ns |   0.85 ns |   176.1 ns |  0.26 |    0.00 |      - |     - |     - |         - |
|               StructLinq |   100 | 1,322.3 ns | 128.63 ns | 379.27 ns | 1,484.3 ns |  0.69 |    0.02 | 0.0191 |     - |     - |      40 B |
| StructLinq_ValueDelegate |   100 |   445.6 ns |   1.94 ns |   1.72 ns |   445.3 ns |  0.67 |    0.00 |      - |     - |     - |         - |
|                Hyperlinq |   100 |   178.8 ns |   1.17 ns |   1.03 ns |   178.4 ns |  0.27 |    0.00 |      - |     - |     - |         - |
