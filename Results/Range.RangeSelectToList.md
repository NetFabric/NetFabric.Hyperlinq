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
|                       Method | Start | Count |      Mean |    Error |   StdDev |        Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|----------------------------- |------ |------ |----------:|---------:|---------:|-------------:|--------:|-------:|------:|------:|----------:|
|                      ForLoop |     0 |   100 | 328.05 ns | 1.274 ns | 1.129 ns |     baseline |         | 0.5660 |     - |     - |   1,184 B |
|                         Linq |     0 |   100 | 338.51 ns | 0.426 ns | 0.356 ns | 1.03x slower |   0.00x | 0.2599 |     - |     - |     544 B |
|                   LinqFaster |     0 |   100 | 390.68 ns | 0.552 ns | 0.489 ns | 1.19x slower |   0.00x | 0.6232 |     - |     - |   1,304 B |
|                       LinqAF |     0 |   100 | 531.07 ns | 1.138 ns | 1.009 ns | 1.62x slower |   0.01x | 0.5655 |     - |     - |   1,184 B |
|                   StructLinq |     0 |   100 | 239.96 ns | 0.381 ns | 0.318 ns | 1.37x faster |   0.00x | 0.2446 |     - |     - |     512 B |
|     StructLinq_ValueDelegate |     0 |   100 | 117.79 ns | 0.248 ns | 0.207 ns | 2.78x faster |   0.01x | 0.2179 |     - |     - |     456 B |
|                    Hyperlinq |     0 |   100 | 334.08 ns | 0.435 ns | 0.407 ns | 1.02x slower |   0.00x | 0.2179 |     - |     - |     456 B |
|      Hyperlinq_ValueDelegate |     0 |   100 | 145.26 ns | 0.230 ns | 0.204 ns | 2.26x faster |   0.01x | 0.2179 |     - |     - |     456 B |
|               Hyperlinq_SIMD |     0 |   100 | 104.92 ns | 0.205 ns | 0.192 ns | 3.13x faster |   0.01x | 0.2180 |     - |     - |     456 B |
| Hyperlinq_ValueDelegate_SIMD |     0 |   100 |  75.18 ns | 0.699 ns | 0.584 ns | 4.36x faster |   0.04x | 0.2180 |     - |     - |     456 B |
