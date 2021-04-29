## Array.Int32.ArrayInt32SkipTakeSelect

### Source
[ArrayInt32SkipTakeSelect.cs](../LinqBenchmarks/Array/Int32/ArrayInt32SkipTakeSelect.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqFasterer: [2.1.0](https://www.nuget.org/packages/LinqFasterer/2.1.0)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- LinqOptimizer.CSharp: [](https://www.nuget.org/packages/LinqOptimizer.CSharp/)
- Streams.CSharp: [0.6.0](https://www.nuget.org/packages/Streams.CSharp/0.6.0)
- StructLinq.BCL: [0.26.0](https://www.nuget.org/packages/StructLinq/0.26.0)
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)

### Results:
``` ini

BenchmarkDotNet=v0.12.1.1527-nightly, OS=Windows 10.0.19043
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.4.21227.6
  [Host] : .NET 5.0.4 (5.0.421.11614), X64 RyuJIT
  .NET 6 : .NET 6.0.0 (6.0.21.22210), X64 RyuJIT

Job=.NET 6  EnvironmentVariables=COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1  Runtime=.NET 6.0  

```
|                   Method | Skip | Count |         Mean |      Error |     StdDev |  Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |----- |------ |-------------:|-----------:|-----------:|-------:|--------:|--------:|------:|------:|----------:|
|                  ForLoop | 1000 |   100 |     61.40 ns |   0.273 ns |   0.256 ns |   1.00 |    0.00 |       - |     - |     - |         - |
|              ForeachLoop | 1000 |   100 |  1,461.95 ns |   5.133 ns |   4.550 ns |  23.81 |    0.13 |  0.0153 |     - |     - |      32 B |
|                     Linq | 1000 |   100 |    883.54 ns |   2.772 ns |   2.315 ns |  14.39 |    0.07 |  0.0725 |     - |     - |     152 B |
|               LinqFaster | 1000 |   100 |    314.67 ns |   2.734 ns |   2.557 ns |   5.12 |    0.05 |  0.6080 |     - |     - |   1,272 B |
|             LinqFasterer | 1000 |   100 |    474.12 ns |   1.528 ns |   1.429 ns |   7.72 |    0.04 |  0.4206 |     - |     - |     880 B |
|                   LinqAF | 1000 |   100 |  2,789.09 ns |  22.106 ns |  18.460 ns |  45.44 |    0.37 |       - |     - |     - |         - |
|            LinqOptimizer | 1000 |   100 | 39,604.08 ns | 475.715 ns | 444.984 ns | 644.99 |    7.82 | 14.7705 |     - |     - |  31,181 B |
|                  Streams | 1000 |   100 |  6,681.12 ns |  21.836 ns |  20.426 ns | 108.81 |    0.45 |  0.4349 |     - |     - |     912 B |
|               StructLinq | 1000 |   100 |    265.39 ns |   1.183 ns |   1.048 ns |   4.32 |    0.02 |  0.0458 |     - |     - |      96 B |
| StructLinq_ValueDelegate | 1000 |   100 |    161.03 ns |   0.436 ns |   0.408 ns |   2.62 |    0.01 |       - |     - |     - |         - |
|                Hyperlinq | 1000 |   100 |    222.27 ns |   0.595 ns |   0.527 ns |   3.62 |    0.02 |       - |     - |     - |         - |
|  Hyperlinq_ValueDelegate | 1000 |   100 |    203.83 ns |   2.452 ns |   2.173 ns |   3.32 |    0.03 |       - |     - |     - |         - |
