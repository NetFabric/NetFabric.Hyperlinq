## Array.Int32.ArrayInt32Where

### Source
[ArrayInt32Where.cs](../LinqBenchmarks/Array/Int32/ArrayInt32Where.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqFasterer: [2.1.0](https://www.nuget.org/packages/LinqFasterer/2.1.0)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- LinqOptimizer.CSharp: [0.7.0](https://www.nuget.org/packages/LinqOptimizer.CSharp/0.7.0)
- SpanLinq: [0.0.1](https://www.nuget.org/packages/SpanLinq/0.0.1)
- Streams.CSharp: [0.6.0](https://www.nuget.org/packages/Streams.CSharp/0.6.0)
- StructLinq.BCL: [0.26.0](https://www.nuget.org/packages/StructLinq/0.26.0)
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)
- System.Linq.Async: [5.0.0](https://www.nuget.org/packages/System.Linq.Async/5.0.0)

### Results:
``` ini

BenchmarkDotNet=v0.13.0, OS=macOS Catalina 10.15.7 (19H1323) [Darwin 19.6.0]
Intel Core i5-7360U CPU 2.30GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.7.21379.14
  [Host] : .NET 5.0.6 (5.0.621.22011), X64 RyuJIT
  .NET 6 : .NET 6.0.0 (6.0.21.37719), X64 RyuJIT

Job=.NET 6  EnvironmentVariables=COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1  Runtime=.NET 6.0  

```
|                   Method | Count |         Mean |      Error |     StdDev |          Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |------ |-------------:|-----------:|-----------:|---------------:|--------:|--------:|------:|------:|----------:|
|                  ForLoop |   100 |     73.22 ns |   0.384 ns |   0.359 ns |       baseline |         |       - |     - |     - |         - |
|              ForeachLoop |   100 |     73.75 ns |   0.579 ns |   0.513 ns |   1.01x slower |   0.01x |       - |     - |     - |         - |
|                     Linq |   100 |    354.47 ns |   0.285 ns |   0.253 ns |   4.84x slower |   0.03x |  0.0229 |     - |     - |      48 B |
|               LinqFaster |   100 |    345.54 ns |   0.600 ns |   0.532 ns |   4.72x slower |   0.02x |  0.3171 |     - |     - |     664 B |
|             LinqFasterer |   100 |    498.39 ns |   0.564 ns |   0.500 ns |   6.81x slower |   0.03x |  0.2136 |     - |     - |     448 B |
|                   LinqAF |   100 |    502.70 ns |   4.191 ns |   3.920 ns |   6.87x slower |   0.06x |       - |     - |     - |         - |
|            LinqOptimizer |   100 | 41,292.80 ns | 233.468 ns | 218.386 ns | 563.93x slower |   4.20x | 13.2446 |     - |     - |  27,703 B |
|                 SpanLinq |   100 |    313.72 ns |   1.167 ns |   0.975 ns |   4.28x slower |   0.02x |       - |     - |     - |         - |
|                  Streams |   100 |  1,222.89 ns |   3.886 ns |   3.635 ns |  16.70x slower |   0.09x |  0.2785 |     - |     - |     584 B |
|               StructLinq |   100 |    335.56 ns |   5.286 ns |   4.686 ns |   4.58x slower |   0.07x |  0.0153 |     - |     - |      32 B |
| StructLinq_ValueDelegate |   100 |    216.90 ns |   0.103 ns |   0.092 ns |   2.96x slower |   0.01x |       - |     - |     - |         - |
|                Hyperlinq |   100 |    315.58 ns |   5.037 ns |   4.712 ns |   4.31x slower |   0.06x |       - |     - |     - |         - |
|  Hyperlinq_ValueDelegate |   100 |    222.14 ns |   0.111 ns |   0.098 ns |   3.03x slower |   0.02x |       - |     - |     - |         - |
