## Enumerable.Int32.EnumerableInt32Where

### Source
[EnumerableInt32Where.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32Where.cs)

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
|                   Method | Count |        Mean |    Error |   StdDev |         Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |------ |------------:|---------:|---------:|--------------:|--------:|--------:|------:|------:|----------:|
|                     Linq |   100 |    588.8 ns |  0.88 ns |  0.74 ns |      baseline |         |  0.0458 |     - |     - |      96 B |
|                   LinqAF |   100 |    398.4 ns |  0.20 ns |  0.17 ns |  1.48x faster |   0.00x |  0.0191 |     - |     - |      40 B |
|            LinqOptimizer |   100 | 46,118.9 ns | 65.78 ns | 58.32 ns | 78.33x slower |   0.14x | 13.8550 |     - |     - |  29,091 B |
|                  Streams |   100 |  1,512.5 ns |  1.02 ns |  0.80 ns |  2.57x slower |   0.00x |  0.2823 |     - |     - |     592 B |
|               StructLinq |   100 |    448.5 ns |  0.34 ns |  0.30 ns |  1.31x faster |   0.00x |  0.0305 |     - |     - |      64 B |
| StructLinq_ValueDelegate |   100 |    287.3 ns |  0.30 ns |  0.25 ns |  2.05x faster |   0.00x |  0.0191 |     - |     - |      40 B |
|                Hyperlinq |   100 |    445.2 ns |  0.35 ns |  0.32 ns |  1.32x faster |   0.00x |  0.0191 |     - |     - |      40 B |
|  Hyperlinq_ValueDelegate |   100 |    341.2 ns |  0.14 ns |  0.11 ns |  1.73x faster |   0.00x |  0.0191 |     - |     - |      40 B |
