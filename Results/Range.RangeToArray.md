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

BenchmarkDotNet=v0.13.0, OS=Windows 10.0.19043.985 (21H1/May2021Update)
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.4.21227.6
  [Host] : .NET 5.0.6 (5.0.621.22011), X64 RyuJIT
  .NET 6 : .NET 6.0.0 (6.0.21.22210), X64 RyuJIT

Job=.NET 6  EnvironmentVariables=COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1  Runtime=.NET 6.0  

```
|          Method | Start | Count |      Mean |    Error |    StdDev |    Median |        Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------- |------ |------ |----------:|---------:|----------:|----------:|-------------:|--------:|-------:|------:|------:|----------:|
|         ForLoop |     0 |   100 |  86.41 ns | 2.000 ns |  5.770 ns |  83.37 ns |     baseline |         | 0.2027 |     - |     - |     424 B |
|            Linq |     0 |   100 | 101.40 ns | 0.852 ns |  0.756 ns | 101.45 ns | 1.07x slower |   0.06x | 0.2218 |     - |     - |     464 B |
|      LinqFaster |     0 |   100 |  76.30 ns | 0.598 ns |  0.500 ns |  76.26 ns | 1.24x faster |   0.07x | 0.2027 |     - |     - |     424 B |
| LinqFaster_SIMD |     0 |   100 |  41.25 ns | 0.646 ns |  0.573 ns |  41.13 ns | 2.30x faster |   0.14x | 0.2027 |     - |     - |     424 B |
|          LinqAF |     0 |   100 | 238.43 ns | 4.743 ns | 12.659 ns | 229.84 ns | 2.76x slower |   0.21x | 0.2027 |     - |     - |     424 B |
|      StructLinq |     0 |   100 |  93.23 ns | 2.358 ns |  6.952 ns |  88.57 ns | 1.08x slower |   0.06x | 0.2027 |     - |     - |     424 B |
|       Hyperlinq |     0 |   100 |  50.90 ns | 0.414 ns |  0.387 ns |  50.99 ns | 1.87x faster |   0.10x | 0.2027 |     - |     - |     424 B |
