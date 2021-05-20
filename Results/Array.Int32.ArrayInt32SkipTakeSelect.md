## Array.Int32.ArrayInt32SkipTakeSelect

### Source
[ArrayInt32SkipTakeSelect.cs](../LinqBenchmarks/Array/Int32/ArrayInt32SkipTakeSelect.cs)

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
|                  ForLoop | 1000 |   100 |     63.81 ns |   0.459 ns |   0.407 ns |       baseline |         |       - |     - |     - |         - |
|                     Linq | 1000 |   100 |    937.48 ns |   5.040 ns |   4.715 ns |  14.70x slower |   0.12x |  0.0725 |     - |     - |     152 B |
|               LinqFaster | 1000 |   100 |    369.97 ns |   4.542 ns |   4.249 ns |   5.80x slower |   0.08x |  0.6080 |     - |     - |   1,272 B |
|             LinqFasterer | 1000 |   100 |    460.33 ns |   2.894 ns |   2.565 ns |   7.21x slower |   0.06x |  0.4206 |     - |     - |     880 B |
|                   LinqAF | 1000 |   100 |  2,877.06 ns |  17.820 ns |  16.669 ns |  45.10x slower |   0.36x |       - |     - |     - |         - |
|            LinqOptimizer | 1000 |   100 | 40,902.03 ns | 304.286 ns | 284.630 ns | 641.33x slower |   5.38x | 14.8926 |     - |     - |  31,181 B |
|                 SpanLinq | 1000 |   100 |    265.01 ns |   3.331 ns |   2.953 ns |   4.15x slower |   0.05x |       - |     - |     - |         - |
|                  Streams | 1000 |   100 |  7,283.37 ns |  43.330 ns |  38.411 ns | 114.15x slower |   0.93x |  0.4349 |     - |     - |     912 B |
|               StructLinq | 1000 |   100 |    274.43 ns |   1.936 ns |   1.716 ns |   4.30x slower |   0.04x |  0.0458 |     - |     - |      96 B |
| StructLinq_ValueDelegate | 1000 |   100 |    180.11 ns |   1.586 ns |   1.406 ns |   2.82x slower |   0.04x |       - |     - |     - |         - |
|                Hyperlinq | 1000 |   100 |    229.57 ns |   1.143 ns |   1.069 ns |   3.60x slower |   0.02x |       - |     - |     - |         - |
|  Hyperlinq_ValueDelegate | 1000 |   100 |    223.99 ns |   0.832 ns |   0.778 ns |   3.51x slower |   0.03x |       - |     - |     - |         - |
