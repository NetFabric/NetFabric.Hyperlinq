## Array.ValueType.ArrayValueTypeWhereSelect

### Source
[ArrayValueTypeWhereSelect.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhereSelect.cs)

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
|                   Method | Count |        Mean |     Error |    StdDev |         Ratio | RatioSD |   Gen 0 |  Gen 1 | Allocated |
|------------------------- |------ |------------:|----------:|----------:|--------------:|--------:|--------:|-------:|----------:|
|                  ForLoop |   100 |    853.0 ns |   1.11 ns |   0.93 ns |      baseline |         |       - |      - |         - |
|              ForeachLoop |   100 |    929.4 ns |   1.82 ns |   1.71 ns |  1.09x slower |   0.00x |       - |      - |         - |
|                     Linq |   100 |  1,476.0 ns |   4.12 ns |   3.65 ns |  1.73x slower |   0.01x |  0.1030 |      - |     216 B |
|               LinqFaster |   100 |  1,996.3 ns |  14.07 ns |  12.47 ns |  2.34x slower |   0.02x |  4.7264 |      - |   9,904 B |
|             LinqFasterer |   100 |  3,632.8 ns |  14.96 ns |  13.26 ns |  4.26x slower |   0.01x |  6.0234 |      - |  12,624 B |
|                   LinqAF |   100 |  2,084.5 ns |  11.18 ns |   9.91 ns |  2.44x slower |   0.01x |       - |      - |         - |
|            LinqOptimizer |   100 | 55,839.0 ns | 472.51 ns | 418.87 ns | 65.38x slower |   0.40x | 74.0356 | 0.0610 | 156,327 B |
|                 SpanLinq |   100 |  1,581.1 ns |   4.50 ns |   4.21 ns |  1.85x slower |   0.00x |       - |      - |         - |
|                  Streams |   100 |  2,667.5 ns |   9.14 ns |   7.63 ns |  3.13x slower |   0.01x |  0.4654 |      - |     976 B |
|               StructLinq |   100 |  1,193.0 ns |   4.64 ns |   4.34 ns |  1.40x slower |   0.00x |  0.0305 |      - |      64 B |
| StructLinq_ValueDelegate |   100 |    971.6 ns |   0.25 ns |   0.20 ns |  1.14x slower |   0.00x |       - |      - |         - |
|                Hyperlinq |   100 |  1,604.6 ns |   7.85 ns |   6.96 ns |  1.88x slower |   0.01x |       - |      - |         - |
|  Hyperlinq_ValueDelegate |   100 |  1,298.9 ns |   2.23 ns |   1.86 ns |  1.52x slower |   0.00x |       - |      - |         - |
