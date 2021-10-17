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
|                   Method | Count |        Mean |     Error |    StdDev |         Ratio | RatioSD |  Gen 0 | Allocated |
|------------------------- |------ |------------:|----------:|----------:|--------------:|--------:|-------:|----------:|
|                  ForLoop |   100 |    73.58 ns |  0.267 ns |  0.250 ns |      baseline |         |      - |         - |
|              ForeachLoop |   100 |    73.33 ns |  0.235 ns |  0.208 ns |  1.00x faster |   0.00x |      - |         - |
|                     Linq |   100 |   451.37 ns |  1.974 ns |  1.750 ns |  6.14x slower |   0.03x | 0.0496 |     104 B |
|               LinqFaster |   100 |   393.76 ns |  1.782 ns |  1.666 ns |  5.35x slower |   0.03x | 0.3171 |     664 B |
|             LinqFasterer |   100 |   732.93 ns |  3.011 ns |  2.669 ns |  9.96x slower |   0.06x | 0.4129 |     864 B |
|                   LinqAF |   100 |   320.28 ns |  1.036 ns |  0.918 ns |  4.35x slower |   0.02x |      - |         - |
|            LinqOptimizer |   100 | 1,583.64 ns | 13.826 ns | 12.256 ns | 21.52x slower |   0.14x | 4.1485 |   8,682 B |
|                 SpanLinq |   100 |   342.19 ns |  1.214 ns |  1.076 ns |  4.65x slower |   0.02x |      - |         - |
|                  Streams |   100 | 1,599.39 ns |  7.552 ns |  7.064 ns | 21.74x slower |   0.13x | 0.3510 |     736 B |
|               StructLinq |   100 |   353.97 ns |  2.501 ns |  2.339 ns |  4.81x slower |   0.04x | 0.0305 |      64 B |
| StructLinq_ValueDelegate |   100 |   198.28 ns |  0.828 ns |  0.774 ns |  2.69x slower |   0.02x |      - |         - |
|                Hyperlinq |   100 |   358.55 ns |  1.100 ns |  1.029 ns |  4.87x slower |   0.02x |      - |         - |
|  Hyperlinq_ValueDelegate |   100 |   230.03 ns |  0.338 ns |  0.282 ns |  3.13x slower |   0.01x |      - |         - |
