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
|          Method | Start | Count |      Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------- |------ |------ |----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|         ForLoop |     0 |   100 |  81.11 ns | 0.733 ns | 0.650 ns |  1.00 |    0.00 | 0.2027 |     - |     - |     424 B |
|            Linq |     0 |   100 |  88.91 ns | 1.224 ns | 0.956 ns |  1.09 |    0.01 | 0.2217 |     - |     - |     464 B |
|      LinqFaster |     0 |   100 |  74.79 ns | 0.937 ns | 0.877 ns |  0.92 |    0.01 | 0.2027 |     - |     - |     424 B |
| LinqFaster_SIMD |     0 |   100 |  40.75 ns | 0.452 ns | 0.378 ns |  0.50 |    0.01 | 0.2027 |     - |     - |     424 B |
|          LinqAF |     0 |   100 | 215.63 ns | 1.808 ns | 1.692 ns |  2.66 |    0.03 | 0.2027 |     - |     - |     424 B |
|      StructLinq |     0 |   100 |  84.38 ns | 1.176 ns | 0.982 ns |  1.04 |    0.02 | 0.2027 |     - |     - |     424 B |
|       Hyperlinq |     0 |   100 |  53.81 ns | 0.865 ns | 0.809 ns |  0.66 |    0.01 | 0.2027 |     - |     - |     424 B |
