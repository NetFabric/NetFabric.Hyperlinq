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
|                   Method | Count |         Mean |      Error |     StdDev |          Ratio | RatioSD |  Gen 0 | Allocated |
|------------------------- |------ |-------------:|-----------:|-----------:|---------------:|--------:|-------:|----------:|
|                  ForLoop |   100 |     73.43 ns |   0.029 ns |   0.026 ns |       baseline |         |      - |         - |
|              ForeachLoop |   100 |    133.04 ns |   0.899 ns |   0.841 ns |   1.81x slower |   0.01x |      - |         - |
|                     Linq |   100 |    582.90 ns |   0.916 ns |   0.812 ns |   7.94x slower |   0.01x | 0.0153 |      32 B |
|               LinqFaster |   100 |    287.32 ns |   0.239 ns |   0.212 ns |   3.91x slower |   0.00x |      - |         - |
|             LinqFasterer |   100 |    304.00 ns |   0.932 ns |   0.826 ns |   4.14x slower |   0.01x |      - |         - |
|                   LinqAF |   100 |    693.33 ns |   2.409 ns |   2.012 ns |   9.44x slower |   0.03x |      - |         - |
|               StructLinq |   100 |    295.81 ns |   5.286 ns |   5.192 ns |   4.03x slower |   0.07x | 0.0305 |      64 B |
|            LinqOptimizer |   100 | 32,202.14 ns | 126.171 ns | 118.020 ns | 438.64x slower |   1.68x | 9.1553 |  19,186 B |
|                  Streams |   100 |    650.23 ns |   5.209 ns |   4.618 ns |   8.86x slower |   0.06x | 0.1717 |     360 B |
| StructLinq_ValueDelegate |   100 |    186.52 ns |   0.271 ns |   0.254 ns |   2.54x slower |   0.00x |      - |         - |
|                Hyperlinq |   100 |    501.01 ns |   0.667 ns |   0.624 ns |   6.82x slower |   0.01x |      - |         - |
|  Hyperlinq_ValueDelegate |   100 |    305.94 ns |   0.270 ns |   0.253 ns |   4.17x slower |   0.00x |      - |         - |
