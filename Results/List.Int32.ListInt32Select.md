## List.Int32.ListInt32Select

### Source
[ListInt32Select.cs](../LinqBenchmarks/List/Int32/ListInt32Select.cs)

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
|                   Method | Count |        Mean |     Error |    StdDev |          Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |------ |------------:|----------:|----------:|---------------:|--------:|--------:|------:|------:|----------:|
|                  ForLoop |   100 |    113.3 ns |   0.86 ns |   0.76 ns |       baseline |         |       - |     - |     - |         - |
|              ForeachLoop |   100 |    142.0 ns |   1.05 ns |   0.98 ns |   1.25x slower |   0.01x |       - |     - |     - |         - |
|                     Linq |   100 |    683.2 ns |   3.38 ns |   2.82 ns |   6.02x slower |   0.04x |  0.0343 |     - |     - |      72 B |
|               LinqFaster |   100 |    400.7 ns |   4.78 ns |   4.47 ns |   3.53x slower |   0.05x |  0.2179 |     - |     - |     456 B |
|             LinqFasterer |   100 |    495.0 ns |   4.78 ns |   4.47 ns |   4.37x slower |   0.06x |  0.4206 |     - |     - |     880 B |
|                   LinqAF |   100 |    809.8 ns |   4.38 ns |   3.65 ns |   7.14x slower |   0.05x |       - |     - |     - |         - |
|            LinqOptimizer |   100 | 38,905.1 ns | 471.27 ns | 440.83 ns | 343.13x slower |   3.56x | 13.4277 |     - |     - |  28,183 B |
|                 SpanLinq |   100 |    254.0 ns |   1.82 ns |   1.70 ns |   2.24x slower |   0.02x |       - |     - |     - |         - |
|                  Streams |   100 |  1,444.9 ns |  22.99 ns |  19.20 ns |  12.74x slower |   0.16x |  0.2899 |     - |     - |     608 B |
|               StructLinq |   100 |    224.3 ns |   3.47 ns |   3.08 ns |   1.98x slower |   0.03x |  0.0153 |     - |     - |      32 B |
| StructLinq_ValueDelegate |   100 |    184.1 ns |   1.65 ns |   1.54 ns |   1.63x slower |   0.01x |       - |     - |     - |         - |
|                Hyperlinq |   100 |    243.8 ns |   1.79 ns |   1.59 ns |   2.15x slower |   0.02x |       - |     - |     - |         - |
|  Hyperlinq_ValueDelegate |   100 |    205.5 ns |   3.97 ns |   3.71 ns |   1.82x slower |   0.03x |       - |     - |     - |         - |
