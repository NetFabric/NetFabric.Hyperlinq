## Array.ValueType.ArrayValueTypeSkipTakeWhere

### Source
[ArrayValueTypeSkipTakeWhere.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeSkipTakeWhere.cs)

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
|                   Method | Skip | Count |        Mean |     Error |    StdDev |          Ratio | RatioSD |   Gen 0 |  Gen 1 | Allocated |
|------------------------- |----- |------ |------------:|----------:|----------:|---------------:|--------:|--------:|-------:|----------:|
|                  ForLoop | 1000 |   100 |    443.4 ns |   0.21 ns |   0.20 ns |       baseline |         |       - |      - |         - |
|                     Linq | 1000 |   100 |  1,525.3 ns |   2.01 ns |   1.88 ns |   3.44x slower |   0.00x |  0.1526 |      - |     320 B |
|               LinqFaster | 1000 |   100 |  2,467.2 ns |  11.98 ns |  10.62 ns |   5.56x slower |   0.03x | 10.7803 |      - |  22,560 B |
|             LinqFasterer | 1000 |   100 |  1,868.9 ns |   7.65 ns |   6.39 ns |   4.21x slower |   0.02x |  4.6501 |      - |   9,744 B |
|                   LinqAF | 1000 |   100 |  6,220.8 ns |  12.44 ns |  11.64 ns |  14.03x slower |   0.02x |       - |      - |         - |
|            LinqOptimizer | 1000 |   100 | 60,312.6 ns | 182.78 ns | 142.70 ns | 136.02x slower |   0.33x | 74.0356 | 0.0610 | 157,823 B |
|                 SpanLinq | 1000 |   100 |    748.3 ns |   0.60 ns |   0.50 ns |   1.69x slower |   0.00x |       - |      - |         - |
|                  Streams | 1000 |   100 |  8,770.8 ns |  10.80 ns |   9.58 ns |  19.78x slower |   0.02x |  0.5493 |      - |   1,152 B |
|               StructLinq | 1000 |   100 |    735.6 ns |   4.12 ns |   3.85 ns |   1.66x slower |   0.01x |  0.0458 |      - |      96 B |
| StructLinq_ValueDelegate | 1000 |   100 |    543.4 ns |   0.32 ns |   0.30 ns |   1.23x slower |   0.00x |       - |      - |         - |
|                Hyperlinq | 1000 |   100 |    977.5 ns |   0.66 ns |   0.59 ns |   2.20x slower |   0.00x |       - |      - |         - |
|  Hyperlinq_ValueDelegate | 1000 |   100 |    862.1 ns |   0.49 ns |   0.46 ns |   1.94x slower |   0.00x |       - |      - |         - |
