## Array.ValueType.ArrayValueTypeWhere

### Source
[ArrayValueTypeWhere.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhere.cs)

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
|                   Method | Count |        Mean |     Error |    StdDev |          Ratio | RatioSD |   Gen 0 |   Gen 1 | Allocated |
|------------------------- |------ |------------:|----------:|----------:|---------------:|--------:|--------:|--------:|----------:|
|                  ForLoop |   100 |    449.3 ns |   0.97 ns |   0.81 ns |       baseline |         |       - |       - |         - |
|              ForeachLoop |   100 |    522.3 ns |   1.91 ns |   1.78 ns |   1.16x slower |   0.00x |       - |       - |         - |
|                     Linq |   100 |    957.2 ns |   2.67 ns |   2.37 ns |   2.13x slower |   0.01x |  0.0496 |       - |     104 B |
|               LinqFaster |   100 |  1,467.2 ns |  11.46 ns |  10.72 ns |   3.27x slower |   0.03x |  4.7264 |       - |   9,904 B |
|             LinqFasterer |   100 |  2,053.6 ns |  12.32 ns |  11.53 ns |   4.57x slower |   0.03x |  3.0174 |       - |   6,328 B |
|                   LinqAF |   100 |  1,288.2 ns |   4.68 ns |   4.38 ns |   2.87x slower |   0.01x |       - |       - |         - |
|            LinqOptimizer |   100 | 49,284.6 ns | 327.97 ns | 290.74 ns | 109.72x slower |   0.70x | 69.5801 | 12.8174 | 153,935 B |
|                 SpanLinq |   100 |    768.3 ns |   2.19 ns |   2.05 ns |   1.71x slower |   0.01x |       - |       - |         - |
|                  Streams |   100 |  1,970.2 ns |   6.26 ns |   4.89 ns |   4.39x slower |   0.01x |  0.3929 |       - |     824 B |
|               StructLinq |   100 |    645.1 ns |   2.27 ns |   1.90 ns |   1.44x slower |   0.01x |  0.0153 |       - |      32 B |
| StructLinq_ValueDelegate |   100 |    568.2 ns |   1.25 ns |   1.17 ns |   1.26x slower |   0.00x |       - |       - |         - |
|                Hyperlinq |   100 |  1,044.4 ns |   6.62 ns |   5.53 ns |   2.32x slower |   0.01x |       - |       - |         - |
|  Hyperlinq_ValueDelegate |   100 |    891.3 ns |   1.88 ns |   1.76 ns |   1.98x slower |   0.00x |       - |       - |         - |
