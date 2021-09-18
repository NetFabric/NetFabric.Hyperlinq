## List.ValueType.ListValueTypeSelect

### Source
[ListValueTypeSelect.cs](../LinqBenchmarks/List/ValueType/ListValueTypeSelect.cs)

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
|                   Method | Count |      Mean |     Error |    StdDev |    Median |         Ratio | RatioSD |   Gen 0 |   Gen 1 | Allocated |
|------------------------- |------ |----------:|----------:|----------:|----------:|--------------:|--------:|--------:|--------:|----------:|
|                  ForLoop |   100 |  1.713 μs | 0.0327 μs | 0.0363 μs |  1.697 μs |      baseline |         |       - |       - |         - |
|              ForeachLoop |   100 |  2.076 μs | 0.0393 μs | 0.0368 μs |  2.063 μs |  1.21x slower |   0.02x |       - |       - |         - |
|                     Linq |   100 |  2.495 μs | 0.0486 μs | 0.0431 μs |  2.484 μs |  1.45x slower |   0.04x |  0.0877 |       - |     184 B |
|               LinqFaster |   100 |  3.299 μs | 0.0408 μs | 0.0319 μs |  3.286 μs |  1.93x slower |   0.04x |  3.0861 |       - |   6,456 B |
|             LinqFasterer |   100 |  5.060 μs | 0.5048 μs | 1.4806 μs |  5.130 μs |  2.59x slower |   0.77x |  6.1531 |       - |  12,880 B |
|                   LinqAF |   100 |  3.120 μs | 0.0615 μs | 0.1200 μs |  3.118 μs |  1.86x slower |   0.08x |       - |       - |         - |
|            LinqOptimizer |   100 | 58.955 μs | 1.1637 μs | 2.5299 μs | 58.512 μs | 34.79x slower |   1.58x | 57.6782 | 19.2261 | 157,624 B |
|                 SpanLinq |   100 |  2.407 μs | 0.0480 μs | 0.0762 μs |  2.397 μs |  1.41x slower |   0.05x |       - |       - |         - |
|                  Streams |   100 |  3.860 μs | 0.0757 μs | 0.1037 μs |  3.862 μs |  2.25x slower |   0.09x |  0.4044 |       - |     848 B |
|               StructLinq |   100 |  2.104 μs | 0.0418 μs | 0.1009 μs |  2.085 μs |  1.25x slower |   0.08x |  0.0191 |       - |      40 B |
| StructLinq_ValueDelegate |   100 |  1.746 μs | 0.0438 μs | 0.1191 μs |  1.725 μs |  1.07x slower |   0.06x |       - |       - |         - |
|                Hyperlinq |   100 |  1.948 μs | 0.0280 μs | 0.0234 μs |  1.943 μs |  1.14x slower |   0.03x |       - |       - |         - |
|  Hyperlinq_ValueDelegate |   100 |  1.908 μs | 0.0381 μs | 0.0786 μs |  1.873 μs |  1.10x slower |   0.05x |       - |       - |         - |
