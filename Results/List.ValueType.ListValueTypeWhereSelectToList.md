## List.ValueType.ListValueTypeWhereSelectToList

### Source
[ListValueTypeWhereSelectToList.cs](../LinqBenchmarks/List/ValueType/ListValueTypeWhereSelectToList.cs)

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
|                  ForLoop |   100 |  1.445 μs | 0.0350 μs | 0.1031 μs |  1.402 μs |  1.00 |    0.00 |  3.8605 |      - |     - |      8 KB |
|              ForeachLoop |   100 |  1.506 μs | 0.0199 μs | 0.0176 μs |  1.506 μs |  0.97 |    0.05 |  3.8605 |      - |     - |      8 KB |
|                     Linq |   100 |  1.817 μs | 0.0601 μs | 0.1676 μs |  1.730 μs |  1.26 |    0.12 |  4.0436 |      - |     - |      8 KB |
|               LinqFaster |   100 |  1.972 μs | 0.0391 μs | 0.0366 μs |  1.964 μs |  1.27 |    0.07 |  5.5389 |      - |     - |     11 KB |
|             LinqFasterer |   100 |  2.323 μs | 0.0352 μs | 0.0329 μs |  2.318 μs |  1.50 |    0.08 |  8.0643 |      - |     - |     16 KB |
|                   LinqAF |   100 |  3.506 μs | 0.0554 μs | 0.0518 μs |  3.484 μs |  2.26 |    0.13 |  3.8605 |      - |     - |      8 KB |
|            LinqOptimizer |   100 | 60.464 μs | 0.7699 μs | 0.7202 μs | 60.675 μs | 38.92 |    2.18 | 69.0918 | 6.1035 |     - |    158 KB |
|                  Streams |   100 |  7.509 μs | 0.0525 μs | 0.0465 μs |  7.509 μs |  4.84 |    0.25 |  4.1199 |      - |     - |      8 KB |
|               StructLinq |   100 |  1.473 μs | 0.0282 μs | 0.0787 μs |  1.435 μs |  1.02 |    0.06 |  1.7262 |      - |     - |      4 KB |
| StructLinq_ValueDelegate |   100 |  1.198 μs | 0.0147 μs | 0.0272 μs |  1.194 μs |  0.82 |    0.07 |  1.6766 |      - |     - |      3 KB |
|                Hyperlinq |   100 |  2.385 μs | 0.0133 μs | 0.0111 μs |  2.387 μs |  1.54 |    0.08 |  1.6747 |      - |     - |      3 KB |
|  Hyperlinq_ValueDelegate |   100 |  2.420 μs | 0.0138 μs | 0.0122 μs |  2.420 μs |  1.56 |    0.08 |  1.6747 |      - |     - |      3 KB |
