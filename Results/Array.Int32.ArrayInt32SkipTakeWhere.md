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
|                   Method | Skip | Count |         Mean |      Error |     StdDev |          Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |----- |------ |-------------:|-----------:|-----------:|---------------:|--------:|--------:|------:|------:|----------:|
|                  ForLoop | 1000 |   100 |     74.97 ns |   1.448 ns |   1.209 ns |       baseline |         |       - |     - |     - |         - |
|                     Linq | 1000 |   100 |  1,027.13 ns |   1.727 ns |   1.531 ns |  13.70x slower |   0.22x |  0.0725 |     - |     - |     152 B |
|               LinqFaster | 1000 |   100 |    412.57 ns |   1.287 ns |   1.141 ns |   5.51x slower |   0.09x |  0.7191 |     - |     - |   1,504 B |
|             LinqFasterer | 1000 |   100 |    464.34 ns |   1.317 ns |   1.232 ns |   6.20x slower |   0.10x |  0.3285 |     - |     - |     688 B |
|                   LinqAF | 1000 |   100 |  2,732.52 ns |   8.421 ns |   7.465 ns |  36.46x slower |   0.61x |       - |     - |     - |         - |
|            LinqOptimizer | 1000 |   100 | 51,168.32 ns |  99.436 ns |  88.147 ns | 682.57x slower |   9.92x | 15.0146 |     - |     - |  31,640 B |
|                 SpanLinq | 1000 |   100 |    246.11 ns |   0.850 ns |   0.753 ns |   3.28x slower |   0.06x |       - |     - |     - |         - |
|                  Streams | 1000 |   100 |  6,228.71 ns | 111.762 ns | 104.542 ns |  82.96x slower |   2.18x |  0.4349 |     - |     - |     912 B |
|               StructLinq | 1000 |   100 |    332.35 ns |   5.183 ns |   4.848 ns |   4.44x slower |   0.11x |  0.0458 |     - |     - |      96 B |
| StructLinq_ValueDelegate | 1000 |   100 |    181.97 ns |   0.248 ns |   0.220 ns |   2.43x slower |   0.04x |       - |     - |     - |         - |
|                Hyperlinq | 1000 |   100 |    345.47 ns |   2.572 ns |   2.280 ns |   4.61x slower |   0.07x |       - |     - |     - |         - |
|  Hyperlinq_ValueDelegate | 1000 |   100 |    239.83 ns |   2.871 ns |   2.820 ns |   3.21x slower |   0.07x |       - |     - |     - |         - |
