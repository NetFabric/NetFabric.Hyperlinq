## List.Int32.ListInt32WhereSelect

### Source
[ListInt32WhereSelect.cs](../LinqBenchmarks/List/Int32/ListInt32WhereSelect.cs)

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
|                   Method | Count |         Mean |      Error |     StdDev |          Ratio | RatioSD |   Gen 0 | Allocated |
|------------------------- |------ |-------------:|-----------:|-----------:|---------------:|--------:|--------:|----------:|
|                  ForLoop |   100 |     78.31 ns |   0.410 ns |   0.342 ns |       baseline |         |       - |         - |
|              ForeachLoop |   100 |     86.78 ns |   0.334 ns |   0.279 ns |   1.11x slower |   0.01x |       - |         - |
|                     Linq |   100 |    541.54 ns |   3.739 ns |   3.314 ns |   6.91x slower |   0.05x |  0.0725 |     152 B |
|               LinqFaster |   100 |    564.31 ns |   4.006 ns |   3.551 ns |   7.21x slower |   0.06x |  0.3090 |     648 B |
|             LinqFasterer |   100 |    567.31 ns |   2.220 ns |   1.854 ns |   7.24x slower |   0.04x |  0.4473 |     936 B |
|                   LinqAF |   100 |    448.07 ns |   1.817 ns |   1.700 ns |   5.72x slower |   0.03x |       - |         - |
|            LinqOptimizer |   100 | 51,611.47 ns | 176.121 ns | 164.744 ns | 659.24x slower |   4.14x | 14.7095 |  30,789 B |
|                 SpanLinq |   100 |    371.86 ns |   2.098 ns |   1.962 ns |   4.75x slower |   0.03x |       - |         - |
|                  Streams |   100 |  1,591.69 ns |   5.324 ns |   4.719 ns |  20.33x slower |   0.11x |  0.3624 |     760 B |
|               StructLinq |   100 |    334.08 ns |   0.457 ns |   0.357 ns |   4.27x slower |   0.02x |  0.0305 |      64 B |
| StructLinq_ValueDelegate |   100 |    200.35 ns |   0.470 ns |   0.416 ns |   2.56x slower |   0.01x |       - |         - |
|                Hyperlinq |   100 |    377.78 ns |   2.195 ns |   1.833 ns |   4.82x slower |   0.03x |       - |         - |
|  Hyperlinq_ValueDelegate |   100 |    232.01 ns |   0.280 ns |   0.262 ns |   2.96x slower |   0.01x |       - |         - |
