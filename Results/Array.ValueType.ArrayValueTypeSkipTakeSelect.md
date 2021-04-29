## Array.ValueType.ArrayValueTypeSkipTakeSelect

### Source
[ArrayValueTypeSkipTakeSelect.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeSkipTakeSelect.cs)

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
|                   Method | Skip | Count |      Mean |     Error |    StdDev |    Median | Ratio | RatioSD |   Gen 0 |   Gen 1 | Gen 2 | Allocated |
|------------------------- |----- |------ |----------:|----------:|----------:|----------:|------:|--------:|--------:|--------:|------:|----------:|
|                  ForLoop | 1000 |   100 |  1.631 μs | 0.0037 μs | 0.0031 μs |  1.631 μs |  1.00 |    0.00 |       - |       - |     - |         - |
|              ForeachLoop | 1000 |   100 |  3.251 μs | 0.0072 μs | 0.0067 μs |  3.251 μs |  1.99 |    0.01 |  0.0153 |       - |     - |      32 B |
|                     Linq | 1000 |   100 |  2.576 μs | 0.0086 μs | 0.0076 μs |  2.575 μs |  1.58 |    0.01 |  0.1526 |       - |     - |     320 B |
|               LinqFaster | 1000 |   100 |  3.387 μs | 0.0677 μs | 0.1746 μs |  3.305 μs |  2.13 |    0.13 |  9.2010 |       - |     - |  19,272 B |
|             LinqFasterer | 1000 |   100 |  3.380 μs | 0.0446 μs | 0.1043 μs |  3.361 μs |  2.14 |    0.12 |  6.1531 |       - |     - |  12,880 B |
|                   LinqAF | 1000 |   100 |  8.643 μs | 0.0801 μs | 0.0749 μs |  8.649 μs |  5.30 |    0.04 |       - |       - |     - |         - |
|            LinqOptimizer | 1000 |   100 | 54.159 μs | 0.5050 μs | 0.4960 μs | 54.111 μs | 33.20 |    0.28 | 72.6318 | 18.0664 |     - | 160,689 B |
|                  Streams | 1000 |   100 | 17.288 μs | 0.0836 μs | 0.0782 μs | 17.270 μs | 10.60 |    0.06 |  0.5493 |       - |     - |   1,152 B |
|               StructLinq | 1000 |   100 |  1.922 μs | 0.0040 μs | 0.0035 μs |  1.922 μs |  1.18 |    0.00 |  0.0458 |       - |     - |      96 B |
| StructLinq_ValueDelegate | 1000 |   100 |  1.795 μs | 0.0034 μs | 0.0030 μs |  1.795 μs |  1.10 |    0.00 |       - |       - |     - |         - |
|                Hyperlinq | 1000 |   100 |  1.988 μs | 0.0042 μs | 0.0039 μs |  1.986 μs |  1.22 |    0.00 |       - |       - |     - |         - |
|  Hyperlinq_ValueDelegate | 1000 |   100 |  2.269 μs | 0.0063 μs | 0.0056 μs |  2.270 μs |  1.39 |    0.00 |       - |       - |     - |         - |
