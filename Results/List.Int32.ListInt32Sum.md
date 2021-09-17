## List.Int32.ListInt32Sum

### Source
[ListInt32Sum.cs](../LinqBenchmarks/List/Int32/ListInt32Sum.cs)

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
|                   Method | Count |         Mean |      Error |     StdDev |          Ratio | RatioSD |  Gen 0 | Allocated |
|------------------------- |------ |-------------:|-----------:|-----------:|---------------:|--------:|-------:|----------:|
|                  ForLoop |   100 |    117.49 ns |   0.108 ns |   0.090 ns |       baseline |         |      - |         - |
|              ForeachLoop |   100 |     81.63 ns |   1.131 ns |   1.002 ns |   1.43x faster |   0.00x |      - |         - |
|                     Linq |   100 |    274.42 ns |   1.138 ns |   1.009 ns |   2.34x slower |   0.01x | 0.0191 |      40 B |
|               LinqFaster |   100 |    120.21 ns |   0.962 ns |   0.751 ns |   1.02x slower |   0.01x |      - |         - |
|             LinqFasterer |   100 |    112.79 ns |   1.515 ns |   1.343 ns |   1.04x faster |   0.01x | 0.2027 |     424 B |
|                   LinqAF |   100 |    308.98 ns |   1.156 ns |   1.025 ns |   2.63x slower |   0.01x |      - |         - |
|            LinqOptimizer |   100 | 27,779.43 ns | 121.260 ns | 113.426 ns | 236.53x slower |   1.00x | 8.1177 |  17,017 B |
|                  Streams |   100 |    195.55 ns |   0.791 ns |   0.740 ns |   1.66x slower |   0.01x | 0.0994 |     208 B |
|               StructLinq |   100 |     81.13 ns |   0.242 ns |   0.226 ns |   1.45x faster |   0.00x | 0.0153 |      32 B |
| StructLinq_ValueDelegate |   100 |     65.25 ns |   0.221 ns |   0.184 ns |   1.80x faster |   0.01x |      - |         - |
|                Hyperlinq |   100 |     21.75 ns |   0.071 ns |   0.066 ns |   5.40x faster |   0.01x |      - |         - |
