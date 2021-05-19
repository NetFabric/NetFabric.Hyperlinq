## ImmutableArray.Int32.ImmutableArrayInt32Select

### Source
[ImmutableArrayInt32Select.cs](../LinqBenchmarks/ImmutableArray/Int32/ImmutableArrayInt32Select.cs)

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
|                   Method | Count |         Mean |      Error |     StdDev |  Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |------ |-------------:|-----------:|-----------:|-------:|--------:|--------:|------:|------:|----------:|
|                  ForLoop |   100 |     60.07 ns |   0.341 ns |   0.319 ns |   1.00 |    0.00 |       - |     - |     - |         - |
|              ForeachLoop |   100 |     59.09 ns |   0.324 ns |   0.303 ns |   0.98 |    0.01 |       - |     - |     - |         - |
|                     Linq |   100 |    498.93 ns |   4.776 ns |   3.988 ns |   8.31 |    0.08 |  0.0229 |     - |     - |      48 B |
|             LinqFasterer |   100 |    496.35 ns |   3.952 ns |   3.697 ns |   8.26 |    0.08 |  0.4320 |     - |     - |     904 B |
|            LinqOptimizer |   100 | 38,250.47 ns | 341.819 ns | 319.738 ns | 636.78 |    6.16 | 13.6108 |     - |     - |  28,584 B |
|                  Streams |   100 |  1,728.06 ns |  13.311 ns |  12.451 ns |  28.77 |    0.24 |  0.2899 |     - |     - |     608 B |
|               StructLinq |   100 |    209.55 ns |   0.714 ns |   0.597 ns |   3.49 |    0.02 |  0.0153 |     - |     - |      32 B |
| StructLinq_ValueDelegate |   100 |    176.10 ns |   0.841 ns |   0.786 ns |   2.93 |    0.01 |       - |     - |     - |         - |
|                Hyperlinq |   100 |    234.93 ns |   1.392 ns |   1.234 ns |   3.91 |    0.03 |       - |     - |     - |         - |
|  Hyperlinq_ValueDelegate |   100 |    201.06 ns |   0.652 ns |   0.610 ns |   3.35 |    0.02 |       - |     - |     - |         - |
