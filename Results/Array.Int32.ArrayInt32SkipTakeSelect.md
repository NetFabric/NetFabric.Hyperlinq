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
- StructLinq.BCL: [0.27.0](https://www.nuget.org/packages/StructLinq/0.27.0)
- NetFabric.Hyperlinq: [3.0.0-beta46](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta46)
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
|                   Method | Skip | Count |         Mean |      Error |     StdDev |          Ratio | RatioSD |   Gen 0 | Allocated |
|------------------------- |----- |------ |-------------:|-----------:|-----------:|---------------:|--------:|--------:|----------:|
|                  ForLoop | 1000 |   100 |     68.20 ns |   0.058 ns |   0.055 ns |       baseline |         |       - |         - |
|                     Linq | 1000 |   100 |    786.32 ns |   0.833 ns |   0.695 ns |  11.53x slower |   0.02x |  0.0725 |     152 B |
|               LinqFaster | 1000 |   100 |    347.03 ns |   4.336 ns |   4.056 ns |   5.09x slower |   0.06x |  0.6080 |   1,272 B |
|             LinqFasterer | 1000 |   100 |    483.10 ns |   0.744 ns |   0.622 ns |   7.08x slower |   0.01x |  0.4206 |     880 B |
|                   LinqAF | 1000 |   100 |  2,708.30 ns |   1.221 ns |   1.082 ns |  39.71x slower |   0.04x |       - |         - |
|            LinqOptimizer | 1000 |   100 | 43,482.85 ns | 170.993 ns | 151.580 ns | 637.55x slower |   2.35x | 14.8926 |  31,182 B |
|                 SpanLinq | 1000 |   100 |    278.06 ns |   0.177 ns |   0.157 ns |   4.08x slower |   0.00x |       - |         - |
|                  Streams | 1000 |   100 |  6,445.58 ns |   8.556 ns |   7.584 ns |  94.51x slower |   0.13x |  0.4349 |     912 B |
|               StructLinq | 1000 |   100 |    254.06 ns |   0.253 ns |   0.237 ns |   3.73x slower |   0.00x |  0.0458 |      96 B |
| StructLinq_ValueDelegate | 1000 |   100 |    177.18 ns |   0.076 ns |   0.067 ns |   2.60x slower |   0.00x |       - |         - |
|                Hyperlinq | 1000 |   100 |    246.19 ns |   0.186 ns |   0.164 ns |   3.61x slower |   0.00x |       - |         - |
|  Hyperlinq_ValueDelegate | 1000 |   100 |    220.73 ns |   0.150 ns |   0.133 ns |   3.24x slower |   0.00x |       - |         - |
