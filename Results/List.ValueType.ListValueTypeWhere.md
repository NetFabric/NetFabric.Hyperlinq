## List.ValueType.ListValueTypeWhere

### Source
[ListValueTypeWhere.cs](../LinqBenchmarks/List/ValueType/ListValueTypeWhere.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta36](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta36)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.200-preview.21079.7
  [Host]        : .NET Core 5.0.3 (CoreCLR 5.0.321.7212, CoreFX 5.0.321.7212), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.3 (CoreCLR 5.0.321.7212, CoreFX 5.0.321.7212), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|               Method | Count |       Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |-----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop |   100 |   528.0 ns |  1.59 ns |  1.49 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 | 1,066.0 ns |  2.78 ns |  2.60 ns |  2.02 |    0.01 |      - |     - |     - |         - |
|                 Linq |   100 | 1,319.3 ns | 12.47 ns | 11.05 ns |  2.50 |    0.02 | 0.0648 |     - |     - |     136 B |
|           LinqFaster |   100 | 1,181.2 ns |  6.68 ns |  5.21 ns |  2.24 |    0.01 | 2.4433 |     - |     - |    5112 B |
|               LinqAF |   100 | 1,646.8 ns | 12.57 ns | 11.14 ns |  3.12 |    0.02 |      - |     - |     - |         - |
|           StructLinq |   100 |   630.1 ns |  2.61 ns |  2.44 ns |  1.19 |    0.01 | 0.0191 |     - |     - |      40 B |
| StructLinq_IFunction |   100 |   538.3 ns |  1.83 ns |  1.62 ns |  1.02 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq |   100 |   559.1 ns |  1.82 ns |  1.70 ns |  1.06 |    0.00 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |   100 |   510.2 ns |  1.95 ns |  1.63 ns |  0.97 |    0.00 |      - |     - |     - |         - |
