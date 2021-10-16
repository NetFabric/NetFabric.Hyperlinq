## Range.RangeToArray

### Source
[RangeToArray.cs](../LinqBenchmarks/Range/RangeToArray.cs)

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
|          Method | Start | Count |      Mean |    Error |   StdDev |        Ratio | RatioSD |  Gen 0 | Allocated |
|---------------- |------ |------ |----------:|---------:|---------:|-------------:|--------:|-------:|----------:|
|         ForLoop |     0 |   100 |  96.31 ns | 0.691 ns | 0.612 ns |     baseline |         | 0.2027 |     424 B |
|            Linq |     0 |   100 |  99.50 ns | 0.522 ns | 0.463 ns | 1.03x slower |   0.01x | 0.2218 |     464 B |
|      LinqFaster |     0 |   100 |  82.47 ns | 0.708 ns | 0.591 ns | 1.17x faster |   0.01x | 0.2027 |     424 B |
| LinqFaster_SIMD |     0 |   100 |  44.89 ns | 0.308 ns | 0.273 ns | 2.15x faster |   0.01x | 0.2027 |     424 B |
|          LinqAF |     0 |   100 | 226.41 ns | 0.795 ns | 0.705 ns | 2.35x slower |   0.02x | 0.2027 |     424 B |
|      StructLinq |     0 |   100 |  94.73 ns | 0.873 ns | 0.774 ns | 1.02x faster |   0.01x | 0.2027 |     424 B |
|       Hyperlinq |     0 |   100 |  51.08 ns | 0.231 ns | 0.216 ns | 1.89x faster |   0.01x | 0.2027 |     424 B |
