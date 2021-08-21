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
- StructLinq.BCL: [0.26.0](https://www.nuget.org/packages/StructLinq/0.26.0)
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)
- System.Linq.Async: [5.0.0](https://www.nuget.org/packages/System.Linq.Async/5.0.0)

### Results:
``` ini

BenchmarkDotNet=v0.13.0, OS=macOS Catalina 10.15.7 (19H1323) [Darwin 19.6.0]
Intel Core i5-7360U CPU 2.30GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.7.21379.14
  [Host] : .NET 5.0.6 (5.0.621.22011), X64 RyuJIT
  .NET 6 : .NET 6.0.0 (6.0.21.37719), X64 RyuJIT

Job=.NET 6  EnvironmentVariables=COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1  Runtime=.NET 6.0  

```
|                   Method | Count |      Mean |     Error |    StdDev |         Ratio | RatioSD |   Gen 0 |   Gen 1 | Gen 2 | Allocated |
|------------------------- |------ |----------:|----------:|----------:|--------------:|--------:|--------:|--------:|------:|----------:|
|                  ForLoop |   100 |  1.651 μs | 0.0005 μs | 0.0005 μs |      baseline |         |       - |       - |     - |         - |
|              ForeachLoop |   100 |  2.003 μs | 0.0007 μs | 0.0007 μs |  1.21x slower |   0.00x |       - |       - |     - |         - |
|                     Linq |   100 |  2.390 μs | 0.0026 μs | 0.0024 μs |  1.45x slower |   0.00x |  0.0877 |       - |     - |     184 B |
|               LinqFaster |   100 |  3.092 μs | 0.0052 μs | 0.0048 μs |  1.87x slower |   0.00x |  3.0861 |       - |     - |   6,456 B |
|             LinqFasterer |   100 |  3.191 μs | 0.0066 μs | 0.0062 μs |  1.93x slower |   0.00x |  6.1531 |       - |     - |  12,880 B |
|                   LinqAF |   100 |  2.885 μs | 0.0319 μs | 0.0266 μs |  1.75x slower |   0.02x |       - |       - |     - |         - |
|            LinqOptimizer |   100 | 51.162 μs | 0.3613 μs | 0.3203 μs | 30.99x slower |   0.20x | 68.9087 | 17.2119 |     - | 157,637 B |
|                 SpanLinq |   100 |  2.228 μs | 0.0012 μs | 0.0010 μs |  1.35x slower |   0.00x |       - |       - |     - |         - |
|                  Streams |   100 |  3.527 μs | 0.0033 μs | 0.0027 μs |  2.14x slower |   0.00x |  0.4044 |       - |     - |     848 B |
|               StructLinq |   100 |  1.928 μs | 0.0008 μs | 0.0007 μs |  1.17x slower |   0.00x |  0.0191 |       - |     - |      40 B |
| StructLinq_ValueDelegate |   100 |  1.603 μs | 0.0008 μs | 0.0007 μs |  1.03x faster |   0.00x |       - |       - |     - |         - |
|                Hyperlinq |   100 |  1.906 μs | 0.0009 μs | 0.0008 μs |  1.15x slower |   0.00x |       - |       - |     - |         - |
|  Hyperlinq_ValueDelegate |   100 |  1.847 μs | 0.0003 μs | 0.0002 μs |  1.12x slower |   0.00x |       - |       - |     - |         - |
