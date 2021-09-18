## AsyncEnumerable.Int32.AsyncEnumerableInt32WhereCountAsync

### Source
[AsyncEnumerableInt32WhereCountAsync.cs](../LinqBenchmarks/AsyncEnumerable/Int32/AsyncEnumerableInt32WhereCountAsync.cs)

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
|                  Method | Count |     Mean |   Error |  StdDev |        Ratio | RatioSD | Allocated |
|------------------------ |------ |---------:|--------:|--------:|-------------:|--------:|----------:|
|             ForeachLoop |   100 | 140.2 ms | 2.01 ms | 1.68 ms |     baseline |         |     20 KB |
|                    Linq |   100 | 139.2 ms | 2.46 ms | 2.30 ms | 1.01x faster |   0.02x |     20 KB |
|               Hyperlinq |   100 | 139.3 ms | 2.74 ms | 2.81 ms | 1.01x faster |   0.03x |     22 KB |
| Hyperlinq_ValueDelegate |   100 | 141.3 ms | 2.62 ms | 5.70 ms | 1.00x slower |   0.04x |     20 KB |
