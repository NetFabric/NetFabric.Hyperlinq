## Array.ValueType.ArrayValueTypeWhereSelectToArray

### Source
[ArrayValueTypeWhereSelectToArray.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhereSelectToArray.cs)

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
|                   Method | Count |      Mean |     Error |    StdDev |    Median | Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |------ |----------:|----------:|----------:|----------:|------:|--------:|--------:|------:|------:|----------:|
|                  ForLoop |   100 |  1.542 μs | 0.0312 μs | 0.0920 μs |  1.506 μs |  1.00 |    0.00 |  5.5237 |     - |     - |     11 KB |
|              ForeachLoop |   100 |  2.026 μs | 0.0210 μs | 0.0197 μs |  2.023 μs |  1.26 |    0.06 |  5.5237 |     - |     - |     11 KB |
|                     Linq |   100 |  1.758 μs | 0.0309 μs | 0.0258 μs |  1.755 μs |  1.10 |    0.06 |  3.9291 |     - |     - |      8 KB |
|               LinqFaster |   100 |  1.350 μs | 0.0149 μs | 0.0279 μs |  1.346 μs |  0.87 |    0.06 |  4.7264 |     - |     - |     10 KB |
|             LinqFasterer |   100 |  2.547 μs | 0.0510 μs | 0.1503 μs |  2.464 μs |  1.66 |    0.13 |  6.0043 |     - |     - |     12 KB |
|                   LinqAF |   100 |  3.026 μs | 0.0205 μs | 0.0192 μs |  3.028 μs |  1.88 |    0.08 |  5.5084 |     - |     - |     11 KB |
|            LinqOptimizer |   100 | 53.402 μs | 0.8184 μs | 0.7655 μs | 53.089 μs | 33.14 |    1.76 | 73.9746 |     - |     - |    154 KB |
|                  Streams |   100 |  7.606 μs | 0.1431 μs | 0.1195 μs |  7.556 μs |  4.74 |    0.20 |  5.7678 |     - |     - |     12 KB |
|               StructLinq |   100 |  1.400 μs | 0.0134 μs | 0.0216 μs |  1.400 μs |  0.88 |    0.05 |  1.7052 |     - |     - |      3 KB |
| StructLinq_ValueDelegate |   100 |  1.145 μs | 0.0071 μs | 0.0066 μs |  1.142 μs |  0.71 |    0.03 |  1.6575 |     - |     - |      3 KB |
|                Hyperlinq |   100 |  1.708 μs | 0.0319 μs | 0.0298 μs |  1.703 μs |  1.06 |    0.05 |  1.6632 |     - |     - |      3 KB |
|  Hyperlinq_ValueDelegate |   100 |  1.547 μs | 0.0122 μs | 0.0114 μs |  1.545 μs |  0.96 |    0.04 |  1.6632 |     - |     - |      3 KB |
