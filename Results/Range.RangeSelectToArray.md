## Range.RangeSelectToArray

### Source
[RangeSelectToArray.cs](../LinqBenchmarks/Range/RangeSelectToArray.cs)

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
|                      ForLoop |     0 |   100 | 103.11 ns | 0.544 ns | 0.483 ns |     baseline |         | 0.2027 |     424 B |
|                         Linq |     0 |   100 | 298.87 ns | 1.317 ns | 1.232 ns | 2.90x slower |   0.02x | 0.2446 |     512 B |
|                   LinqFaster |     0 |   100 | 294.91 ns | 1.666 ns | 1.558 ns | 2.86x slower |   0.02x | 0.4053 |     848 B |
|              LinqFaster_SIMD |     0 |   100 | 125.23 ns | 1.065 ns | 0.944 ns | 1.21x slower |   0.01x | 0.4053 |     848 B |
|                       LinqAF |     0 |   100 | 562.48 ns | 2.000 ns | 1.561 ns | 5.46x slower |   0.03x | 0.7534 |   1,576 B |
|                   StructLinq |     0 |   100 | 231.97 ns | 0.548 ns | 0.427 ns | 2.25x slower |   0.01x | 0.2294 |     480 B |
|     StructLinq_ValueDelegate |     0 |   100 | 107.80 ns | 0.473 ns | 0.419 ns | 1.05x slower |   0.01x | 0.2027 |     424 B |
|                    Hyperlinq |     0 |   100 | 325.62 ns | 1.691 ns | 1.499 ns | 3.16x slower |   0.02x | 0.2027 |     424 B |
|      Hyperlinq_ValueDelegate |     0 |   100 | 132.36 ns | 0.814 ns | 0.762 ns | 1.28x slower |   0.01x | 0.2027 |     424 B |
|               Hyperlinq_SIMD |     0 |   100 |  96.96 ns | 0.623 ns | 0.552 ns | 1.06x faster |   0.01x | 0.2027 |     424 B |
| Hyperlinq_ValueDelegate_SIMD |     0 |   100 |  65.75 ns | 0.324 ns | 0.270 ns | 1.57x faster |   0.01x | 0.2027 |     424 B |
