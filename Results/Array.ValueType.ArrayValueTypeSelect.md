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
|                  ForLoop |   100 |  1.513 μs | 0.0032 μs | 0.0027 μs |      baseline |         |       - |       - |         - |
|              ForeachLoop |   100 |  1.626 μs | 0.0049 μs | 0.0046 μs |  1.07x slower |   0.00x |       - |       - |         - |
|                     Linq |   100 |  2.263 μs | 0.0022 μs | 0.0017 μs |  1.50x slower |   0.00x |  0.0496 |       - |     104 B |
|               LinqFaster |   100 |  2.443 μs | 0.0314 μs | 0.0278 μs |  1.62x slower |   0.02x |  3.0670 |       - |   6,424 B |
|             LinqFasterer |   100 |  2.708 μs | 0.0087 μs | 0.0078 μs |  1.79x slower |   0.01x |  3.0861 |       - |   6,456 B |
|                   LinqAF |   100 |  2.676 μs | 0.0082 μs | 0.0072 μs |  1.77x slower |   0.00x |       - |       - |         - |
|            LinqOptimizer |   100 | 48.152 μs | 0.2976 μs | 0.2784 μs | 31.83x slower |   0.18x | 57.6782 | 19.2261 | 156,723 B |
|                 SpanLinq |   100 |  2.233 μs | 0.0048 μs | 0.0045 μs |  1.48x slower |   0.00x |       - |       - |         - |
|                  Streams |   100 |  3.366 μs | 0.0093 μs | 0.0087 μs |  2.22x slower |   0.00x |  0.3929 |       - |     824 B |
|               StructLinq |   100 |  1.879 μs | 0.0028 μs | 0.0027 μs |  1.24x slower |   0.00x |  0.0153 |       - |      32 B |
| StructLinq_ValueDelegate |   100 |  1.650 μs | 0.0029 μs | 0.0027 μs |  1.09x slower |   0.00x |       - |       - |         - |
|                Hyperlinq |   100 |  1.908 μs | 0.0063 μs | 0.0059 μs |  1.26x slower |   0.00x |       - |       - |         - |
|  Hyperlinq_ValueDelegate |   100 |  1.849 μs | 0.0030 μs | 0.0027 μs |  1.22x slower |   0.00x |       - |       - |         - |
