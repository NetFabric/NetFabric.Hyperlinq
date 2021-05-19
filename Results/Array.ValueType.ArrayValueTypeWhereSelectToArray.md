## Array.ValueType.ArrayValueTypeWhereSelectToArray

### Source
[ArrayValueTypeWhereSelectToArray.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhereSelectToArray.cs)

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
|                   Method | Count |      Mean |     Error |    StdDev |    Median | Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |------ |----------:|----------:|----------:|----------:|------:|--------:|--------:|------:|------:|----------:|
|                  ForLoop |   100 |  1.484 μs | 0.0278 μs | 0.0232 μs |  1.482 μs |  1.00 |    0.00 |  5.5237 |     - |     - |     11 KB |
|              ForeachLoop |   100 |  1.588 μs | 0.0238 μs | 0.0429 μs |  1.583 μs |  1.09 |    0.05 |  5.5237 |     - |     - |     11 KB |
|                     Linq |   100 |  1.720 μs | 0.0141 μs | 0.0312 μs |  1.715 μs |  1.16 |    0.05 |  3.9291 |     - |     - |      8 KB |
|               LinqFaster |   100 |  1.563 μs | 0.0305 μs | 0.0375 μs |  1.567 μs |  1.05 |    0.04 |  4.7264 |     - |     - |     10 KB |
|             LinqFasterer |   100 |  2.549 μs | 0.0346 μs | 0.0324 μs |  2.553 μs |  1.71 |    0.03 |  6.0043 |     - |     - |     12 KB |
|                   LinqAF |   100 |  2.795 μs | 0.0615 μs | 0.1814 μs |  2.697 μs |  1.96 |    0.12 |  5.5084 |     - |     - |     11 KB |
|            LinqOptimizer |   100 | 57.837 μs | 1.8194 μs | 5.3646 μs | 53.985 μs | 42.87 |    1.88 | 74.0356 |     - |     - |    154 KB |
|                 SpanLinq |   100 |  2.186 μs | 0.0188 μs | 0.0157 μs |  2.190 μs |  1.47 |    0.02 |  5.5237 |     - |     - |     11 KB |
|                  Streams |   100 |  7.426 μs | 0.1480 μs | 0.4149 μs |  7.149 μs |  5.39 |    0.21 |  5.7678 |     - |     - |     12 KB |
|               StructLinq |   100 |  1.449 μs | 0.0141 μs | 0.0125 μs |  1.448 μs |  0.98 |    0.02 |  1.7052 |     - |     - |      3 KB |
| StructLinq_ValueDelegate |   100 |  1.205 μs | 0.0260 μs | 0.0767 μs |  1.159 μs |  0.84 |    0.05 |  1.6575 |     - |     - |      3 KB |
|                Hyperlinq |   100 |  2.154 μs | 0.0117 μs | 0.0109 μs |  2.152 μs |  1.45 |    0.02 |  1.6632 |     - |     - |      3 KB |
|  Hyperlinq_ValueDelegate |   100 |  1.528 μs | 0.0102 μs | 0.0090 μs |  1.526 μs |  1.03 |    0.02 |  1.6632 |     - |     - |      3 KB |
