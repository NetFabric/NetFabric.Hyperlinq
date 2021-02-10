## Range.RangeSelect

### Source
[RangeSelect.cs](../LinqBenchmarks/Range/RangeSelect.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta35](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta35)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.200-preview.20614.14
  [Host]        : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|               Method | Start | Count |        Mean |     Error |     StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |------ |------------:|----------:|-----------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop |     0 |   100 |    37.89 ns |  0.113 ns |   0.105 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |     0 |   100 |   760.44 ns | 14.994 ns |  24.635 ns | 20.03 |    0.66 | 0.0267 |     - |     - |      56 B |
|                 Linq |     0 |   100 | 1,248.44 ns | 27.174 ns |  77.967 ns | 33.48 |    1.77 | 0.0420 |     - |     - |      88 B |
|           LinqFaster |     0 |   100 |   411.17 ns |  3.088 ns |   2.737 ns | 10.85 |    0.08 | 0.4053 |     - |     - |     848 B |
|      LinqFaster_SIMD |     0 |   100 |   156.33 ns |  1.419 ns |   1.258 ns |  4.12 |    0.03 | 0.4053 |     - |     - |     848 B |
|               LinqAF |     0 |   100 | 1,434.05 ns | 36.430 ns | 107.416 ns | 38.88 |    3.25 |      - |     - |     - |         - |
|           StructLinq |     0 |   100 |   413.44 ns |  8.249 ns |  20.234 ns | 10.88 |    0.42 | 0.0114 |     - |     - |      24 B |
| StructLinq_IFunction |     0 |   100 |   163.26 ns |  0.346 ns |   0.306 ns |  4.31 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq |     0 |   100 |   502.86 ns | 12.033 ns |  35.292 ns | 13.28 |    0.87 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |     0 |   100 |   172.20 ns |  0.330 ns |   0.292 ns |  4.54 |    0.02 |      - |     - |     - |         - |
