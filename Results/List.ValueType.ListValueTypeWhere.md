## List.ValueType.ListValueTypeWhere

### Source
[ListValueTypeWhere.cs](../LinqBenchmarks/List/ValueType/ListValueTypeWhere.cs)

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
|               Method | Count |       Mean |   Error |  StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |-----------:|--------:|--------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop |   100 |   490.7 ns | 1.78 ns | 1.48 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 |   672.8 ns | 1.86 ns | 1.65 ns |  1.37 |    0.01 |      - |     - |     - |         - |
|                 Linq |   100 | 1,105.5 ns | 9.30 ns | 8.24 ns |  2.25 |    0.02 | 0.0648 |     - |     - |     136 B |
|           LinqFaster |   100 | 1,102.8 ns | 8.52 ns | 7.55 ns |  2.25 |    0.02 | 2.4433 |     - |     - |    5112 B |
|               LinqAF |   100 | 1,369.8 ns | 9.54 ns | 8.45 ns |  2.79 |    0.02 |      - |     - |     - |         - |
|           StructLinq |   100 |   581.0 ns | 1.63 ns | 1.44 ns |  1.18 |    0.00 | 0.0191 |     - |     - |      40 B |
| StructLinq_IFunction |   100 |   498.1 ns | 1.41 ns | 1.31 ns |  1.02 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq |   100 |   516.5 ns | 1.60 ns | 1.50 ns |  1.05 |    0.01 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |   100 |   481.7 ns | 3.97 ns | 3.52 ns |  0.98 |    0.01 |      - |     - |     - |         - |
