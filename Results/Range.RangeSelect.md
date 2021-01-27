## Range.RangeSelect

### Source
[RangeSelect.cs](../LinqBenchmarks/Range/RangeSelect.cs)

### References:
- Cistern.ValueLinq: [0.0.11](https://www.nuget.org/packages/Cistern.ValueLinq/0.0.11)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.19.2](https://www.nuget.org/packages/StructLinq.BCL/0.19.2)
- NetFabric.Hyperlinq: [3.0.0-beta27](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta27)

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
|              ForLoop |     0 |   100 |  38.49 ns | 0.102 ns | 0.090 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |     0 |   100 | 443.96 ns | 1.262 ns | 1.119 ns | 11.54 |    0.05 | 0.0267 |     - |     - |      56 B |
|                 Linq |     0 |   100 | 571.72 ns | 2.284 ns | 2.024 ns | 14.86 |    0.05 | 0.0420 |     - |     - |      88 B |
|           LinqFaster |     0 |   100 | 334.59 ns | 2.235 ns | 1.866 ns |  8.69 |    0.06 | 0.4053 |     - |     - |     848 B |
|               LinqAF |     0 |   100 | 468.78 ns | 0.703 ns | 0.623 ns | 12.18 |    0.03 |      - |     - |     - |         - |
|           StructLinq |     0 |   100 | 203.73 ns | 0.443 ns | 0.370 ns |  5.29 |    0.01 | 0.0114 |     - |     - |      24 B |
| StructLinq_IFunction |     0 |   100 | 160.47 ns | 0.471 ns | 0.418 ns |  4.17 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq |     0 |   100 | 227.51 ns | 0.450 ns | 0.398 ns |  5.91 |    0.02 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |     0 |   100 | 168.89 ns | 0.292 ns | 0.273 ns |  4.39 |    0.01 |      - |     - |     - |         - |
