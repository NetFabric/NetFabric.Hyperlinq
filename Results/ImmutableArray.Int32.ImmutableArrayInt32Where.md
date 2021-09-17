## ImmutableArray.Int32.ImmutableArrayInt32Where

### Source
[ImmutableArrayInt32Where.cs](../LinqBenchmarks/ImmutableArray/Int32/ImmutableArrayInt32Where.cs)

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
|                   Method | Count |         Mean |      Error |     StdDev |          Ratio | RatioSD |   Gen 0 | Allocated |
|------------------------- |------ |-------------:|-----------:|-----------:|---------------:|--------:|--------:|----------:|
|                  ForLoop |   100 |     72.87 ns |   0.383 ns |   0.358 ns |       baseline |         |       - |         - |
|              ForeachLoop |   100 |     73.14 ns |   0.590 ns |   0.552 ns |   1.00x slower |   0.01x |       - |         - |
|                     Linq |   100 |    357.12 ns |   2.627 ns |   2.329 ns |   4.90x slower |   0.03x |  0.0229 |      48 B |
|             LinqFasterer |   100 |    420.13 ns |   1.869 ns |   1.748 ns |   5.77x slower |   0.04x |  0.3443 |     720 B |
|            LinqOptimizer |   100 | 47,496.56 ns | 264.803 ns | 247.697 ns | 651.77x slower |   4.30x | 13.8550 |  29,051 B |
|                  Streams |   100 |  1,254.64 ns |   4.121 ns |   3.653 ns |  17.22x slower |   0.10x |  0.2899 |     608 B |
|               StructLinq |   100 |    363.42 ns |   3.814 ns |   3.381 ns |   4.99x slower |   0.05x |  0.0153 |      32 B |
| StructLinq_ValueDelegate |   100 |    197.66 ns |   0.697 ns |   0.652 ns |   2.71x slower |   0.02x |       - |         - |
|                Hyperlinq |   100 |    329.49 ns |   5.138 ns |   4.806 ns |   4.52x slower |   0.06x |       - |         - |
|  Hyperlinq_ValueDelegate |   100 |    222.88 ns |   0.305 ns |   0.271 ns |   3.06x slower |   0.02x |       - |         - |
