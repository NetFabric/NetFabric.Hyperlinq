## Array.ValueType.ArrayValueTypeWhereCount

### Source
[ArrayValueTypeWhereCount.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhereCount.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqFasterer: [2.1.0](https://www.nuget.org/packages/LinqFasterer/2.1.0)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- LinqOptimizer.CSharp: [0.7.0](https://www.nuget.org/packages/LinqOptimizer.CSharp/0.7.0)
- SpanLinq: [1.0.0](https://www.nuget.org/packages/SpanLinq/1.0.0)
- Streams.CSharp: [0.6.0](https://www.nuget.org/packages/Streams.CSharp/0.6.0)
- StructLinq.BCL: [0.26.0](https://www.nuget.org/packages/StructLinq/0.26.0)
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)
- System.Linq.Async: [5.0.0](https://www.nuget.org/packages/System.Linq.Async/5.0.0)

### Results:
``` ini

BenchmarkDotNet=v0.12.1.1538-nightly, OS=Windows 10.0.19043
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.4.21227.6
  [Host] : .NET 5.0.6 (5.0.621.22011), X64 RyuJIT
  .NET 6 : .NET 6.0.0 (6.0.21.22210), X64 RyuJIT

Job=.NET 6  EnvironmentVariables=COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1  Runtime=.NET 6.0  

```
|                   Method | Count |         Mean |      Error |     StdDev |  Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |------ |-------------:|-----------:|-----------:|-------:|--------:|-------:|------:|------:|----------:|
|                  ForLoop |   100 |     70.16 ns |   0.703 ns |   0.623 ns |   1.00 |    0.00 |      - |     - |     - |         - |
|              ForeachLoop |   100 |    151.32 ns |   0.796 ns |   0.665 ns |   2.16 |    0.03 |      - |     - |     - |         - |
|                     Linq |   100 |    573.87 ns |  10.461 ns |   9.273 ns |   8.18 |    0.17 | 0.0153 |     - |     - |      32 B |
|               LinqFaster |   100 |    246.84 ns |   1.628 ns |   1.443 ns |   3.52 |    0.04 |      - |     - |     - |         - |
|             LinqFasterer |   100 |    266.63 ns |   4.111 ns |   3.846 ns |   3.80 |    0.06 |      - |     - |     - |         - |
|                   LinqAF |   100 |    672.73 ns |  13.031 ns |  17.837 ns |   9.62 |    0.24 |      - |     - |     - |         - |
|               StructLinq |   100 |    307.28 ns |   4.608 ns |   4.085 ns |   4.38 |    0.07 | 0.0305 |     - |     - |      64 B |
|            LinqOptimizer |   100 | 28,961.66 ns | 332.160 ns | 715.009 ns | 417.20 |   20.34 | 9.1553 |     - |     - |  19,185 B |
|                  Streams |   100 |    781.15 ns |  12.171 ns |  11.385 ns |  11.13 |    0.17 | 0.1717 |     - |     - |     360 B |
| StructLinq_ValueDelegate |   100 |    187.80 ns |   0.944 ns |   0.837 ns |   2.68 |    0.03 |      - |     - |     - |         - |
|                Hyperlinq |   100 |    454.48 ns |   9.039 ns |  15.102 ns |   6.55 |    0.25 |      - |     - |     - |         - |
|  Hyperlinq_ValueDelegate |   100 |    323.60 ns |   6.405 ns |   5.992 ns |   4.61 |    0.12 |      - |     - |     - |         - |
