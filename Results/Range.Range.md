## Range.Range

### Source
[Range.cs](../LinqBenchmarks/Range/Range.cs)

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
|         ForLoop |     0 |   100 |  38.35 ns | 0.269 ns | 0.225 ns |  38.38 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|            Linq |     0 |   100 | 264.25 ns | 4.981 ns | 4.415 ns | 265.05 ns |  6.91 |    0.11 | 0.0191 |     - |     - |      40 B |
|      LinqFaster |     0 |   100 | 117.02 ns | 2.133 ns | 1.996 ns | 117.14 ns |  3.04 |    0.05 | 0.2027 |     - |     - |     424 B |
| LinqFaster_SIMD |     0 |   100 |  84.13 ns | 0.389 ns | 0.901 ns |  84.34 ns |  2.19 |    0.03 | 0.2027 |     - |     - |     424 B |
|          LinqAF |     0 |   100 | 191.70 ns | 0.464 ns | 0.434 ns | 191.77 ns |  5.00 |    0.03 |      - |     - |     - |         - |
|      StructLinq |     0 |   100 |  38.68 ns | 0.152 ns | 0.127 ns |  38.67 ns |  1.01 |    0.01 |      - |     - |     - |         - |
|       Hyperlinq |     0 |   100 |  45.66 ns | 0.974 ns | 2.011 ns |  44.50 ns |  1.28 |    0.01 |      - |     - |     - |         - |
