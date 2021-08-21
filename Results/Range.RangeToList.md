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
|     Method | Start | Count |      Mean |    Error |   StdDev |        Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|----------- |------ |------ |----------:|---------:|---------:|-------------:|--------:|-------:|------:|------:|----------:|
|    ForLoop |     0 |   100 | 322.74 ns | 0.597 ns | 0.559 ns |     baseline |         | 0.5660 |     - |     - |   1,184 B |
|       Linq |     0 |   100 | 205.68 ns | 0.334 ns | 0.296 ns | 1.57x faster |   0.00x | 0.2370 |     - |     - |     496 B |
| LinqFaster |     0 |   100 | 146.04 ns | 0.387 ns | 0.343 ns | 2.21x faster |   0.01x | 0.4208 |     - |     - |     880 B |
|     LinqAF |     0 |   100 | 281.93 ns | 0.311 ns | 0.291 ns | 1.14x faster |   0.00x | 0.2179 |     - |     - |     456 B |
| StructLinq |     0 |   100 | 102.85 ns | 0.255 ns | 0.238 ns | 3.14x faster |   0.01x | 0.2180 |     - |     - |     456 B |
|  Hyperlinq |     0 |   100 |  61.72 ns | 0.076 ns | 0.063 ns | 5.23x faster |   0.01x | 0.2180 |     - |     - |     456 B |
