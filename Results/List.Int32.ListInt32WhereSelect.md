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
|                   Method | Count |         Mean |      Error |     StdDev |          Ratio | RatioSD |   Gen 0 | Allocated |
|------------------------- |------ |-------------:|-----------:|-----------:|---------------:|--------:|--------:|----------:|
|                  ForLoop |   100 |     93.59 ns |   0.328 ns |   0.291 ns |       baseline |         |       - |         - |
|              ForeachLoop |   100 |     91.13 ns |   0.328 ns |   0.291 ns |   1.03x faster |   0.00x |       - |         - |
|                     Linq |   100 |    492.45 ns |   2.320 ns |   1.937 ns |   5.26x slower |   0.03x |  0.0725 |     152 B |
|               LinqFaster |   100 |    546.50 ns |   2.531 ns |   2.244 ns |   5.84x slower |   0.03x |  0.3090 |     648 B |
|             LinqFasterer |   100 |    536.82 ns |   2.825 ns |   2.643 ns |   5.73x slower |   0.04x |  0.4473 |     936 B |
|                   LinqAF |   100 |    444.56 ns |   1.244 ns |   1.103 ns |   4.75x slower |   0.02x |       - |         - |
|            LinqOptimizer |   100 | 51,183.19 ns | 187.787 ns | 175.656 ns | 546.88x slower |   2.50x | 14.6484 |  30,787 B |
|                 SpanLinq |   100 |    375.29 ns |   1.908 ns |   1.785 ns |   4.01x slower |   0.02x |       - |         - |
|                  Streams |   100 |  1,458.58 ns |   6.131 ns |   5.735 ns |  15.59x slower |   0.09x |  0.3624 |     760 B |
|               StructLinq |   100 |    325.99 ns |   1.106 ns |   0.923 ns |   3.48x slower |   0.02x |  0.0305 |      64 B |
| StructLinq_ValueDelegate |   100 |    199.48 ns |   0.528 ns |   0.494 ns |   2.13x slower |   0.01x |       - |         - |
|                Hyperlinq |   100 |    383.28 ns |   2.247 ns |   2.101 ns |   4.10x slower |   0.03x |       - |         - |
|  Hyperlinq_ValueDelegate |   100 |    230.75 ns |   0.997 ns |   0.832 ns |   2.47x slower |   0.01x |       - |         - |
