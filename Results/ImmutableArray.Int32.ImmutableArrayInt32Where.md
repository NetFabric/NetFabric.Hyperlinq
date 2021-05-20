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

BenchmarkDotNet=v0.13.0, OS=Windows 10.0.19043.985 (21H1/May2021Update)
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.4.21227.6
  [Host] : .NET 5.0.6 (5.0.621.22011), X64 RyuJIT
  .NET 6 : .NET 6.0.0 (6.0.21.22210), X64 RyuJIT

Job=.NET 6  EnvironmentVariables=COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1  Runtime=.NET 6.0  

```
|                   Method | Count |         Mean |      Error |     StdDev |          Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |------ |-------------:|-----------:|-----------:|---------------:|--------:|--------:|------:|------:|----------:|
|                  ForLoop |   100 |     69.98 ns |   0.783 ns |   0.732 ns |       baseline |         |       - |     - |     - |         - |
|              ForeachLoop |   100 |     70.24 ns |   0.874 ns |   0.775 ns |   1.00x slower |   0.02x |       - |     - |     - |         - |
|                     Linq |   100 |    458.30 ns |   7.975 ns |   7.069 ns |   6.55x slower |   0.12x |  0.0229 |     - |     - |      48 B |
|             LinqFasterer |   100 |    466.99 ns |   4.320 ns |   4.041 ns |   6.67x slower |   0.10x |  0.3443 |     - |     - |     720 B |
|            LinqOptimizer |   100 | 54,837.60 ns | 722.257 ns | 640.262 ns | 783.62x slower |  12.52x | 13.9160 |     - |     - |  29,195 B |
|                  Streams |   100 |  1,754.80 ns |  10.919 ns |   8.525 ns |  25.09x slower |   0.31x |  0.2899 |     - |     - |     608 B |
|               StructLinq |   100 |    343.30 ns |   6.328 ns |   7.033 ns |   4.92x slower |   0.11x |  0.0153 |     - |     - |      32 B |
| StructLinq_ValueDelegate |   100 |    191.98 ns |   1.155 ns |   1.081 ns |   2.74x slower |   0.04x |       - |     - |     - |         - |
|                Hyperlinq |   100 |    382.87 ns |   4.681 ns |   4.379 ns |   5.47x slower |   0.07x |       - |     - |     - |         - |
|  Hyperlinq_ValueDelegate |   100 |    221.08 ns |   1.552 ns |   1.452 ns |   3.16x slower |   0.04x |       - |     - |     - |         - |
