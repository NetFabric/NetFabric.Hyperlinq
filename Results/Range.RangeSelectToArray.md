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
|                      ForLoop |     0 |   100 | 106.36 ns | 0.561 ns | 0.524 ns |     baseline |         | 0.2027 |     424 B |
|                         Linq |     0 |   100 | 299.95 ns | 1.527 ns | 1.429 ns | 2.82x slower |   0.02x | 0.2446 |     512 B |
|                   LinqFaster |     0 |   100 | 296.02 ns | 1.237 ns | 1.033 ns | 2.78x slower |   0.01x | 0.4053 |     848 B |
|              LinqFaster_SIMD |     0 |   100 | 127.49 ns | 0.753 ns | 0.667 ns | 1.20x slower |   0.01x | 0.4053 |     848 B |
|                       LinqAF |     0 |   100 | 603.64 ns | 5.915 ns | 5.533 ns | 5.68x slower |   0.07x | 0.7534 |   1,576 B |
|                   StructLinq |     0 |   100 | 229.93 ns | 0.428 ns | 0.334 ns | 2.16x slower |   0.01x | 0.2294 |     480 B |
|     StructLinq_ValueDelegate |     0 |   100 | 108.91 ns | 0.454 ns | 0.403 ns | 1.02x slower |   0.01x | 0.2027 |     424 B |
|                    Hyperlinq |     0 |   100 | 256.05 ns | 0.439 ns | 0.343 ns | 2.41x slower |   0.01x | 0.2027 |     424 B |
|      Hyperlinq_ValueDelegate |     0 |   100 | 134.76 ns | 0.591 ns | 0.524 ns | 1.27x slower |   0.01x | 0.2027 |     424 B |
|               Hyperlinq_SIMD |     0 |   100 |  97.85 ns | 0.613 ns | 0.574 ns | 1.09x faster |   0.01x | 0.2027 |     424 B |
| Hyperlinq_ValueDelegate_SIMD |     0 |   100 |  65.30 ns | 0.194 ns | 0.152 ns | 1.63x faster |   0.01x | 0.2027 |     424 B |
