## Enumerable.Int32.EnumerableInt32Sum

### Source
[EnumerableInt32Sum.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32Sum.cs)

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
|                   Method | Count |        Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |------ |------------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|              ForeachLoop |   100 |    281.1 ns |   1.13 ns |   1.06 ns |  1.00 |    0.00 | 0.0191 |     - |     - |      40 B |
|                     Linq |   100 |    204.0 ns |   1.07 ns |   0.95 ns |  0.73 |    0.00 | 0.0191 |     - |     - |      40 B |
|                   LinqAF |   100 |    403.1 ns |   3.87 ns |   3.43 ns |  1.43 |    0.01 | 0.0191 |     - |     - |      40 B |
|            LinqOptimizer |   100 | 25,542.5 ns | 129.10 ns | 172.35 ns | 90.77 |    0.48 | 8.2397 |     - |     - |  17,273 B |
|                  Streams |   100 |    515.6 ns |   2.76 ns |   2.44 ns |  1.83 |    0.01 | 0.1183 |     - |     - |     248 B |
|               StructLinq |   100 |    323.2 ns |   0.87 ns |   0.73 ns |  1.15 |    0.01 | 0.0305 |     - |     - |      64 B |
| StructLinq_ValueDelegate |   100 |    317.6 ns |   1.98 ns |   1.86 ns |  1.13 |    0.01 | 0.0191 |     - |     - |      40 B |
|                Hyperlinq |   100 |    257.0 ns |   1.09 ns |   0.97 ns |  0.91 |    0.00 | 0.0191 |     - |     - |      40 B |
