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
|                  ForLoop |   100 |     67.86 ns |   1.159 ns |   1.138 ns |   1.00 |    0.00 |      - |     - |     - |         - |
|              ForeachLoop |   100 |    153.45 ns |   0.481 ns |   0.401 ns |   2.26 |    0.04 |      - |     - |     - |         - |
|                     Linq |   100 |    579.57 ns |   8.880 ns |   8.307 ns |   8.54 |    0.17 | 0.0153 |     - |     - |      32 B |
|               LinqFaster |   100 |    323.60 ns |   1.939 ns |   1.813 ns |   4.77 |    0.08 |      - |     - |     - |         - |
|             LinqFasterer |   100 |    217.40 ns |   1.403 ns |   1.171 ns |   3.20 |    0.06 |      - |     - |     - |         - |
|                   LinqAF |   100 |    702.58 ns |  12.887 ns |  13.789 ns |  10.36 |    0.21 |      - |     - |     - |         - |
|            LinqOptimizer |   100 | 30,134.16 ns | 200.837 ns | 187.863 ns | 443.99 |    7.85 | 9.0332 |     - |     - |  18,930 B |
|                  Streams |   100 |    591.98 ns |   5.650 ns |   5.285 ns |   8.72 |    0.17 | 0.1717 |     - |     - |     360 B |
|               StructLinq |   100 |    215.42 ns |   1.031 ns |   0.861 ns |   3.17 |    0.06 | 0.0153 |     - |     - |      32 B |
| StructLinq_ValueDelegate |   100 |     78.34 ns |   0.466 ns |   0.413 ns |   1.15 |    0.02 |      - |     - |     - |         - |
|                Hyperlinq |   100 |    499.47 ns |   4.164 ns |   3.477 ns |   7.35 |    0.14 |      - |     - |     - |         - |
|  Hyperlinq_ValueDelegate |   100 |    347.95 ns |   2.079 ns |   3.696 ns |   5.11 |    0.08 |      - |     - |     - |         - |
