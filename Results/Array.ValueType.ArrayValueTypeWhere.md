## Array.ValueType.ArrayValueTypeWhere

### Source
[ArrayValueTypeWhere.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhere.cs)

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
|                   Method | Count |        Mean |     Error |    StdDev | Ratio | RatioSD |   Gen 0 |   Gen 1 | Gen 2 | Allocated |
|------------------------- |------ |------------:|----------:|----------:|------:|--------:|--------:|--------:|------:|----------:|
|                  ForLoop |   100 |    502.5 ns |   2.02 ns |   1.58 ns |  1.00 |    0.00 |       - |       - |     - |         - |
|              ForeachLoop |   100 |    587.6 ns |   2.37 ns |   2.10 ns |  1.17 |    0.01 |       - |       - |     - |         - |
|                     Linq |   100 |  1,035.9 ns |  12.30 ns |  10.90 ns |  2.06 |    0.02 |  0.0496 |       - |     - |     104 B |
|               LinqFaster |   100 |  1,362.7 ns |  20.49 ns |  18.16 ns |  2.71 |    0.03 |  4.7264 |       - |     - |   9,904 B |
|             LinqFasterer |   100 |  2,185.5 ns |  35.34 ns |  33.05 ns |  4.34 |    0.06 |  3.0022 |       - |     - |   6,296 B |
|                   LinqAF |   100 |  2,398.7 ns |   7.28 ns |   6.45 ns |  4.77 |    0.02 |       - |       - |     - |         - |
|            LinqOptimizer |   100 | 43,785.6 ns | 448.88 ns | 419.88 ns | 87.26 |    0.72 | 68.7256 | 18.6768 |     - | 154,078 B |
|                  Streams |   100 |  1,994.3 ns |  39.55 ns |  38.85 ns |  3.94 |    0.06 |  0.3929 |       - |     - |     824 B |
|               StructLinq |   100 |    668.5 ns |   5.21 ns |   4.35 ns |  1.33 |    0.01 |  0.0153 |       - |     - |      32 B |
| StructLinq_ValueDelegate |   100 |    581.6 ns |   1.85 ns |   1.64 ns |  1.16 |    0.00 |       - |       - |     - |         - |
|                Hyperlinq |   100 |  1,084.0 ns |   3.55 ns |   3.15 ns |  2.16 |    0.01 |       - |       - |     - |         - |
|  Hyperlinq_ValueDelegate |   100 |    814.6 ns |   2.76 ns |   2.45 ns |  1.62 |    0.01 |       - |       - |     - |         - |
