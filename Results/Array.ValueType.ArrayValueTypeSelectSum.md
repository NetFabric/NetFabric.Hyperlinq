## Array.ValueType.ArrayValueTypeSelectSum

### Source
[ArrayValueTypeSelectSum.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeSelectSum.cs)

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
|                  ForLoop |   100 |     75.09 ns |   0.296 ns |   0.276 ns |   1.00 |    0.00 |      - |     - |     - |         - |
|              ForeachLoop |   100 |    150.74 ns |   0.858 ns |   0.843 ns |   2.01 |    0.01 |      - |     - |     - |         - |
|                     Linq |   100 |    573.22 ns |   6.984 ns |   6.533 ns |   7.63 |    0.08 | 0.0153 |     - |     - |      32 B |
|               LinqFaster |   100 |    316.69 ns |   1.694 ns |   1.414 ns |   4.22 |    0.02 |      - |     - |     - |         - |
|             LinqFasterer |   100 |    220.75 ns |   1.434 ns |   1.198 ns |   2.94 |    0.02 |      - |     - |     - |         - |
|                   LinqAF |   100 |    683.96 ns |  13.638 ns |  16.748 ns |   9.16 |    0.23 |      - |     - |     - |         - |
|            LinqOptimizer |   100 | 29,729.44 ns | 153.756 ns | 128.394 ns | 395.80 |    2.38 | 9.0332 |     - |     - |  18,930 B |
|                  Streams |   100 |    616.26 ns |  12.150 ns |  18.554 ns |   8.02 |    0.24 | 0.1717 |     - |     - |     360 B |
|               StructLinq |   100 |    205.20 ns |   1.312 ns |   1.227 ns |   2.73 |    0.02 | 0.0153 |     - |     - |      32 B |
| StructLinq_ValueDelegate |   100 |     82.41 ns |   0.301 ns |   0.267 ns |   1.10 |    0.00 |      - |     - |     - |         - |
|                Hyperlinq |   100 |    486.04 ns |   2.172 ns |   1.926 ns |   6.47 |    0.04 |      - |     - |     - |         - |
|  Hyperlinq_ValueDelegate |   100 |    340.29 ns |   0.960 ns |   0.851 ns |   4.53 |    0.02 |      - |     - |     - |         - |
