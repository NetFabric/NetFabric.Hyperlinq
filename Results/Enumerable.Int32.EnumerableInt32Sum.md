## Enumerable.Int32.EnumerableInt32Sum

### Source
[EnumerableInt32Sum.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32Sum.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqFasterer: [2.1.0](https://www.nuget.org/packages/LinqFasterer/2.1.0)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- LinqOptimizer.CSharp: [0.7.0](https://www.nuget.org/packages/LinqOptimizer.CSharp/0.7.0)
- SpanLinq: [1.0.0](https://www.nuget.org/packages/SpanLinq/1.0.0)
- Streams.CSharp: [0.6.0](https://www.nuget.org/packages/Streams.CSharp/0.6.0)
- StructLinq.BCL: [0.26.0](https://www.nuget.org/packages/StructLinq/0.26.0)
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)
- System.Linq.Async: [5.0.0](https://www.nuget.org/packages/System.Linq.Async/5.0.0)

### Results:
``` ini

BenchmarkDotNet=v0.12.1.1538-nightly, OS=Windows 10.0.19043
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.4.21227.6
  [Host] : .NET 5.0.6 (5.0.621.22011), X64 RyuJIT
  .NET 6 : .NET 6.0.0 (6.0.21.22210), X64 RyuJIT

Job=.NET 6  EnvironmentVariables=COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1  Runtime=.NET 6.0  

```
|                   Method | Count |        Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |------ |------------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|              ForeachLoop |   100 |    286.8 ns |   2.77 ns |   2.59 ns |  1.00 |    0.00 | 0.0191 |     - |     - |      40 B |
|                     Linq |   100 |    203.8 ns |   1.11 ns |   0.98 ns |  0.71 |    0.01 | 0.0191 |     - |     - |      40 B |
|                   LinqAF |   100 |    280.5 ns |   1.71 ns |   1.52 ns |  0.98 |    0.01 | 0.0191 |     - |     - |      40 B |
|            LinqOptimizer |   100 | 25,217.8 ns | 284.80 ns | 266.40 ns | 87.95 |    1.15 | 8.2397 |     - |     - |  17,273 B |
|                  Streams |   100 |    477.8 ns |   8.22 ns |   7.29 ns |  1.67 |    0.03 | 0.1183 |     - |     - |     248 B |
|               StructLinq |   100 |    327.0 ns |   4.56 ns |   9.72 ns |  1.15 |    0.05 | 0.0305 |     - |     - |      64 B |
| StructLinq_ValueDelegate |   100 |    282.1 ns |   1.47 ns |   1.30 ns |  0.98 |    0.01 | 0.0191 |     - |     - |      40 B |
|                Hyperlinq |   100 |    309.5 ns |   1.44 ns |   1.20 ns |  1.08 |    0.01 | 0.0191 |     - |     - |      40 B |
