## Range.RangeSelectToArray

### Source
[RangeSelectToArray.cs](../LinqBenchmarks/Range/RangeSelectToArray.cs)

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
|                       Method | Start | Count |      Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|----------------------------- |------ |------ |----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|                      ForLoop |     0 |   100 |  91.47 ns | 0.785 ns | 0.696 ns |  1.00 |    0.00 | 0.2027 |     - |     - |     424 B |
|                         Linq |     0 |   100 | 247.95 ns | 0.895 ns | 0.794 ns |  2.71 |    0.02 | 0.2446 |     - |     - |     512 B |
|                   LinqFaster |     0 |   100 | 323.26 ns | 2.135 ns | 1.997 ns |  3.53 |    0.03 | 0.4053 |     - |     - |     848 B |
|              LinqFaster_SIMD |     0 |   100 | 104.85 ns | 1.024 ns | 0.908 ns |  1.15 |    0.01 | 0.4054 |     - |     - |     848 B |
|                       LinqAF |     0 |   100 | 743.99 ns | 8.696 ns | 7.262 ns |  8.13 |    0.10 | 0.7534 |     - |     - |   1,576 B |
|                   StructLinq |     0 |   100 | 235.85 ns | 1.594 ns | 1.331 ns |  2.58 |    0.02 | 0.2294 |     - |     - |     480 B |
|     StructLinq_ValueDelegate |     0 |   100 |  96.71 ns | 1.646 ns | 1.459 ns |  1.06 |    0.02 | 0.2027 |     - |     - |     424 B |
|                    Hyperlinq |     0 |   100 | 244.06 ns | 1.132 ns | 0.945 ns |  2.67 |    0.02 | 0.2027 |     - |     - |     424 B |
|      Hyperlinq_ValueDelegate |     0 |   100 | 131.88 ns | 1.192 ns | 1.115 ns |  1.44 |    0.02 | 0.2027 |     - |     - |     424 B |
|               Hyperlinq_SIMD |     0 |   100 |  86.20 ns | 0.443 ns | 0.393 ns |  0.94 |    0.01 | 0.2027 |     - |     - |     424 B |
| Hyperlinq_ValueDelegate_SIMD |     0 |   100 |  60.19 ns | 0.943 ns | 0.882 ns |  0.66 |    0.01 | 0.2027 |     - |     - |     424 B |
