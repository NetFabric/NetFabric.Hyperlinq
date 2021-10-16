## Enumerable.Int32.EnumerableInt32Where

### Source
[EnumerableInt32Where.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32Where.cs)

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
|                   Method | Count |        Mean |     Error |    StdDev |         Ratio | RatioSD |   Gen 0 | Allocated |
|------------------------- |------ |------------:|----------:|----------:|--------------:|--------:|--------:|----------:|
|                     Linq |   100 |    506.6 ns |   0.97 ns |   0.76 ns |      baseline |         |  0.0458 |      96 B |
|                   LinqAF |   100 |    400.6 ns |   1.33 ns |   1.25 ns |  1.26x faster |   0.00x |  0.0191 |      40 B |
|            LinqOptimizer |   100 | 45,870.4 ns | 251.21 ns | 222.69 ns | 90.55x slower |   0.44x | 13.8550 |  29,091 B |
|                  Streams |   100 |  1,546.6 ns |   5.54 ns |   4.91 ns |  3.05x slower |   0.01x |  0.2823 |     592 B |
|               StructLinq |   100 |    451.1 ns |   0.84 ns |   0.79 ns |  1.12x faster |   0.00x |  0.0305 |      64 B |
| StructLinq_ValueDelegate |   100 |    286.8 ns |   1.17 ns |   0.91 ns |  1.77x faster |   0.01x |  0.0191 |      40 B |
|                Hyperlinq |   100 |    445.8 ns |   1.09 ns |   1.02 ns |  1.14x faster |   0.00x |  0.0191 |      40 B |
|  Hyperlinq_ValueDelegate |   100 |    343.6 ns |   1.36 ns |   1.28 ns |  1.47x faster |   0.01x |  0.0191 |      40 B |
