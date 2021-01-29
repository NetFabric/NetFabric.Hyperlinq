## Range.RangeSelect

### Source
[RangeSelect.cs](../LinqBenchmarks/Range/RangeSelect.cs)

### References:
- Cistern.ValueLinq: [0.0.11](https://www.nuget.org/packages/Cistern.ValueLinq/0.0.11)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta28](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta28)

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
|              ForLoop |     0 |   100 |  42.80 ns | 0.279 ns | 0.233 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |     0 |   100 | 545.50 ns | 1.748 ns | 1.364 ns | 12.74 |    0.07 | 0.0267 |     - |     - |      56 B |
|                 Linq |     0 |   100 | 634.93 ns | 3.568 ns | 3.163 ns | 14.83 |    0.11 | 0.0420 |     - |     - |      88 B |
|           LinqFaster |     0 |   100 | 356.71 ns | 2.677 ns | 2.504 ns |  8.33 |    0.08 | 0.4053 |     - |     - |     848 B |
|               LinqAF |     0 |   100 | 466.70 ns | 2.066 ns | 1.932 ns | 10.90 |    0.07 |      - |     - |     - |         - |
|           StructLinq |     0 |   100 | 223.42 ns | 0.687 ns | 0.642 ns |  5.22 |    0.03 | 0.0114 |     - |     - |      24 B |
| StructLinq_IFunction |     0 |   100 | 177.70 ns | 0.662 ns | 0.587 ns |  4.15 |    0.02 |      - |     - |     - |         - |
|            Hyperlinq |     0 |   100 | 250.30 ns | 0.674 ns | 0.598 ns |  5.85 |    0.04 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |     0 |   100 | 181.04 ns | 0.567 ns | 0.530 ns |  4.23 |    0.02 |      - |     - |     - |         - |
