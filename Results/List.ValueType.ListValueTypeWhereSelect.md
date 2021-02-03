## List.ValueType.ListValueTypeWhereSelect

### Source
[ListValueTypeWhereSelect.cs](../LinqBenchmarks/List/ValueType/ListValueTypeWhereSelect.cs)

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
|              ForLoop |   100 |   869.3 ns |  1.23 ns |  0.96 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 | 1,043.9 ns |  1.18 ns |  1.05 ns |  1.20 |    0.00 |      - |     - |     - |         - |
|                 Linq |   100 | 1,577.8 ns |  4.58 ns |  4.29 ns |  1.81 |    0.01 | 0.1335 |     - |     - |     280 B |
|           LinqFaster |   100 | 1,683.6 ns | 15.99 ns | 13.36 ns |  1.94 |    0.02 | 2.4433 |     - |     - |    5112 B |
|               LinqAF |   100 | 2,100.2 ns | 23.80 ns | 22.26 ns |  2.41 |    0.02 |      - |     - |     - |         - |
|           StructLinq |   100 | 1,123.2 ns |  1.89 ns |  1.68 ns |  1.29 |    0.00 | 0.0343 |     - |     - |      72 B |
| StructLinq_IFunction |   100 |   879.4 ns |  1.04 ns |  0.92 ns |  1.01 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq |   100 | 1,041.7 ns |  2.83 ns |  2.36 ns |  1.20 |    0.00 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |   100 |   921.4 ns |  1.14 ns |  1.01 ns |  1.06 |    0.00 |      - |     - |     - |         - |
