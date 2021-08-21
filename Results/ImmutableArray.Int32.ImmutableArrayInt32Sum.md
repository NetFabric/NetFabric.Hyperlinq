## ImmutableArray.Int32.ImmutableArrayInt32Sum

### Source
[ImmutableArrayInt32Sum.cs](../LinqBenchmarks/ImmutableArray/Int32/ImmutableArrayInt32Sum.cs)

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
|                   Method | Count |         Mean |     Error |    StdDev |          Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |------ |-------------:|----------:|----------:|---------------:|--------:|-------:|------:|------:|----------:|
|                  ForLoop |   100 |     47.43 ns |  0.968 ns |  0.808 ns |       baseline |         |      - |     - |     - |         - |
|              ForeachLoop |   100 |     48.06 ns |  0.042 ns |  0.037 ns |   1.01x slower |   0.02x |      - |     - |     - |         - |
|                     Linq |   100 |    305.50 ns |  0.650 ns |  0.508 ns |   6.43x slower |   0.09x | 0.0267 |     - |     - |      56 B |
|             LinqFasterer |   100 |    148.36 ns |  0.673 ns |  0.597 ns |   3.13x slower |   0.06x | 0.2141 |     - |     - |     448 B |
|            LinqOptimizer |   100 | 28,199.25 ns | 80.689 ns | 71.529 ns | 594.73x slower |  10.88x | 8.3008 |     - |     - |  17,415 B |
|                  Streams |   100 |    424.77 ns |  0.294 ns |  0.275 ns |   8.96x slower |   0.16x | 0.1259 |     - |     - |     264 B |
|               StructLinq |   100 |     90.73 ns |  0.080 ns |  0.071 ns |   1.91x slower |   0.03x | 0.0153 |     - |     - |      32 B |
| StructLinq_ValueDelegate |   100 |     66.25 ns |  0.037 ns |  0.031 ns |   1.40x slower |   0.02x |      - |     - |     - |         - |
|                Hyperlinq |   100 |     21.70 ns |  0.008 ns |  0.007 ns |   2.19x faster |   0.04x |      - |     - |     - |         - |
