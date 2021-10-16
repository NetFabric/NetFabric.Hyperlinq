## Range.Range

### Source
[Range.cs](../LinqBenchmarks/Range/Range.cs)

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
|         ForLoop |     0 |   100 |  39.24 ns | 0.110 ns | 0.097 ns |     baseline |         |      - |         - |
|            Linq |     0 |   100 | 220.12 ns | 0.473 ns | 0.443 ns | 5.61x slower |   0.02x | 0.0191 |      40 B |
|      LinqFaster |     0 |   100 | 130.20 ns | 0.288 ns | 0.225 ns | 3.32x slower |   0.01x | 0.2027 |     424 B |
| LinqFaster_SIMD |     0 |   100 |  94.19 ns | 0.432 ns | 0.404 ns | 2.40x slower |   0.01x | 0.2027 |     424 B |
|          LinqAF |     0 |   100 | 179.79 ns | 0.303 ns | 0.284 ns | 4.58x slower |   0.01x |      - |         - |
|      StructLinq |     0 |   100 |  39.90 ns | 0.081 ns | 0.075 ns | 1.02x slower |   0.00x |      - |         - |
|       Hyperlinq |     0 |   100 |  47.07 ns | 0.119 ns | 0.111 ns | 1.20x slower |   0.00x |      - |         - |
