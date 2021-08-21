## Array.ValueType.ArrayValueTypeSelect

### Source
[ArrayValueTypeSelect.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeSelect.cs)

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
|                  ForLoop |   100 |  1.535 μs | 0.0291 μs | 0.0368 μs |      baseline |         |       - |       - |     - |         - |
|              ForeachLoop |   100 |  1.637 μs | 0.0024 μs | 0.0022 μs |  1.06x slower |   0.03x |       - |       - |     - |         - |
|                     Linq |   100 |  2.255 μs | 0.0011 μs | 0.0009 μs |  1.46x slower |   0.04x |  0.0496 |       - |     - |     104 B |
|               LinqFaster |   100 |  2.413 μs | 0.0031 μs | 0.0025 μs |  1.56x slower |   0.05x |  3.0670 |       - |     - |   6,424 B |
|             LinqFasterer |   100 |  2.705 μs | 0.0048 μs | 0.0045 μs |  1.76x slower |   0.05x |  3.0861 |       - |     - |   6,456 B |
|                   LinqAF |   100 |  2.672 μs | 0.0009 μs | 0.0008 μs |  1.73x slower |   0.05x |       - |       - |     - |         - |
|            LinqOptimizer |   100 | 48.058 μs | 0.2341 μs | 0.2189 μs | 31.24x slower |   0.83x | 57.6782 | 19.1650 |     - | 156,724 B |
|                 SpanLinq |   100 |  2.231 μs | 0.0021 μs | 0.0019 μs |  1.45x slower |   0.04x |       - |       - |     - |         - |
|                  Streams |   100 |  3.360 μs | 0.0026 μs | 0.0023 μs |  2.18x slower |   0.06x |  0.3929 |       - |     - |     824 B |
|               StructLinq |   100 |  1.875 μs | 0.0006 μs | 0.0005 μs |  1.21x slower |   0.04x |  0.0153 |       - |     - |      32 B |
| StructLinq_ValueDelegate |   100 |  1.651 μs | 0.0010 μs | 0.0009 μs |  1.07x slower |   0.03x |       - |       - |     - |         - |
|                Hyperlinq |   100 |  1.905 μs | 0.0010 μs | 0.0008 μs |  1.23x slower |   0.04x |       - |       - |     - |         - |
|  Hyperlinq_ValueDelegate |   100 |  1.848 μs | 0.0010 μs | 0.0009 μs |  1.20x slower |   0.03x |       - |       - |     - |         - |
