## List.ValueType.ListValueTypeWhereSelect

### Source
[ListValueTypeWhereSelect.cs](../LinqBenchmarks/List/ValueType/ListValueTypeWhereSelect.cs)

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
|               Method | Count |       Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |-----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop |   100 |   948.2 ns |  3.42 ns |  3.20 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 | 1,137.9 ns |  4.60 ns |  4.08 ns |  1.20 |    0.01 |      - |     - |     - |         - |
|                 Linq |   100 | 1,724.8 ns |  3.56 ns |  2.78 ns |  1.82 |    0.01 | 0.1335 |     - |     - |     280 B |
|           LinqFaster |   100 | 1,908.8 ns | 14.01 ns | 12.42 ns |  2.01 |    0.02 | 2.4433 |     - |     - |    5112 B |
|               LinqAF |   100 | 2,279.5 ns |  6.62 ns |  6.19 ns |  2.40 |    0.01 |      - |     - |     - |         - |
|           StructLinq |   100 | 1,192.4 ns |  5.76 ns |  5.39 ns |  1.26 |    0.01 | 0.0343 |     - |     - |      72 B |
| StructLinq_IFunction |   100 |   957.0 ns |  3.37 ns |  3.15 ns |  1.01 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq |   100 | 1,251.6 ns |  5.19 ns |  4.85 ns |  1.32 |    0.01 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |   100 |   997.9 ns |  8.02 ns |  7.11 ns |  1.05 |    0.01 |      - |     - |     - |         - |
