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
|     Method | Start | Count |      Mean |    Error |   StdDev |        Ratio | RatioSD |  Gen 0 | Allocated |
|----------- |------ |------ |----------:|---------:|---------:|-------------:|--------:|-------:|----------:|
|    ForLoop |     0 |   100 | 327.05 ns | 2.415 ns | 2.141 ns |     baseline |         | 0.5660 |   1,184 B |
|       Linq |     0 |   100 | 210.13 ns | 1.195 ns | 1.059 ns | 1.56x faster |   0.01x | 0.2370 |     496 B |
| LinqFaster |     0 |   100 | 149.33 ns | 1.417 ns | 1.326 ns | 2.19x faster |   0.02x | 0.4208 |     880 B |
|     LinqAF |     0 |   100 | 282.87 ns | 3.181 ns | 2.820 ns | 1.16x faster |   0.01x | 0.2179 |     456 B |
| StructLinq |     0 |   100 | 103.16 ns | 0.429 ns | 0.402 ns | 3.17x faster |   0.03x | 0.2180 |     456 B |
|  Hyperlinq |     0 |   100 |  61.37 ns | 0.483 ns | 0.428 ns | 5.33x faster |   0.06x | 0.2180 |     456 B |
