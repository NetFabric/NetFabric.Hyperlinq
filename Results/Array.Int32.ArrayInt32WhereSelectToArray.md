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
|                   Method | Count |        Mean |     Error |    StdDev |  Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |------ |------------:|----------:|----------:|-------:|--------:|--------:|------:|------:|----------:|
|                  ForLoop |   100 |    240.7 ns |   2.21 ns |   2.07 ns |   1.00 |    0.00 |  0.4244 |     - |     - |     888 B |
|              ForeachLoop |   100 |    243.7 ns |   4.24 ns |   3.54 ns |   1.01 |    0.02 |  0.4244 |     - |     - |     888 B |
|                     Linq |   100 |    572.2 ns |   4.13 ns |   3.66 ns |   2.38 |    0.02 |  0.3786 |     - |     - |     792 B |
|               LinqFaster |   100 |    370.9 ns |   3.66 ns |   3.42 ns |   1.54 |    0.01 |  0.3171 |     - |     - |     664 B |
|             LinqFasterer |   100 |    487.8 ns |   2.97 ns |   2.48 ns |   2.03 |    0.02 |  0.3977 |     - |     - |     832 B |
|                   LinqAF |   100 |    647.2 ns |   5.77 ns |   5.40 ns |   2.69 |    0.04 |  0.4091 |     - |     - |     856 B |
|            LinqOptimizer |   100 | 44,553.6 ns | 236.19 ns | 209.38 ns | 185.20 |    1.63 | 14.5264 |     - |     - |  30,496 B |
|                  Streams |   100 |    986.3 ns |   5.73 ns |   5.36 ns |   4.10 |    0.05 |  0.6695 |     - |     - |   1,400 B |
|               StructLinq |   100 |    552.3 ns |   7.09 ns |   6.63 ns |   2.29 |    0.04 |  0.1602 |     - |     - |     336 B |
| StructLinq_ValueDelegate |   100 |    312.6 ns |   1.76 ns |   1.64 ns |   1.30 |    0.01 |  0.1144 |     - |     - |     240 B |
|                Hyperlinq |   100 |    643.6 ns |   5.86 ns |   5.48 ns |   2.67 |    0.03 |  0.1144 |     - |     - |     240 B |
|  Hyperlinq_ValueDelegate |   100 |    343.3 ns |   1.38 ns |   1.15 ns |   1.43 |    0.01 |  0.1144 |     - |     - |     240 B |
