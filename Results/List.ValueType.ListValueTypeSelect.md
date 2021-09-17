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
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)
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
|                   Method | Count |      Mean |     Error |    StdDev |         Ratio | RatioSD |   Gen 0 |   Gen 1 | Allocated |
|------------------------- |------ |----------:|----------:|----------:|--------------:|--------:|--------:|--------:|----------:|
|                  ForLoop |   100 |  1.652 μs | 0.0030 μs | 0.0028 μs |      baseline |         |       - |       - |         - |
|              ForeachLoop |   100 |  2.005 μs | 0.0060 μs | 0.0056 μs |  1.21x slower |   0.00x |       - |       - |         - |
|                     Linq |   100 |  2.390 μs | 0.0069 μs | 0.0061 μs |  1.45x slower |   0.00x |  0.0877 |       - |     184 B |
|               LinqFaster |   100 |  3.084 μs | 0.0130 μs | 0.0116 μs |  1.87x slower |   0.01x |  3.0861 |       - |   6,456 B |
|             LinqFasterer |   100 |  3.200 μs | 0.0101 μs | 0.0084 μs |  1.94x slower |   0.01x |  6.1531 |       - |  12,880 B |
|                   LinqAF |   100 |  2.869 μs | 0.0059 μs | 0.0055 μs |  1.74x slower |   0.00x |       - |       - |         - |
|            LinqOptimizer |   100 | 51.073 μs | 0.3941 μs | 0.3291 μs | 30.91x slower |   0.20x | 57.6782 | 19.2261 | 157,625 B |
|                 SpanLinq |   100 |  2.228 μs | 0.0017 μs | 0.0014 μs |  1.35x slower |   0.00x |       - |       - |         - |
|                  Streams |   100 |  3.534 μs | 0.0122 μs | 0.0108 μs |  2.14x slower |   0.01x |  0.4044 |       - |     848 B |
|               StructLinq |   100 |  1.931 μs | 0.0060 μs | 0.0056 μs |  1.17x slower |   0.00x |  0.0191 |       - |      40 B |
| StructLinq_ValueDelegate |   100 |  1.604 μs | 0.0026 μs | 0.0022 μs |  1.03x faster |   0.00x |       - |       - |         - |
|                Hyperlinq |   100 |  1.904 μs | 0.0014 μs | 0.0011 μs |  1.15x slower |   0.00x |       - |       - |         - |
|  Hyperlinq_ValueDelegate |   100 |  1.850 μs | 0.0045 μs | 0.0042 μs |  1.12x slower |   0.00x |       - |       - |         - |
