## Array.Int32.ArrayInt32WhereCount

### Source
[ArrayInt32WhereCount.cs](../LinqBenchmarks/Array/Int32/ArrayInt32WhereCount.cs)

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
|                  ForLoop |   100 |     73.19 ns |  0.491 ns |  0.435 ns |     73.20 ns |       baseline |         |      - |     - |     - |         - |
|              ForeachLoop |   100 |     73.49 ns |  0.363 ns |  0.321 ns |     73.49 ns |   1.00x slower |   0.01x |      - |     - |     - |         - |
|                     Linq |   100 |    327.87 ns |  0.660 ns |  0.585 ns |    327.70 ns |   4.48x slower |   0.03x | 0.0153 |     - |     - |      32 B |
|               LinqFaster |   100 |    254.04 ns |  0.853 ns |  0.712 ns |    254.08 ns |   3.47x slower |   0.02x |      - |     - |     - |         - |
|             LinqFasterer |   100 |    220.14 ns |  0.516 ns |  0.403 ns |    220.00 ns |   3.01x slower |   0.02x |      - |     - |     - |         - |
|                   LinqAF |   100 |    235.74 ns |  0.505 ns |  0.422 ns |    235.66 ns |   3.22x slower |   0.02x |      - |     - |     - |         - |
|            LinqOptimizer |   100 | 32,925.01 ns | 86.000 ns | 76.237 ns | 32,905.37 ns | 449.85x slower |   2.25x | 9.0942 |     - |     - |  19,067 B |
|                 SpanLinq |   100 |    244.25 ns |  0.149 ns |  0.140 ns |    244.19 ns |   3.34x slower |   0.02x |      - |     - |     - |         - |
|                  Streams |   100 |    522.41 ns |  2.209 ns |  2.066 ns |    522.92 ns |   7.14x slower |   0.06x | 0.1717 |     - |     - |     360 B |
|               StructLinq |   100 |    295.75 ns |  0.246 ns |  0.230 ns |    295.72 ns |   4.04x slower |   0.03x | 0.0305 |     - |     - |      64 B |
| StructLinq_ValueDelegate |   100 |     92.61 ns |  0.120 ns |  0.094 ns |     92.60 ns |   1.27x slower |   0.01x |      - |     - |     - |         - |
|                Hyperlinq |   100 |    212.31 ns |  1.441 ns |  1.203 ns |    212.54 ns |   2.90x slower |   0.02x |      - |     - |     - |         - |
|  Hyperlinq_ValueDelegate |   100 |     93.83 ns |  1.929 ns |  2.144 ns |     95.30 ns |   1.30x slower |   0.02x |      - |     - |     - |         - |
