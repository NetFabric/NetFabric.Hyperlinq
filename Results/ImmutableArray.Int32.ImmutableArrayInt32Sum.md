## ImmutableArray.Int32.ImmutableArrayInt32Sum

### Source
[ImmutableArrayInt32Sum.cs](../LinqBenchmarks/ImmutableArray/Int32/ImmutableArrayInt32Sum.cs)

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
|                   Method | Count |         Mean |      Error |     StdDev |       Median |  Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |------ |-------------:|-----------:|-----------:|-------------:|-------:|--------:|-------:|------:|------:|----------:|
|                  ForLoop |   100 |     44.93 ns |   0.177 ns |   0.157 ns |     44.91 ns |   1.00 |    0.00 |      - |     - |     - |         - |
|              ForeachLoop |   100 |     44.56 ns |   0.930 ns |   0.825 ns |     44.80 ns |   0.99 |    0.02 |      - |     - |     - |         - |
|                     Linq |   100 |    399.69 ns |   4.762 ns |   4.454 ns |    401.21 ns |   8.89 |    0.11 | 0.0267 |     - |     - |      56 B |
|            LinqOptimizer |   100 | 25,362.82 ns | 204.218 ns | 181.034 ns | 25,419.52 ns | 564.51 |    4.15 | 8.3008 |     - |     - |  17,415 B |
|                  Streams |   100 |    555.38 ns |   3.038 ns |   2.841 ns |    555.49 ns |  12.35 |    0.09 | 0.1259 |     - |     - |     264 B |
|               StructLinq |   100 |    145.00 ns |   0.708 ns |   0.591 ns |    144.86 ns |   3.23 |    0.02 | 0.0153 |     - |     - |      32 B |
| StructLinq_ValueDelegate |   100 |     62.63 ns |   0.184 ns |   0.172 ns |     62.68 ns |   1.39 |    0.01 |      - |     - |     - |         - |
|                Hyperlinq |   100 |     20.50 ns |   0.471 ns |   0.850 ns |     19.93 ns |   0.48 |    0.01 |      - |     - |     - |         - |
