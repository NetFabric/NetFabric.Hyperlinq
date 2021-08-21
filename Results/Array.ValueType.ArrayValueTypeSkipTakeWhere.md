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
- StructLinq.BCL: [0.26.0](https://www.nuget.org/packages/StructLinq/0.26.0)
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)
- System.Linq.Async: [5.0.0](https://www.nuget.org/packages/System.Linq.Async/5.0.0)

### Results:
``` ini

BenchmarkDotNet=v0.13.0, OS=macOS Catalina 10.15.7 (19H1323) [Darwin 19.6.0]
Intel Core i5-7360U CPU 2.30GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.7.21379.14
  [Host] : .NET 5.0.6 (5.0.621.22011), X64 RyuJIT
  .NET 6 : .NET 6.0.0 (6.0.21.37719), X64 RyuJIT

Job=.NET 6  EnvironmentVariables=COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1  Runtime=.NET 6.0  

```
|                   Method | Skip | Count |        Mean |     Error |    StdDev |          Ratio | RatioSD |   Gen 0 |  Gen 1 | Gen 2 | Allocated |
|------------------------- |----- |------ |------------:|----------:|----------:|---------------:|--------:|--------:|-------:|------:|----------:|
|                  ForLoop | 1000 |   100 |    443.0 ns |   0.31 ns |   0.29 ns |       baseline |         |       - |      - |     - |         - |
|                     Linq | 1000 |   100 |  1,529.3 ns |   1.06 ns |   0.94 ns |   3.45x slower |   0.00x |  0.1526 |      - |     - |     320 B |
|               LinqFaster | 1000 |   100 |  2,438.0 ns |  10.89 ns |  10.19 ns |   5.50x slower |   0.02x | 10.7803 |      - |     - |  22,560 B |
|             LinqFasterer | 1000 |   100 |  1,873.7 ns |   7.06 ns |   6.60 ns |   4.23x slower |   0.02x |  4.6501 |      - |     - |   9,744 B |
|                   LinqAF | 1000 |   100 |  6,324.0 ns |   5.39 ns |   4.78 ns |  14.27x slower |   0.01x |       - |      - |     - |         - |
|            LinqOptimizer | 1000 |   100 | 60,602.4 ns | 183.03 ns | 162.25 ns | 136.78x slower |   0.42x | 74.0356 | 0.0610 |     - | 157,823 B |
|                 SpanLinq | 1000 |   100 |    752.7 ns |   0.45 ns |   0.37 ns |   1.70x slower |   0.00x |       - |      - |     - |         - |
|                  Streams | 1000 |   100 |  8,785.9 ns |   5.45 ns |   4.55 ns |  19.83x slower |   0.01x |  0.5493 |      - |     - |   1,152 B |
|               StructLinq | 1000 |   100 |    638.5 ns |   0.68 ns |   0.64 ns |   1.44x slower |   0.00x |  0.0458 |      - |     - |      96 B |
| StructLinq_ValueDelegate | 1000 |   100 |    541.6 ns |   0.68 ns |   0.57 ns |   1.22x slower |   0.00x |       - |      - |     - |         - |
|                Hyperlinq | 1000 |   100 |  1,062.4 ns |   4.04 ns |   3.78 ns |   2.40x slower |   0.01x |       - |      - |     - |         - |
|  Hyperlinq_ValueDelegate | 1000 |   100 |    880.5 ns |   7.86 ns |   6.14 ns |   1.99x slower |   0.01x |       - |      - |     - |         - |
