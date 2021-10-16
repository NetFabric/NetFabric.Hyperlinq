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
|                   Method | Count |        Mean |     Error |    StdDev |          Ratio | RatioSD |   Gen 0 |   Gen 1 | Allocated |
|------------------------- |------ |------------:|----------:|----------:|---------------:|--------:|--------:|--------:|----------:|
|                  ForLoop |   100 |    449.1 ns |   0.25 ns |   0.23 ns |       baseline |         |       - |       - |         - |
|              ForeachLoop |   100 |    523.4 ns |   0.29 ns |   0.26 ns |   1.17x slower |   0.00x |       - |       - |         - |
|                     Linq |   100 |    945.7 ns |   0.91 ns |   0.81 ns |   2.11x slower |   0.00x |  0.0496 |       - |     104 B |
|               LinqFaster |   100 |  1,509.3 ns |   6.97 ns |   5.82 ns |   3.36x slower |   0.01x |  4.7264 |       - |   9,904 B |
|             LinqFasterer |   100 |  2,121.3 ns |  35.55 ns |  40.94 ns |   4.74x slower |   0.10x |  3.0174 |       - |   6,328 B |
|                   LinqAF |   100 |  1,172.6 ns |   6.04 ns |   5.65 ns |   2.61x slower |   0.01x |       - |       - |         - |
|            LinqOptimizer |   100 | 50,207.2 ns | 370.81 ns | 328.72 ns | 111.80x slower |   0.74x | 68.9697 | 17.2119 | 153,934 B |
|                 SpanLinq |   100 |    786.5 ns |   0.69 ns |   0.58 ns |   1.75x slower |   0.00x |       - |       - |         - |
|                  Streams |   100 |  1,996.6 ns |   3.81 ns |   3.38 ns |   4.45x slower |   0.01x |  0.3929 |       - |     824 B |
|               StructLinq |   100 |    636.8 ns |   0.54 ns |   0.45 ns |   1.42x slower |   0.00x |  0.0153 |       - |      32 B |
| StructLinq_ValueDelegate |   100 |    583.7 ns |   0.31 ns |   0.28 ns |   1.30x slower |   0.00x |       - |       - |         - |
|                Hyperlinq |   100 |    993.7 ns |   1.58 ns |   1.32 ns |   2.21x slower |   0.00x |       - |       - |         - |
|  Hyperlinq_ValueDelegate |   100 |    882.5 ns |   0.47 ns |   0.39 ns |   1.96x slower |   0.00x |       - |       - |         - |
