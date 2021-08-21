## Array.Int32.ArrayInt32WhereSelectToList

### Source
[ArrayInt32WhereSelectToList.cs](../LinqBenchmarks/Array/Int32/ArrayInt32WhereSelectToList.cs)

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
|                   Method | Count |        Mean |     Error |   StdDev |          Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |------ |------------:|----------:|---------:|---------------:|--------:|--------:|------:|------:|----------:|
|                  ForLoop |   100 |    232.1 ns |   0.36 ns |  0.33 ns |       baseline |         |  0.3095 |     - |     - |     648 B |
|              ForeachLoop |   100 |    229.9 ns |   0.16 ns |  0.14 ns |   1.01x faster |   0.00x |  0.3097 |     - |     - |     648 B |
|                     Linq |   100 |    557.5 ns |   1.36 ns |  1.27 ns |   2.40x slower |   0.01x |  0.3595 |     - |     - |     752 B |
|               LinqFaster |   100 |    423.8 ns |   1.41 ns |  1.25 ns |   1.83x slower |   0.01x |  0.4473 |     - |     - |     936 B |
|             LinqFasterer |   100 |    614.9 ns |   0.81 ns |  0.76 ns |   2.65x slower |   0.01x |  0.6113 |     - |     - |   1,280 B |
|                   LinqAF |   100 |    591.1 ns |   1.52 ns |  1.42 ns |   2.55x slower |   0.01x |  0.3090 |     - |     - |     648 B |
|            LinqOptimizer |   100 | 47,561.8 ns | 104.80 ns | 87.51 ns | 204.99x slower |   0.51x | 14.6484 |     - |     - |  30,760 B |
|                 SpanLinq |   100 |    568.3 ns |   0.66 ns |  0.62 ns |   2.45x slower |   0.00x |  0.3090 |     - |     - |     648 B |
|                  Streams |   100 |  1,364.3 ns |   3.08 ns |  2.57 ns |   5.88x slower |   0.01x |  0.5684 |     - |     - |   1,192 B |
|               StructLinq |   100 |    623.8 ns |   1.63 ns |  1.53 ns |   2.69x slower |   0.01x |  0.1755 |     - |     - |     368 B |
| StructLinq_ValueDelegate |   100 |    379.1 ns |   1.26 ns |  1.11 ns |   1.63x slower |   0.01x |  0.1297 |     - |     - |     272 B |
|                Hyperlinq |   100 |    679.2 ns |   1.51 ns |  1.34 ns |   2.93x slower |   0.01x |  0.1297 |     - |     - |     272 B |
|  Hyperlinq_ValueDelegate |   100 |    443.9 ns |   0.51 ns |  0.45 ns |   1.91x slower |   0.00x |  0.1297 |     - |     - |     272 B |
