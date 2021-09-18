## Array.Int32.ArrayInt32Select

### Source
[ArrayInt32Select.cs](../LinqBenchmarks/Array/Int32/ArrayInt32Select.cs)

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
|                   Method | Count |         Mean |     Error |    StdDev |       Median |          Ratio | RatioSD |   Gen 0 | Allocated |
|------------------------- |------ |-------------:|----------:|----------:|-------------:|---------------:|--------:|--------:|----------:|
|                  ForLoop |   100 |     66.11 ns |  1.916 ns |  5.276 ns |     64.47 ns |       baseline |         |       - |         - |
|              ForeachLoop |   100 |     60.95 ns |  0.980 ns |  0.765 ns |     61.13 ns |   1.08x faster |   0.08x |       - |         - |
|                     Linq |   100 |    538.65 ns | 19.720 ns | 56.263 ns |    517.62 ns |   8.25x slower |   1.16x |  0.0229 |      48 B |
|               LinqFaster |   100 |    285.54 ns |  0.757 ns |  0.671 ns |    285.39 ns |   4.40x slower |   0.29x |  0.2027 |     424 B |
|          LinqFaster_SIMD |   100 |    130.42 ns |  0.851 ns |  0.665 ns |    130.23 ns |   1.99x slower |   0.14x |  0.2027 |     424 B |
|             LinqFasterer |   100 |    463.47 ns |  7.605 ns |  5.938 ns |    463.81 ns |   7.08x slower |   0.50x |  0.2179 |     456 B |
|                   LinqAF |   100 |    295.97 ns |  0.986 ns |  1.828 ns |    295.30 ns |   4.57x slower |   0.36x |       - |         - |
|            LinqOptimizer |   100 | 34,093.66 ns | 78.243 ns | 73.189 ns | 34,083.71 ns | 522.04x slower |  36.24x | 13.0005 |  27,235 B |
|                 SpanLinq |   100 |    278.00 ns |  0.278 ns |  0.232 ns |    277.98 ns |   4.26x slower |   0.29x |       - |         - |
|                  Streams |   100 |  1,479.54 ns |  2.199 ns |  1.949 ns |  1,478.89 ns |  22.80x slower |   1.53x |  0.2785 |     584 B |
|               StructLinq |   100 |    229.17 ns |  0.369 ns |  0.308 ns |    229.04 ns |   3.52x slower |   0.24x |  0.0153 |      32 B |
| StructLinq_ValueDelegate |   100 |    181.68 ns |  0.172 ns |  0.144 ns |    181.63 ns |   2.79x slower |   0.19x |       - |         - |
|                Hyperlinq |   100 |    259.74 ns |  0.346 ns |  0.270 ns |    259.67 ns |   3.97x slower |   0.27x |       - |         - |
|  Hyperlinq_ValueDelegate |   100 |    199.66 ns |  0.162 ns |  0.135 ns |    199.64 ns |   3.06x slower |   0.21x |       - |         - |
