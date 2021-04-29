## Range.RangeSelect

### Source
[RangeSelect.cs](../LinqBenchmarks/Range/RangeSelect.cs)

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
|                   Method | Start | Count |      Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |------ |------ |----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|                  ForLoop |     0 |   100 |  47.43 ns | 0.233 ns | 0.218 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|                     Linq |     0 |   100 | 422.61 ns | 2.093 ns | 1.958 ns |  8.91 |    0.05 | 0.0420 |     - |     - |      88 B |
|               LinqFaster |     0 |   100 | 366.81 ns | 2.686 ns | 2.512 ns |  7.73 |    0.06 | 0.4053 |     - |     - |     848 B |
|          LinqFaster_SIMD |     0 |   100 | 147.94 ns | 1.783 ns | 1.581 ns |  3.12 |    0.04 | 0.4053 |     - |     - |     848 B |
|                   LinqAF |     0 |   100 | 530.49 ns | 2.336 ns | 2.185 ns | 11.19 |    0.08 |      - |     - |     - |         - |
|               StructLinq |     0 |   100 | 206.80 ns | 0.804 ns | 0.752 ns |  4.36 |    0.03 | 0.0114 |     - |     - |      24 B |
| StructLinq_ValueDelegate |     0 |   100 | 167.82 ns | 1.019 ns | 0.953 ns |  3.54 |    0.03 |      - |     - |     - |         - |
|                Hyperlinq |     0 |   100 | 197.19 ns | 0.751 ns | 0.702 ns |  4.16 |    0.02 |      - |     - |     - |         - |
|  Hyperlinq_ValueDelegate |     0 |   100 | 173.12 ns | 0.836 ns | 0.782 ns |  3.65 |    0.03 |      - |     - |     - |         - |
