## Range.RangeSelect

### Source
[RangeSelect.cs](../LinqBenchmarks/Range/RangeSelect.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- StructLinq.BCL: [0.19.1](https://www.nuget.org/packages/StructLinq.BCL/0.19.1)
- NetFabric.Hyperlinq: [3.0.0-beta23](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta23)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.100-preview.7.20366.6
  [Host]        : .NET Core 5.0.0 (CoreCLR 5.0.20.36411, CoreFX 5.0.20.36411), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.0 (CoreCLR 5.0.20.36411, CoreFX 5.0.20.36411), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|               Method | Start | Count |      Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |------ |----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop |     0 |   100 |  36.12 ns | 0.141 ns | 0.118 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |     0 |   100 | 454.13 ns | 1.215 ns | 1.077 ns | 12.57 |    0.05 | 0.0267 |     - |     - |      56 B |
|                 Linq |     0 |   100 | 631.49 ns | 3.456 ns | 3.064 ns | 17.48 |    0.11 | 0.0420 |     - |     - |      88 B |
|           LinqFaster |     0 |   100 | 340.09 ns | 2.496 ns | 2.213 ns |  9.42 |    0.06 | 0.4053 |     - |     - |     848 B |
|           StructLinq |     0 |   100 | 252.06 ns | 1.958 ns | 1.736 ns |  6.98 |    0.06 |      - |     - |     - |         - |
| StructLinq_IFunction |     0 |   100 | 170.93 ns | 1.425 ns | 1.333 ns |  4.74 |    0.04 |      - |     - |     - |         - |
|    Hyperlinq_Foreach |     0 |   100 | 372.29 ns | 1.862 ns | 1.650 ns | 10.31 |    0.06 |      - |     - |     - |         - |
|        Hyperlinq_For |     0 |   100 | 397.83 ns | 2.807 ns | 2.488 ns | 11.01 |    0.09 |      - |     - |     - |         - |
