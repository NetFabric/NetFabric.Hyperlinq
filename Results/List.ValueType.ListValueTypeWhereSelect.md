## List.ValueType.ListValueTypeWhereSelect

### Source
[ListValueTypeWhereSelect.cs](../LinqBenchmarks/List/ValueType/ListValueTypeWhereSelect.cs)

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
|                   Method | Count |        Mean |     Error |    StdDev |         Ratio | RatioSD |   Gen 0 |   Gen 1 | Allocated |
|------------------------- |------ |------------:|----------:|----------:|--------------:|--------:|--------:|--------:|----------:|
|                  ForLoop |   100 |    958.5 ns |   1.63 ns |   1.36 ns |      baseline |         |       - |       - |         - |
|              ForeachLoop |   100 |  1,241.4 ns |  23.33 ns |  21.82 ns |  1.29x slower |   0.02x |       - |       - |         - |
|                     Linq |   100 |  1,695.7 ns |   7.12 ns |   6.31 ns |  1.77x slower |   0.01x |  0.1793 |       - |     376 B |
|               LinqFaster |   100 |  2,418.1 ns |  21.39 ns |  20.01 ns |  2.52x slower |   0.02x |  3.8605 |       - |   8,088 B |
|             LinqFasterer |   100 |  2,709.1 ns |  16.99 ns |  15.06 ns |  2.83x slower |   0.02x |  6.4087 |       - |  13,416 B |
|                   LinqAF |   100 |  2,255.2 ns |   8.13 ns |   7.21 ns |  2.35x slower |   0.01x |       - |       - |         - |
|            LinqOptimizer |   100 | 60,714.4 ns | 452.32 ns | 423.10 ns | 63.36x slower |   0.48x | 57.6782 | 19.2261 | 157,274 B |
|                 SpanLinq |   100 |  1,580.2 ns |   6.47 ns |   6.05 ns |  1.65x slower |   0.00x |       - |       - |         - |
|                  Streams |   100 |  2,896.9 ns |  18.99 ns |  16.84 ns |  3.02x slower |   0.02x |  0.4768 |       - |   1,000 B |
|               StructLinq |   100 |  1,197.6 ns |   3.38 ns |   3.16 ns |  1.25x slower |   0.00x |  0.0343 |       - |      72 B |
| StructLinq_ValueDelegate |   100 |    983.3 ns |   2.16 ns |   1.91 ns |  1.03x slower |   0.00x |       - |       - |         - |
|                Hyperlinq |   100 |  1,600.1 ns |   4.13 ns |   3.86 ns |  1.67x slower |   0.00x |       - |       - |         - |
|  Hyperlinq_ValueDelegate |   100 |  1,300.9 ns |   1.17 ns |   0.91 ns |  1.36x slower |   0.00x |       - |       - |         - |
