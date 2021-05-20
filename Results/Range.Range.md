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
|          Method | Start | Count |      Mean |    Error |   StdDev |        Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------- |------ |------ |----------:|---------:|---------:|-------------:|--------:|-------:|------:|------:|----------:|
|         ForLoop |     0 |   100 |  39.48 ns | 0.304 ns | 0.284 ns |     baseline |         |      - |     - |     - |         - |
|            Linq |     0 |   100 | 210.16 ns | 0.703 ns | 0.548 ns | 5.32x slower |   0.05x | 0.0191 |     - |     - |      40 B |
|      LinqFaster |     0 |   100 | 119.59 ns | 1.056 ns | 0.936 ns | 3.03x slower |   0.03x | 0.2027 |     - |     - |     424 B |
| LinqFaster_SIMD |     0 |   100 | 101.37 ns | 1.065 ns | 0.890 ns | 2.57x slower |   0.03x | 0.2027 |     - |     - |     424 B |
|          LinqAF |     0 |   100 | 188.06 ns | 0.707 ns | 0.661 ns | 4.76x slower |   0.03x |      - |     - |     - |         - |
|      StructLinq |     0 |   100 |  41.08 ns | 0.463 ns | 0.433 ns | 1.04x slower |   0.01x |      - |     - |     - |         - |
|       Hyperlinq |     0 |   100 |  49.71 ns | 0.353 ns | 0.313 ns | 1.26x slower |   0.01x |      - |     - |     - |         - |
