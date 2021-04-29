## Array.Int32.ArrayInt32WhereSelectToArray

### Source
[ArrayInt32WhereSelectToArray.cs](../LinqBenchmarks/Array/Int32/ArrayInt32WhereSelectToArray.cs)

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
|                   Method | Count |        Mean |     Error |    StdDev |      Median |  Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |------ |------------:|----------:|----------:|------------:|-------:|--------:|--------:|------:|------:|----------:|
|                  ForLoop |   100 |    221.8 ns |   2.72 ns |   2.41 ns |    221.5 ns |   1.00 |    0.00 |  0.4246 |     - |     - |     888 B |
|              ForeachLoop |   100 |    239.0 ns |   5.44 ns |  15.69 ns |    230.2 ns |   1.16 |    0.07 |  0.4246 |     - |     - |     888 B |
|                     Linq |   100 |    571.1 ns |  11.37 ns |  20.78 ns |    580.6 ns |   2.46 |    0.09 |  0.3786 |     - |     - |     792 B |
|               LinqFaster |   100 |    360.7 ns |   1.92 ns |   1.80 ns |    360.2 ns |   1.63 |    0.02 |  0.3171 |     - |     - |     664 B |
|             LinqFasterer |   100 |    551.0 ns |   5.35 ns |   4.47 ns |    550.1 ns |   2.48 |    0.04 |  0.3977 |     - |     - |     832 B |
|                   LinqAF |   100 |    655.0 ns |  12.80 ns |  19.16 ns |    661.4 ns |   2.90 |    0.11 |  0.4091 |     - |     - |     856 B |
|            LinqOptimizer |   100 | 44,764.3 ns | 282.36 ns | 220.45 ns | 44,787.7 ns | 201.67 |    2.51 | 14.5264 |     - |     - |  30,496 B |
|                  Streams |   100 |    978.0 ns |   9.91 ns |   8.27 ns |    974.8 ns |   4.41 |    0.07 |  0.6695 |     - |     - |   1,400 B |
|               StructLinq |   100 |    569.0 ns |   4.65 ns |   4.35 ns |    568.2 ns |   2.57 |    0.03 |  0.1602 |     - |     - |     336 B |
| StructLinq_ValueDelegate |   100 |    309.3 ns |   2.32 ns |   2.17 ns |    308.8 ns |   1.39 |    0.02 |  0.1144 |     - |     - |     240 B |
|                Hyperlinq |   100 |    553.6 ns |   3.74 ns |   3.31 ns |    553.0 ns |   2.50 |    0.03 |  0.1144 |     - |     - |     240 B |
|  Hyperlinq_ValueDelegate |   100 |    338.0 ns |   1.53 ns |   1.28 ns |    337.4 ns |   1.52 |    0.02 |  0.1144 |     - |     - |     240 B |
