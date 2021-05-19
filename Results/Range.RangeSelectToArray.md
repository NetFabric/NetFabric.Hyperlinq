## Range.RangeSelectToArray

### Source
[RangeSelectToArray.cs](../LinqBenchmarks/Range/RangeSelectToArray.cs)

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
|                       Method | Start | Count |      Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|----------------------------- |------ |------ |----------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|                      ForLoop |     0 |   100 |  91.11 ns |  1.912 ns |  3.399 ns |  1.00 |    0.00 | 0.2027 |     - |     - |     424 B |
|                         Linq |     0 |   100 | 224.49 ns |  1.602 ns |  1.420 ns |  2.38 |    0.08 | 0.2446 |     - |     - |     512 B |
|                   LinqFaster |     0 |   100 | 296.89 ns |  2.713 ns |  2.405 ns |  3.14 |    0.11 | 0.4053 |     - |     - |     848 B |
|              LinqFaster_SIMD |     0 |   100 | 108.08 ns |  2.242 ns |  2.302 ns |  1.15 |    0.04 | 0.4053 |     - |     - |     848 B |
|                       LinqAF |     0 |   100 | 777.82 ns | 15.439 ns | 12.892 ns |  8.20 |    0.37 | 0.7534 |     - |     - |   1,576 B |
|                   StructLinq |     0 |   100 | 262.28 ns |  2.460 ns |  2.302 ns |  2.78 |    0.11 | 0.2294 |     - |     - |     480 B |
|     StructLinq_ValueDelegate |     0 |   100 | 101.43 ns |  0.753 ns |  0.588 ns |  1.07 |    0.04 | 0.2027 |     - |     - |     424 B |
|                    Hyperlinq |     0 |   100 | 245.90 ns |  0.844 ns |  0.748 ns |  2.60 |    0.10 | 0.2027 |     - |     - |     424 B |
|      Hyperlinq_ValueDelegate |     0 |   100 | 136.54 ns |  0.668 ns |  0.625 ns |  1.45 |    0.05 | 0.2027 |     - |     - |     424 B |
|               Hyperlinq_SIMD |     0 |   100 |  99.38 ns |  0.917 ns |  0.813 ns |  1.05 |    0.04 | 0.2027 |     - |     - |     424 B |
| Hyperlinq_ValueDelegate_SIMD |     0 |   100 |  65.96 ns |  0.931 ns |  0.871 ns |  0.70 |    0.03 | 0.2027 |     - |     - |     424 B |
