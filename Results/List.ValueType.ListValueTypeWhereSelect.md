## List.ValueType.ListValueTypeWhereSelect

### Source
[ListValueTypeWhereSelect.cs](../LinqBenchmarks/List/ValueType/ListValueTypeWhereSelect.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta35](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta35)

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
|              ForLoop |   100 |   908.4 ns |  2.63 ns |  2.19 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 | 1,098.5 ns |  2.48 ns |  2.32 ns |  1.21 |    0.00 |      - |     - |     - |         - |
|                 Linq |   100 | 1,762.3 ns |  4.44 ns |  3.71 ns |  1.94 |    0.01 | 0.1335 |     - |     - |     280 B |
|           LinqFaster |   100 | 1,728.6 ns | 10.16 ns |  9.01 ns |  1.90 |    0.01 | 2.4433 |     - |     - |    5112 B |
|               LinqAF |   100 | 2,441.3 ns | 17.85 ns | 16.70 ns |  2.69 |    0.02 |      - |     - |     - |         - |
|           StructLinq |   100 | 1,173.2 ns |  4.62 ns |  4.09 ns |  1.29 |    0.01 | 0.0343 |     - |     - |      72 B |
| StructLinq_IFunction |   100 |   947.6 ns |  2.27 ns |  2.01 ns |  1.04 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq |   100 | 1,112.7 ns |  3.75 ns |  3.33 ns |  1.23 |    0.01 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |   100 |   985.0 ns |  2.45 ns |  2.30 ns |  1.08 |    0.00 |      - |     - |     - |         - |
