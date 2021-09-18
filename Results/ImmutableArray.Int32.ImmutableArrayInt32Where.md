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
|                   Method | Count |         Mean |        Error |       StdDev |       Median |          Ratio | RatioSD |   Gen 0 | Allocated |
|------------------------- |------ |-------------:|-------------:|-------------:|-------------:|---------------:|--------:|--------:|----------:|
|                  ForLoop |   100 |     72.40 ns |     1.509 ns |     3.343 ns |     71.54 ns |       baseline |         |       - |         - |
|              ForeachLoop |   100 |     75.77 ns |     0.547 ns |     0.456 ns |     75.81 ns |   1.03x slower |   0.03x |       - |         - |
|                     Linq |   100 |    360.44 ns |     7.032 ns |    12.315 ns |    355.16 ns |   4.96x slower |   0.27x |  0.0229 |      48 B |
|             LinqFasterer |   100 |    440.20 ns |     8.866 ns |    24.420 ns |    429.97 ns |   6.14x slower |   0.45x |  0.3443 |     720 B |
|            LinqOptimizer |   100 | 52,028.36 ns | 1,177.612 ns | 3,359.793 ns | 50,604.55 ns | 723.38x slower |  61.65x | 13.8550 |  29,051 B |
|                  Streams |   100 |  1,248.99 ns |     9.993 ns |     8.344 ns |  1,246.16 ns |  16.90x slower |   0.49x |  0.2899 |     608 B |
|               StructLinq |   100 |    363.20 ns |     4.930 ns |     4.612 ns |    363.55 ns |   4.94x slower |   0.15x |  0.0153 |      32 B |
| StructLinq_ValueDelegate |   100 |    198.03 ns |     0.937 ns |     0.830 ns |    197.70 ns |   2.69x slower |   0.08x |       - |         - |
|                Hyperlinq |   100 |    333.65 ns |     6.741 ns |     7.493 ns |    332.79 ns |   4.57x slower |   0.19x |       - |         - |
|  Hyperlinq_ValueDelegate |   100 |    225.02 ns |     2.461 ns |     1.921 ns |    224.62 ns |   3.04x slower |   0.08x |       - |         - |
