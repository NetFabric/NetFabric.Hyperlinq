## AsyncEnumerable.Int32.AsyncEnumerableInt32SkipTakeWhere

### Source
[AsyncEnumerableInt32SkipTakeWhere.cs](../LinqBenchmarks/AsyncEnumerable/Int32/AsyncEnumerableInt32SkipTakeWhere.cs)

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

BenchmarkDotNet=v0.13.0, OS=Windows 10.0.19043.985 (21H1/May2021Update)
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.4.21227.6
  [Host] : .NET 5.0.6 (5.0.621.22011), X64 RyuJIT
  .NET 6 : .NET 6.0.0 (6.0.21.22210), X64 RyuJIT

Job=.NET 6  EnvironmentVariables=COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1  Runtime=.NET 6.0  

```
|                  Method | Skip | Count |    Mean |   Error |  StdDev |        Ratio | RatioSD | Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------ |----- |------ |--------:|--------:|--------:|-------------:|--------:|------:|------:|------:|----------:|
|                    Linq | 1000 |   100 | 17.30 s | 0.086 s | 0.076 s |     baseline |         |     - |     - |     - |    277 KB |
|               Hyperlinq | 1000 |   100 | 17.35 s | 0.083 s | 0.074 s | 1.00x slower |   0.01x |     - |     - |     - |    217 KB |
| Hyperlinq_ValueDelegate | 1000 |   100 | 17.33 s | 0.121 s | 0.113 s | 1.00x slower |   0.01x |     - |     - |     - |    217 KB |
