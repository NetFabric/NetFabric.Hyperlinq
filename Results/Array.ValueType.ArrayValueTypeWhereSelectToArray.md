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
|                  ForLoop |   100 |  1.430 μs | 0.0138 μs | 0.0129 μs |  1.428 μs |  1.00 |    0.00 |  5.5237 |     - |     - |     11 KB |
|              ForeachLoop |   100 |  1.619 μs | 0.0129 μs | 0.0121 μs |  1.615 μs |  1.13 |    0.01 |  5.5237 |     - |     - |     11 KB |
|                     Linq |   100 |  1.757 μs | 0.0249 μs | 0.0233 μs |  1.759 μs |  1.23 |    0.02 |  3.9291 |     - |     - |      8 KB |
|               LinqFaster |   100 |  1.433 μs | 0.0477 μs | 0.1370 μs |  1.368 μs |  1.03 |    0.07 |  4.7264 |     - |     - |     10 KB |
|             LinqFasterer |   100 |  2.517 μs | 0.0270 μs | 0.0239 μs |  2.523 μs |  1.76 |    0.03 |  6.0043 |     - |     - |     12 KB |
|                   LinqAF |   100 |  2.666 μs | 0.0317 μs | 0.0281 μs |  2.669 μs |  1.87 |    0.03 |  5.5084 |     - |     - |     11 KB |
|            LinqOptimizer |   100 | 52.106 μs | 0.2429 μs | 0.2153 μs | 52.041 μs | 36.48 |    0.36 | 74.0356 |     - |     - |    154 KB |
|                  Streams |   100 |  7.091 μs | 0.0517 μs | 0.0431 μs |  7.100 μs |  4.97 |    0.06 |  5.7678 |     - |     - |     12 KB |
|               StructLinq |   100 |  1.437 μs | 0.0068 μs | 0.0060 μs |  1.436 μs |  1.01 |    0.01 |  1.7052 |     - |     - |      3 KB |
| StructLinq_ValueDelegate |   100 |  1.134 μs | 0.0069 μs | 0.0061 μs |  1.133 μs |  0.79 |    0.01 |  1.6575 |     - |     - |      3 KB |
|                Hyperlinq |   100 |  1.806 μs | 0.0262 μs | 0.0218 μs |  1.811 μs |  1.26 |    0.02 |  1.6632 |     - |     - |      3 KB |
|  Hyperlinq_ValueDelegate |   100 |  1.408 μs | 0.0109 μs | 0.0102 μs |  1.408 μs |  0.99 |    0.01 |  1.6632 |     - |     - |      3 KB |
