## Range.RangeSelect

### Source
[RangeSelect.cs](../LinqBenchmarks/Range/RangeSelect.cs)

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
|                   Method | Start | Count |      Mean |    Error |    StdDev |    Median | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |------ |------ |----------:|---------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|                  ForLoop |     0 |   100 |  49.44 ns | 0.164 ns |  0.137 ns |  49.47 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|                     Linq |     0 |   100 | 493.62 ns | 3.619 ns |  3.385 ns | 493.69 ns |  9.99 |    0.09 | 0.0420 |     - |     - |      88 B |
|               LinqFaster |     0 |   100 | 365.28 ns | 3.017 ns |  2.822 ns | 365.33 ns |  7.39 |    0.07 | 0.4053 |     - |     - |     848 B |
|          LinqFaster_SIMD |     0 |   100 | 151.87 ns | 3.725 ns | 10.984 ns | 146.32 ns |  3.21 |    0.27 | 0.4053 |     - |     - |     848 B |
|                   LinqAF |     0 |   100 | 541.98 ns | 2.443 ns |  2.285 ns | 541.96 ns | 10.96 |    0.06 |      - |     - |     - |         - |
|               StructLinq |     0 |   100 | 204.43 ns | 0.855 ns |  0.799 ns | 204.49 ns |  4.13 |    0.02 | 0.0114 |     - |     - |      24 B |
| StructLinq_ValueDelegate |     0 |   100 | 194.35 ns | 1.921 ns |  1.797 ns | 195.34 ns |  3.92 |    0.03 |      - |     - |     - |         - |
|                Hyperlinq |     0 |   100 | 211.56 ns | 1.509 ns |  1.412 ns | 210.88 ns |  4.28 |    0.03 |      - |     - |     - |         - |
|  Hyperlinq_ValueDelegate |     0 |   100 | 199.67 ns | 0.815 ns |  0.681 ns | 199.45 ns |  4.04 |    0.01 |      - |     - |     - |         - |
