## Enumerable.Int32.EnumerableInt32WhereCount

### Source
[EnumerableInt32WhereCount.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32WhereCount.cs)

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
|                   Method | Count |        Mean |     Error |    StdDev |          Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |------ |------------:|----------:|----------:|---------------:|--------:|-------:|------:|------:|----------:|
|              ForeachLoop |   100 |    270.5 ns |   5.06 ns |   4.48 ns |       baseline |         | 0.0191 |     - |     - |      40 B |
|                     Linq |   100 |    392.3 ns |   3.50 ns |   3.10 ns |   1.45x slower |   0.02x | 0.0191 |     - |     - |      40 B |
|                   LinqAF |   100 |    498.0 ns |   3.50 ns |   3.10 ns |   1.84x slower |   0.04x | 0.0191 |     - |     - |      40 B |
|            LinqOptimizer |   100 | 39,101.1 ns | 520.27 ns | 486.66 ns | 144.54x slower |   2.21x | 9.7656 |     - |     - |  20,501 B |
|                  Streams |   100 |    903.3 ns |   8.80 ns |   7.35 ns |   3.33x slower |   0.08x | 0.1907 |     - |     - |     400 B |
|               StructLinq |   100 |    483.0 ns |   4.97 ns |   4.41 ns |   1.79x slower |   0.03x | 0.0458 |     - |     - |      96 B |
| StructLinq_ValueDelegate |   100 |    378.6 ns |   3.84 ns |   3.41 ns |   1.40x slower |   0.03x | 0.0191 |     - |     - |      40 B |
|                Hyperlinq |   100 |    440.9 ns |   4.36 ns |   3.87 ns |   1.63x slower |   0.03x | 0.0191 |     - |     - |      40 B |
|  Hyperlinq_ValueDelegate |   100 |    267.5 ns |   4.91 ns |   4.35 ns |   1.01x faster |   0.02x | 0.0191 |     - |     - |      40 B |
