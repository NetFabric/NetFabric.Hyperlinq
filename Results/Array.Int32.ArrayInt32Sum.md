## Array.Int32.ArrayInt32Sum

### Source
[ArrayInt32Sum.cs](../LinqBenchmarks/Array/Int32/ArrayInt32Sum.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqFasterer: [2.1.0](https://www.nuget.org/packages/LinqFasterer/2.1.0)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- LinqOptimizer.CSharp: [0.7.0](https://www.nuget.org/packages/LinqOptimizer.CSharp/0.7.0)
- SpanLinq: [0.0.1](https://www.nuget.org/packages/SpanLinq/0.0.1)
- Streams.CSharp: [0.6.0](https://www.nuget.org/packages/Streams.CSharp/0.6.0)
- StructLinq.BCL: [0.27.0](https://www.nuget.org/packages/StructLinq/0.27.0)
- NetFabric.Hyperlinq: [3.0.0-beta46](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta46)
- System.Linq.Async: [5.0.0](https://www.nuget.org/packages/System.Linq.Async/5.0.0)

### Results:
``` ini

BenchmarkDotNet=v0.13.1, OS=macOS Catalina 10.15.7 (19H1417) [Darwin 19.6.0]
Intel Core i5-7360U CPU 2.30GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-rc.1.21458.32
  [Host]     : .NET 5.0.6 (5.0.621.22011), X64 RyuJIT
  .NET 6 PGO : .NET 6.0.0 (6.0.21.45113), X64 RyuJIT

Job=.NET 6 PGO  EnvironmentVariables=COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1  Runtime=.NET 6.0  

```
|                   Method | Count |         Mean |     Error |    StdDev |          Ratio | RatioSD |  Gen 0 | Allocated |
|------------------------- |------ |-------------:|----------:|----------:|---------------:|--------:|-------:|----------:|
|                  ForLoop |   100 |     47.35 ns |  0.067 ns |  0.063 ns |       baseline |         |      - |         - |
|              ForeachLoop |   100 |     47.85 ns |  0.039 ns |  0.035 ns |   1.01x slower |   0.00x |      - |         - |
|                     Linq |   100 |    217.18 ns |  0.516 ns |  0.457 ns |   4.59x slower |   0.01x | 0.0153 |      32 B |
|               LinqFaster |   100 |     54.06 ns |  0.028 ns |  0.024 ns |   1.14x slower |   0.00x |      - |         - |
|          LinqFaster_SIMD |   100 |     12.74 ns |  0.014 ns |  0.011 ns |   3.72x faster |   0.00x |      - |         - |
|             LinqFasterer |   100 |     65.90 ns |  0.139 ns |  0.123 ns |   1.39x slower |   0.00x |      - |         - |
|                   LinqAF |   100 |     94.23 ns |  0.040 ns |  0.035 ns |   1.99x slower |   0.00x |      - |         - |
|            LinqOptimizer |   100 | 21,689.47 ns | 76.390 ns | 71.455 ns | 458.10x slower |   1.68x | 7.6599 |  16,071 B |
|                  Streams |   100 |    197.01 ns |  0.629 ns |  0.588 ns |   4.16x slower |   0.01x | 0.0994 |     208 B |
|               StructLinq |   100 |     81.09 ns |  0.126 ns |  0.105 ns |   1.71x slower |   0.00x | 0.0153 |      32 B |
| StructLinq_ValueDelegate |   100 |     66.85 ns |  0.053 ns |  0.044 ns |   1.41x slower |   0.00x |      - |         - |
|                Hyperlinq |   100 |     20.30 ns |  0.406 ns |  0.360 ns |   2.33x faster |   0.04x |      - |         - |
