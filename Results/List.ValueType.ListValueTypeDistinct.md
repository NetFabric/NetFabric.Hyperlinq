## List.ValueType.ListValueTypeDistinct

### Source
[ListValueTypeDistinct.cs](../LinqBenchmarks/List/ValueType/ListValueTypeDistinct.cs)

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
|                   Method | Duplicates | Count |      Mean |     Error |    StdDev |    Median | Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |----------- |------ |----------:|----------:|----------:|----------:|------:|--------:|--------:|------:|------:|----------:|
|                  ForLoop |          4 |   100 | 15.736 μs | 0.1776 μs | 0.1483 μs | 15.729 μs |  1.00 |    0.00 | 12.8174 |     - |     - |  26,976 B |
|              ForeachLoop |          4 |   100 | 15.097 μs | 0.0700 μs | 0.0585 μs | 15.097 μs |  0.96 |    0.01 | 12.8174 |     - |     - |  26,976 B |
|                     Linq |          4 |   100 | 17.121 μs | 0.1177 μs | 0.1043 μs | 17.104 μs |  1.09 |    0.01 | 12.8174 |     - |     - |  26,912 B |
|               LinqFaster |          4 |   100 |  3.066 μs | 0.0430 μs | 0.0381 μs |  3.061 μs |  0.19 |    0.00 |  0.0114 |     - |     - |      24 B |
|             LinqFasterer |          4 |   100 | 17.896 μs | 0.4105 μs | 1.1645 μs | 17.442 μs |  1.25 |    0.02 | 34.8816 |     - |     - |  73,168 B |
|                   LinqAF |          4 |   100 | 63.441 μs | 1.3406 μs | 3.5550 μs | 62.625 μs |  3.94 |    0.15 | 20.2637 |     - |     - |  42,552 B |
|               StructLinq |          4 |   100 | 15.401 μs | 0.0784 μs | 0.0733 μs | 15.397 μs |  0.98 |    0.01 |  0.0305 |     - |     - |      64 B |
| StructLinq_ValueDelegate |          4 |   100 |  5.002 μs | 0.0675 μs | 0.0599 μs |  4.979 μs |  0.32 |    0.00 |       - |     - |     - |         - |
|                Hyperlinq |          4 |   100 | 13.410 μs | 0.0455 μs | 0.0404 μs | 13.396 μs |  0.85 |    0.01 |       - |     - |     - |         - |
