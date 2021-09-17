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
|                       Method | Start | Count |      Mean |    Error |   StdDev |        Ratio | RatioSD |  Gen 0 | Allocated |
|----------------------------- |------ |------ |----------:|---------:|---------:|-------------:|--------:|-------:|----------:|
|                      ForLoop |     0 |   100 | 326.33 ns | 1.635 ns | 1.449 ns |     baseline |         | 0.5660 |   1,184 B |
|                         Linq |     0 |   100 | 342.46 ns | 1.967 ns | 1.840 ns | 1.05x slower |   0.00x | 0.2599 |     544 B |
|                   LinqFaster |     0 |   100 | 418.92 ns | 2.412 ns | 2.014 ns | 1.28x slower |   0.01x | 0.6232 |   1,304 B |
|                       LinqAF |     0 |   100 | 573.24 ns | 4.272 ns | 3.996 ns | 1.76x slower |   0.01x | 0.5655 |   1,184 B |
|                   StructLinq |     0 |   100 | 266.49 ns | 1.452 ns | 1.288 ns | 1.22x faster |   0.01x | 0.2446 |     512 B |
|     StructLinq_ValueDelegate |     0 |   100 | 116.92 ns | 0.273 ns | 0.214 ns | 2.79x faster |   0.01x | 0.2179 |     456 B |
|                    Hyperlinq |     0 |   100 | 332.40 ns | 1.123 ns | 0.938 ns | 1.02x slower |   0.01x | 0.2179 |     456 B |
|      Hyperlinq_ValueDelegate |     0 |   100 | 144.33 ns | 0.815 ns | 0.681 ns | 2.26x faster |   0.01x | 0.2179 |     456 B |
|               Hyperlinq_SIMD |     0 |   100 | 103.83 ns | 0.526 ns | 0.492 ns | 3.14x faster |   0.02x | 0.2180 |     456 B |
| Hyperlinq_ValueDelegate_SIMD |     0 |   100 |  74.71 ns | 0.453 ns | 0.423 ns | 4.37x faster |   0.03x | 0.2180 |     456 B |
