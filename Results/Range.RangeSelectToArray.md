## Range.RangeSelectToArray

### Source
[RangeSelectToArray.cs](../LinqBenchmarks/Range/RangeSelectToArray.cs)

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
|                       Method | Start | Count |      Mean |    Error |   StdDev |        Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|----------------------------- |------ |------ |----------:|---------:|---------:|-------------:|--------:|-------:|------:|------:|----------:|
|                      ForLoop |     0 |   100 | 100.42 ns | 1.112 ns | 0.986 ns |     baseline |         | 0.2027 |     - |     - |     424 B |
|                         Linq |     0 |   100 | 231.82 ns | 4.135 ns | 7.767 ns | 2.37x slower |   0.11x | 0.2446 |     - |     - |     512 B |
|                   LinqFaster |     0 |   100 | 311.18 ns | 2.218 ns | 1.966 ns | 3.10x slower |   0.04x | 0.4053 |     - |     - |     848 B |
|              LinqFaster_SIMD |     0 |   100 | 108.37 ns | 2.012 ns | 2.066 ns | 1.08x slower |   0.02x | 0.4053 |     - |     - |     848 B |
|                       LinqAF |     0 |   100 | 747.85 ns | 6.472 ns | 5.737 ns | 7.45x slower |   0.11x | 0.7534 |     - |     - |   1,576 B |
|                   StructLinq |     0 |   100 | 245.07 ns | 2.551 ns | 1.992 ns | 2.44x slower |   0.03x | 0.2294 |     - |     - |     480 B |
|     StructLinq_ValueDelegate |     0 |   100 | 121.23 ns | 1.850 ns | 1.640 ns | 1.21x slower |   0.02x | 0.2027 |     - |     - |     424 B |
|                    Hyperlinq |     0 |   100 | 256.39 ns | 1.949 ns | 1.823 ns | 2.56x slower |   0.03x | 0.2027 |     - |     - |     424 B |
|      Hyperlinq_ValueDelegate |     0 |   100 | 142.34 ns | 1.267 ns | 1.123 ns | 1.42x slower |   0.02x | 0.2027 |     - |     - |     424 B |
|               Hyperlinq_SIMD |     0 |   100 |  90.13 ns | 0.917 ns | 1.481 ns | 1.11x faster |   0.03x | 0.2027 |     - |     - |     424 B |
| Hyperlinq_ValueDelegate_SIMD |     0 |   100 |  68.81 ns | 0.770 ns | 0.683 ns | 1.46x faster |   0.03x | 0.2027 |     - |     - |     424 B |
