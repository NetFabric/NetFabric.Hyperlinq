## Range.RangeToArray

### Source
[RangeToArray.cs](../LinqBenchmarks/Range/RangeToArray.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqFasterer: [2.1.0](https://www.nuget.org/packages/LinqFasterer/2.1.0)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- LinqOptimizer.CSharp: [](https://www.nuget.org/packages/LinqOptimizer.CSharp/)
- Streams.CSharp: [0.6.0](https://www.nuget.org/packages/Streams.CSharp/0.6.0)
- StructLinq.BCL: [0.26.0](https://www.nuget.org/packages/StructLinq/0.26.0)
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)

### Results:
``` ini

BenchmarkDotNet=v0.12.1.1527-nightly, OS=Windows 10.0.19043
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.4.21227.6
  [Host] : .NET 5.0.4 (5.0.421.11614), X64 RyuJIT
  .NET 6 : .NET 6.0.0 (6.0.21.22210), X64 RyuJIT

Job=.NET 6  EnvironmentVariables=COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1  Runtime=.NET 6.0  

```
|          Method | Start | Count |      Mean |    Error |   StdDev |    Median | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------- |------ |------ |----------:|---------:|---------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|         ForLoop |     0 |   100 |  90.63 ns | 0.995 ns | 0.882 ns |  90.65 ns |  1.00 |    0.00 | 0.2027 |     - |     - |     424 B |
|            Linq |     0 |   100 |  84.66 ns | 1.663 ns | 1.475 ns |  84.99 ns |  0.93 |    0.02 | 0.2218 |     - |     - |     464 B |
|      LinqFaster |     0 |   100 |  73.50 ns | 0.957 ns | 0.895 ns |  73.54 ns |  0.81 |    0.01 | 0.2027 |     - |     - |     424 B |
| LinqFaster_SIMD |     0 |   100 |  46.38 ns | 0.538 ns | 0.477 ns |  46.40 ns |  0.51 |    0.01 | 0.2027 |     - |     - |     424 B |
|          LinqAF |     0 |   100 | 206.68 ns | 1.385 ns | 1.295 ns | 206.08 ns |  2.28 |    0.02 | 0.2027 |     - |     - |     424 B |
|      StructLinq |     0 |   100 |  82.11 ns | 0.857 ns | 0.802 ns |  82.25 ns |  0.91 |    0.01 | 0.2027 |     - |     - |     424 B |
|       Hyperlinq |     0 |   100 |  45.57 ns | 1.005 ns | 2.851 ns |  44.40 ns |  0.54 |    0.02 | 0.2027 |     - |     - |     424 B |
