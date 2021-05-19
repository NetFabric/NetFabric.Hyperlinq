## Range.RangeToList

### Source
[RangeToList.cs](../LinqBenchmarks/Range/RangeToList.cs)

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
|     Method | Start | Count |      Mean |    Error |   StdDev |    Median | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|----------- |------ |------ |----------:|---------:|---------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|    ForLoop |     0 |   100 | 289.74 ns | 5.707 ns | 9.994 ns | 284.71 ns |  1.00 |    0.00 | 0.5660 |     - |     - |   1,184 B |
|       Linq |     0 |   100 | 197.07 ns | 1.454 ns | 1.135 ns | 196.97 ns |  0.65 |    0.02 | 0.2370 |     - |     - |     496 B |
| LinqFaster |     0 |   100 | 150.29 ns | 1.909 ns | 1.692 ns | 150.56 ns |  0.50 |    0.02 | 0.4206 |     - |     - |     880 B |
|     LinqAF |     0 |   100 | 279.64 ns | 4.176 ns | 3.906 ns | 277.63 ns |  0.94 |    0.04 | 0.2179 |     - |     - |     456 B |
| StructLinq |     0 |   100 |  95.15 ns | 1.194 ns | 1.058 ns |  95.10 ns |  0.32 |    0.01 | 0.2180 |     - |     - |     456 B |
|  Hyperlinq |     0 |   100 |  55.17 ns | 1.195 ns | 1.118 ns |  55.32 ns |  0.19 |    0.01 | 0.2180 |     - |     - |     456 B |
