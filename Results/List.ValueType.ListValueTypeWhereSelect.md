## List.ValueType.ListValueTypeWhereSelect

### Source
[ListValueTypeWhereSelect.cs](../LinqBenchmarks/List/ValueType/ListValueTypeWhereSelect.cs)

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
|              ForLoop |   100 |   862.7 ns |  1.43 ns |  1.12 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 | 1,031.0 ns |  1.84 ns |  1.44 ns |  1.20 |    0.00 |      - |     - |     - |         - |
|                 Linq |   100 | 1,576.7 ns |  6.28 ns |  5.87 ns |  1.83 |    0.01 | 0.1335 |     - |     - |     280 B |
|           LinqFaster |   100 | 1,657.6 ns | 14.75 ns | 13.80 ns |  1.92 |    0.02 | 2.4433 |     - |     - |    5112 B |
|               LinqAF |   100 | 2,107.3 ns | 24.83 ns | 23.23 ns |  2.44 |    0.03 |      - |     - |     - |         - |
|           StructLinq |   100 | 1,120.6 ns |  2.46 ns |  2.18 ns |  1.30 |    0.00 | 0.0343 |     - |     - |      72 B |
| StructLinq_IFunction |   100 |   882.1 ns |  1.22 ns |  1.08 ns |  1.02 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq |   100 | 1,197.5 ns |  1.73 ns |  1.62 ns |  1.39 |    0.00 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |   100 |   930.3 ns |  1.28 ns |  1.20 ns |  1.08 |    0.00 |      - |     - |     - |         - |
