## Array.ValueType.ArrayValueTypeWhereCount

### Source
[ArrayValueTypeWhereCount.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhereCount.cs)

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
|                  ForLoop |   100 |     71.18 ns |   0.667 ns |   0.591 ns |   1.00 |    0.00 |      - |     - |     - |         - |
|              ForeachLoop |   100 |    155.30 ns |   0.839 ns |   0.744 ns |   2.18 |    0.02 |      - |     - |     - |         - |
|                     Linq |   100 |    611.29 ns |  11.202 ns |   9.930 ns |   8.59 |    0.16 | 0.0153 |     - |     - |      32 B |
|               LinqFaster |   100 |    288.44 ns |   4.601 ns |   4.304 ns |   4.05 |    0.06 |      - |     - |     - |         - |
|             LinqFasterer |   100 |    223.47 ns |   2.006 ns |   1.675 ns |   3.14 |    0.03 |      - |     - |     - |         - |
|                   LinqAF |   100 |    684.54 ns |  12.757 ns |  11.933 ns |   9.61 |    0.20 |      - |     - |     - |         - |
|               StructLinq |   100 |    378.25 ns |   7.415 ns |   6.936 ns |   5.31 |    0.13 | 0.0305 |     - |     - |      64 B |
|            LinqOptimizer |   100 | 29,890.85 ns | 208.599 ns | 336.849 ns | 420.36 |    4.68 | 9.1553 |     - |     - |  19,185 B |
|                  Streams |   100 |    682.50 ns |  12.934 ns |  10.801 ns |   9.58 |    0.17 | 0.1717 |     - |     - |     360 B |
| StructLinq_ValueDelegate |   100 |    183.66 ns |   0.657 ns |   0.582 ns |   2.58 |    0.02 |      - |     - |     - |         - |
|                Hyperlinq |   100 |    501.90 ns |   2.306 ns |   2.045 ns |   7.05 |    0.07 |      - |     - |     - |         - |
|  Hyperlinq_ValueDelegate |   100 |    348.61 ns |   2.015 ns |   1.885 ns |   4.90 |    0.03 |      - |     - |     - |         - |
