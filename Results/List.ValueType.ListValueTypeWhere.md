## List.ValueType.ListValueTypeWhere

### Source
[ListValueTypeWhere.cs](../LinqBenchmarks/List/ValueType/ListValueTypeWhere.cs)

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
|              ForLoop |   100 |   485.4 ns |  1.45 ns |  1.29 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 |   680.8 ns |  1.52 ns |  1.35 ns |  1.40 |    0.01 |      - |     - |     - |         - |
|                 Linq |   100 | 1,108.9 ns | 10.66 ns |  9.45 ns |  2.28 |    0.02 | 0.0648 |     - |     - |     136 B |
|           LinqFaster |   100 | 1,162.9 ns |  3.77 ns |  3.15 ns |  2.40 |    0.01 | 2.4433 |     - |     - |    5112 B |
|               LinqAF |   100 | 1,427.8 ns | 25.71 ns | 24.05 ns |  2.94 |    0.05 |      - |     - |     - |         - |
|           StructLinq |   100 |   579.1 ns |  0.93 ns |  0.78 ns |  1.19 |    0.00 | 0.0191 |     - |     - |      40 B |
| StructLinq_IFunction |   100 |   494.6 ns |  1.46 ns |  1.30 ns |  1.02 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq |   100 |   512.6 ns |  1.35 ns |  1.19 ns |  1.06 |    0.00 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |   100 |   480.5 ns |  1.06 ns |  0.94 ns |  0.99 |    0.00 |      - |     - |     - |         - |
