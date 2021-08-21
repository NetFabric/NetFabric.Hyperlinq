## Enumerable.Int32.EnumerableInt32Distinct

### Source
[EnumerableInt32Distinct.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32Distinct.cs)

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
|                   Method | Count |       Mean |   Error |  StdDev |        Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |------ |-----------:|--------:|--------:|-------------:|--------:|-------:|------:|------:|----------:|
|              ForeachLoop |   100 |   747.3 ns | 0.42 ns | 0.35 ns |     baseline |         | 0.0992 |     - |     - |     208 B |
|                     Linq |   100 |   800.3 ns | 0.68 ns | 0.60 ns | 1.07x slower |   0.00x | 0.1602 |     - |     - |     336 B |
|                   LinqAF |   100 | 1,570.5 ns | 2.90 ns | 2.42 ns | 2.10x slower |   0.00x | 1.2531 |     - |     - |   2,624 B |
|               StructLinq |   100 |   733.7 ns | 0.64 ns | 0.53 ns | 1.02x faster |   0.00x | 0.0305 |     - |     - |      64 B |
| StructLinq_ValueDelegate |   100 |   735.8 ns | 3.57 ns | 3.16 ns | 1.02x faster |   0.00x | 0.0191 |     - |     - |      40 B |
|                Hyperlinq |   100 |   776.8 ns | 1.05 ns | 0.88 ns | 1.04x slower |   0.00x | 0.0191 |     - |     - |      40 B |
