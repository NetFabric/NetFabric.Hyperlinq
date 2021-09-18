## List.ValueType.ListValueTypeDistinct

### Source
[ListValueTypeDistinct.cs](../LinqBenchmarks/List/ValueType/ListValueTypeDistinct.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqFasterer: [2.1.0](https://www.nuget.org/packages/LinqFasterer/2.1.0)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- LinqOptimizer.CSharp: [0.7.0](https://www.nuget.org/packages/LinqOptimizer.CSharp/0.7.0)
- SpanLinq: [0.0.1](https://www.nuget.org/packages/SpanLinq/0.0.1)
- Streams.CSharp: [0.6.0](https://www.nuget.org/packages/Streams.CSharp/0.6.0)
- StructLinq.BCL: [0.27.0](https://www.nuget.org/packages/StructLinq/0.27.0)
- NetFabric.Hyperlinq: [3.0.0-beta46](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta46)
- System.Linq.Async: [5.0.0](https://www.nuget.org/packages/System.Linq.Async/5.0.0)

### Results:
``` ini

BenchmarkDotNet=v0.13.1, OS=macOS Catalina 10.15.7 (19H1417) [Darwin 19.6.0]
Intel Core i5-7360U CPU 2.30GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-rc.1.21458.32
  [Host]     : .NET 5.0.6 (5.0.621.22011), X64 RyuJIT
  .NET 6 PGO : .NET 6.0.0 (6.0.21.45113), X64 RyuJIT

Job=.NET 6 PGO  EnvironmentVariables=COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1  Runtime=.NET 6.0  

```
|                   Method | Duplicates | Count |      Mean |     Error |    StdDev |    Median |        Ratio | RatioSD |   Gen 0 | Allocated |
|------------------------- |----------- |------ |----------:|----------:|----------:|----------:|-------------:|--------:|--------:|----------:|
|                  ForLoop |          4 |   100 | 14.967 μs | 0.2958 μs | 0.7086 μs | 14.948 μs |     baseline |         | 12.8784 |  26,976 B |
|              ForeachLoop |          4 |   100 | 14.195 μs | 0.2830 μs | 0.5031 μs | 14.059 μs | 1.05x faster |   0.06x | 12.8784 |  26,976 B |
|                     Linq |          4 |   100 | 15.694 μs | 0.2633 μs | 0.2463 μs | 15.757 μs | 1.11x slower |   0.03x | 12.8174 |  26,912 B |
|               LinqFaster |          4 |   100 |  3.041 μs | 0.0594 μs | 0.1637 μs |  3.005 μs | 4.91x faster |   0.34x |  0.0114 |      24 B |
|             LinqFasterer |          4 |   100 | 19.293 μs | 0.4586 μs | 1.3231 μs | 18.992 μs | 1.28x slower |   0.12x | 34.8816 |  73,168 B |
|                   LinqAF |          4 |   100 | 41.935 μs | 0.8272 μs | 1.6134 μs | 41.400 μs | 2.83x slower |   0.17x | 20.8740 |  43,792 B |
|               StructLinq |          4 |   100 | 13.410 μs | 0.0820 μs | 0.0685 μs | 13.415 μs | 1.05x faster |   0.03x |  0.0305 |      65 B |
| StructLinq_ValueDelegate |          4 |   100 |  5.616 μs | 0.1258 μs | 0.3486 μs |  5.495 μs | 2.68x faster |   0.20x |       - |         - |
|                Hyperlinq |          4 |   100 | 12.005 μs | 0.1826 μs | 0.2103 μs | 11.941 μs | 1.19x faster |   0.06x |       - |         - |
