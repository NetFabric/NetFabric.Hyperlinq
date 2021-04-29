## Range.Range

### Source
[Range.cs](../LinqBenchmarks/Range/Range.cs)

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
|         ForLoop |     0 |   100 |  37.09 ns | 0.115 ns | 0.096 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|     ForeachLoop |     0 |   100 | 312.23 ns | 1.267 ns | 1.124 ns |  8.42 |    0.04 | 0.0267 |     - |     - |      56 B |
|            Linq |     0 |   100 | 204.03 ns | 0.999 ns | 0.834 ns |  5.50 |    0.03 | 0.0191 |     - |     - |      40 B |
|      LinqFaster |     0 |   100 | 129.66 ns | 2.251 ns | 2.105 ns |  3.49 |    0.06 | 0.2027 |     - |     - |     424 B |
| LinqFaster_SIMD |     0 |   100 | 112.52 ns | 0.687 ns | 0.642 ns |  3.03 |    0.01 | 0.2027 |     - |     - |     424 B |
|          LinqAF |     0 |   100 | 165.21 ns | 0.451 ns | 0.400 ns |  4.46 |    0.02 |      - |     - |     - |         - |
|      StructLinq |     0 |   100 |  37.30 ns | 0.352 ns | 0.329 ns |  1.01 |    0.01 |      - |     - |     - |         - |
|       Hyperlinq |     0 |   100 |  43.97 ns | 0.141 ns | 0.131 ns |  1.19 |    0.00 |      - |     - |     - |         - |
