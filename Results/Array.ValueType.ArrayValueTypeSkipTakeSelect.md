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
|                   Method | Skip | Count |      Mean |     Error |    StdDev | Ratio | RatioSD |   Gen 0 |   Gen 1 | Gen 2 | Allocated |
|------------------------- |----- |------ |----------:|----------:|----------:|------:|--------:|--------:|--------:|------:|----------:|
|                  ForLoop | 1000 |   100 |  1.701 μs | 0.0081 μs | 0.0076 μs |  1.00 |    0.00 |       - |       - |     - |         - |
|                     Linq | 1000 |   100 |  2.638 μs | 0.0111 μs | 0.0104 μs |  1.55 |    0.01 |  0.1526 |       - |     - |     320 B |
|               LinqFaster | 1000 |   100 |  3.439 μs | 0.0237 μs | 0.0440 μs |  2.03 |    0.03 |  9.2010 |       - |     - |  19,272 B |
|             LinqFasterer | 1000 |   100 |  3.856 μs | 0.0304 μs | 0.0270 μs |  2.27 |    0.02 |  6.1531 |       - |     - |  12,880 B |
|                   LinqAF | 1000 |   100 |  8.769 μs | 0.1511 μs | 0.1414 μs |  5.16 |    0.09 |       - |       - |     - |         - |
|            LinqOptimizer | 1000 |   100 | 56.186 μs | 0.4623 μs | 0.4098 μs | 33.02 |    0.21 | 72.6318 | 18.0664 |     - | 160,689 B |
|                  Streams | 1000 |   100 | 17.111 μs | 0.0925 μs | 0.0865 μs | 10.06 |    0.06 |  0.5493 |       - |     - |   1,152 B |
|               StructLinq | 1000 |   100 |  1.977 μs | 0.0118 μs | 0.0111 μs |  1.16 |    0.01 |  0.0458 |       - |     - |      96 B |
| StructLinq_ValueDelegate | 1000 |   100 |  1.853 μs | 0.0066 μs | 0.0062 μs |  1.09 |    0.01 |       - |       - |     - |         - |
|                Hyperlinq | 1000 |   100 |  2.059 μs | 0.0387 μs | 0.0415 μs |  1.21 |    0.02 |       - |       - |     - |         - |
|  Hyperlinq_ValueDelegate | 1000 |   100 |  1.793 μs | 0.0072 μs | 0.0067 μs |  1.05 |    0.01 |       - |       - |     - |         - |
