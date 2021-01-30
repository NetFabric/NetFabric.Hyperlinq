## List.ValueType.ListValueTypeWhere

### Source
[ListValueTypeWhere.cs](../LinqBenchmarks/List/ValueType/ListValueTypeWhere.cs)

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
|               Method | Count |       Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |-----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop |   100 |   476.2 ns |  1.07 ns |  1.00 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 |   668.5 ns |  3.12 ns |  2.44 ns |  1.40 |    0.01 |      - |     - |     - |         - |
|                 Linq |   100 | 1,091.9 ns |  5.51 ns |  5.15 ns |  2.29 |    0.01 | 0.0648 |     - |     - |     136 B |
|           LinqFaster |   100 | 1,112.0 ns |  4.53 ns |  4.02 ns |  2.34 |    0.01 | 2.4433 |     - |     - |    5112 B |
|               LinqAF |   100 | 1,354.6 ns | 19.22 ns | 17.98 ns |  2.84 |    0.04 |      - |     - |     - |         - |
|           StructLinq |   100 |   618.3 ns |  1.33 ns |  1.18 ns |  1.30 |    0.00 | 0.0191 |     - |     - |      40 B |
| StructLinq_IFunction |   100 |   495.1 ns |  1.14 ns |  1.07 ns |  1.04 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq |   100 |   824.2 ns |  0.79 ns |  0.70 ns |  1.73 |    0.00 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |   100 |   482.2 ns |  1.16 ns |  1.08 ns |  1.01 |    0.00 |      - |     - |     - |         - |
