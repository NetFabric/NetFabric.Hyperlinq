## ImmutableArray.Int32.ImmutableArrayInt32Select

### Source
[ImmutableArrayInt32Select.cs](../LinqBenchmarks/ImmutableArray/Int32/ImmutableArrayInt32Select.cs)

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
|                   Method | Count |         Mean |      Error |     StdDev |  Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |------ |-------------:|-----------:|-----------:|-------:|--------:|--------:|------:|------:|----------:|
|                  ForLoop |   100 |     58.99 ns |   0.249 ns |   0.233 ns |   1.00 |    0.00 |       - |     - |     - |         - |
|              ForeachLoop |   100 |     57.38 ns |   0.223 ns |   0.209 ns |   0.97 |    0.00 |       - |     - |     - |         - |
|                     Linq |   100 |    490.41 ns |   3.091 ns |   2.891 ns |   8.31 |    0.07 |  0.0229 |     - |     - |      48 B |
|             LinqFasterer |   100 |    412.89 ns |   6.896 ns |   6.451 ns |   7.00 |    0.10 |  0.4320 |     - |     - |     904 B |
|            LinqOptimizer |   100 | 37,788.15 ns | 206.153 ns | 160.951 ns | 640.56 |    5.10 | 13.6108 |     - |     - |  28,583 B |
|                  Streams |   100 |  1,646.83 ns |   7.078 ns |   6.621 ns |  27.92 |    0.15 |  0.2899 |     - |     - |     608 B |
|               StructLinq |   100 |    210.99 ns |   0.851 ns |   0.796 ns |   3.58 |    0.02 |  0.0153 |     - |     - |      32 B |
| StructLinq_ValueDelegate |   100 |    164.12 ns |   0.885 ns |   0.827 ns |   2.78 |    0.02 |       - |     - |     - |         - |
|                Hyperlinq |   100 |    237.75 ns |   1.378 ns |   1.289 ns |   4.03 |    0.03 |       - |     - |     - |         - |
|  Hyperlinq_ValueDelegate |   100 |    188.13 ns |   0.595 ns |   0.527 ns |   3.19 |    0.02 |       - |     - |     - |         - |
