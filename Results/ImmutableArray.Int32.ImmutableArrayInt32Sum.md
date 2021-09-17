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
- StructLinq.BCL: [0.27.0](https://www.nuget.org/packages/StructLinq/0.27.0)
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)
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
|                   Method | Count |         Mean |      Error |    StdDev |          Ratio | RatioSD |  Gen 0 | Allocated |
|------------------------- |------ |-------------:|-----------:|----------:|---------------:|--------:|-------:|----------:|
|                  ForLoop |   100 |     48.34 ns |   0.142 ns |  0.133 ns |       baseline |         |      - |         - |
|              ForeachLoop |   100 |     48.09 ns |   0.195 ns |  0.163 ns |   1.01x faster |   0.01x |      - |         - |
|                     Linq |   100 |    306.56 ns |   1.521 ns |  1.423 ns |   6.34x slower |   0.04x | 0.0267 |      56 B |
|             LinqFasterer |   100 |    148.91 ns |   0.517 ns |  0.432 ns |   3.08x slower |   0.01x | 0.2141 |     448 B |
|            LinqOptimizer |   100 | 27,335.87 ns | 110.674 ns | 98.109 ns | 565.50x slower |   2.93x | 8.3008 |  17,414 B |
|                  Streams |   100 |    420.91 ns |   1.947 ns |  1.726 ns |   8.71x slower |   0.04x | 0.1259 |     264 B |
|               StructLinq |   100 |     90.35 ns |   0.426 ns |  0.356 ns |   1.87x slower |   0.01x | 0.0153 |      32 B |
| StructLinq_ValueDelegate |   100 |     65.99 ns |   0.171 ns |  0.151 ns |   1.37x slower |   0.00x |      - |         - |
|                Hyperlinq |   100 |     21.64 ns |   0.100 ns |  0.088 ns |   2.23x faster |   0.01x |      - |         - |
