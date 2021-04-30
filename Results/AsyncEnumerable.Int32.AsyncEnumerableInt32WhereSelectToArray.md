## AsyncEnumerable.Int32.AsyncEnumerableInt32WhereSelectToArray

### Source
[AsyncEnumerableInt32WhereSelectToArray.cs](../LinqBenchmarks/AsyncEnumerable/Int32/AsyncEnumerableInt32WhereSelectToArray.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqFasterer: [2.1.0](https://www.nuget.org/packages/LinqFasterer/2.1.0)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- LinqOptimizer.CSharp: [0.7.0](https://www.nuget.org/packages/LinqOptimizer.CSharp/0.7.0)
- Streams.CSharp: [0.6.0](https://www.nuget.org/packages/Streams.CSharp/0.6.0)
- StructLinq.BCL: [0.26.0](https://www.nuget.org/packages/StructLinq/0.26.0)
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)
- System.Linq.Async: [5.0.0](https://www.nuget.org/packages/System.Linq.Async/5.0.0)

### Results:
``` ini

BenchmarkDotNet=v0.12.1.1527-nightly, OS=Windows 10.0.19043
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.4.21227.6
  [Host] : .NET 5.0.4 (5.0.421.11614), X64 RyuJIT
  .NET 6 : .NET 6.0.0 (6.0.21.22210), X64 RyuJIT

Job=.NET 6  EnvironmentVariables=COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1  Runtime=.NET 6.0  

```
|                  Method | Count |    Mean |    Error |   StdDev | Ratio | RatioSD | Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------ |------ |--------:|---------:|---------:|------:|--------:|------:|------:|------:|----------:|
|             ForeachLoop |   100 | 1.568 s | 0.0175 s | 0.0146 s |  1.00 |    0.00 |     - |     - |     - |     33 KB |
|                    Linq |   100 | 1.578 s | 0.0252 s | 0.0224 s |  1.01 |    0.02 |     - |     - |     - |     53 KB |
|               Hyperlinq |   100 | 1.559 s | 0.0044 s | 0.0039 s |  0.99 |    0.01 |     - |     - |     - |     34 KB |
| Hyperlinq_ValueDelegate |   100 | 1.561 s | 0.0064 s | 0.0057 s |  1.00 |    0.01 |     - |     - |     - |     22 KB |
