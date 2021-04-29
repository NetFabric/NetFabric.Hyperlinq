## Array.Int32.ArrayInt32WhereCount

### Source
[ArrayInt32WhereCount.cs](../LinqBenchmarks/Array/Int32/ArrayInt32WhereCount.cs)

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
|                  ForLoop |   100 |     69.40 ns |   0.892 ns |   0.834 ns |   1.00 |    0.00 |      - |     - |     - |         - |
|              ForeachLoop |   100 |     69.08 ns |   1.071 ns |   1.002 ns |   1.00 |    0.01 |      - |     - |     - |         - |
|                     Linq |   100 |    307.74 ns |   4.049 ns |   3.589 ns |   4.44 |    0.07 | 0.0153 |     - |     - |      32 B |
|               LinqFaster |   100 |    305.41 ns |   3.482 ns |   3.257 ns |   4.40 |    0.06 |      - |     - |     - |         - |
|             LinqFasterer |   100 |    257.82 ns |   2.848 ns |   2.664 ns |   3.72 |    0.04 |      - |     - |     - |         - |
|                   LinqAF |   100 |    256.88 ns |   3.052 ns |   2.705 ns |   3.71 |    0.06 |      - |     - |     - |         - |
|            LinqOptimizer |   100 | 31,349.06 ns | 226.172 ns | 211.562 ns | 451.77 |    6.88 | 8.9722 |     - |     - |  19,066 B |
|                  Streams |   100 |    547.38 ns |   2.558 ns |   2.393 ns |   7.89 |    0.09 | 0.1717 |     - |     - |     360 B |
|               StructLinq |   100 |    271.65 ns |   2.589 ns |   2.295 ns |   3.92 |    0.05 | 0.0305 |     - |     - |      64 B |
| StructLinq_ValueDelegate |   100 |     89.41 ns |   1.442 ns |   1.349 ns |   1.29 |    0.02 |      - |     - |     - |         - |
|                Hyperlinq |   100 |    203.70 ns |   1.588 ns |   1.240 ns |   2.93 |    0.04 |      - |     - |     - |         - |
|  Hyperlinq_ValueDelegate |   100 |     89.60 ns |   0.495 ns |   0.463 ns |   1.29 |    0.02 |      - |     - |     - |         - |
