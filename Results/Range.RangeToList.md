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

BenchmarkDotNet=v0.13.0, OS=Windows 10.0.19043.985 (21H1/May2021Update)
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.4.21227.6
  [Host] : .NET 5.0.6 (5.0.621.22011), X64 RyuJIT
  .NET 6 : .NET 6.0.0 (6.0.21.22210), X64 RyuJIT

Job=.NET 6  EnvironmentVariables=COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1  Runtime=.NET 6.0  

```
|     Method | Start | Count |      Mean |    Error |    StdDev |    Median |        Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|----------- |------ |------ |----------:|---------:|----------:|----------:|-------------:|--------:|-------:|------:|------:|----------:|
|    ForLoop |     0 |   100 | 311.94 ns | 2.708 ns |  2.533 ns | 311.71 ns |     baseline |         | 0.5660 |     - |     - |   1,184 B |
|       Linq |     0 |   100 | 207.17 ns | 2.045 ns |  1.813 ns | 206.94 ns | 1.50x faster |   0.02x | 0.2370 |     - |     - |     496 B |
| LinqFaster |     0 |   100 | 137.49 ns | 4.026 ns | 11.744 ns | 131.15 ns | 2.04x faster |   0.12x | 0.4206 |     - |     - |     880 B |
|     LinqAF |     0 |   100 | 317.34 ns | 2.189 ns |  1.828 ns | 317.51 ns | 1.02x slower |   0.01x | 0.2179 |     - |     - |     456 B |
| StructLinq |     0 |   100 |  98.68 ns | 1.830 ns |  1.622 ns |  98.72 ns | 3.16x faster |   0.06x | 0.2180 |     - |     - |     456 B |
|  Hyperlinq |     0 |   100 |  56.70 ns | 0.616 ns |  0.514 ns |  56.65 ns | 5.49x faster |   0.06x | 0.2180 |     - |     - |     456 B |
