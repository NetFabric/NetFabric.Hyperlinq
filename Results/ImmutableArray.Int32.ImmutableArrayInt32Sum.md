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
|                   Method | Count |         Mean |      Error |     StdDev |  Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |------ |-------------:|-----------:|-----------:|-------:|--------:|-------:|------:|------:|----------:|
|                  ForLoop |   100 |     46.28 ns |   0.206 ns |   0.172 ns |   1.00 |    0.00 |      - |     - |     - |         - |
|              ForeachLoop |   100 |     46.07 ns |   0.781 ns |   0.610 ns |   0.99 |    0.01 |      - |     - |     - |         - |
|                     Linq |   100 |    409.77 ns |   2.153 ns |   2.014 ns |   8.86 |    0.05 | 0.0267 |     - |     - |      56 B |
|             LinqFasterer |   100 |    125.76 ns |   1.012 ns |   0.897 ns |   2.72 |    0.02 | 0.2141 |     - |     - |     448 B |
|            LinqOptimizer |   100 | 27,458.00 ns | 377.940 ns | 491.429 ns | 596.62 |   13.21 | 8.1787 |     - |     - |  17,414 B |
|                  Streams |   100 |    613.15 ns |   2.884 ns |   2.556 ns |  13.25 |    0.07 | 0.1259 |     - |     - |     264 B |
|               StructLinq |   100 |    153.14 ns |   0.719 ns |   0.637 ns |   3.31 |    0.02 | 0.0153 |     - |     - |      32 B |
| StructLinq_ValueDelegate |   100 |     63.98 ns |   0.320 ns |   0.250 ns |   1.38 |    0.01 |      - |     - |     - |         - |
|                Hyperlinq |   100 |     21.79 ns |   0.276 ns |   0.245 ns |   0.47 |    0.01 |      - |     - |     - |         - |
