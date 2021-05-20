## List.Int32.ListInt32WhereSelect

### Source
[ListInt32WhereSelect.cs](../LinqBenchmarks/List/Int32/ListInt32WhereSelect.cs)

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
|                  ForLoop |   100 |    133.79 ns |   1.740 ns |   1.542 ns |       baseline |         |       - |     - |     - |         - |
|              ForeachLoop |   100 |     83.39 ns |   0.906 ns |   0.803 ns |   1.60x faster |   0.02x |       - |     - |     - |         - |
|                     Linq |   100 |    760.97 ns |   9.285 ns |   8.686 ns |   5.69x slower |   0.11x |  0.0725 |     - |     - |     152 B |
|               LinqFaster |   100 |    514.25 ns |   4.955 ns |   4.393 ns |   3.84x slower |   0.05x |  0.3090 |     - |     - |     648 B |
|             LinqFasterer |   100 |    511.98 ns |   3.723 ns |   3.483 ns |   3.83x slower |   0.06x |  0.4473 |     - |     - |     936 B |
|                   LinqAF |   100 |    949.99 ns |  11.125 ns |   9.862 ns |   7.10x slower |   0.12x |       - |     - |     - |         - |
|            LinqOptimizer |   100 | 49,971.39 ns | 332.163 ns | 259.331 ns | 373.21x slower |   5.08x | 14.6484 |     - |     - |  30,787 B |
|                 SpanLinq |   100 |    411.03 ns |   3.096 ns |   2.585 ns |   3.07x slower |   0.04x |       - |     - |     - |         - |
|                  Streams |   100 |  1,577.55 ns |   8.245 ns |   7.309 ns |  11.79x slower |   0.16x |  0.3624 |     - |     - |     760 B |
|               StructLinq |   100 |    389.44 ns |   4.675 ns |   4.373 ns |   2.91x slower |   0.04x |  0.0305 |     - |     - |      64 B |
| StructLinq_ValueDelegate |   100 |    206.49 ns |   1.865 ns |   1.653 ns |   1.54x slower |   0.03x |       - |     - |     - |         - |
|                Hyperlinq |   100 |    359.35 ns |   7.119 ns |   7.311 ns |   2.69x slower |   0.05x |       - |     - |     - |         - |
|  Hyperlinq_ValueDelegate |   100 |    235.26 ns |   2.064 ns |   1.931 ns |   1.76x slower |   0.02x |       - |     - |     - |         - |
