## ImmutableArray.Int32.ImmutableArrayInt32Select

### Source
[ImmutableArrayInt32Select.cs](../LinqBenchmarks/ImmutableArray/Int32/ImmutableArrayInt32Select.cs)

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
|                  ForLoop |   100 |     61.91 ns |  0.031 ns |  0.028 ns |       baseline |         |       - |     - |     - |         - |
|              ForeachLoop |   100 |     61.43 ns |  0.041 ns |  0.037 ns |   1.01x faster |   0.00x |       - |     - |     - |         - |
|                     Linq |   100 |    351.10 ns |  0.135 ns |  0.120 ns |   5.67x slower |   0.00x |  0.0229 |     - |     - |      48 B |
|             LinqFasterer |   100 |    444.12 ns |  2.064 ns |  1.612 ns |   7.17x slower |   0.03x |  0.4320 |     - |     - |     904 B |
|            LinqOptimizer |   100 | 40,050.87 ns | 41.713 ns | 32.567 ns | 646.85x slower |   0.53x | 13.6108 |     - |     - |  28,584 B |
|                  Streams |   100 |  1,601.18 ns |  1.312 ns |  1.163 ns |  25.86x slower |   0.02x |  0.2899 |     - |     - |     608 B |
|               StructLinq |   100 |    225.93 ns |  0.291 ns |  0.272 ns |   3.65x slower |   0.00x |  0.0153 |     - |     - |      32 B |
| StructLinq_ValueDelegate |   100 |    175.46 ns |  0.120 ns |  0.107 ns |   2.83x slower |   0.00x |       - |     - |     - |         - |
|                Hyperlinq |   100 |    254.86 ns |  0.505 ns |  0.473 ns |   4.12x slower |   0.00x |       - |     - |     - |         - |
|  Hyperlinq_ValueDelegate |   100 |    198.88 ns |  0.070 ns |  0.059 ns |   3.21x slower |   0.00x |       - |     - |     - |         - |
