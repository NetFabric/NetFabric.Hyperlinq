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
|          Method | Start | Count |      Mean |    Error |   StdDev |        Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------- |------ |------ |----------:|---------:|---------:|-------------:|--------:|-------:|------:|------:|----------:|
|         ForLoop |     0 |   100 |  93.83 ns | 0.192 ns | 0.180 ns |     baseline |         | 0.2027 |     - |     - |     424 B |
|            Linq |     0 |   100 |  97.51 ns | 0.369 ns | 0.345 ns | 1.04x slower |   0.00x | 0.2218 |     - |     - |     464 B |
|      LinqFaster |     0 |   100 |  80.44 ns | 0.119 ns | 0.100 ns | 1.17x faster |   0.00x | 0.2027 |     - |     - |     424 B |
| LinqFaster_SIMD |     0 |   100 |  44.10 ns | 0.093 ns | 0.073 ns | 2.13x faster |   0.01x | 0.2027 |     - |     - |     424 B |
|          LinqAF |     0 |   100 | 225.53 ns | 0.622 ns | 0.519 ns | 2.40x slower |   0.01x | 0.2027 |     - |     - |     424 B |
|      StructLinq |     0 |   100 |  93.85 ns | 0.459 ns | 0.429 ns | 1.00x slower |   0.00x | 0.2027 |     - |     - |     424 B |
|       Hyperlinq |     0 |   100 |  51.92 ns | 0.170 ns | 0.159 ns | 1.81x faster |   0.01x | 0.2027 |     - |     - |     424 B |
