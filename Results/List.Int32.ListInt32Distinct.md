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
|                   Method | Duplicates | Count |       Mean |     Error |    StdDev |     Median |        Ratio | RatioSD |  Gen 0 | Allocated |
|------------------------- |----------- |------ |-----------:|----------:|----------:|-----------:|-------------:|--------:|-------:|----------:|
|                  ForLoop |          4 |   100 | 4,618.9 ns | 207.11 ns | 577.35 ns | 4,545.1 ns |     baseline |         | 2.8687 |   6,000 B |
|              ForeachLoop |          4 |   100 | 4,678.9 ns | 165.17 ns | 435.12 ns | 4,550.0 ns | 1.02x slower |   0.14x | 2.8687 |   6,000 B |
|                     Linq |          4 |   100 | 5,046.7 ns | 166.54 ns | 467.01 ns | 4,864.8 ns | 1.11x slower |   0.14x | 2.8687 |   6,000 B |
|               LinqFaster |          4 |   100 |   760.2 ns |  12.74 ns |  11.92 ns |   757.4 ns | 6.20x faster |   0.57x |      - |         - |
|             LinqFasterer |          4 |   100 | 5,013.6 ns | 205.73 ns | 552.69 ns | 4,965.5 ns | 1.10x slower |   0.19x | 5.2032 |  10,896 B |
|                   LinqAF |          4 |   100 | 8,130.2 ns | 148.97 ns | 240.56 ns | 8,100.8 ns | 1.73x slower |   0.18x | 5.9204 |  12,400 B |
|               StructLinq |          4 |   100 | 3,886.2 ns |  57.53 ns |  53.81 ns | 3,917.7 ns | 1.21x faster |   0.10x | 0.0153 |      32 B |
| StructLinq_ValueDelegate |          4 |   100 | 3,927.0 ns |  69.26 ns |  74.11 ns | 3,935.4 ns | 1.20x faster |   0.12x |      - |         - |
|                Hyperlinq |          4 |   100 | 3,368.4 ns |  59.75 ns | 123.40 ns | 3,311.3 ns | 1.44x faster |   0.19x |      - |         - |
