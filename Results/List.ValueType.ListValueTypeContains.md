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
|                   Method | Count |       Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |------ |-----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|                  ForLoop |   100 |   596.5 ns |  1.18 ns |  1.05 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|              ForeachLoop |   100 |   830.6 ns | 16.51 ns | 22.04 ns |  1.40 |    0.04 |      - |     - |     - |         - |
|                     Linq |   100 |   177.9 ns |  0.84 ns |  0.70 ns |  0.30 |    0.00 |      - |     - |     - |         - |
|               LinqFaster |   100 |   197.4 ns |  1.14 ns |  1.06 ns |  0.33 |    0.00 |      - |     - |     - |         - |
|             LinqFasterer |   100 |   561.7 ns |  7.42 ns |  6.94 ns |  0.94 |    0.01 | 3.0670 |     - |     - |   6,424 B |
|                   LinqAF |   100 |   197.9 ns |  0.62 ns |  0.55 ns |  0.33 |    0.00 |      - |     - |     - |         - |
|               StructLinq |   100 | 1,535.3 ns |  3.49 ns |  3.09 ns |  2.57 |    0.01 | 0.0191 |     - |     - |      40 B |
| StructLinq_ValueDelegate |   100 |   448.7 ns |  1.75 ns |  1.46 ns |  0.75 |    0.00 |      - |     - |     - |         - |
|                Hyperlinq |   100 |   178.5 ns |  1.00 ns |  0.93 ns |  0.30 |    0.00 |      - |     - |     - |         - |
