## Range.RangeSelect

### Source
[RangeSelect.cs](../LinqBenchmarks/Range/RangeSelect.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta31](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta31)

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
|              ForLoop |     0 |   100 |  38.38 ns | 0.100 ns | 0.084 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |     0 |   100 | 471.99 ns | 2.324 ns | 2.060 ns | 12.30 |    0.05 | 0.0267 |     - |     - |      56 B |
|                 Linq |     0 |   100 | 623.08 ns | 0.729 ns | 0.609 ns | 16.23 |    0.03 | 0.0420 |     - |     - |      88 B |
|           LinqFaster |     0 |   100 | 309.70 ns | 2.114 ns | 1.977 ns |  8.08 |    0.06 | 0.4053 |     - |     - |     848 B |
|               LinqAF |     0 |   100 | 420.50 ns | 1.190 ns | 0.993 ns | 10.96 |    0.03 |      - |     - |     - |         - |
|           StructLinq |     0 |   100 | 206.79 ns | 0.529 ns | 0.469 ns |  5.39 |    0.01 | 0.0114 |     - |     - |      24 B |
| StructLinq_IFunction |     0 |   100 | 163.26 ns | 0.163 ns | 0.152 ns |  4.25 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq |     0 |   100 | 232.55 ns | 0.765 ns | 0.678 ns |  6.06 |    0.02 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |     0 |   100 | 167.03 ns | 0.192 ns | 0.170 ns |  4.35 |    0.01 |      - |     - |     - |         - |
