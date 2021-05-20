## ImmutableArray.Int32.ImmutableArrayInt32Sum

### Source
[ImmutableArrayInt32Sum.cs](../LinqBenchmarks/ImmutableArray/Int32/ImmutableArrayInt32Sum.cs)

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
|                   Method | Count |         Mean |      Error |       StdDev |       Median |          Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |------ |-------------:|-----------:|-------------:|-------------:|---------------:|--------:|-------:|------:|------:|----------:|
|                  ForLoop |   100 |     47.45 ns |   0.184 ns |     0.154 ns |     47.43 ns |       baseline |         |      - |     - |     - |         - |
|              ForeachLoop |   100 |     47.52 ns |   0.977 ns |     1.003 ns |     47.90 ns |   1.01x slower |   0.02x |      - |     - |     - |         - |
|                     Linq |   100 |    399.14 ns |   4.079 ns |     3.816 ns |    398.60 ns |   8.42x slower |   0.08x | 0.0267 |     - |     - |      56 B |
|             LinqFasterer |   100 |    115.04 ns |   1.026 ns |     0.960 ns |    115.53 ns |   2.43x slower |   0.03x | 0.2142 |     - |     - |     448 B |
|            LinqOptimizer |   100 | 29,070.92 ns | 884.041 ns | 2,606.615 ns | 27,395.32 ns | 604.14x slower |  49.60x | 8.2397 |     - |     - |  17,414 B |
|                  Streams |   100 |    622.21 ns |   4.382 ns |     4.099 ns |    621.47 ns |  13.12x slower |   0.11x | 0.1259 |     - |     - |     264 B |
|               StructLinq |   100 |    150.31 ns |   1.572 ns |     1.470 ns |    149.98 ns |   3.17x slower |   0.03x | 0.0153 |     - |     - |      32 B |
| StructLinq_ValueDelegate |   100 |     68.79 ns |   0.582 ns |     0.545 ns |     68.71 ns |   1.45x slower |   0.01x |      - |     - |     - |         - |
|                Hyperlinq |   100 |     23.42 ns |   0.524 ns |     0.846 ns |     22.90 ns |   1.94x faster |   0.02x |      - |     - |     - |         - |
