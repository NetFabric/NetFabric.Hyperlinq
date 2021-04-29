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
|          Method | Start | Count |      Mean |    Error |   StdDev |    Median | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------- |------ |------ |----------:|---------:|---------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|         ForLoop |     0 |   100 |  37.82 ns | 0.281 ns | 0.263 ns |  37.82 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|            Linq |     0 |   100 | 205.73 ns | 1.011 ns | 0.946 ns | 205.56 ns |  5.44 |    0.04 | 0.0191 |     - |     - |      40 B |
|      LinqFaster |     0 |   100 | 113.97 ns | 0.855 ns | 0.800 ns | 113.94 ns |  3.01 |    0.02 | 0.2027 |     - |     - |     424 B |
| LinqFaster_SIMD |     0 |   100 |  87.58 ns | 0.421 ns | 0.373 ns |  87.51 ns |  2.32 |    0.02 | 0.2027 |     - |     - |     424 B |
|          LinqAF |     0 |   100 | 168.10 ns | 0.818 ns | 0.765 ns | 167.93 ns |  4.44 |    0.04 |      - |     - |     - |         - |
|      StructLinq |     0 |   100 |  38.27 ns | 0.236 ns | 0.221 ns |  38.25 ns |  1.01 |    0.01 |      - |     - |     - |         - |
|       Hyperlinq |     0 |   100 |  42.99 ns | 0.922 ns | 2.381 ns |  41.54 ns |  1.19 |    0.04 |      - |     - |     - |         - |
