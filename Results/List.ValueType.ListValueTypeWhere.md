## List.ValueType.ListValueTypeWhere

### Source
[ListValueTypeWhere.cs](../LinqBenchmarks/List/ValueType/ListValueTypeWhere.cs)

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
|               Method | Count |       Mean |    Error |  StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |-----------:|---------:|--------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop |   100 |   517.7 ns |  1.80 ns | 1.69 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 |   741.3 ns |  4.22 ns | 3.94 ns |  1.43 |    0.01 |      - |     - |     - |         - |
|                 Linq |   100 | 1,201.6 ns |  6.83 ns | 5.71 ns |  2.32 |    0.01 | 0.0648 |     - |     - |     136 B |
|           LinqFaster |   100 | 1,316.5 ns | 10.39 ns | 9.21 ns |  2.54 |    0.02 | 2.4433 |     - |     - |    5112 B |
|               LinqAF |   100 | 1,470.9 ns |  9.31 ns | 7.77 ns |  2.84 |    0.02 |      - |     - |     - |         - |
|           StructLinq |   100 |   673.2 ns |  2.12 ns | 1.98 ns |  1.30 |    0.01 | 0.0191 |     - |     - |      40 B |
| StructLinq_IFunction |   100 |   537.2 ns |  3.53 ns | 3.31 ns |  1.04 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq |   100 |   508.9 ns |  1.47 ns | 1.38 ns |  0.98 |    0.00 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |   100 |   508.4 ns |  3.81 ns | 3.38 ns |  0.98 |    0.01 |      - |     - |     - |         - |
