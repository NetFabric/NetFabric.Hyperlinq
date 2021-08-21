## ImmutableArray.Int32.ImmutableArrayInt32Where

### Source
[ImmutableArrayInt32Where.cs](../LinqBenchmarks/ImmutableArray/Int32/ImmutableArrayInt32Where.cs)

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
|                   Method | Count |         Mean |     Error |    StdDev |          Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |------ |-------------:|----------:|----------:|---------------:|--------:|--------:|------:|------:|----------:|
|                  ForLoop |   100 |     73.10 ns |  0.572 ns |  0.535 ns |       baseline |         |       - |     - |     - |         - |
|              ForeachLoop |   100 |     72.96 ns |  0.387 ns |  0.343 ns |   1.00x faster |   0.01x |       - |     - |     - |         - |
|                     Linq |   100 |    339.77 ns |  0.242 ns |  0.202 ns |   4.65x slower |   0.04x |  0.0229 |     - |     - |      48 B |
|             LinqFasterer |   100 |    425.71 ns |  0.709 ns |  0.553 ns |   5.83x slower |   0.04x |  0.3443 |     - |     - |     720 B |
|            LinqOptimizer |   100 | 48,080.26 ns | 81.521 ns | 72.266 ns | 658.01x slower |   5.37x | 13.8550 |     - |     - |  29,051 B |
|                  Streams |   100 |  1,241.30 ns |  0.985 ns |  0.873 ns |  16.99x slower |   0.13x |  0.2899 |     - |     - |     608 B |
|               StructLinq |   100 |    382.40 ns |  2.821 ns |  2.501 ns |   5.23x slower |   0.05x |  0.0153 |     - |     - |      32 B |
| StructLinq_ValueDelegate |   100 |    197.51 ns |  0.081 ns |  0.067 ns |   2.70x slower |   0.02x |       - |     - |     - |         - |
|                Hyperlinq |   100 |    335.29 ns |  5.376 ns |  5.029 ns |   4.59x slower |   0.07x |       - |     - |     - |         - |
|  Hyperlinq_ValueDelegate |   100 |    222.77 ns |  0.074 ns |  0.058 ns |   3.05x slower |   0.02x |       - |     - |     - |         - |
