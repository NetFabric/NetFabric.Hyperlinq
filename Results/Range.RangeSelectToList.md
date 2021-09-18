## Range.RangeSelectToList

### Source
[RangeSelectToList.cs](../LinqBenchmarks/Range/RangeSelectToList.cs)

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
|                       Method | Start | Count |      Mean |    Error |   StdDev |        Ratio | RatioSD |  Gen 0 | Allocated |
|----------------------------- |------ |------ |----------:|---------:|---------:|-------------:|--------:|-------:|----------:|
|                      ForLoop |     0 |   100 | 329.08 ns | 2.126 ns | 1.885 ns |     baseline |         | 0.5660 |   1,184 B |
|                         Linq |     0 |   100 | 339.72 ns | 2.168 ns | 1.922 ns | 1.03x slower |   0.01x | 0.2599 |     544 B |
|                   LinqFaster |     0 |   100 | 419.91 ns | 1.668 ns | 1.560 ns | 1.28x slower |   0.01x | 0.6232 |   1,304 B |
|                       LinqAF |     0 |   100 | 535.25 ns | 4.572 ns | 4.277 ns | 1.62x slower |   0.01x | 0.5655 |   1,184 B |
|                   StructLinq |     0 |   100 | 266.96 ns | 0.739 ns | 0.617 ns | 1.23x faster |   0.01x | 0.2446 |     512 B |
|     StructLinq_ValueDelegate |     0 |   100 | 118.15 ns | 0.477 ns | 0.373 ns | 2.78x faster |   0.02x | 0.2179 |     456 B |
|                    Hyperlinq |     0 |   100 | 292.84 ns | 1.531 ns | 1.357 ns | 1.12x faster |   0.00x | 0.2179 |     456 B |
|      Hyperlinq_ValueDelegate |     0 |   100 | 151.93 ns | 0.965 ns | 0.903 ns | 2.17x faster |   0.02x | 0.2179 |     456 B |
|               Hyperlinq_SIMD |     0 |   100 | 104.72 ns | 0.581 ns | 0.544 ns | 3.14x faster |   0.02x | 0.2180 |     456 B |
| Hyperlinq_ValueDelegate_SIMD |     0 |   100 |  75.43 ns | 0.476 ns | 0.445 ns | 4.36x faster |   0.04x | 0.2180 |     456 B |
