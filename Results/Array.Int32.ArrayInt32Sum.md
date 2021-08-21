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
- StructLinq.BCL: [0.26.0](https://www.nuget.org/packages/StructLinq/0.26.0)
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)
- System.Linq.Async: [5.0.0](https://www.nuget.org/packages/System.Linq.Async/5.0.0)

### Results:
``` ini

BenchmarkDotNet=v0.13.0, OS=macOS Catalina 10.15.7 (19H1323) [Darwin 19.6.0]
Intel Core i5-7360U CPU 2.30GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.7.21379.14
  [Host] : .NET 5.0.6 (5.0.621.22011), X64 RyuJIT
  .NET 6 : .NET 6.0.0 (6.0.21.37719), X64 RyuJIT

Job=.NET 6  EnvironmentVariables=COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1  Runtime=.NET 6.0  

```
|                   Method | Count |         Mean |     Error |    StdDev |       Median |          Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |------ |-------------:|----------:|----------:|-------------:|---------------:|--------:|-------:|------:|------:|----------:|
|                  ForLoop |   100 |     48.52 ns |  0.177 ns |  0.148 ns |     48.51 ns |       baseline |         |      - |     - |     - |         - |
|              ForeachLoop |   100 |     48.36 ns |  0.040 ns |  0.036 ns |     48.34 ns |   1.00x faster |   0.00x |      - |     - |     - |         - |
|                     Linq |   100 |    272.73 ns |  0.250 ns |  0.208 ns |    272.71 ns |   5.62x slower |   0.02x | 0.0153 |     - |     - |      32 B |
|               LinqFaster |   100 |     54.41 ns |  0.027 ns |  0.022 ns |     54.41 ns |   1.12x slower |   0.00x |      - |     - |     - |         - |
|          LinqFaster_SIMD |   100 |     11.24 ns |  0.255 ns |  0.485 ns |     11.17 ns |   4.24x faster |   0.25x |      - |     - |     - |         - |
|             LinqFasterer |   100 |     66.76 ns |  0.070 ns |  0.062 ns |     66.76 ns |   1.38x slower |   0.00x |      - |     - |     - |         - |
|                   LinqAF |   100 |     94.22 ns |  1.692 ns |  1.413 ns |     94.62 ns |   1.94x slower |   0.03x |      - |     - |     - |         - |
|            LinqOptimizer |   100 | 21,790.31 ns | 39.183 ns | 34.735 ns | 21,787.54 ns | 449.06x slower |   1.67x | 7.6599 |     - |     - |  16,071 B |
|                  Streams |   100 |    197.62 ns |  0.166 ns |  0.130 ns |    197.63 ns |   4.07x slower |   0.01x | 0.0994 |     - |     - |     208 B |
|               StructLinq |   100 |     81.48 ns |  0.071 ns |  0.059 ns |     81.46 ns |   1.68x slower |   0.01x | 0.0153 |     - |     - |      32 B |
| StructLinq_ValueDelegate |   100 |     67.38 ns |  0.069 ns |  0.057 ns |     67.36 ns |   1.39x slower |   0.00x |      - |     - |     - |         - |
|                Hyperlinq |   100 |     21.67 ns |  0.500 ns |  0.717 ns |     21.15 ns |   2.18x faster |   0.06x |      - |     - |     - |         - |
