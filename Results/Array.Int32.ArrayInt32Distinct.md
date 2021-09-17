## Array.Int32.ArrayInt32Distinct

### Source
[ArrayInt32Distinct.cs](../LinqBenchmarks/Array/Int32/ArrayInt32Distinct.cs)

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
|                   Method | Duplicates | Count |     Mean |     Error |    StdDev |        Ratio | RatioSD |  Gen 0 | Allocated |
|------------------------- |----------- |------ |---------:|----------:|----------:|-------------:|--------:|-------:|----------:|
|                  ForLoop |          4 |   100 | 3.228 μs | 0.0169 μs | 0.0141 μs |     baseline |         | 2.8687 |   6,000 B |
|              ForeachLoop |          4 |   100 | 3.315 μs | 0.0183 μs | 0.0171 μs | 1.03x slower |   0.01x | 2.8687 |   6,000 B |
|                     Linq |          4 |   100 | 4.186 μs | 0.0083 μs | 0.0069 μs | 1.30x slower |   0.01x | 2.8610 |   5,992 B |
|             LinqFasterer |          4 |   100 | 4.167 μs | 0.0177 μs | 0.0148 μs | 1.29x slower |   0.01x | 4.4250 |   9,272 B |
|                   LinqAF |          4 |   100 | 7.031 μs | 0.0456 μs | 0.0427 μs | 2.18x slower |   0.01x | 5.9280 |  12,400 B |
|               StructLinq |          4 |   100 | 3.974 μs | 0.0119 μs | 0.0099 μs | 1.23x slower |   0.01x | 0.0153 |      32 B |
| StructLinq_ValueDelegate |          4 |   100 | 3.856 μs | 0.0077 μs | 0.0060 μs | 1.19x slower |   0.01x |      - |         - |
|                Hyperlinq |          4 |   100 | 3.363 μs | 0.0125 μs | 0.0111 μs | 1.04x slower |   0.00x |      - |         - |
