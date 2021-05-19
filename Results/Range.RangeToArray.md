## Range.RangeToArray

### Source
[RangeToArray.cs](../LinqBenchmarks/Range/RangeToArray.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqFasterer: [2.1.0](https://www.nuget.org/packages/LinqFasterer/2.1.0)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- LinqOptimizer.CSharp: [0.7.0](https://www.nuget.org/packages/LinqOptimizer.CSharp/0.7.0)
- SpanLinq: [1.0.0](https://www.nuget.org/packages/SpanLinq/1.0.0)
- Streams.CSharp: [0.6.0](https://www.nuget.org/packages/Streams.CSharp/0.6.0)
- StructLinq.BCL: [0.26.0](https://www.nuget.org/packages/StructLinq/0.26.0)
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)
- System.Linq.Async: [5.0.0](https://www.nuget.org/packages/System.Linq.Async/5.0.0)

### Results:
``` ini

BenchmarkDotNet=v0.12.1.1538-nightly, OS=Windows 10.0.19043
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.4.21227.6
  [Host] : .NET 5.0.6 (5.0.621.22011), X64 RyuJIT
  .NET 6 : .NET 6.0.0 (6.0.21.22210), X64 RyuJIT

Job=.NET 6  EnvironmentVariables=COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1  Runtime=.NET 6.0  

```
|          Method | Start | Count |      Mean |    Error |   StdDev |    Median | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------- |------ |------ |----------:|---------:|---------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|         ForLoop |     0 |   100 |  82.14 ns | 1.655 ns | 3.227 ns |  81.23 ns |  1.00 |    0.00 | 0.2027 |     - |     - |     424 B |
|            Linq |     0 |   100 |  89.04 ns | 1.943 ns | 5.728 ns |  86.23 ns |  1.10 |    0.09 | 0.2218 |     - |     - |     464 B |
|      LinqFaster |     0 |   100 |  74.03 ns | 1.250 ns | 1.169 ns |  73.64 ns |  0.87 |    0.04 | 0.2027 |     - |     - |     424 B |
| LinqFaster_SIMD |     0 |   100 |  41.31 ns | 0.462 ns | 0.386 ns |  41.37 ns |  0.49 |    0.02 | 0.2027 |     - |     - |     424 B |
|          LinqAF |     0 |   100 | 250.84 ns | 1.889 ns | 1.767 ns | 251.27 ns |  2.96 |    0.15 | 0.2027 |     - |     - |     424 B |
|      StructLinq |     0 |   100 |  85.75 ns | 1.194 ns | 1.117 ns |  85.85 ns |  1.01 |    0.05 | 0.2027 |     - |     - |     424 B |
|       Hyperlinq |     0 |   100 |  56.42 ns | 0.843 ns | 0.747 ns |  56.52 ns |  0.66 |    0.03 | 0.2027 |     - |     - |     424 B |
