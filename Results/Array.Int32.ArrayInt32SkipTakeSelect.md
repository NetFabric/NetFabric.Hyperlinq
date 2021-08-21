## Array.Int32.ArrayInt32SkipTakeSelect

### Source
[ArrayInt32SkipTakeSelect.cs](../LinqBenchmarks/Array/Int32/ArrayInt32SkipTakeSelect.cs)

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
|                   Method | Skip | Count |         Mean |      Error |     StdDev |       Median |          Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |----- |------ |-------------:|-----------:|-----------:|-------------:|---------------:|--------:|--------:|------:|------:|----------:|
|                  ForLoop | 1000 |   100 |     68.26 ns |   0.113 ns |   0.094 ns |     68.21 ns |       baseline |         |       - |     - |     - |         - |
|                     Linq | 1000 |   100 |    750.86 ns |   1.853 ns |   1.547 ns |    751.30 ns |  11.00x slower |   0.02x |  0.0725 |     - |     - |     152 B |
|               LinqFaster | 1000 |   100 |    365.37 ns |   4.658 ns |   4.358 ns |    362.81 ns |   5.36x slower |   0.06x |  0.6080 |     - |     - |   1,272 B |
|             LinqFasterer | 1000 |   100 |    475.24 ns |   1.121 ns |   0.994 ns |    475.51 ns |   6.96x slower |   0.02x |  0.4206 |     - |     - |     880 B |
|                   LinqAF | 1000 |   100 | 16,907.65 ns | 335.532 ns | 784.295 ns | 16,643.00 ns | 251.82x slower |  14.00x |       - |     - |     - |     576 B |
|            LinqOptimizer | 1000 |   100 | 43,942.34 ns | 108.127 ns |  90.291 ns | 43,942.56 ns | 643.71x slower |   1.61x | 14.8926 |     - |     - |  31,181 B |
|                 SpanLinq | 1000 |   100 |    276.17 ns |   0.359 ns |   0.299 ns |    276.02 ns |   4.05x slower |   0.01x |       - |     - |     - |         - |
|                  Streams | 1000 |   100 |  6,366.12 ns |   6.167 ns |   5.769 ns |  6,365.26 ns |  93.26x slower |   0.13x |  0.4349 |     - |     - |     912 B |
|               StructLinq | 1000 |   100 |    277.28 ns |   0.610 ns |   0.510 ns |    277.38 ns |   4.06x slower |   0.01x |  0.0458 |     - |     - |      96 B |
| StructLinq_ValueDelegate | 1000 |   100 |    176.01 ns |   0.056 ns |   0.044 ns |    176.01 ns |   2.58x slower |   0.00x |       - |     - |     - |         - |
|                Hyperlinq | 1000 |   100 |    244.69 ns |   0.149 ns |   0.132 ns |    244.65 ns |   3.58x slower |   0.01x |       - |     - |     - |         - |
|  Hyperlinq_ValueDelegate | 1000 |   100 |    218.22 ns |   0.165 ns |   0.138 ns |    218.19 ns |   3.20x slower |   0.01x |       - |     - |     - |         - |
