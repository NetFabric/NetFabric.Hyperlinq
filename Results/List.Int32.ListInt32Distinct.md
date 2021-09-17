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
|                   Method | Duplicates | Count |       Mean |    Error |   StdDev |        Ratio | RatioSD |  Gen 0 | Allocated |
|------------------------- |----------- |------ |-----------:|---------:|---------:|-------------:|--------:|-------:|----------:|
|                  ForLoop |          4 |   100 | 3,388.4 ns | 22.37 ns | 18.68 ns |     baseline |         | 2.8687 |   6,000 B |
|              ForeachLoop |          4 |   100 | 3,520.3 ns | 21.43 ns | 18.99 ns | 1.04x slower |   0.01x | 2.8687 |   6,000 B |
|                     Linq |          4 |   100 | 4,388.7 ns | 22.05 ns | 20.62 ns | 1.29x slower |   0.01x | 2.8687 |   6,000 B |
|               LinqFaster |          4 |   100 |   743.2 ns |  3.04 ns |  2.70 ns | 4.56x faster |   0.03x |      - |         - |
|             LinqFasterer |          4 |   100 | 4,109.5 ns | 38.12 ns | 35.66 ns | 1.21x slower |   0.01x | 5.2032 |  10,896 B |
|                   LinqAF |          4 |   100 | 7,492.8 ns | 30.82 ns | 27.32 ns | 2.21x slower |   0.02x | 5.9280 |  12,400 B |
|               StructLinq |          4 |   100 | 3,778.5 ns |  4.73 ns |  3.95 ns | 1.12x slower |   0.01x | 0.0153 |      32 B |
| StructLinq_ValueDelegate |          4 |   100 | 3,786.2 ns | 14.86 ns | 13.17 ns | 1.12x slower |   0.01x |      - |         - |
|                Hyperlinq |          4 |   100 | 3,408.2 ns |  9.87 ns |  8.75 ns | 1.01x slower |   0.01x |      - |         - |
