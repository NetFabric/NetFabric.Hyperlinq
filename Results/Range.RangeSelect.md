## Range.RangeSelect

### Source
[RangeSelect.cs](../LinqBenchmarks/Range/RangeSelect.cs)

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
|                   Method | Start | Count |      Mean |    Error |   StdDev |        Ratio | RatioSD |  Gen 0 | Allocated |
|------------------------- |------ |------ |----------:|---------:|---------:|-------------:|--------:|-------:|----------:|
|                  ForLoop |     0 |   100 |  48.34 ns | 0.136 ns | 0.121 ns |     baseline |         |      - |         - |
|                     Linq |     0 |   100 | 393.85 ns | 2.492 ns | 2.209 ns | 8.15x slower |   0.05x | 0.0420 |      88 B |
|               LinqFaster |     0 |   100 | 340.13 ns | 3.491 ns | 3.266 ns | 7.04x slower |   0.07x | 0.4053 |     848 B |
|          LinqFaster_SIMD |     0 |   100 | 175.92 ns | 3.105 ns | 2.752 ns | 3.64x slower |   0.06x | 0.4053 |     848 B |
|                   LinqAF |     0 |   100 | 231.16 ns | 0.471 ns | 0.441 ns | 4.78x slower |   0.01x |      - |         - |
|               StructLinq |     0 |   100 | 218.33 ns | 0.750 ns | 0.701 ns | 4.52x slower |   0.02x | 0.0114 |      24 B |
| StructLinq_ValueDelegate |     0 |   100 | 180.12 ns | 0.241 ns | 0.226 ns | 3.73x slower |   0.01x |      - |         - |
|                Hyperlinq |     0 |   100 | 199.92 ns | 0.369 ns | 0.327 ns | 4.14x slower |   0.01x |      - |         - |
|  Hyperlinq_ValueDelegate |     0 |   100 | 187.10 ns | 0.242 ns | 0.227 ns | 3.87x slower |   0.01x |      - |         - |
