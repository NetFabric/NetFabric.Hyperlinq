## List.ValueType.ListValueTypeWhereSelect

### Source
[ListValueTypeWhereSelect.cs](../LinqBenchmarks/List/ValueType/ListValueTypeWhereSelect.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta33](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta33)

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
|              ForLoop |   100 |   870.6 ns |  1.69 ns |  1.41 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 | 1,036.3 ns |  2.89 ns |  2.56 ns |  1.19 |    0.00 |      - |     - |     - |         - |
|                 Linq |   100 | 1,569.4 ns |  2.90 ns |  2.57 ns |  1.80 |    0.00 | 0.1335 |     - |     - |     280 B |
|           LinqFaster |   100 | 1,647.4 ns | 17.46 ns | 16.33 ns |  1.89 |    0.02 | 2.4433 |     - |     - |    5112 B |
|               LinqAF |   100 | 2,132.3 ns | 31.36 ns | 27.80 ns |  2.45 |    0.03 |      - |     - |     - |         - |
|           StructLinq |   100 | 1,079.4 ns |  1.23 ns |  1.03 ns |  1.24 |    0.00 | 0.0343 |     - |     - |      72 B |
| StructLinq_IFunction |   100 |   886.3 ns |  2.07 ns |  1.94 ns |  1.02 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq |   100 | 1,054.4 ns |  3.10 ns |  2.90 ns |  1.21 |    0.00 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |   100 |   929.6 ns |  1.53 ns |  1.36 ns |  1.07 |    0.00 |      - |     - |     - |         - |
