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
|                   Method | Count |         Mean |     Error |    StdDev |          Ratio | RatioSD |  Gen 0 | Allocated |
|------------------------- |------ |-------------:|----------:|----------:|---------------:|--------:|-------:|----------:|
|                  ForLoop |   100 |    118.46 ns |  0.102 ns |  0.080 ns |       baseline |         |      - |         - |
|              ForeachLoop |   100 |     82.22 ns |  0.170 ns |  0.159 ns |   1.44x faster |   0.00x |      - |         - |
|                     Linq |   100 |    274.59 ns |  0.801 ns |  0.749 ns |   2.32x slower |   0.01x | 0.0191 |      40 B |
|               LinqFaster |   100 |    118.29 ns |  0.157 ns |  0.131 ns |   1.00x faster |   0.00x |      - |         - |
|             LinqFasterer |   100 |    109.95 ns |  0.399 ns |  0.333 ns |   1.08x faster |   0.00x | 0.2027 |     424 B |
|                   LinqAF |   100 |    260.11 ns |  0.801 ns |  0.669 ns |   2.20x slower |   0.01x |      - |         - |
|            LinqOptimizer |   100 | 28,152.69 ns | 99.154 ns | 87.898 ns | 237.61x slower |   0.76x | 8.1177 |  17,017 B |
|                  Streams |   100 |    199.85 ns |  0.767 ns |  0.680 ns |   1.69x slower |   0.01x | 0.0994 |     208 B |
|               StructLinq |   100 |     81.97 ns |  0.290 ns |  0.271 ns |   1.45x faster |   0.00x | 0.0153 |      32 B |
| StructLinq_ValueDelegate |   100 |     66.60 ns |  0.115 ns |  0.102 ns |   1.78x faster |   0.00x |      - |         - |
|                Hyperlinq |   100 |     25.05 ns |  0.044 ns |  0.037 ns |   4.73x faster |   0.01x |      - |         - |
