## List.Int32.ListInt32Sum

### Source
[ListInt32Sum.cs](../LinqBenchmarks/List/Int32/ListInt32Sum.cs)

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
|                   Method | Count |         Mean |      Error |     StdDev |          Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |------ |-------------:|-----------:|-----------:|---------------:|--------:|-------:|------:|------:|----------:|
|                  ForLoop |   100 |     87.88 ns |   0.632 ns |   0.591 ns |       baseline |         |      - |     - |     - |         - |
|              ForeachLoop |   100 |    141.90 ns |   1.954 ns |   1.525 ns |   1.61x slower |   0.02x |      - |     - |     - |         - |
|                     Linq |   100 |    669.30 ns |   8.791 ns |   7.341 ns |   7.62x slower |   0.10x | 0.0191 |     - |     - |      40 B |
|               LinqFaster |   100 |     86.56 ns |   1.216 ns |   1.016 ns |   1.01x faster |   0.01x |      - |     - |     - |         - |
|             LinqFasterer |   100 |     99.83 ns |   0.860 ns |   0.763 ns |   1.14x slower |   0.01x | 0.2027 |     - |     - |     424 B |
|                   LinqAF |   100 |    436.39 ns |   2.063 ns |   1.829 ns |   4.97x slower |   0.04x |      - |     - |     - |         - |
|            LinqOptimizer |   100 | 26,068.23 ns | 227.834 ns | 201.969 ns | 296.84x slower |   3.00x | 8.1177 |     - |     - |  17,017 B |
|                  Streams |   100 |    272.54 ns |   1.963 ns |   1.740 ns |   3.10x slower |   0.03x | 0.0992 |     - |     - |     208 B |
|               StructLinq |   100 |     86.07 ns |   0.417 ns |   0.390 ns |   1.02x faster |   0.01x | 0.0153 |     - |     - |      32 B |
| StructLinq_ValueDelegate |   100 |     65.75 ns |   0.326 ns |   0.289 ns |   1.34x faster |   0.01x |      - |     - |     - |         - |
|                Hyperlinq |   100 |     22.24 ns |   0.165 ns |   0.154 ns |   3.95x faster |   0.03x |      - |     - |     - |         - |
