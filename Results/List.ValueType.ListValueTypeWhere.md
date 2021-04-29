## List.ValueType.ListValueTypeWhere

### Source
[ListValueTypeWhere.cs](../LinqBenchmarks/List/ValueType/ListValueTypeWhere.cs)

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
|                   Method | Count |        Mean |     Error |    StdDev | Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |------ |------------:|----------:|----------:|------:|--------:|--------:|------:|------:|----------:|
|                  ForLoop |   100 |    618.5 ns |   2.94 ns |   2.61 ns |  1.00 |    0.00 |       - |     - |     - |         - |
|              ForeachLoop |   100 |    820.8 ns |   4.47 ns |   3.96 ns |  1.33 |    0.01 |       - |     - |     - |         - |
|                     Linq |   100 |  1,425.8 ns |  22.87 ns |  21.39 ns |  2.31 |    0.04 |  0.0877 |     - |     - |     184 B |
|               LinqFaster |   100 |  1,633.0 ns |  30.20 ns |  25.22 ns |  2.64 |    0.04 |  3.8605 |     - |     - |   8,088 B |
|             LinqFasterer |   100 |  1,716.4 ns |  32.72 ns |  27.32 ns |  2.78 |    0.05 |  4.7379 |     - |     - |   9,936 B |
|                   LinqAF |   100 |  2,110.2 ns |  39.72 ns |  37.16 ns |  3.41 |    0.06 |       - |     - |     - |         - |
|            LinqOptimizer |   100 | 48,054.1 ns | 352.29 ns | 275.04 ns | 77.70 |    0.46 | 73.1201 |     - |     - | 154,976 B |
|                  Streams |   100 |  2,175.1 ns |  14.25 ns |  13.33 ns |  3.52 |    0.02 |  0.4044 |     - |     - |     848 B |
|               StructLinq |   100 |    681.4 ns |   5.39 ns |   5.04 ns |  1.10 |    0.01 |  0.0191 |     - |     - |      40 B |
| StructLinq_ValueDelegate |   100 |    603.3 ns |   4.25 ns |   3.77 ns |  0.98 |    0.01 |       - |     - |     - |         - |
|                Hyperlinq |   100 |  1,368.7 ns |   3.42 ns |   3.20 ns |  2.21 |    0.01 |       - |     - |     - |         - |
|  Hyperlinq_ValueDelegate |   100 |    831.1 ns |   2.56 ns |   2.39 ns |  1.34 |    0.01 |       - |     - |     - |         - |
