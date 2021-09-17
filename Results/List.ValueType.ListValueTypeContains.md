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
|                   Method | Count |       Mean |   Error |  StdDev |        Ratio | RatioSD |  Gen 0 | Allocated |
|------------------------- |------ |-----------:|--------:|--------:|-------------:|--------:|-------:|----------:|
|                  ForLoop |   100 |   749.0 ns | 2.38 ns | 2.22 ns |     baseline |         |      - |         - |
|              ForeachLoop |   100 | 1,269.5 ns | 2.14 ns | 1.90 ns | 1.70x slower |   0.01x |      - |         - |
|                     Linq |   100 |   145.0 ns | 0.24 ns | 0.19 ns | 5.16x faster |   0.02x |      - |         - |
|               LinqFaster |   100 |   142.8 ns | 0.07 ns | 0.06 ns | 5.24x faster |   0.02x |      - |         - |
|             LinqFasterer |   100 |   593.8 ns | 4.91 ns | 4.59 ns | 1.26x faster |   0.01x | 3.0670 |   6,424 B |
|                   LinqAF |   100 |   144.7 ns | 0.19 ns | 0.15 ns | 5.18x faster |   0.02x |      - |         - |
|               StructLinq |   100 |   521.4 ns | 0.83 ns | 0.65 ns | 1.44x faster |   0.00x | 0.0191 |      40 B |
| StructLinq_ValueDelegate |   100 |   580.9 ns | 1.65 ns | 1.46 ns | 1.29x faster |   0.00x |      - |         - |
|                Hyperlinq |   100 |   143.9 ns | 0.56 ns | 0.52 ns | 5.20x faster |   0.02x |      - |         - |
