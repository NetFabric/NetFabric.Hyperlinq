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
|                   Method | Count |         Mean |      Error |    StdDev |          Ratio | RatioSD |  Gen 0 | Allocated |
|------------------------- |------ |-------------:|-----------:|----------:|---------------:|--------:|-------:|----------:|
|                  ForLoop |   100 |     73.00 ns |   0.222 ns |  0.208 ns |       baseline |         |      - |         - |
|              ForeachLoop |   100 |    143.25 ns |   1.348 ns |  1.261 ns |   1.96x slower |   0.02x |      - |         - |
|                     Linq |   100 |    599.61 ns |   0.884 ns |  0.690 ns |   8.21x slower |   0.03x | 0.0153 |      32 B |
|               LinqFaster |   100 |    288.63 ns |   0.271 ns |  0.212 ns |   3.95x slower |   0.01x |      - |         - |
|             LinqFasterer |   100 |    300.04 ns |   1.133 ns |  0.946 ns |   4.11x slower |   0.01x |      - |         - |
|                   LinqAF |   100 |    716.86 ns |  12.432 ns | 11.629 ns |   9.82x slower |   0.16x |      - |         - |
|               StructLinq |   100 |    313.71 ns |   5.682 ns |  5.315 ns |   4.30x slower |   0.07x | 0.0305 |      64 B |
|            LinqOptimizer |   100 | 33,252.55 ns | 104.928 ns | 81.921 ns | 455.43x slower |   2.05x | 9.1553 |  19,186 B |
|                  Streams |   100 |    675.84 ns |   3.340 ns |  2.960 ns |   9.26x slower |   0.04x | 0.1717 |     360 B |
| StructLinq_ValueDelegate |   100 |    186.16 ns |   0.644 ns |  0.602 ns |   2.55x slower |   0.01x |      - |         - |
|                Hyperlinq |   100 |    506.69 ns |   0.776 ns |  0.688 ns |   6.94x slower |   0.02x |      - |         - |
|  Hyperlinq_ValueDelegate |   100 |    311.15 ns |   0.426 ns |  0.377 ns |   4.26x slower |   0.01x |      - |         - |
