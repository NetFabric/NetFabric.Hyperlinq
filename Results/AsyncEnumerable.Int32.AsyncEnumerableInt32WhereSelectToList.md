## AsyncEnumerable.Int32.AsyncEnumerableInt32WhereSelectToList

### Source
[AsyncEnumerableInt32WhereSelectToList.cs](../LinqBenchmarks/AsyncEnumerable/Int32/AsyncEnumerableInt32WhereSelectToList.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqFasterer: [2.1.0](https://www.nuget.org/packages/LinqFasterer/2.1.0)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- LinqOptimizer.CSharp: [0.7.0](https://www.nuget.org/packages/LinqOptimizer.CSharp/0.7.0)
- SpanLinq: [1.0.0](https://www.nuget.org/packages/SpanLinq/1.0.0)
- Streams.CSharp: [0.6.0](https://www.nuget.org/packages/Streams.CSharp/0.6.0)
- StructLinq.BCL: [0.26.0](https://www.nuget.org/packages/StructLinq/0.26.0)
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)
- System.Linq.Async: [5.0.0](https://www.nuget.org/packages/System.Linq.Async/5.0.0)

### Results:
``` ini

BenchmarkDotNet=v0.12.1.1538-nightly, OS=Windows 10.0.19043
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.4.21227.6
  [Host] : .NET 5.0.6 (5.0.621.22011), X64 RyuJIT
  .NET 6 : .NET 6.0.0 (6.0.21.22210), X64 RyuJIT

Job=.NET 6  EnvironmentVariables=COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1  Runtime=.NET 6.0  

```
|                  Method | Count |    Mean |    Error |   StdDev | Ratio | RatioSD | Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------ |------ |--------:|---------:|---------:|------:|--------:|------:|------:|------:|----------:|
|             ForeachLoop |   100 | 1.586 s | 0.0201 s | 0.0188 s |  1.00 |    0.00 |     - |     - |     - |     21 KB |
|                    Linq |   100 | 1.580 s | 0.0136 s | 0.0121 s |  1.00 |    0.01 |     - |     - |     - |     52 KB |
|               Hyperlinq |   100 | 1.585 s | 0.0146 s | 0.0129 s |  1.00 |    0.02 |     - |     - |     - |     22 KB |
| Hyperlinq_ValueDelegate |   100 | 1.582 s | 0.0114 s | 0.0107 s |  1.00 |    0.01 |     - |     - |     - |     33 KB |
