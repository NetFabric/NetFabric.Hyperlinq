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
|                   Method | Count |         Mean |     Error |    StdDev |          Ratio | RatioSD |  Gen 0 | Allocated |
|------------------------- |------ |-------------:|----------:|----------:|---------------:|--------:|-------:|----------:|
|                  ForLoop |   100 |    117.95 ns |  0.396 ns |  0.351 ns |       baseline |         |      - |         - |
|              ForeachLoop |   100 |     81.88 ns |  0.205 ns |  0.192 ns |   1.44x faster |   0.01x |      - |         - |
|                     Linq |   100 |    275.43 ns |  0.905 ns |  0.847 ns |   2.33x slower |   0.01x | 0.0191 |      40 B |
|               LinqFaster |   100 |    118.78 ns |  0.346 ns |  0.324 ns |   1.01x slower |   0.00x |      - |         - |
|             LinqFasterer |   100 |    110.07 ns |  1.008 ns |  0.943 ns |   1.07x faster |   0.01x | 0.2027 |     424 B |
|                   LinqAF |   100 |    307.67 ns |  0.742 ns |  0.694 ns |   2.61x slower |   0.01x |      - |         - |
|            LinqOptimizer |   100 | 27,526.08 ns | 85.209 ns | 75.535 ns | 233.37x slower |   1.03x | 8.1177 |  17,017 B |
|                  Streams |   100 |    201.67 ns |  0.598 ns |  0.531 ns |   1.71x slower |   0.01x | 0.0994 |     208 B |
|               StructLinq |   100 |     81.84 ns |  0.071 ns |  0.055 ns |   1.44x faster |   0.00x | 0.0153 |      32 B |
| StructLinq_ValueDelegate |   100 |     65.95 ns |  0.124 ns |  0.104 ns |   1.79x faster |   0.01x |      - |         - |
|                Hyperlinq |   100 |     21.19 ns |  0.466 ns |  0.436 ns |   5.54x faster |   0.02x |      - |         - |
