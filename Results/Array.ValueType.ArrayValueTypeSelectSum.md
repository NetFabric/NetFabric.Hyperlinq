## Array.ValueType.ArrayValueTypeSelectSum

### Source
[ArrayValueTypeSelectSum.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeSelectSum.cs)

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
|                   Method | Count |         Mean |      Error |     StdDev |  Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |------ |-------------:|-----------:|-----------:|-------:|--------:|-------:|------:|------:|----------:|
|                  ForLoop |   100 |     69.39 ns |   0.176 ns |   0.156 ns |   1.00 |    0.00 |      - |     - |     - |         - |
|              ForeachLoop |   100 |    150.31 ns |   0.443 ns |   0.393 ns |   2.17 |    0.01 |      - |     - |     - |         - |
|                     Linq |   100 |    563.97 ns |   9.847 ns |   9.211 ns |   8.14 |    0.14 | 0.0153 |     - |     - |      32 B |
|               LinqFaster |   100 |    318.66 ns |   1.284 ns |   1.201 ns |   4.59 |    0.02 |      - |     - |     - |         - |
|             LinqFasterer |   100 |    210.51 ns |   0.824 ns |   0.730 ns |   3.03 |    0.01 |      - |     - |     - |         - |
|                   LinqAF |   100 |    677.71 ns |  13.313 ns |  16.836 ns |   9.88 |    0.21 |      - |     - |     - |         - |
|            LinqOptimizer |   100 | 29,905.68 ns | 280.233 ns | 597.199 ns | 437.19 |   15.24 | 9.0332 |     - |     - |  18,930 B |
|                  Streams |   100 |    576.98 ns |   7.040 ns |   5.879 ns |   8.31 |    0.09 | 0.1717 |     - |     - |     360 B |
|               StructLinq |   100 |    208.76 ns |   2.080 ns |   1.624 ns |   3.01 |    0.02 | 0.0153 |     - |     - |      32 B |
| StructLinq_ValueDelegate |   100 |     76.42 ns |   0.199 ns |   0.177 ns |   1.10 |    0.00 |      - |     - |     - |         - |
|                Hyperlinq |   100 |    491.61 ns |   2.247 ns |   1.876 ns |   7.08 |    0.03 |      - |     - |     - |         - |
|  Hyperlinq_ValueDelegate |   100 |    343.43 ns |   1.226 ns |   1.147 ns |   4.95 |    0.02 |      - |     - |     - |         - |
