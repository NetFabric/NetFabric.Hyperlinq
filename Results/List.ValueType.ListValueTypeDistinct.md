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
|                   Method | Duplicates | Count |      Mean |     Error |    StdDev |        Ratio | RatioSD |   Gen 0 | Allocated |
|------------------------- |----------- |------ |----------:|----------:|----------:|-------------:|--------:|--------:|----------:|
|                  ForLoop |          4 |   100 | 12.719 μs | 0.0627 μs | 0.0587 μs |     baseline |         | 12.8784 |  26,976 B |
|              ForeachLoop |          4 |   100 | 13.382 μs | 0.0756 μs | 0.0707 μs | 1.05x slower |   0.01x | 12.8784 |  26,976 B |
|                     Linq |          4 |   100 | 15.291 μs | 0.0584 μs | 0.0518 μs | 1.20x slower |   0.01x | 12.8174 |  26,912 B |
|               LinqFaster |          4 |   100 |  2.828 μs | 0.0042 μs | 0.0037 μs | 4.50x faster |   0.02x |  0.0114 |      24 B |
|             LinqFasterer |          4 |   100 | 17.298 μs | 0.1600 μs | 0.1497 μs | 1.36x slower |   0.01x | 34.8816 |  73,168 B |
|                   LinqAF |          4 |   100 | 57.056 μs | 0.6353 μs | 0.5632 μs | 4.48x slower |   0.03x | 20.3247 |  42,552 B |
|               StructLinq |          4 |   100 | 13.031 μs | 0.0407 μs | 0.0381 μs | 1.02x slower |   0.00x |  0.0305 |      64 B |
| StructLinq_ValueDelegate |          4 |   100 |  5.186 μs | 0.0100 μs | 0.0094 μs | 2.45x faster |   0.01x |       - |         - |
|                Hyperlinq |          4 |   100 | 11.950 μs | 0.0350 μs | 0.0310 μs | 1.06x faster |   0.01x |       - |         - |
