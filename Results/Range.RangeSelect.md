## Range.RangeSelect

### Source
[RangeSelect.cs](../LinqBenchmarks/Range/RangeSelect.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta33](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta33)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.200-preview.20614.14
  [Host]        : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|               Method | Start | Count |      Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |------ |----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop |     0 |   100 |  38.70 ns | 0.136 ns | 0.120 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |     0 |   100 | 445.15 ns | 1.219 ns | 0.952 ns | 11.49 |    0.05 | 0.0267 |     - |     - |      56 B |
|                 Linq |     0 |   100 | 572.98 ns | 1.953 ns | 1.827 ns | 14.80 |    0.06 | 0.0420 |     - |     - |      88 B |
|           LinqFaster |     0 |   100 | 332.73 ns | 1.133 ns | 1.060 ns |  8.60 |    0.04 | 0.4053 |     - |     - |     848 B |
|      LinqFaster_SIMD |     0 |   100 | 149.07 ns | 0.464 ns | 0.388 ns |  3.85 |    0.01 | 0.4053 |     - |     - |     848 B |
|               LinqAF |     0 |   100 | 469.09 ns | 0.800 ns | 0.710 ns | 12.12 |    0.04 |      - |     - |     - |         - |
|           StructLinq |     0 |   100 | 207.63 ns | 0.574 ns | 0.479 ns |  5.36 |    0.02 | 0.0114 |     - |     - |      24 B |
| StructLinq_IFunction |     0 |   100 | 163.35 ns | 0.264 ns | 0.247 ns |  4.22 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq |     0 |   100 | 188.02 ns | 0.445 ns | 0.372 ns |  4.86 |    0.02 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |     0 |   100 | 166.56 ns | 0.342 ns | 0.303 ns |  4.30 |    0.02 |      - |     - |     - |         - |
