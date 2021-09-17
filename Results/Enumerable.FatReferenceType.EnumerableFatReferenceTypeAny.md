## Enumerable.FatReferenceType.EnumerableFatReferenceTypeAny

### Source
[EnumerableFatReferenceTypeAny.cs](../LinqBenchmarks/Enumerable/FatReferenceType/EnumerableFatReferenceTypeAny.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqFasterer: [2.1.0](https://www.nuget.org/packages/LinqFasterer/2.1.0)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- LinqOptimizer.CSharp: [0.7.0](https://www.nuget.org/packages/LinqOptimizer.CSharp/0.7.0)
- SpanLinq: [0.0.1](https://www.nuget.org/packages/SpanLinq/0.0.1)
- Streams.CSharp: [0.6.0](https://www.nuget.org/packages/Streams.CSharp/0.6.0)
- StructLinq.BCL: [0.27.0](https://www.nuget.org/packages/StructLinq/0.27.0)
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)
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
|              ForeachLoop |   100 | 12.71 ns | 0.068 ns | 0.126 ns | 12.66 ns |     baseline |         | 0.0229 |      48 B |
|                     Linq |   100 | 24.38 ns | 0.164 ns | 0.145 ns | 24.33 ns | 1.92x slower |   0.02x | 0.0229 |      48 B |
|                   LinqAF |   100 | 37.32 ns | 0.231 ns | 0.216 ns | 37.20 ns | 2.94x slower |   0.03x | 0.0229 |      48 B |
|               StructLinq |   100 | 23.84 ns | 0.123 ns | 0.115 ns | 23.80 ns | 1.88x slower |   0.02x | 0.0344 |      72 B |
| StructLinq_ValueDelegate |   100 | 23.79 ns | 0.128 ns | 0.120 ns | 23.75 ns | 1.87x slower |   0.02x | 0.0344 |      72 B |
|                Hyperlinq |   100 | 21.42 ns | 0.126 ns | 0.112 ns | 21.38 ns | 1.69x slower |   0.01x | 0.0229 |      48 B |
