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
- NetFabric.Hyperlinq: [3.0.0-beta48](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta48)
- System.Linq.Async: [5.0.0](https://www.nuget.org/packages/System.Linq.Async/5.0.0)

### Results:
``` ini

BenchmarkDotNet=v0.13.1, OS=macOS Catalina 10.15.7 (19H1419) [Darwin 19.6.0]
Intel Core i5-7360U CPU 2.30GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-rc.2.21505.57
  [Host]     : .NET 5.0.6 (5.0.621.22011), X64 RyuJIT
  .NET 6 PGO : .NET 6.0.0 (6.0.21.48005), X64 RyuJIT

Job=.NET 6 PGO  EnvironmentVariables=COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1  Runtime=.NET 6.0  

```
|                   Method | Count |      Mean |     Error |    StdDev |         Ratio | RatioSD |   Gen 0 |   Gen 1 | Allocated |
|------------------------- |------ |----------:|----------:|----------:|--------------:|--------:|--------:|--------:|----------:|
|                  ForLoop |   100 |  1.655 μs | 0.0034 μs | 0.0030 μs |      baseline |         |       - |       - |         - |
|              ForeachLoop |   100 |  1.958 μs | 0.0025 μs | 0.0021 μs |  1.18x slower |   0.00x |       - |       - |         - |
|                     Linq |   100 |  2.402 μs | 0.0076 μs | 0.0063 μs |  1.45x slower |   0.00x |  0.0877 |       - |     184 B |
|               LinqFaster |   100 |  3.134 μs | 0.0070 μs | 0.0062 μs |  1.89x slower |   0.01x |  3.0861 |       - |   6,456 B |
|             LinqFasterer |   100 |  3.261 μs | 0.0237 μs | 0.0222 μs |  1.97x slower |   0.01x |  6.1531 |       - |  12,880 B |
|                   LinqAF |   100 |  2.870 μs | 0.0035 μs | 0.0031 μs |  1.73x slower |   0.00x |       - |       - |         - |
|            LinqOptimizer |   100 | 52.917 μs | 0.9995 μs | 1.1109 μs | 32.09x slower |   0.74x | 57.6782 | 19.2261 | 157,624 B |
|                 SpanLinq |   100 |  2.224 μs | 0.0035 μs | 0.0033 μs |  1.34x slower |   0.00x |       - |       - |         - |
|                  Streams |   100 |  3.526 μs | 0.0090 μs | 0.0084 μs |  2.13x slower |   0.01x |  0.4044 |       - |     848 B |
|               StructLinq |   100 |  1.909 μs | 0.0021 μs | 0.0020 μs |  1.15x slower |   0.00x |  0.0191 |       - |      40 B |
| StructLinq_ValueDelegate |   100 |  1.607 μs | 0.0019 μs | 0.0017 μs |  1.03x faster |   0.00x |       - |       - |         - |
|                Hyperlinq |   100 |  1.909 μs | 0.0015 μs | 0.0012 μs |  1.15x slower |   0.00x |       - |       - |         - |
|  Hyperlinq_ValueDelegate |   100 |  1.806 μs | 0.0193 μs | 0.0161 μs |  1.09x slower |   0.01x |       - |       - |         - |
