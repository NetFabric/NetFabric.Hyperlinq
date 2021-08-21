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
|                      ForLoop |     0 |   100 | 104.95 ns | 0.227 ns | 0.212 ns |     baseline |         | 0.2027 |     - |     - |     424 B |
|                         Linq |     0 |   100 | 241.63 ns | 0.448 ns | 0.374 ns | 2.30x slower |   0.01x | 0.2446 |     - |     - |     512 B |
|                   LinqFaster |     0 |   100 | 347.94 ns | 0.732 ns | 0.649 ns | 3.32x slower |   0.01x | 0.4053 |     - |     - |     848 B |
|              LinqFaster_SIMD |     0 |   100 | 125.79 ns | 0.398 ns | 0.372 ns | 1.20x slower |   0.00x | 0.4053 |     - |     - |     848 B |
|                       LinqAF |     0 |   100 | 591.20 ns | 1.392 ns | 1.234 ns | 5.63x slower |   0.02x | 0.7534 |     - |     - |   1,576 B |
|                   StructLinq |     0 |   100 | 228.38 ns | 0.238 ns | 0.211 ns | 2.18x slower |   0.01x | 0.2294 |     - |     - |     480 B |
|     StructLinq_ValueDelegate |     0 |   100 | 107.33 ns | 1.236 ns | 1.156 ns | 1.02x slower |   0.01x | 0.2027 |     - |     - |     424 B |
|                    Hyperlinq |     0 |   100 | 306.97 ns | 0.480 ns | 0.401 ns | 2.93x slower |   0.01x | 0.2027 |     - |     - |     424 B |
|      Hyperlinq_ValueDelegate |     0 |   100 | 132.38 ns | 0.469 ns | 0.438 ns | 1.26x slower |   0.01x | 0.2027 |     - |     - |     424 B |
|               Hyperlinq_SIMD |     0 |   100 |  97.05 ns | 0.122 ns | 0.108 ns | 1.08x faster |   0.00x | 0.2027 |     - |     - |     424 B |
| Hyperlinq_ValueDelegate_SIMD |     0 |   100 |  65.10 ns | 1.404 ns | 1.826 ns | 1.60x faster |   0.05x | 0.2027 |     - |     - |     424 B |
