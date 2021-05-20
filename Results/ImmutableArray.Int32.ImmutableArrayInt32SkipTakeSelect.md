## ImmutableArray.Int32.ImmutableArrayInt32SkipTakeSelect

### Source
[ImmutableArrayInt32SkipTakeSelect.cs](../LinqBenchmarks/ImmutableArray/Int32/ImmutableArrayInt32SkipTakeSelect.cs)

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
|                  ForLoop | 1000 |   100 |     87.64 ns |   0.359 ns |   0.318 ns |       baseline |         |       - |     - |     - |         - |
|                     Linq | 1000 |   100 |  1,180.06 ns |   6.786 ns |   5.667 ns |  13.46x slower |   0.09x |  0.0839 |     - |     - |     176 B |
|             LinqFasterer | 1000 |   100 |    838.46 ns |   9.094 ns |   8.507 ns |   9.57x slower |   0.11x |  2.5444 |     - |     - |   5,328 B |
|            LinqOptimizer | 1000 |   100 | 53,679.24 ns | 363.769 ns | 322.472 ns | 612.54x slower |   5.11x | 15.6250 |     - |     - |  32,723 B |
|                  Streams | 1000 |   100 |  9,756.05 ns | 119.616 ns | 111.889 ns | 111.29x slower |   1.36x |  0.4425 |     - |     - |     936 B |
|               StructLinq | 1000 |   100 |    253.30 ns |   1.704 ns |   1.423 ns |   2.89x slower |   0.02x |  0.0458 |     - |     - |      96 B |
| StructLinq_ValueDelegate | 1000 |   100 |    184.47 ns |   0.905 ns |   0.756 ns |   2.10x slower |   0.01x |       - |     - |     - |         - |
|                Hyperlinq | 1000 |   100 |    250.02 ns |   1.871 ns |   1.750 ns |   2.85x slower |   0.02x |       - |     - |     - |         - |
|  Hyperlinq_ValueDelegate | 1000 |   100 |    229.44 ns |   1.401 ns |   1.311 ns |   2.62x slower |   0.02x |       - |     - |     - |         - |
