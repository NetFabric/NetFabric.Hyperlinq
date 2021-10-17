## Array.Int32.ArrayInt32SkipTakeWhere

### Source
[ArrayInt32SkipTakeWhere.cs](../LinqBenchmarks/Array/Int32/ArrayInt32SkipTakeWhere.cs)

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
|                   Method | Skip | Count |        Mean |     Error |    StdDev |         Ratio | RatioSD |  Gen 0 | Allocated |
|------------------------- |----- |------ |------------:|----------:|----------:|--------------:|--------:|-------:|----------:|
|                  ForLoop | 1000 |   100 |    75.80 ns |  0.201 ns |  0.168 ns |      baseline |         |      - |         - |
|                     Linq | 1000 |   100 | 1,034.64 ns |  5.451 ns |  5.099 ns | 13.66x slower |   0.08x | 0.0725 |     152 B |
|               LinqFaster | 1000 |   100 |   422.82 ns |  2.184 ns |  2.043 ns |  5.58x slower |   0.03x | 0.7191 |   1,504 B |
|             LinqFasterer | 1000 |   100 |   452.44 ns |  1.747 ns |  1.634 ns |  5.97x slower |   0.02x | 0.3285 |     688 B |
|                   LinqAF | 1000 |   100 | 2,607.63 ns |  4.461 ns |  3.483 ns | 34.40x slower |   0.06x |      - |         - |
|            LinqOptimizer | 1000 |   100 | 2,522.92 ns | 14.507 ns | 12.114 ns | 33.29x slower |   0.18x | 4.1389 |   8,674 B |
|                 SpanLinq | 1000 |   100 |   314.38 ns |  0.234 ns |  0.183 ns |  4.15x slower |   0.01x |      - |         - |
|                  Streams | 1000 |   100 | 6,165.41 ns | 37.712 ns | 35.276 ns | 81.35x slower |   0.56x | 0.4349 |     912 B |
|               StructLinq | 1000 |   100 |   354.63 ns |  6.573 ns |  6.149 ns |  4.67x slower |   0.07x | 0.0458 |      96 B |
| StructLinq_ValueDelegate | 1000 |   100 |   203.59 ns |  0.514 ns |  0.429 ns |  2.69x slower |   0.01x |      - |         - |
|                Hyperlinq | 1000 |   100 |   450.66 ns |  2.166 ns |  1.920 ns |  5.94x slower |   0.03x |      - |         - |
|  Hyperlinq_ValueDelegate | 1000 |   100 |   238.64 ns |  0.964 ns |  0.805 ns |  3.15x slower |   0.02x |      - |         - |
