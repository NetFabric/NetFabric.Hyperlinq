## List.Int32.ListInt32Sum

### Source
[ListInt32Sum.cs](../LinqBenchmarks/List/Int32/ListInt32Sum.cs)

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
|                   Method | Count |         Mean |      Error |     StdDev |  Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |------ |-------------:|-----------:|-----------:|-------:|--------:|-------:|------:|------:|----------:|
|                  ForLoop |   100 |     84.93 ns |   0.247 ns |   0.207 ns |   1.00 |    0.00 |      - |     - |     - |         - |
|              ForeachLoop |   100 |    138.50 ns |   1.121 ns |   0.994 ns |   1.63 |    0.01 |      - |     - |     - |         - |
|                     Linq |   100 |    665.35 ns |   6.330 ns |   5.611 ns |   7.84 |    0.07 | 0.0191 |     - |     - |      40 B |
|               LinqFaster |   100 |     85.21 ns |   0.522 ns |   0.488 ns |   1.00 |    0.01 |      - |     - |     - |         - |
|             LinqFasterer |   100 |    100.20 ns |   1.341 ns |   1.254 ns |   1.18 |    0.02 | 0.2027 |     - |     - |     424 B |
|                   LinqAF |   100 |    432.36 ns |   2.560 ns |   2.269 ns |   5.09 |    0.03 |      - |     - |     - |         - |
|            LinqOptimizer |   100 | 25,922.94 ns | 255.834 ns | 239.308 ns | 305.45 |    3.05 | 8.1177 |     - |     - |  17,017 B |
|                  Streams |   100 |    262.96 ns |   1.223 ns |   1.085 ns |   3.10 |    0.01 | 0.0992 |     - |     - |     208 B |
|               StructLinq |   100 |     86.04 ns |   0.430 ns |   0.402 ns |   1.01 |    0.01 | 0.0153 |     - |     - |      32 B |
| StructLinq_ValueDelegate |   100 |     64.68 ns |   0.252 ns |   0.236 ns |   0.76 |    0.00 |      - |     - |     - |         - |
|                Hyperlinq |   100 |     24.56 ns |   0.256 ns |   0.227 ns |   0.29 |    0.00 |      - |     - |     - |         - |
