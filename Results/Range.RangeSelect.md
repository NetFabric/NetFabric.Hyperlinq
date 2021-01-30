## Range.RangeSelect

### Source
[RangeSelect.cs](../LinqBenchmarks/Range/RangeSelect.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta29](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta29)

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
|              ForLoop |     0 |   100 |  38.48 ns | 0.158 ns | 0.140 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |     0 |   100 | 473.48 ns | 1.326 ns | 1.176 ns | 12.30 |    0.03 | 0.0267 |     - |     - |      56 B |
|                 Linq |     0 |   100 | 627.25 ns | 3.167 ns | 2.807 ns | 16.30 |    0.12 | 0.0420 |     - |     - |      88 B |
|           LinqFaster |     0 |   100 | 311.47 ns | 1.554 ns | 1.377 ns |  8.09 |    0.03 | 0.4053 |     - |     - |     848 B |
|               LinqAF |     0 |   100 | 422.13 ns | 1.274 ns | 1.130 ns | 10.97 |    0.05 |      - |     - |     - |         - |
|           StructLinq |     0 |   100 | 206.64 ns | 0.547 ns | 0.485 ns |  5.37 |    0.02 | 0.0114 |     - |     - |      24 B |
| StructLinq_IFunction |     0 |   100 | 164.42 ns | 1.051 ns | 0.878 ns |  4.27 |    0.03 |      - |     - |     - |         - |
|            Hyperlinq |     0 |   100 | 208.69 ns | 0.807 ns | 0.755 ns |  5.42 |    0.02 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |     0 |   100 | 166.17 ns | 0.260 ns | 0.243 ns |  4.32 |    0.02 |      - |     - |     - |         - |
