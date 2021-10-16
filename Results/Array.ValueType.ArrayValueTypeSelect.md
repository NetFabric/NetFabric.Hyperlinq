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
|                  ForLoop |   100 |  1.512 μs | 0.0007 μs | 0.0006 μs |      baseline |         |       - |       - |         - |
|              ForeachLoop |   100 |  1.625 μs | 0.0010 μs | 0.0008 μs |  1.07x slower |   0.00x |       - |       - |         - |
|                     Linq |   100 |  2.263 μs | 0.0020 μs | 0.0018 μs |  1.50x slower |   0.00x |  0.0496 |       - |     104 B |
|               LinqFaster |   100 |  2.422 μs | 0.0041 μs | 0.0032 μs |  1.60x slower |   0.00x |  3.0670 |       - |   6,424 B |
|             LinqFasterer |   100 |  2.696 μs | 0.0114 μs | 0.0107 μs |  1.78x slower |   0.01x |  3.0861 |       - |   6,456 B |
|                   LinqAF |   100 |  2.714 μs | 0.0015 μs | 0.0014 μs |  1.79x slower |   0.00x |       - |       - |         - |
|            LinqOptimizer |   100 | 47.118 μs | 0.2392 μs | 0.2237 μs | 31.16x slower |   0.16x | 60.7910 | 18.6157 | 156,726 B |
|                 SpanLinq |   100 |  2.220 μs | 0.0028 μs | 0.0023 μs |  1.47x slower |   0.00x |       - |       - |         - |
|                  Streams |   100 |  3.345 μs | 0.0024 μs | 0.0022 μs |  2.21x slower |   0.00x |  0.3929 |       - |     824 B |
|               StructLinq |   100 |  1.879 μs | 0.0017 μs | 0.0016 μs |  1.24x slower |   0.00x |  0.0153 |       - |      32 B |
| StructLinq_ValueDelegate |   100 |  1.708 μs | 0.0012 μs | 0.0011 μs |  1.13x slower |   0.00x |       - |       - |         - |
|                Hyperlinq |   100 |  1.910 μs | 0.0013 μs | 0.0011 μs |  1.26x slower |   0.00x |       - |       - |         - |
|  Hyperlinq_ValueDelegate |   100 |  1.793 μs | 0.0008 μs | 0.0007 μs |  1.19x slower |   0.00x |       - |       - |         - |
