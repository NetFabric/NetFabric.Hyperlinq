## List.ValueType.ListValueTypeWhere

### Source
[ListValueTypeWhere.cs](../LinqBenchmarks/List/ValueType/ListValueTypeWhere.cs)

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
|               Method | Count |       Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |-----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop |   100 |   470.2 ns |  0.96 ns |  0.85 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 |   659.1 ns |  1.58 ns |  1.32 ns |  1.40 |    0.00 |      - |     - |     - |         - |
|                 Linq |   100 | 1,079.5 ns |  4.41 ns |  3.68 ns |  2.30 |    0.01 | 0.0648 |     - |     - |     136 B |
|           LinqFaster |   100 | 1,167.0 ns | 12.80 ns | 10.69 ns |  2.48 |    0.02 | 2.4433 |     - |     - |    5112 B |
|               LinqAF |   100 | 1,348.2 ns | 11.11 ns |  9.28 ns |  2.87 |    0.02 |      - |     - |     - |         - |
|           StructLinq |   100 |   591.7 ns |  1.12 ns |  0.99 ns |  1.26 |    0.00 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |   100 |   476.2 ns |  1.90 ns |  1.69 ns |  1.01 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq |   100 |   598.0 ns |  0.85 ns |  0.71 ns |  1.27 |    0.00 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |   100 |   504.4 ns |  4.42 ns |  3.69 ns |  1.07 |    0.01 |      - |     - |     - |         - |
