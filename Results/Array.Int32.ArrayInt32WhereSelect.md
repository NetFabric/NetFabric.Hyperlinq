## Array.Int32.ArrayInt32WhereSelect

### Source
[ArrayInt32WhereSelect.cs](../LinqBenchmarks/Array/Int32/ArrayInt32WhereSelect.cs)

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
|                   Method | Count |         Mean |        Error |       StdDev |       Median |          Ratio | RatioSD |   Gen 0 | Allocated |
|------------------------- |------ |-------------:|-------------:|-------------:|-------------:|---------------:|--------:|--------:|----------:|
|                  ForLoop |   100 |     72.50 ns |     0.062 ns |     0.049 ns |     72.49 ns |       baseline |         |       - |         - |
|              ForeachLoop |   100 |     72.84 ns |     0.124 ns |     0.103 ns |     72.82 ns |   1.00x slower |   0.00x |       - |         - |
|                     Linq |   100 |    451.32 ns |     1.820 ns |     1.702 ns |    450.99 ns |   6.22x slower |   0.03x |  0.0496 |     104 B |
|               LinqFaster |   100 |    411.34 ns |     1.848 ns |     1.729 ns |    410.75 ns |   5.67x slower |   0.03x |  0.3171 |     664 B |
|             LinqFasterer |   100 |    731.71 ns |     3.451 ns |     3.228 ns |    730.99 ns |  10.10x slower |   0.03x |  0.4129 |     864 B |
|                   LinqAF |   100 |    308.43 ns |     0.804 ns |     0.672 ns |    308.14 ns |   4.25x slower |   0.01x |       - |         - |
|            LinqOptimizer |   100 | 49,300.68 ns | 1,347.731 ns | 3,973.814 ns | 46,920.44 ns | 649.91x slower |  11.39x | 14.2212 |  29,775 B |
|                 SpanLinq |   100 |    349.16 ns |     0.940 ns |     0.833 ns |    348.77 ns |   4.82x slower |   0.01x |       - |         - |
|                  Streams |   100 |  1,563.68 ns |     6.752 ns |     5.985 ns |  1,561.09 ns |  21.58x slower |   0.08x |  0.3510 |     736 B |
|               StructLinq |   100 |    353.19 ns |     1.836 ns |     1.717 ns |    352.26 ns |   4.87x slower |   0.03x |  0.0305 |      64 B |
| StructLinq_ValueDelegate |   100 |    196.84 ns |     0.783 ns |     0.654 ns |    196.83 ns |   2.72x slower |   0.01x |       - |         - |
|                Hyperlinq |   100 |    367.97 ns |     1.120 ns |     1.048 ns |    367.59 ns |   5.08x slower |   0.01x |       - |         - |
|  Hyperlinq_ValueDelegate |   100 |    229.51 ns |     1.431 ns |     1.268 ns |    229.08 ns |   3.16x slower |   0.02x |       - |         - |
