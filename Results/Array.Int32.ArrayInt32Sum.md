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
- NetFabric.Hyperlinq: [3.0.0-beta48](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta48)
- System.Linq.Async: [5.0.0](https://www.nuget.org/packages/System.Linq.Async/5.0.0)

### Results:
``` ini

BenchmarkDotNet=v0.13.1, OS=macOS Catalina 10.15.7 (19H1419) [Darwin 19.6.0]
Intel Core i5-7360U CPU 2.30GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-rc.2.21505.57
  [Host]     : .NET 5.0.6 (5.0.621.22011), X64 RyuJIT
  .NET 6 PGO : .NET 6.0.0 (6.0.21.48005), X64 RyuJIT

Job=.NET 6 PGO  EnvironmentVariables=COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1  Runtime=.NET 6.0  

```
|                   Method | Count |         Mean |     Error |    StdDev |          Ratio | RatioSD |  Gen 0 | Allocated |
|------------------------- |------ |-------------:|----------:|----------:|---------------:|--------:|-------:|----------:|
|                  ForLoop |   100 |     48.27 ns |  0.095 ns |  0.084 ns |       baseline |         |      - |         - |
|              ForeachLoop |   100 |     47.87 ns |  0.055 ns |  0.051 ns |   1.01x faster |   0.00x |      - |         - |
|                     Linq |   100 |    273.36 ns |  0.414 ns |  0.388 ns |   5.66x slower |   0.01x | 0.0153 |      32 B |
|               LinqFaster |   100 |     54.56 ns |  0.072 ns |  0.068 ns |   1.13x slower |   0.00x |      - |         - |
|          LinqFaster_SIMD |   100 |     14.37 ns |  0.021 ns |  0.020 ns |   3.36x faster |   0.01x |      - |         - |
|             LinqFasterer |   100 |     66.81 ns |  0.050 ns |  0.047 ns |   1.38x slower |   0.00x |      - |         - |
|                   LinqAF |   100 |     93.93 ns |  0.130 ns |  0.109 ns |   1.95x slower |   0.00x |      - |         - |
|            LinqOptimizer |   100 | 21,951.13 ns | 54.237 ns | 50.733 ns | 454.94x slower |   1.11x | 7.6599 |  16,071 B |
|                  Streams |   100 |    195.86 ns |  0.375 ns |  0.351 ns |   4.06x slower |   0.01x | 0.0994 |     208 B |
|               StructLinq |   100 |     80.62 ns |  0.774 ns |  0.646 ns |   1.67x slower |   0.01x | 0.0153 |      32 B |
| StructLinq_ValueDelegate |   100 |     66.37 ns |  0.057 ns |  0.053 ns |   1.37x slower |   0.00x |      - |         - |
|                Hyperlinq |   100 |     23.15 ns |  0.012 ns |  0.011 ns |   2.08x faster |   0.00x |      - |         - |
