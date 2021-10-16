## List.Int32.ListInt32Distinct

### Source
[ListInt32Distinct.cs](../LinqBenchmarks/List/Int32/ListInt32Distinct.cs)

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
|                   Method | Duplicates | Count |       Mean |     Error |    StdDev |        Ratio | RatioSD |  Gen 0 | Allocated |
|------------------------- |----------- |------ |-----------:|----------:|----------:|-------------:|--------:|-------:|----------:|
|                  ForLoop |          4 |   100 | 3,408.5 ns |  15.12 ns |  13.40 ns |     baseline |         | 2.8687 |   6,000 B |
|              ForeachLoop |          4 |   100 | 3,537.1 ns |  27.11 ns |  22.64 ns | 1.04x slower |   0.01x | 2.8687 |   6,000 B |
|                     Linq |          4 |   100 | 4,398.7 ns |  22.27 ns |  19.74 ns | 1.29x slower |   0.01x | 2.8687 |   6,000 B |
|               LinqFaster |          4 |   100 |   677.3 ns |   1.88 ns |   1.76 ns | 5.03x faster |   0.02x |      - |         - |
|             LinqFasterer |          4 |   100 | 4,124.9 ns |  70.02 ns |  65.49 ns | 1.21x slower |   0.02x | 5.2032 |  10,896 B |
|                   LinqAF |          4 |   100 | 7,689.3 ns | 131.43 ns | 122.94 ns | 2.26x slower |   0.04x | 5.9204 |  12,400 B |
|               StructLinq |          4 |   100 | 3,816.7 ns |   8.19 ns |   6.39 ns | 1.12x slower |   0.01x | 0.0153 |      32 B |
| StructLinq_ValueDelegate |          4 |   100 | 3,809.3 ns |  10.63 ns |   9.42 ns | 1.12x slower |   0.01x |      - |         - |
|                Hyperlinq |          4 |   100 | 3,300.9 ns |  13.83 ns |  11.55 ns | 1.03x faster |   0.00x |      - |         - |
