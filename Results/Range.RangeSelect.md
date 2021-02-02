## Range.RangeSelect

### Source
[RangeSelect.cs](../LinqBenchmarks/Range/RangeSelect.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta30](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta30)

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
|              ForLoop |     0 |   100 |  38.78 ns | 0.128 ns | 0.114 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |     0 |   100 | 446.25 ns | 1.067 ns | 0.946 ns | 11.51 |    0.04 | 0.0267 |     - |     - |      56 B |
|                 Linq |     0 |   100 | 576.53 ns | 3.018 ns | 2.675 ns | 14.87 |    0.10 | 0.0420 |     - |     - |      88 B |
|           LinqFaster |     0 |   100 | 318.12 ns | 2.762 ns | 2.449 ns |  8.20 |    0.06 | 0.4053 |     - |     - |     848 B |
|               LinqAF |     0 |   100 | 420.64 ns | 0.694 ns | 0.579 ns | 10.85 |    0.03 |      - |     - |     - |         - |
|           StructLinq |     0 |   100 | 205.38 ns | 0.373 ns | 0.330 ns |  5.30 |    0.02 | 0.0114 |     - |     - |      24 B |
| StructLinq_IFunction |     0 |   100 | 162.78 ns | 0.233 ns | 0.218 ns |  4.20 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq |     0 |   100 | 229.88 ns | 0.605 ns | 0.536 ns |  5.93 |    0.02 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |     0 |   100 | 167.73 ns | 0.253 ns | 0.224 ns |  4.32 |    0.01 |      - |     - |     - |         - |
