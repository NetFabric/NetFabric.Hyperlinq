## List.ValueType.ListValueTypeWhereSelect

### Source
[ListValueTypeWhereSelect.cs](../LinqBenchmarks/List/ValueType/ListValueTypeWhereSelect.cs)

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
|              ForLoop |   100 |   856.0 ns |  1.86 ns |  1.55 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 | 1,046.0 ns |  2.72 ns |  2.55 ns |  1.22 |    0.00 |      - |     - |     - |         - |
|                 Linq |   100 | 1,549.4 ns |  3.92 ns |  3.27 ns |  1.81 |    0.01 | 0.1335 |     - |     - |     280 B |
|           LinqFaster |   100 | 1,652.4 ns | 19.67 ns | 16.42 ns |  1.93 |    0.02 | 2.4433 |     - |     - |    5112 B |
|               LinqAF |   100 | 2,066.0 ns | 12.55 ns | 11.13 ns |  2.41 |    0.01 |      - |     - |     - |         - |
|           StructLinq |   100 | 1,089.7 ns |  4.54 ns |  4.24 ns |  1.27 |    0.01 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction |   100 |   866.0 ns |  3.44 ns |  2.87 ns |  1.01 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq |   100 | 1,150.0 ns |  2.49 ns |  2.08 ns |  1.34 |    0.00 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |   100 |   908.2 ns |  2.52 ns |  2.36 ns |  1.06 |    0.00 |      - |     - |     - |         - |
