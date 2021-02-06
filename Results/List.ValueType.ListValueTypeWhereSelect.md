## List.ValueType.ListValueTypeWhereSelect

### Source
[ListValueTypeWhereSelect.cs](../LinqBenchmarks/List/ValueType/ListValueTypeWhereSelect.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta32](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta32)

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
|              ForLoop |   100 |   873.6 ns |  2.07 ns |  1.83 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 | 1,037.2 ns |  3.82 ns |  2.98 ns |  1.19 |    0.00 |      - |     - |     - |         - |
|                 Linq |   100 | 1,594.5 ns |  5.55 ns |  5.19 ns |  1.83 |    0.01 | 0.1335 |     - |     - |     280 B |
|           LinqFaster |   100 | 1,650.4 ns | 12.83 ns | 11.38 ns |  1.89 |    0.01 | 2.4433 |     - |     - |    5112 B |
|               LinqAF |   100 | 2,128.6 ns | 30.16 ns | 28.22 ns |  2.44 |    0.03 |      - |     - |     - |         - |
|           StructLinq |   100 | 1,130.4 ns |  4.41 ns |  4.12 ns |  1.29 |    0.01 | 0.0343 |     - |     - |      72 B |
| StructLinq_IFunction |   100 |   889.2 ns |  1.55 ns |  1.37 ns |  1.02 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq |   100 | 1,044.3 ns |  3.69 ns |  3.45 ns |  1.20 |    0.01 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |   100 |   918.6 ns |  2.41 ns |  2.01 ns |  1.05 |    0.00 |      - |     - |     - |         - |
