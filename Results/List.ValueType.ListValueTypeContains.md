## List.ValueType.ListValueTypeContains

### Source
[ListValueTypeContains.cs](../LinqBenchmarks/List/ValueType/ListValueTypeContains.cs)

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
|                   Method | Count |       Mean |   Error |  StdDev |        Ratio | RatioSD |  Gen 0 | Allocated |
|------------------------- |------ |-----------:|--------:|--------:|-------------:|--------:|-------:|----------:|
|                  ForLoop |   100 |   784.8 ns | 0.86 ns | 0.77 ns |     baseline |         |      - |         - |
|              ForeachLoop |   100 | 1,174.7 ns | 2.15 ns | 1.91 ns | 1.50x slower |   0.00x |      - |         - |
|                     Linq |   100 |   143.6 ns | 1.08 ns | 1.01 ns | 5.46x faster |   0.03x |      - |         - |
|               LinqFaster |   100 |   143.1 ns | 0.41 ns | 0.34 ns | 5.49x faster |   0.02x |      - |         - |
|             LinqFasterer |   100 |   609.1 ns | 4.55 ns | 4.04 ns | 1.29x faster |   0.01x | 3.0670 |   6,424 B |
|                   LinqAF |   100 |   144.1 ns | 0.96 ns | 0.90 ns | 5.44x faster |   0.01x |      - |         - |
|               StructLinq |   100 |   521.3 ns | 0.47 ns | 0.37 ns | 1.51x faster |   0.00x | 0.0191 |      40 B |
| StructLinq_ValueDelegate |   100 |   538.4 ns | 0.90 ns | 0.80 ns | 1.46x faster |   0.00x |      - |         - |
|                Hyperlinq |   100 |   149.3 ns | 0.41 ns | 0.39 ns | 5.26x faster |   0.02x | 0.0153 |      32 B |
