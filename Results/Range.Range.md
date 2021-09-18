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
|          Method | Start | Count |      Mean |    Error |   StdDev |    Median |        Ratio | RatioSD |  Gen 0 | Allocated |
|---------------- |------ |------ |----------:|---------:|---------:|----------:|-------------:|--------:|-------:|----------:|
|         ForLoop |     0 |   100 |  39.24 ns | 0.143 ns | 0.133 ns |  39.17 ns |     baseline |         |      - |         - |
|            Linq |     0 |   100 | 219.67 ns | 0.566 ns | 0.502 ns | 219.40 ns | 5.60x slower |   0.02x | 0.0191 |      40 B |
|      LinqFaster |     0 |   100 | 128.65 ns | 0.219 ns | 0.171 ns | 128.65 ns | 3.28x slower |   0.01x | 0.2027 |     424 B |
| LinqFaster_SIMD |     0 |   100 |  93.38 ns | 0.441 ns | 0.391 ns |  93.31 ns | 2.38x slower |   0.01x | 0.2027 |     424 B |
|          LinqAF |     0 |   100 | 180.03 ns | 0.338 ns | 0.316 ns | 179.95 ns | 4.59x slower |   0.01x |      - |         - |
|      StructLinq |     0 |   100 |  35.40 ns | 0.132 ns | 0.281 ns |  35.30 ns | 1.11x faster |   0.01x |      - |         - |
|       Hyperlinq |     0 |   100 |  44.42 ns | 0.950 ns | 1.875 ns |  43.35 ns | 1.20x slower |   0.03x |      - |         - |
