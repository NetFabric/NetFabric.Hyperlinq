## ImmutableArray.Int32.ImmutableArrayInt32Select

### Source
[ImmutableArrayInt32Select.cs](../LinqBenchmarks/ImmutableArray/Int32/ImmutableArrayInt32Select.cs)

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
|                  ForLoop |   100 |     61.26 ns |   0.123 ns |   0.109 ns |       baseline |         |       - |         - |
|              ForeachLoop |   100 |     61.82 ns |   0.133 ns |   0.118 ns |   1.01x slower |   0.00x |       - |         - |
|                     Linq |   100 |    354.81 ns |   1.091 ns |   0.967 ns |   5.79x slower |   0.02x |  0.0229 |      48 B |
|             LinqFasterer |   100 |    447.44 ns |   1.367 ns |   1.279 ns |   7.30x slower |   0.03x |  0.4320 |     904 B |
|            LinqOptimizer |   100 | 40,325.86 ns | 128.016 ns | 106.899 ns | 658.28x slower |   2.32x | 13.6108 |  28,584 B |
|                  Streams |   100 |  1,593.03 ns |   5.248 ns |   4.653 ns |  26.00x slower |   0.09x |  0.2899 |     608 B |
|               StructLinq |   100 |    249.08 ns |   0.179 ns |   0.140 ns |   4.07x slower |   0.01x |  0.0153 |      32 B |
| StructLinq_ValueDelegate |   100 |    179.76 ns |   0.297 ns |   0.264 ns |   2.93x slower |   0.01x |       - |         - |
|                Hyperlinq |   100 |    254.62 ns |   0.724 ns |   0.677 ns |   4.16x slower |   0.02x |       - |         - |
|  Hyperlinq_ValueDelegate |   100 |    201.03 ns |   0.247 ns |   0.231 ns |   3.28x slower |   0.01x |       - |         - |
