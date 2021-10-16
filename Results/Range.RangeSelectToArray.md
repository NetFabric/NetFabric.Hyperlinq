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
- NetFabric.Hyperlinq: [3.0.0-beta48](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta48)
- System.Linq.Async: [5.0.0](https://www.nuget.org/packages/System.Linq.Async/5.0.0)

### Results:
``` ini

BenchmarkDotNet=v0.13.1, OS=macOS Catalina 10.15.7 (19H1419) [Darwin 19.6.0]
Intel Core i5-7360U CPU 2.30GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-rc.2.21505.57
  [Host]     : .NET 5.0.6 (5.0.621.22011), X64 RyuJIT
  .NET 6 PGO : .NET 6.0.0 (6.0.21.48005), X64 RyuJIT

Job=.NET 6 PGO  EnvironmentVariables=COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1  Runtime=.NET 6.0  

```
|                       Method | Start | Count |      Mean |    Error |   StdDev |        Ratio | RatioSD |  Gen 0 | Allocated |
|----------------------------- |------ |------ |----------:|---------:|---------:|-------------:|--------:|-------:|----------:|
|                      ForLoop |     0 |   100 | 107.34 ns | 0.798 ns | 0.747 ns |     baseline |         | 0.2027 |     424 B |
|                         Linq |     0 |   100 | 270.89 ns | 1.334 ns | 1.248 ns | 2.52x slower |   0.02x | 0.2446 |     512 B |
|                   LinqFaster |     0 |   100 | 298.60 ns | 1.733 ns | 1.621 ns | 2.78x slower |   0.02x | 0.4053 |     848 B |
|              LinqFaster_SIMD |     0 |   100 | 130.04 ns | 0.657 ns | 0.615 ns | 1.21x slower |   0.01x | 0.4053 |     848 B |
|                       LinqAF |     0 |   100 | 571.37 ns | 6.392 ns | 5.338 ns | 5.32x slower |   0.04x | 0.7534 |   1,576 B |
|                   StructLinq |     0 |   100 | 231.03 ns | 1.082 ns | 1.012 ns | 2.15x slower |   0.02x | 0.2294 |     480 B |
|     StructLinq_ValueDelegate |     0 |   100 | 109.19 ns | 0.354 ns | 0.331 ns | 1.02x slower |   0.01x | 0.2027 |     424 B |
|                    Hyperlinq |     0 |   100 | 283.60 ns | 1.168 ns | 0.975 ns | 2.64x slower |   0.02x | 0.2027 |     424 B |
|      Hyperlinq_ValueDelegate |     0 |   100 | 135.51 ns | 1.098 ns | 0.917 ns | 1.26x slower |   0.01x | 0.2027 |     424 B |
|               Hyperlinq_SIMD |     0 |   100 |  98.23 ns | 0.449 ns | 0.420 ns | 1.09x faster |   0.01x | 0.2027 |     424 B |
| Hyperlinq_ValueDelegate_SIMD |     0 |   100 |  65.34 ns | 0.285 ns | 0.238 ns | 1.64x faster |   0.01x | 0.2027 |     424 B |
