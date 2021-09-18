## AsyncEnumerable.Int32.AsyncEnumerableInt32SkipTakeSelect

### Source
[AsyncEnumerableInt32SkipTakeSelect.cs](../LinqBenchmarks/AsyncEnumerable/Int32/AsyncEnumerableInt32SkipTakeSelect.cs)

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
|                  Method | Skip | Count |    Mean |    Error |   StdDev |        Ratio | RatioSD | Allocated |
|------------------------ |----- |------ |--------:|---------:|---------:|-------------:|--------:|----------:|
|                    Linq | 1000 |   100 | 1.542 s | 0.0301 s | 0.0716 s |     baseline |         |    279 KB |
|               Hyperlinq | 1000 |   100 | 1.589 s | 0.0313 s | 0.0861 s | 1.02x slower |   0.07x |    218 KB |
| Hyperlinq_ValueDelegate | 1000 |   100 | 1.706 s | 0.0380 s | 0.1119 s | 1.09x slower |   0.10x |    218 KB |
