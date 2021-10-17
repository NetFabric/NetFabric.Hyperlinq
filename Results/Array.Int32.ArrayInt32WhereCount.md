## Array.Int32.ArrayInt32WhereCount

### Source
[ArrayInt32WhereCount.cs](../LinqBenchmarks/Array/Int32/ArrayInt32WhereCount.cs)

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
|                   Method | Count |      Mean |    Error |   StdDev |        Ratio | RatioSD |  Gen 0 | Allocated |
|------------------------- |------ |----------:|---------:|---------:|-------------:|--------:|-------:|----------:|
|                  ForLoop |   100 |  74.25 ns | 0.642 ns | 0.569 ns |     baseline |         |      - |         - |
|              ForeachLoop |   100 |  73.86 ns | 0.427 ns | 0.399 ns | 1.00x faster |   0.01x |      - |         - |
|                     Linq |   100 | 327.89 ns | 1.869 ns | 1.748 ns | 4.41x slower |   0.04x | 0.0153 |      32 B |
|               LinqFaster |   100 | 238.36 ns | 0.433 ns | 0.362 ns | 3.21x slower |   0.03x |      - |         - |
|             LinqFasterer |   100 | 232.05 ns | 0.893 ns | 0.792 ns | 3.13x slower |   0.02x |      - |         - |
|                   LinqAF |   100 | 225.89 ns | 1.698 ns | 1.588 ns | 3.04x slower |   0.03x |      - |         - |
|            LinqOptimizer |   100 | 600.57 ns | 0.901 ns | 0.703 ns | 8.08x slower |   0.06x | 0.0114 |      24 B |
|                 SpanLinq |   100 | 244.48 ns | 0.429 ns | 0.335 ns | 3.29x slower |   0.03x |      - |         - |
|                  Streams |   100 | 506.50 ns | 2.450 ns | 2.172 ns | 6.82x slower |   0.07x | 0.1717 |     360 B |
|               StructLinq |   100 | 285.93 ns | 1.204 ns | 1.067 ns | 3.85x slower |   0.03x | 0.0305 |      64 B |
| StructLinq_ValueDelegate |   100 |  93.51 ns | 0.265 ns | 0.248 ns | 1.26x slower |   0.01x |      - |         - |
|                Hyperlinq |   100 | 212.86 ns | 0.609 ns | 0.509 ns | 2.87x slower |   0.02x |      - |         - |
|  Hyperlinq_ValueDelegate |   100 |  92.39 ns | 0.264 ns | 0.247 ns | 1.24x slower |   0.01x |      - |         - |
