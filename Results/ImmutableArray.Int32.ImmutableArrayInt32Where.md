## ImmutableArray.Int32.ImmutableArrayInt32Where

### Source
[ImmutableArrayInt32Where.cs](../LinqBenchmarks/ImmutableArray/Int32/ImmutableArrayInt32Where.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqFasterer: [2.1.0](https://www.nuget.org/packages/LinqFasterer/2.1.0)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- LinqOptimizer.CSharp: [](https://www.nuget.org/packages/LinqOptimizer.CSharp/)
- Streams.CSharp: [0.6.0](https://www.nuget.org/packages/Streams.CSharp/0.6.0)
- StructLinq.BCL: [0.26.0](https://www.nuget.org/packages/StructLinq/0.26.0)
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)

### Results:
``` ini

BenchmarkDotNet=v0.12.1.1527-nightly, OS=Windows 10.0.19043
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.4.21227.6
  [Host] : .NET 5.0.4 (5.0.421.11614), X64 RyuJIT
  .NET 6 : .NET 6.0.0 (6.0.21.22210), X64 RyuJIT

Job=.NET 6  EnvironmentVariables=COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1  Runtime=.NET 6.0  

```
|                   Method | Count |         Mean |      Error |       StdDev |       Median |  Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |------ |-------------:|-----------:|-------------:|-------------:|-------:|--------:|--------:|------:|------:|----------:|
|                  ForLoop |   100 |     66.63 ns |   0.258 ns |     0.228 ns |     66.61 ns |   1.00 |    0.00 |       - |     - |     - |         - |
|              ForeachLoop |   100 |     67.19 ns |   0.300 ns |     0.281 ns |     67.09 ns |   1.01 |    0.00 |       - |     - |     - |         - |
|                     Linq |   100 |    442.67 ns |   6.543 ns |    13.068 ns |    439.07 ns |   6.73 |    0.31 |  0.0229 |     - |     - |      48 B |
|            LinqOptimizer |   100 | 43,621.03 ns | 708.828 ns | 1,829.712 ns | 43,032.39 ns | 680.68 |   48.16 | 13.9160 |     - |     - |  29,195 B |
|                  Streams |   100 |  1,767.10 ns |  27.484 ns |    25.709 ns |  1,777.71 ns |  26.49 |    0.41 |  0.2899 |     - |     - |     608 B |
|               StructLinq |   100 |    324.16 ns |   3.284 ns |     2.564 ns |    324.46 ns |   4.87 |    0.04 |  0.0153 |     - |     - |      32 B |
| StructLinq_ValueDelegate |   100 |    190.18 ns |   1.191 ns |     0.930 ns |    190.47 ns |   2.86 |    0.02 |       - |     - |     - |         - |
|                Hyperlinq |   100 |    296.59 ns |   3.968 ns |     3.712 ns |    296.82 ns |   4.46 |    0.06 |       - |     - |     - |         - |
|  Hyperlinq_ValueDelegate |   100 |    205.01 ns |   0.563 ns |     0.470 ns |    205.21 ns |   3.08 |    0.01 |       - |     - |     - |         - |
