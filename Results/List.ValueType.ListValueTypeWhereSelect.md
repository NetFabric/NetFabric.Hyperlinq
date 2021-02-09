## List.ValueType.ListValueTypeWhereSelect

### Source
[ListValueTypeWhereSelect.cs](../LinqBenchmarks/List/ValueType/ListValueTypeWhereSelect.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta34](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta34)

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
|              ForLoop |   100 |   933.5 ns |  1.78 ns |  1.58 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 | 1,093.0 ns |  2.91 ns |  2.58 ns |  1.17 |    0.00 |      - |     - |     - |         - |
|                 Linq |   100 | 1,772.5 ns |  4.46 ns |  4.17 ns |  1.90 |    0.00 | 0.1335 |     - |     - |     280 B |
|           LinqFaster |   100 | 1,764.0 ns |  8.03 ns |  7.12 ns |  1.89 |    0.01 | 2.4433 |     - |     - |    5112 B |
|               LinqAF |   100 | 2,423.6 ns | 18.68 ns | 17.48 ns |  2.59 |    0.02 |      - |     - |     - |         - |
|           StructLinq |   100 | 1,163.0 ns |  2.43 ns |  2.27 ns |  1.25 |    0.00 | 0.0343 |     - |     - |      72 B |
| StructLinq_IFunction |   100 |   946.7 ns |  1.99 ns |  1.66 ns |  1.01 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq |   100 | 1,109.9 ns |  1.99 ns |  1.76 ns |  1.19 |    0.00 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |   100 |   982.7 ns |  1.83 ns |  1.62 ns |  1.05 |    0.00 |      - |     - |     - |         - |
