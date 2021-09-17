## List.ValueType.ListValueTypeWhere

### Source
[ListValueTypeWhere.cs](../LinqBenchmarks/List/ValueType/ListValueTypeWhere.cs)

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
|                   Method | Count |        Mean |     Error |    StdDev |         Ratio | RatioSD |   Gen 0 | Allocated |
|------------------------- |------ |------------:|----------:|----------:|--------------:|--------:|--------:|----------:|
|                  ForLoop |   100 |    549.7 ns |   0.64 ns |   0.50 ns |      baseline |         |       - |         - |
|              ForeachLoop |   100 |    793.7 ns |   1.75 ns |   1.64 ns |  1.44x slower |   0.00x |       - |         - |
|                     Linq |   100 |  1,296.4 ns |   6.75 ns |   6.32 ns |  2.36x slower |   0.01x |  0.0877 |     184 B |
|               LinqFaster |   100 |  1,753.2 ns |   9.77 ns |   9.14 ns |  3.19x slower |   0.02x |  3.8605 |   8,088 B |
|             LinqFasterer |   100 |  1,759.9 ns |  30.02 ns |  28.08 ns |  3.19x slower |   0.05x |  4.7379 |   9,936 B |
|                   LinqAF |   100 |  1,370.6 ns |   6.91 ns |   6.47 ns |  2.49x slower |   0.01x |       - |         - |
|            LinqOptimizer |   100 | 53,203.5 ns | 384.07 ns | 340.47 ns | 96.78x slower |   0.56x | 73.1201 | 154,832 B |
|                 SpanLinq |   100 |    769.9 ns |   1.77 ns |   1.66 ns |  1.40x slower |   0.00x |       - |         - |
|                  Streams |   100 |  2,011.0 ns |   3.73 ns |   2.91 ns |  3.66x slower |   0.01x |  0.4044 |     848 B |
|               StructLinq |   100 |    655.0 ns |   1.87 ns |   1.75 ns |  1.19x slower |   0.00x |  0.0191 |      40 B |
| StructLinq_ValueDelegate |   100 |    576.1 ns |   2.96 ns |   2.62 ns |  1.05x slower |   0.00x |       - |         - |
|                Hyperlinq |   100 |  1,007.8 ns |   3.58 ns |   3.17 ns |  1.83x slower |   0.01x |       - |         - |
|  Hyperlinq_ValueDelegate |   100 |    890.9 ns |   1.81 ns |   1.70 ns |  1.62x slower |   0.00x |       - |         - |
