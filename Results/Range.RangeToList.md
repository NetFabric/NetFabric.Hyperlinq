## Range.RangeToList

### Source
[RangeToList.cs](../LinqBenchmarks/Range/RangeToList.cs)

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
|      Method | Start | Count |      Mean |    Error |    StdDev |    Median | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------ |------ |------ |----------:|---------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|     ForLoop |     0 |   100 | 329.90 ns | 3.096 ns |  2.896 ns | 330.41 ns |  1.00 |    0.00 | 0.5660 |     - |     - |   1,184 B |
| ForeachLoop |     0 |   100 | 524.10 ns | 3.575 ns |  3.344 ns | 523.10 ns |  1.59 |    0.02 | 0.5922 |     - |     - |   1,240 B |
|        Linq |     0 |   100 | 196.61 ns | 4.312 ns | 12.162 ns | 190.25 ns |  0.64 |    0.04 | 0.2370 |     - |     - |     496 B |
|  LinqFaster |     0 |   100 | 127.45 ns | 2.147 ns |  2.008 ns | 128.01 ns |  0.39 |    0.01 | 0.4206 |     - |     - |     880 B |
|      LinqAF |     0 |   100 | 263.34 ns | 1.615 ns |  1.511 ns | 263.63 ns |  0.80 |    0.01 | 0.2179 |     - |     - |     456 B |
|  StructLinq |     0 |   100 |  92.07 ns | 1.404 ns |  1.244 ns |  92.09 ns |  0.28 |    0.00 | 0.2180 |     - |     - |     456 B |
|   Hyperlinq |     0 |   100 |  61.83 ns | 0.323 ns |  0.287 ns |  61.81 ns |  0.19 |    0.00 | 0.2180 |     - |     - |     456 B |
