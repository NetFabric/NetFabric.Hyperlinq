## List.Int32.ListInt32Select

### Source
[ListInt32Select.cs](../LinqBenchmarks/List/Int32/ListInt32Select.cs)

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
|                   Method | Count |         Mean |      Error |     StdDev |          Ratio | RatioSD |   Gen 0 | Allocated |
|------------------------- |------ |-------------:|-----------:|-----------:|---------------:|--------:|--------:|----------:|
|                  ForLoop |   100 |     78.84 ns |   0.137 ns |   0.128 ns |       baseline |         |       - |         - |
|              ForeachLoop |   100 |    148.60 ns |   0.218 ns |   0.193 ns |   1.88x slower |   0.00x |       - |         - |
|                     Linq |   100 |    413.77 ns |   0.993 ns |   0.929 ns |   5.25x slower |   0.01x |  0.0343 |      72 B |
|               LinqFaster |   100 |    399.92 ns |   2.956 ns |   2.765 ns |   5.07x slower |   0.04x |  0.2179 |     456 B |
|             LinqFasterer |   100 |    436.96 ns |   1.703 ns |   1.593 ns |   5.54x slower |   0.02x |  0.4206 |     880 B |
|                   LinqAF |   100 |    392.84 ns |   1.070 ns |   1.001 ns |   4.98x slower |   0.01x |       - |         - |
|            LinqOptimizer |   100 | 39,810.79 ns | 213.214 ns | 199.441 ns | 504.94x slower |   2.93x | 13.4277 |  28,183 B |
|                 SpanLinq |   100 |    304.54 ns |   0.797 ns |   0.707 ns |   3.86x slower |   0.01x |       - |         - |
|                  Streams |   100 |  1,499.57 ns |   4.955 ns |   4.635 ns |  19.02x slower |   0.07x |  0.2899 |     608 B |
|               StructLinq |   100 |    225.82 ns |   0.461 ns |   0.431 ns |   2.86x slower |   0.01x |  0.0153 |      32 B |
| StructLinq_ValueDelegate |   100 |    177.04 ns |   0.272 ns |   0.241 ns |   2.25x slower |   0.01x |       - |         - |
|                Hyperlinq |   100 |    229.91 ns |   0.635 ns |   0.594 ns |   2.92x slower |   0.01x |       - |         - |
|  Hyperlinq_ValueDelegate |   100 |    201.64 ns |   0.316 ns |   0.280 ns |   2.56x slower |   0.00x |       - |         - |
