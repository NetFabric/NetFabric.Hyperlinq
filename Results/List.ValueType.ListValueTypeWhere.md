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
|                   Method | Count |        Mean |     Error |    StdDev |      Median | Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |------ |------------:|----------:|----------:|------------:|------:|--------:|--------:|------:|------:|----------:|
|                  ForLoop |   100 |    607.2 ns |   2.28 ns |   2.13 ns |    607.4 ns |  1.00 |    0.00 |       - |     - |     - |         - |
|              ForeachLoop |   100 |    801.5 ns |   4.66 ns |   4.13 ns |    801.7 ns |  1.32 |    0.01 |       - |     - |     - |         - |
|                     Linq |   100 |  1,358.8 ns |  16.22 ns |  15.17 ns |  1,353.1 ns |  2.24 |    0.03 |  0.0877 |     - |     - |     184 B |
|               LinqFaster |   100 |  1,528.7 ns |  30.15 ns |  79.97 ns |  1,489.2 ns |  2.69 |    0.11 |  3.8605 |     - |     - |   8,088 B |
|                   LinqAF |   100 |  1,968.2 ns |  25.73 ns |  21.49 ns |  1,961.0 ns |  3.24 |    0.04 |       - |     - |     - |         - |
|            LinqOptimizer |   100 | 49,257.1 ns | 503.98 ns | 672.80 ns | 49,237.1 ns | 80.98 |    1.12 | 73.1201 |     - |     - | 154,976 B |
|                  Streams |   100 |  2,197.5 ns |  42.51 ns |  47.25 ns |  2,216.3 ns |  3.60 |    0.07 |  0.4044 |     - |     - |     848 B |
|               StructLinq |   100 |    664.9 ns |   3.17 ns |   2.64 ns |    664.6 ns |  1.10 |    0.01 |  0.0191 |     - |     - |      40 B |
| StructLinq_ValueDelegate |   100 |    586.9 ns |   1.17 ns |   0.97 ns |    586.9 ns |  0.97 |    0.00 |       - |     - |     - |         - |
|                Hyperlinq |   100 |  1,079.2 ns |   5.14 ns |   4.81 ns |  1,077.4 ns |  1.78 |    0.01 |       - |     - |     - |         - |
|  Hyperlinq_ValueDelegate |   100 |    810.7 ns |   2.81 ns |   2.49 ns |    810.5 ns |  1.34 |    0.01 |       - |     - |     - |         - |
