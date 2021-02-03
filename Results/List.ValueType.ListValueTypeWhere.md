## List.ValueType.ListValueTypeWhere

### Source
[ListValueTypeWhere.cs](../LinqBenchmarks/List/ValueType/ListValueTypeWhere.cs)

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
|               Method | Count |       Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |-----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop |   100 |   475.0 ns |  1.26 ns |  1.11 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 |   666.8 ns |  1.60 ns |  1.34 ns |  1.40 |    0.00 |      - |     - |     - |         - |
|                 Linq |   100 | 1,102.4 ns | 13.66 ns | 12.11 ns |  2.32 |    0.02 | 0.0648 |     - |     - |     136 B |
|           LinqFaster |   100 | 1,090.9 ns |  7.16 ns |  5.59 ns |  2.30 |    0.01 | 2.4433 |     - |     - |    5112 B |
|               LinqAF |   100 | 1,355.6 ns | 26.35 ns | 24.65 ns |  2.86 |    0.05 |      - |     - |     - |         - |
|           StructLinq |   100 |   578.4 ns |  1.48 ns |  1.31 ns |  1.22 |    0.00 | 0.0191 |     - |     - |      40 B |
| StructLinq_IFunction |   100 |   494.9 ns |  1.09 ns |  0.97 ns |  1.04 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq |   100 |   525.1 ns |  0.86 ns |  0.76 ns |  1.11 |    0.00 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |   100 |   481.1 ns |  1.54 ns |  1.37 ns |  1.01 |    0.00 |      - |     - |     - |         - |
