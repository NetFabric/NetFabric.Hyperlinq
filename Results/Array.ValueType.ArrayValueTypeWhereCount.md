## Array.ValueType.ArrayValueTypeWhereCount

### Source
[ArrayValueTypeWhereCount.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhereCount.cs)

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
|                   Method | Count |         Mean |      Error |     StdDev |          Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |------ |-------------:|-----------:|-----------:|---------------:|--------:|-------:|------:|------:|----------:|
|                  ForLoop |   100 |     73.53 ns |   0.524 ns |   0.491 ns |       baseline |         |      - |     - |     - |         - |
|              ForeachLoop |   100 |    141.77 ns |   0.988 ns |   0.924 ns |   1.93x slower |   0.02x |      - |     - |     - |         - |
|                     Linq |   100 |    602.78 ns |   1.030 ns |   0.913 ns |   8.18x slower |   0.02x | 0.0153 |     - |     - |      32 B |
|               LinqFaster |   100 |    286.25 ns |   0.132 ns |   0.110 ns |   3.89x slower |   0.00x |      - |     - |     - |         - |
|             LinqFasterer |   100 |    305.40 ns |   1.161 ns |   1.029 ns |   4.15x slower |   0.02x |      - |     - |     - |         - |
|                   LinqAF |   100 |    727.38 ns |  13.787 ns |  14.751 ns |   9.88x slower |   0.23x |      - |     - |     - |         - |
|               StructLinq |   100 |    299.59 ns |   5.040 ns |   4.714 ns |   4.07x slower |   0.07x | 0.0305 |     - |     - |      64 B |
|            LinqOptimizer |   100 | 31,687.10 ns | 126.659 ns | 112.280 ns | 430.19x slower |   1.58x | 9.1553 |     - |     - |  19,185 B |
|                  Streams |   100 |    657.83 ns |   1.731 ns |   1.620 ns |   8.95x slower |   0.06x | 0.1717 |     - |     - |     360 B |
| StructLinq_ValueDelegate |   100 |    185.07 ns |   0.148 ns |   0.124 ns |   2.51x slower |   0.00x |      - |     - |     - |         - |
|                Hyperlinq |   100 |    511.45 ns |   0.416 ns |   0.369 ns |   6.94x slower |   0.01x |      - |     - |     - |         - |
|  Hyperlinq_ValueDelegate |   100 |    313.83 ns |   2.185 ns |   2.044 ns |   4.27x slower |   0.01x |      - |     - |     - |         - |
