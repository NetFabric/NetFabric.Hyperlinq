## List.ValueType.ListValueTypeWhere

### Source
[ListValueTypeWhere.cs](../LinqBenchmarks/List/ValueType/ListValueTypeWhere.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta30](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta30)

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
|              ForLoop |   100 |   487.1 ns |  0.91 ns |  0.81 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 |   680.3 ns |  2.10 ns |  1.76 ns |  1.40 |    0.00 |      - |     - |     - |         - |
|                 Linq |   100 | 1,109.4 ns |  9.69 ns |  9.06 ns |  2.28 |    0.02 | 0.0648 |     - |     - |     136 B |
|           LinqFaster |   100 | 1,105.5 ns |  6.56 ns |  5.82 ns |  2.27 |    0.01 | 2.4433 |     - |     - |    5112 B |
|               LinqAF |   100 | 1,410.4 ns | 19.63 ns | 18.36 ns |  2.90 |    0.04 |      - |     - |     - |         - |
|           StructLinq |   100 |   578.4 ns |  1.32 ns |  1.17 ns |  1.19 |    0.00 | 0.0191 |     - |     - |      40 B |
| StructLinq_IFunction |   100 |   493.4 ns |  0.80 ns |  0.67 ns |  1.01 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq |   100 |   562.3 ns |  1.07 ns |  0.90 ns |  1.15 |    0.00 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |   100 |   482.9 ns |  0.98 ns |  0.82 ns |  0.99 |    0.00 |      - |     - |     - |         - |
