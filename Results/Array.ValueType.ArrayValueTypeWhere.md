## Array.ValueType.ArrayValueTypeWhere

### Source
[ArrayValueTypeWhere.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhere.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqFasterer: [2.1.0](https://www.nuget.org/packages/LinqFasterer/2.1.0)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- LinqOptimizer.CSharp: [0.7.0](https://www.nuget.org/packages/LinqOptimizer.CSharp/0.7.0)
- SpanLinq: [0.0.1](https://www.nuget.org/packages/SpanLinq/0.0.1)
- Streams.CSharp: [0.6.0](https://www.nuget.org/packages/Streams.CSharp/0.6.0)
- StructLinq.BCL: [0.26.0](https://www.nuget.org/packages/StructLinq/0.26.0)
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)
- System.Linq.Async: [5.0.0](https://www.nuget.org/packages/System.Linq.Async/5.0.0)

### Results:
``` ini

BenchmarkDotNet=v0.13.0, OS=Windows 10.0.19043.985 (21H1/May2021Update)
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.4.21227.6
  [Host] : .NET 5.0.6 (5.0.621.22011), X64 RyuJIT
  .NET 6 : .NET 6.0.0 (6.0.21.22210), X64 RyuJIT

Job=.NET 6  EnvironmentVariables=COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1  Runtime=.NET 6.0  

```
|                   Method | Count |        Mean |     Error |    StdDev |         Ratio | RatioSD |   Gen 0 |   Gen 1 | Gen 2 | Allocated |
|------------------------- |------ |------------:|----------:|----------:|--------------:|--------:|--------:|--------:|------:|----------:|
|                  ForLoop |   100 |    523.5 ns |   2.98 ns |   2.64 ns |      baseline |         |       - |       - |     - |         - |
|              ForeachLoop |   100 |    614.4 ns |   7.56 ns |   6.70 ns |  1.17x slower |   0.01x |       - |       - |     - |         - |
|                     Linq |   100 |  1,116.5 ns |  17.25 ns |  16.13 ns |  2.14x slower |   0.03x |  0.0496 |       - |     - |     104 B |
|               LinqFaster |   100 |  1,449.0 ns |  16.22 ns |  13.55 ns |  2.77x slower |   0.03x |  4.7264 |       - |     - |   9,904 B |
|             LinqFasterer |   100 |  2,187.3 ns |  25.48 ns |  23.84 ns |  4.18x slower |   0.05x |  3.0174 |       - |     - |   6,328 B |
|                   LinqAF |   100 |  2,042.4 ns |  13.92 ns |  12.34 ns |  3.90x slower |   0.03x |       - |       - |     - |         - |
|            LinqOptimizer |   100 | 47,320.6 ns | 701.18 ns | 936.05 ns | 89.98x slower |   2.01x | 68.1763 | 22.7051 |     - | 154,077 B |
|                 SpanLinq |   100 |    838.2 ns |   2.96 ns |   2.47 ns |  1.60x slower |   0.01x |       - |       - |     - |         - |
|                  Streams |   100 |  2,038.1 ns |  39.48 ns |  49.93 ns |  3.93x slower |   0.11x |  0.3929 |       - |     - |     824 B |
|               StructLinq |   100 |    702.0 ns |   4.29 ns |   3.81 ns |  1.34x slower |   0.01x |  0.0153 |       - |     - |      32 B |
| StructLinq_ValueDelegate |   100 |    635.2 ns |   3.29 ns |   2.75 ns |  1.21x slower |   0.01x |       - |       - |     - |         - |
|                Hyperlinq |   100 |  1,124.8 ns |   4.74 ns |   4.20 ns |  2.15x slower |   0.02x |       - |       - |     - |         - |
|  Hyperlinq_ValueDelegate |   100 |    853.2 ns |  10.84 ns |   9.61 ns |  1.63x slower |   0.02x |       - |       - |     - |         - |
