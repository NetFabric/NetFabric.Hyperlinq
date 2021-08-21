## Array.Int32.ArrayInt32WhereSelect

### Source
[ArrayInt32WhereSelect.cs](../LinqBenchmarks/Array/Int32/ArrayInt32WhereSelect.cs)

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
|                   Method | Count |         Mean |      Error |    StdDev |          Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |------ |-------------:|-----------:|----------:|---------------:|--------:|--------:|------:|------:|----------:|
|                  ForLoop |   100 |     72.92 ns |   0.072 ns |  0.067 ns |       baseline |         |       - |     - |     - |         - |
|              ForeachLoop |   100 |     73.22 ns |   0.103 ns |  0.086 ns |   1.00x slower |   0.00x |       - |     - |     - |         - |
|                     Linq |   100 |    448.64 ns |   8.918 ns |  9.912 ns |   6.19x slower |   0.13x |  0.0496 |     - |     - |     104 B |
|               LinqFaster |   100 |    422.82 ns |   1.742 ns |  1.360 ns |   5.80x slower |   0.02x |  0.3171 |     - |     - |     664 B |
|             LinqFasterer |   100 |    733.68 ns |   2.027 ns |  1.692 ns |  10.06x slower |   0.02x |  0.4129 |     - |     - |     864 B |
|                   LinqAF |   100 |    315.53 ns |   2.817 ns |  2.635 ns |   4.33x slower |   0.04x |       - |     - |     - |         - |
|            LinqOptimizer |   100 | 46,013.04 ns | 107.451 ns | 95.252 ns | 630.97x slower |   1.54x | 14.2212 |     - |     - |  29,776 B |
|                 SpanLinq |   100 |    362.15 ns |   0.381 ns |  0.356 ns |   4.97x slower |   0.01x |       - |     - |     - |         - |
|                  Streams |   100 |  1,590.29 ns |  30.873 ns | 27.368 ns |  21.81x slower |   0.37x |  0.3510 |     - |     - |     736 B |
|               StructLinq |   100 |    352.71 ns |   1.086 ns |  0.962 ns |   4.84x slower |   0.01x |  0.0305 |     - |     - |      64 B |
| StructLinq_ValueDelegate |   100 |    196.19 ns |   0.070 ns |  0.054 ns |   2.69x slower |   0.00x |       - |     - |     - |         - |
|                Hyperlinq |   100 |    335.88 ns |   0.528 ns |  0.493 ns |   4.61x slower |   0.01x |       - |     - |     - |         - |
|  Hyperlinq_ValueDelegate |   100 |    228.79 ns |   0.183 ns |  0.162 ns |   3.14x slower |   0.00x |       - |     - |     - |         - |
