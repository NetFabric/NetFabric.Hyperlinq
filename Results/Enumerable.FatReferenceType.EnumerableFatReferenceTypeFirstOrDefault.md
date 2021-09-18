## Enumerable.FatReferenceType.EnumerableFatReferenceTypeFirstOrDefault

### Source
[EnumerableFatReferenceTypeFirstOrDefault.cs](../LinqBenchmarks/Enumerable/FatReferenceType/EnumerableFatReferenceTypeFirstOrDefault.cs)

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
|                   Method | Count |     Mean |    Error |   StdDev |   Median |        Ratio | RatioSD |  Gen 0 | Allocated |
|------------------------- |------ |---------:|---------:|---------:|---------:|-------------:|--------:|-------:|----------:|
|              ForeachLoop |   100 | 16.12 ns | 1.229 ns | 3.425 ns | 14.82 ns |     baseline |         | 0.0229 |      48 B |
|                     Linq |   100 | 23.57 ns | 1.067 ns | 3.027 ns | 22.09 ns | 1.49x slower |   0.24x | 0.0229 |      48 B |
|                   LinqAF |   100 | 48.80 ns | 1.560 ns | 4.575 ns | 50.95 ns | 3.14x slower |   0.70x | 0.0229 |      48 B |
|               StructLinq |   100 | 25.21 ns | 1.061 ns | 3.010 ns | 24.20 ns | 1.61x slower |   0.28x | 0.0344 |      72 B |
| StructLinq_ValueDelegate |   100 | 14.85 ns | 0.682 ns | 1.912 ns | 14.24 ns | 1.10x faster |   0.25x | 0.0229 |      48 B |
|                Hyperlinq |   100 | 45.65 ns | 1.876 ns | 5.231 ns | 44.30 ns | 2.94x slower |   0.65x | 0.0344 |      72 B |
