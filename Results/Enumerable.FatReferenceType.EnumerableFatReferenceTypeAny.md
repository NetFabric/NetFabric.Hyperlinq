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
|              ForeachLoop |   100 | 15.73 ns | 0.655 ns | 1.837 ns | 15.11 ns |     baseline |         | 0.0229 |      48 B |
|                     Linq |   100 | 23.07 ns | 1.199 ns | 3.282 ns | 21.55 ns | 1.49x slower |   0.26x | 0.0229 |      48 B |
|                   LinqAF |   100 | 31.82 ns | 1.291 ns | 3.622 ns | 30.58 ns | 2.04x slower |   0.23x | 0.0229 |      48 B |
|               StructLinq |   100 | 23.29 ns | 0.640 ns | 1.774 ns | 22.88 ns | 1.50x slower |   0.21x | 0.0344 |      72 B |
| StructLinq_ValueDelegate |   100 | 24.66 ns | 0.861 ns | 2.342 ns | 23.86 ns | 1.59x slower |   0.24x | 0.0344 |      72 B |
|                Hyperlinq |   100 | 23.40 ns | 0.531 ns | 1.262 ns | 23.21 ns | 1.46x slower |   0.17x | 0.0229 |      48 B |
