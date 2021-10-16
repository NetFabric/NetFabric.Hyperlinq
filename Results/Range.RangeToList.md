## Range.RangeToList

### Source
[RangeToList.cs](../LinqBenchmarks/Range/RangeToList.cs)

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
|     Method | Start | Count |      Mean |    Error |   StdDev |        Ratio | RatioSD |  Gen 0 | Allocated |
|----------- |------ |------ |----------:|---------:|---------:|-------------:|--------:|-------:|----------:|
|    ForLoop |     0 |   100 | 323.61 ns | 1.687 ns | 1.578 ns |     baseline |         | 0.5660 |   1,184 B |
|       Linq |     0 |   100 | 208.58 ns | 0.657 ns | 0.583 ns | 1.55x faster |   0.01x | 0.2370 |     496 B |
| LinqFaster |     0 |   100 | 148.16 ns | 0.792 ns | 0.702 ns | 2.18x faster |   0.02x | 0.4208 |     880 B |
|     LinqAF |     0 |   100 | 283.52 ns | 1.041 ns | 0.974 ns | 1.14x faster |   0.01x | 0.2179 |     456 B |
| StructLinq |     0 |   100 | 104.26 ns | 0.521 ns | 0.462 ns | 3.10x faster |   0.02x | 0.2180 |     456 B |
|  Hyperlinq |     0 |   100 |  61.87 ns | 0.556 ns | 0.520 ns | 5.23x faster |   0.05x | 0.2180 |     456 B |
