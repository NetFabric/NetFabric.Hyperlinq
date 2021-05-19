## Array.ValueType.ArrayValueTypeSkipTakeSelect

### Source
[ArrayValueTypeSkipTakeSelect.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeSkipTakeSelect.cs)

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
|                   Method | Skip | Count |      Mean |     Error |    StdDev | Ratio | RatioSD |   Gen 0 |   Gen 1 | Gen 2 | Allocated |
|------------------------- |----- |------ |----------:|----------:|----------:|------:|--------:|--------:|--------:|------:|----------:|
|                  ForLoop | 1000 |   100 |  1.657 μs | 0.0067 μs | 0.0059 μs |  1.00 |    0.00 |       - |       - |     - |         - |
|                     Linq | 1000 |   100 |  2.576 μs | 0.0078 μs | 0.0069 μs |  1.55 |    0.01 |  0.1526 |       - |     - |     320 B |
|               LinqFaster | 1000 |   100 |  3.355 μs | 0.0285 μs | 0.0483 μs |  2.04 |    0.03 |  9.2010 |       - |     - |  19,272 B |
|             LinqFasterer | 1000 |   100 |  3.344 μs | 0.0336 μs | 0.0280 μs |  2.02 |    0.02 |  6.1531 |       - |     - |  12,880 B |
|                   LinqAF | 1000 |   100 |  9.165 μs | 0.1324 μs | 0.1238 μs |  5.53 |    0.08 |       - |       - |     - |         - |
|            LinqOptimizer | 1000 |   100 | 55.594 μs | 0.7568 μs | 0.7079 μs | 33.52 |    0.40 | 72.6318 | 18.0664 |     - | 160,690 B |
|                 SpanLinq | 1000 |   100 |  2.200 μs | 0.0064 μs | 0.0057 μs |  1.33 |    0.01 |       - |       - |     - |         - |
|                  Streams | 1000 |   100 | 18.186 μs | 0.1098 μs | 0.0973 μs | 10.97 |    0.05 |  0.5493 |       - |     - |   1,152 B |
|               StructLinq | 1000 |   100 |  1.913 μs | 0.0083 μs | 0.0077 μs |  1.15 |    0.01 |  0.0458 |       - |     - |      96 B |
| StructLinq_ValueDelegate | 1000 |   100 |  1.837 μs | 0.0047 μs | 0.0042 μs |  1.11 |    0.00 |       - |       - |     - |         - |
|                Hyperlinq | 1000 |   100 |  1.992 μs | 0.0059 μs | 0.0052 μs |  1.20 |    0.00 |       - |       - |     - |         - |
|  Hyperlinq_ValueDelegate | 1000 |   100 |  1.767 μs | 0.0078 μs | 0.0065 μs |  1.07 |    0.01 |       - |       - |     - |         - |
