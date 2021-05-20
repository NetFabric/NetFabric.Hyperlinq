## Array.Int32.ArrayInt32SkipTakeWhere

### Source
[ArrayInt32SkipTakeWhere.cs](../LinqBenchmarks/Array/Int32/ArrayInt32SkipTakeWhere.cs)

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
|                   Method | Skip | Count |         Mean |      Error |     StdDev |          Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |----- |------ |-------------:|-----------:|-----------:|---------------:|--------:|--------:|------:|------:|----------:|
|                  ForLoop | 1000 |   100 |     91.64 ns |   0.713 ns |   0.632 ns |       baseline |         |       - |     - |     - |         - |
|                     Linq | 1000 |   100 |  1,218.57 ns |  11.653 ns |  10.330 ns |  13.30x slower |   0.15x |  0.0725 |     - |     - |     152 B |
|               LinqFaster | 1000 |   100 |    359.57 ns |   6.960 ns |   5.812 ns |   3.92x slower |   0.05x |  0.7191 |     - |     - |   1,504 B |
|             LinqFasterer | 1000 |   100 |    481.71 ns |   4.037 ns |   3.579 ns |   5.26x slower |   0.07x |  0.3285 |     - |     - |     688 B |
|                   LinqAF | 1000 |   100 |  2,975.16 ns |  13.923 ns |  13.023 ns |  32.47x slower |   0.27x |       - |     - |     - |         - |
|            LinqOptimizer | 1000 |   100 | 47,105.63 ns | 525.252 ns | 491.321 ns | 513.92x slower |   7.07x | 15.1367 |     - |     - |  31,784 B |
|                 SpanLinq | 1000 |   100 |    347.39 ns |   4.366 ns |   3.646 ns |   3.79x slower |   0.04x |       - |     - |     - |         - |
|                  Streams | 1000 |   100 |  7,074.74 ns | 132.875 ns | 124.292 ns |  77.19x slower |   1.26x |  0.4349 |     - |     - |     912 B |
|               StructLinq | 1000 |   100 |    333.06 ns |   3.556 ns |   3.152 ns |   3.63x slower |   0.05x |  0.0458 |     - |     - |      96 B |
| StructLinq_ValueDelegate | 1000 |   100 |    172.30 ns |   0.961 ns |   0.852 ns |   1.88x slower |   0.01x |       - |     - |     - |         - |
|                Hyperlinq | 1000 |   100 |    315.60 ns |   4.257 ns |   3.774 ns |   3.44x slower |   0.04x |       - |     - |     - |         - |
|  Hyperlinq_ValueDelegate | 1000 |   100 |    241.26 ns |   1.472 ns |   1.305 ns |   2.63x slower |   0.02x |       - |     - |     - |         - |
