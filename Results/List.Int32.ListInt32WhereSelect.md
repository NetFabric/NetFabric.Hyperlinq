## List.Int32.ListInt32WhereSelect

### Source
[ListInt32WhereSelect.cs](../LinqBenchmarks/List/Int32/ListInt32WhereSelect.cs)

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
|                  ForLoop |   100 |    135.74 ns |   1.484 ns |     1.316 ns |    135.50 ns |   1.00 |    0.00 |       - |     - |     - |         - |
|              ForeachLoop |   100 |     86.74 ns |   0.403 ns |     0.337 ns |     86.84 ns |   0.64 |    0.01 |       - |     - |     - |         - |
|                     Linq |   100 |    801.08 ns |  11.622 ns |    10.872 ns |    803.93 ns |   5.90 |    0.10 |  0.0725 |     - |     - |     152 B |
|               LinqFaster |   100 |    576.98 ns |   4.191 ns |     5.449 ns |    575.81 ns |   4.24 |    0.04 |  0.3090 |     - |     - |     648 B |
|             LinqFasterer |   100 |    537.33 ns |   8.347 ns |     7.399 ns |    537.24 ns |   3.96 |    0.07 |  0.4473 |     - |     - |     936 B |
|                   LinqAF |   100 |    970.77 ns |   6.788 ns |     6.017 ns |    969.92 ns |   7.15 |    0.09 |       - |     - |     - |         - |
|            LinqOptimizer |   100 | 49,447.27 ns | 977.953 ns | 1,812.698 ns | 48,661.60 ns | 374.83 |   17.10 | 14.6484 |     - |     - |  30,787 B |
|                  Streams |   100 |  1,495.90 ns |   4.978 ns |     4.413 ns |  1,496.89 ns |  11.02 |    0.12 |  0.3624 |     - |     - |     760 B |
|               StructLinq |   100 |    328.73 ns |   2.220 ns |     1.733 ns |    329.02 ns |   2.42 |    0.02 |  0.0305 |     - |     - |      64 B |
| StructLinq_ValueDelegate |   100 |    199.20 ns |   0.753 ns |     0.704 ns |    199.27 ns |   1.47 |    0.02 |       - |     - |     - |         - |
|                Hyperlinq |   100 |    361.02 ns |   2.726 ns |     2.417 ns |    361.95 ns |   2.66 |    0.03 |       - |     - |     - |         - |
|  Hyperlinq_ValueDelegate |   100 |    216.02 ns |   1.229 ns |     1.089 ns |    215.96 ns |   1.59 |    0.02 |       - |     - |     - |         - |
