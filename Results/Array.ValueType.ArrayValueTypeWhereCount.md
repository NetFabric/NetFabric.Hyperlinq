## Array.ValueType.ArrayValueTypeWhereCount

### Source
[ArrayValueTypeWhereCount.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhereCount.cs)

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
|                   Method | Count |         Mean |     Error |    StdDev |          Ratio | RatioSD |  Gen 0 | Allocated |
|------------------------- |------ |-------------:|----------:|----------:|---------------:|--------:|-------:|----------:|
|                  ForLoop |   100 |     72.85 ns |  0.058 ns |  0.051 ns |       baseline |         |      - |         - |
|              ForeachLoop |   100 |    144.01 ns |  0.976 ns |  0.865 ns |   1.98x slower |   0.01x |      - |         - |
|                     Linq |   100 |    599.69 ns |  1.111 ns |  0.985 ns |   8.23x slower |   0.02x | 0.0153 |      32 B |
|               LinqFaster |   100 |    286.29 ns |  0.241 ns |  0.188 ns |   3.93x slower |   0.00x |      - |         - |
|             LinqFasterer |   100 |    301.35 ns |  0.838 ns |  0.700 ns |   4.14x slower |   0.01x |      - |         - |
|                   LinqAF |   100 |    689.55 ns |  7.077 ns |  5.910 ns |   9.46x slower |   0.08x |      - |         - |
|               StructLinq |   100 |    310.84 ns |  3.699 ns |  3.279 ns |   4.27x slower |   0.05x | 0.0305 |      64 B |
|            LinqOptimizer |   100 | 31,507.47 ns | 75.296 ns | 66.748 ns | 432.47x slower |   1.06x | 9.1553 |  19,185 B |
|                  Streams |   100 |    666.04 ns |  0.762 ns |  0.636 ns |   9.14x slower |   0.01x | 0.1717 |     360 B |
| StructLinq_ValueDelegate |   100 |    186.07 ns |  0.160 ns |  0.149 ns |   2.55x slower |   0.00x |      - |         - |
|                Hyperlinq |   100 |    507.24 ns |  0.628 ns |  0.556 ns |   6.96x slower |   0.01x |      - |         - |
|  Hyperlinq_ValueDelegate |   100 |    309.44 ns |  2.498 ns |  2.336 ns |   4.25x slower |   0.03x |      - |         - |
