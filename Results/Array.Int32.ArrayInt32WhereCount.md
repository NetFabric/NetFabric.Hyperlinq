## Array.Int32.ArrayInt32WhereCount

### Source
[ArrayInt32WhereCount.cs](../LinqBenchmarks/Array/Int32/ArrayInt32WhereCount.cs)

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
|                   Method | Count |         Mean |      Error |     StdDev |          Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |------ |-------------:|-----------:|-----------:|---------------:|--------:|-------:|------:|------:|----------:|
|                  ForLoop |   100 |     69.44 ns |   1.412 ns |   1.785 ns |       baseline |         |      - |     - |     - |         - |
|              ForeachLoop |   100 |     69.67 ns |   0.604 ns |   0.535 ns |   1.01x faster |   0.03x |      - |     - |     - |         - |
|                     Linq |   100 |    328.78 ns |   3.877 ns |   3.436 ns |   4.69x slower |   0.14x | 0.0153 |     - |     - |      32 B |
|               LinqFaster |   100 |    223.61 ns |   3.095 ns |   2.743 ns |   3.19x slower |   0.07x |      - |     - |     - |         - |
|             LinqFasterer |   100 |    258.70 ns |   3.017 ns |   2.675 ns |   3.69x slower |   0.11x |      - |     - |     - |         - |
|                   LinqAF |   100 |    239.34 ns |   1.866 ns |   1.655 ns |   3.41x slower |   0.10x |      - |     - |     - |         - |
|            LinqOptimizer |   100 | 33,448.78 ns | 417.099 ns | 752.116 ns | 482.53x slower |  11.37x | 9.0942 |     - |     - |  19,066 B |
|                 SpanLinq |   100 |    294.88 ns |   2.600 ns |   2.305 ns |   4.20x slower |   0.11x |      - |     - |     - |         - |
|                  Streams |   100 |    598.35 ns |   4.700 ns |   4.167 ns |   8.53x slower |   0.22x | 0.1717 |     - |     - |     360 B |
|               StructLinq |   100 |    255.07 ns |   4.368 ns |   4.086 ns |   3.64x slower |   0.09x | 0.0305 |     - |     - |      64 B |
| StructLinq_ValueDelegate |   100 |     94.03 ns |   1.222 ns |   1.084 ns |   1.34x slower |   0.04x |      - |     - |     - |         - |
|                Hyperlinq |   100 |    206.69 ns |   1.138 ns |   0.950 ns |   2.93x slower |   0.07x |      - |     - |     - |         - |
|  Hyperlinq_ValueDelegate |   100 |     95.70 ns |   1.068 ns |   0.999 ns |   1.37x slower |   0.03x |      - |     - |     - |         - |
