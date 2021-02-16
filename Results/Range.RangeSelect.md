## Range.RangeSelect

### Source
[RangeSelect.cs](../LinqBenchmarks/Range/RangeSelect.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta37](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta37)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.200-preview.21079.7
  [Host]        : .NET Core 5.0.3 (CoreCLR 5.0.321.7212, CoreFX 5.0.321.7212), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.3 (CoreCLR 5.0.321.7212, CoreFX 5.0.321.7212), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|               Method | Start | Count |      Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |------ |----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop |     0 |   100 |  38.63 ns | 0.125 ns | 0.111 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |     0 |   100 | 450.20 ns | 1.868 ns | 1.560 ns | 11.65 |    0.05 | 0.0267 |     - |     - |      56 B |
|                 Linq |     0 |   100 | 581.28 ns | 3.100 ns | 2.589 ns | 15.04 |    0.08 | 0.0420 |     - |     - |      88 B |
|           LinqFaster |     0 |   100 | 335.59 ns | 1.677 ns | 1.487 ns |  8.69 |    0.05 | 0.4053 |     - |     - |     848 B |
|      LinqFaster_SIMD |     0 |   100 | 156.46 ns | 1.752 ns | 1.553 ns |  4.05 |    0.04 | 0.4053 |     - |     - |     848 B |
|               LinqAF |     0 |   100 | 552.41 ns | 2.405 ns | 1.877 ns | 14.29 |    0.06 |      - |     - |     - |         - |
|           StructLinq |     0 |   100 | 182.59 ns | 0.478 ns | 0.424 ns |  4.73 |    0.02 | 0.0114 |     - |     - |      24 B |
| StructLinq_IFunction |     0 |   100 | 164.06 ns | 0.422 ns | 0.394 ns |  4.25 |    0.02 |      - |     - |     - |         - |
|            Hyperlinq |     0 |   100 | 181.83 ns | 0.410 ns | 0.384 ns |  4.71 |    0.02 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |     0 |   100 | 163.15 ns | 0.462 ns | 0.432 ns |  4.22 |    0.02 |      - |     - |     - |         - |
