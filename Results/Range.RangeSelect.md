## Range.RangeSelect

### Source
[RangeSelect.cs](../LinqBenchmarks/Range/RangeSelect.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta32](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta32)

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
|              ForLoop |     0 |   100 |  38.74 ns | 0.107 ns | 0.090 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |     0 |   100 | 476.03 ns | 2.192 ns | 1.830 ns | 12.29 |    0.05 | 0.0267 |     - |     - |      56 B |
|                 Linq |     0 |   100 | 574.69 ns | 2.689 ns | 2.384 ns | 14.83 |    0.06 | 0.0420 |     - |     - |      88 B |
|           LinqFaster |     0 |   100 | 310.92 ns | 2.028 ns | 1.693 ns |  8.02 |    0.04 | 0.4053 |     - |     - |     848 B |
|               LinqAF |     0 |   100 | 421.80 ns | 1.267 ns | 1.185 ns | 10.89 |    0.04 |      - |     - |     - |         - |
|           StructLinq |     0 |   100 | 183.66 ns | 0.388 ns | 0.344 ns |  4.74 |    0.02 | 0.0114 |     - |     - |      24 B |
| StructLinq_IFunction |     0 |   100 | 164.22 ns | 0.260 ns | 0.230 ns |  4.24 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq |     0 |   100 | 204.37 ns | 0.448 ns | 0.374 ns |  5.27 |    0.01 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |     0 |   100 | 166.31 ns | 0.405 ns | 0.379 ns |  4.29 |    0.02 |      - |     - |     - |         - |
