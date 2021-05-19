## Array.ValueType.ArrayValueTypeWhereSelectToList

### Source
[ArrayValueTypeWhereSelectToList.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhereSelectToList.cs)

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
|                   Method | Count |      Mean |     Error |    StdDev |    Median | Ratio | RatioSD |   Gen 0 |  Gen 1 | Gen 2 | Allocated |
|------------------------- |------ |----------:|----------:|----------:|----------:|------:|--------:|--------:|-------:|------:|----------:|
|                  ForLoop |   100 |  1.226 μs | 0.0178 μs | 0.0158 μs |  1.223 μs |  1.00 |    0.00 |  3.8605 |      - |     - |      8 KB |
|              ForeachLoop |   100 |  1.400 μs | 0.0281 μs | 0.0769 μs |  1.358 μs |  1.14 |    0.06 |  3.8605 |      - |     - |      8 KB |
|                     Linq |   100 |  1.606 μs | 0.0250 μs | 0.0234 μs |  1.609 μs |  1.31 |    0.03 |  3.9673 |      - |     - |      8 KB |
|               LinqFaster |   100 |  1.610 μs | 0.0291 μs | 0.0453 μs |  1.605 μs |  1.33 |    0.05 |  6.4087 |      - |     - |     13 KB |
|             LinqFasterer |   100 |  3.047 μs | 0.0374 μs | 0.0292 μs |  3.055 μs |  2.48 |    0.04 |  9.0332 |      - |     - |     18 KB |
|                   LinqAF |   100 |  2.614 μs | 0.0592 μs | 0.1745 μs |  2.526 μs |  2.20 |    0.16 |  3.8605 |      - |     - |      8 KB |
|            LinqOptimizer |   100 | 60.538 μs | 2.0740 μs | 6.1152 μs | 56.233 μs | 53.56 |    4.34 | 71.9604 | 6.7139 |     - |    157 KB |
|                 SpanLinq |   100 |  1.936 μs | 0.0267 μs | 0.0249 μs |  1.937 μs |  1.58 |    0.02 |  3.8605 |      - |     - |      8 KB |
|                  Streams |   100 |  7.524 μs | 0.1501 μs | 0.3510 μs |  7.294 μs |  6.11 |    0.32 |  4.1199 |      - |     - |      8 KB |
|               StructLinq |   100 |  1.649 μs | 0.0167 μs | 0.0148 μs |  1.648 μs |  1.35 |    0.03 |  1.7204 |      - |     - |      4 KB |
| StructLinq_ValueDelegate |   100 |  1.237 μs | 0.0108 μs | 0.0095 μs |  1.235 μs |  1.01 |    0.01 |  1.6766 |      - |     - |      3 KB |
|                Hyperlinq |   100 |  1.749 μs | 0.0329 μs | 0.0352 μs |  1.750 μs |  1.43 |    0.03 |  1.6747 |      - |     - |      3 KB |
|  Hyperlinq_ValueDelegate |   100 |  1.339 μs | 0.0117 μs | 0.0271 μs |  1.330 μs |  1.11 |    0.02 |  1.6766 |      - |     - |      3 KB |
