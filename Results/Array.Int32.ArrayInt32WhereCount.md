## Array.Int32.ArrayInt32WhereCount

### Source
[ArrayInt32WhereCount.cs](../LinqBenchmarks/Array/Int32/ArrayInt32WhereCount.cs)

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
|                   Method | Count |         Mean |      Error |       StdDev |       Median |  Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |------ |-------------:|-----------:|-------------:|-------------:|-------:|--------:|-------:|------:|------:|----------:|
|                  ForLoop |   100 |     66.53 ns |   0.270 ns |     0.240 ns |     66.51 ns |   1.00 |    0.00 |      - |     - |     - |         - |
|              ForeachLoop |   100 |     66.51 ns |   0.239 ns |     0.212 ns |     66.46 ns |   1.00 |    0.01 |      - |     - |     - |         - |
|                     Linq |   100 |    307.75 ns |   2.392 ns |     2.237 ns |    307.81 ns |   4.63 |    0.04 | 0.0153 |     - |     - |      32 B |
|               LinqFaster |   100 |    235.79 ns |   1.299 ns |     1.216 ns |    235.73 ns |   3.54 |    0.02 |      - |     - |     - |         - |
|             LinqFasterer |   100 |    248.14 ns |   0.875 ns |     0.818 ns |    248.11 ns |   3.73 |    0.01 |      - |     - |     - |         - |
|                   LinqAF |   100 |    248.17 ns |   1.278 ns |     1.067 ns |    247.78 ns |   3.73 |    0.02 |      - |     - |     - |         - |
|            LinqOptimizer |   100 | 32,356.77 ns | 891.263 ns | 2,627.910 ns | 30,683.76 ns | 544.06 |   12.38 | 9.0942 |     - |     - |  19,066 B |
|                  Streams |   100 |    604.63 ns |   3.667 ns |     3.430 ns |    605.92 ns |   9.08 |    0.06 | 0.1717 |     - |     - |     360 B |
|               StructLinq |   100 |    241.51 ns |   1.864 ns |     1.652 ns |    241.71 ns |   3.63 |    0.02 | 0.0305 |     - |     - |      64 B |
| StructLinq_ValueDelegate |   100 |     84.38 ns |   0.388 ns |     0.324 ns |     84.29 ns |   1.27 |    0.01 |      - |     - |     - |         - |
|                Hyperlinq |   100 |    199.02 ns |   0.467 ns |     0.414 ns |    199.16 ns |   2.99 |    0.01 |      - |     - |     - |         - |
|  Hyperlinq_ValueDelegate |   100 |     87.18 ns |   0.609 ns |     0.540 ns |     87.29 ns |   1.31 |    0.01 |      - |     - |     - |         - |
