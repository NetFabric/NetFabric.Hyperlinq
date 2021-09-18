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
- NetFabric.Hyperlinq: [3.0.0-beta46](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta46)
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
|                   Method | Count |       Mean |    Error |   StdDev |     Median |        Ratio | RatioSD |  Gen 0 | Allocated |
|------------------------- |------ |-----------:|---------:|---------:|-----------:|-------------:|--------:|-------:|----------:|
|                  ForLoop |   100 |   749.7 ns |  1.13 ns |  0.94 ns |   749.3 ns |     baseline |         |      - |         - |
|              ForeachLoop |   100 | 1,270.3 ns |  1.77 ns |  1.65 ns | 1,269.9 ns | 1.69x slower |   0.00x |      - |         - |
|                     Linq |   100 |   144.5 ns |  0.46 ns |  0.43 ns |   144.5 ns | 5.19x faster |   0.02x |      - |         - |
|               LinqFaster |   100 |   143.6 ns |  0.48 ns |  0.40 ns |   143.6 ns | 5.22x faster |   0.02x |      - |         - |
|             LinqFasterer |   100 |   678.2 ns | 23.17 ns | 64.20 ns |   663.5 ns | 1.13x faster |   0.07x | 3.0670 |   6,424 B |
|                   LinqAF |   100 |   200.8 ns | 13.82 ns | 40.53 ns |   199.6 ns | 4.65x faster |   0.78x |      - |         - |
|               StructLinq |   100 |   560.5 ns | 11.18 ns | 30.04 ns |   548.6 ns | 1.34x faster |   0.08x | 0.0191 |      40 B |
| StructLinq_ValueDelegate |   100 |   557.5 ns |  9.84 ns |  8.22 ns |   555.6 ns | 1.35x faster |   0.02x |      - |         - |
|                Hyperlinq |   100 |   157.8 ns |  3.11 ns |  2.75 ns |   156.8 ns | 4.74x faster |   0.08x | 0.0153 |      32 B |
