## List.ValueType.ListValueTypeWhere

### Source
[ListValueTypeWhere.cs](../LinqBenchmarks/List/ValueType/ListValueTypeWhere.cs)

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
|              ForLoop |   100 |   500.4 ns |  0.82 ns |  0.77 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 |   716.0 ns |  2.78 ns |  2.46 ns |  1.43 |    0.00 |      - |     - |     - |         - |
|                 Linq |   100 | 1,254.8 ns |  7.15 ns |  6.34 ns |  2.51 |    0.01 | 0.0648 |     - |     - |     136 B |
|           LinqFaster |   100 | 1,144.6 ns |  5.01 ns |  4.18 ns |  2.29 |    0.01 | 2.4433 |     - |     - |    5112 B |
|               LinqAF |   100 | 1,656.4 ns | 12.18 ns | 11.39 ns |  3.31 |    0.02 |      - |     - |     - |         - |
|           StructLinq |   100 |   615.5 ns |  1.81 ns |  1.69 ns |  1.23 |    0.00 | 0.0191 |     - |     - |      40 B |
| StructLinq_IFunction |   100 |   526.0 ns |  1.16 ns |  1.02 ns |  1.05 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq |   100 |   544.7 ns |  0.76 ns |  0.67 ns |  1.09 |    0.00 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |   100 |   499.2 ns |  1.32 ns |  1.03 ns |  1.00 |    0.00 |      - |     - |     - |         - |
