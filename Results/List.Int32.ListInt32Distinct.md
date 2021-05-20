## List.Int32.ListInt32Distinct

### Source
[ListInt32Distinct.cs](../LinqBenchmarks/List/Int32/ListInt32Distinct.cs)

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
|                   Method | Duplicates | Count |        Mean |     Error |    StdDev |      Median |        Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |----------- |------ |------------:|----------:|----------:|------------:|-------------:|--------:|-------:|------:|------:|----------:|
|                  ForLoop |          4 |   100 |  3,797.7 ns |  73.87 ns | 157.43 ns |  3,721.1 ns |     baseline |         | 2.8610 |     - |     - |   6,000 B |
|              ForeachLoop |          4 |   100 |  4,025.6 ns |  45.20 ns |  40.06 ns |  4,015.5 ns | 1.00x faster |   0.03x | 2.8610 |     - |     - |   6,000 B |
|                     Linq |          4 |   100 |  6,959.5 ns |  36.95 ns |  32.75 ns |  6,951.6 ns | 1.73x slower |   0.05x | 2.8610 |     - |     - |   6,000 B |
|               LinqFaster |          4 |   100 |    651.2 ns |   5.45 ns |   4.83 ns |    650.8 ns | 6.19x faster |   0.19x |      - |     - |     - |         - |
|             LinqFasterer |          4 |   100 |  4,602.4 ns |  92.07 ns | 252.03 ns |  4,459.9 ns | 1.24x slower |   0.09x | 5.2032 |     - |     - |  10,896 B |
|                   LinqAF |          4 |   100 | 10,027.0 ns | 120.00 ns | 106.38 ns | 10,006.6 ns | 2.49x slower |   0.08x | 5.9204 |     - |     - |  12,400 B |
|               StructLinq |          4 |   100 |  3,666.2 ns |  46.37 ns |  38.72 ns |  3,685.6 ns | 1.11x faster |   0.02x | 0.0153 |     - |     - |      32 B |
| StructLinq_ValueDelegate |          4 |   100 |  3,601.3 ns |  22.96 ns |  21.48 ns |  3,601.0 ns | 1.11x faster |   0.03x |      - |     - |     - |         - |
|                Hyperlinq |          4 |   100 |  3,871.1 ns |  50.89 ns |  45.11 ns |  3,857.8 ns | 1.04x faster |   0.03x |      - |     - |     - |         - |
