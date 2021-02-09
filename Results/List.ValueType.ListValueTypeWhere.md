## List.ValueType.ListValueTypeWhere

### Source
[ListValueTypeWhere.cs](../LinqBenchmarks/List/ValueType/ListValueTypeWhere.cs)

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
|               Method | Count |       Mean |   Error |  StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |-----------:|--------:|--------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop |   100 |   513.9 ns | 1.09 ns | 0.97 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 |   716.2 ns | 2.43 ns | 2.03 ns |  1.39 |    0.00 |      - |     - |     - |         - |
|                 Linq |   100 | 1,250.8 ns | 7.52 ns | 6.66 ns |  2.43 |    0.01 | 0.0648 |     - |     - |     136 B |
|           LinqFaster |   100 | 1,133.9 ns | 5.96 ns | 5.57 ns |  2.21 |    0.01 | 2.4433 |     - |     - |    5112 B |
|               LinqAF |   100 | 1,585.5 ns | 8.58 ns | 7.60 ns |  3.09 |    0.02 |      - |     - |     - |         - |
|           StructLinq |   100 |   619.5 ns | 1.91 ns | 1.69 ns |  1.21 |    0.00 | 0.0191 |     - |     - |      40 B |
| StructLinq_IFunction |   100 |   527.2 ns | 2.59 ns | 2.16 ns |  1.03 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq |   100 |   544.3 ns | 2.13 ns | 1.89 ns |  1.06 |    0.00 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |   100 |   515.2 ns | 1.16 ns | 1.08 ns |  1.00 |    0.00 |      - |     - |     - |         - |
