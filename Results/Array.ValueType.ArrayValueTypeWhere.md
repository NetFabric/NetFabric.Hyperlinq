## Array.ValueType.ArrayValueTypeWhere

### Source
[ArrayValueTypeWhere.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhere.cs)

### References:
- Cistern.ValueLinq: [0.0.11](https://www.nuget.org/packages/Cistern.ValueLinq/0.0.11)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta28](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta28)

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
|              ForLoop |   100 |   432.3 ns | 1.12 ns | 1.05 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 |   490.3 ns | 1.26 ns | 1.18 ns |  1.13 |    0.00 |      - |     - |     - |         - |
|                 Linq |   100 |   929.7 ns | 2.69 ns | 2.24 ns |  2.15 |    0.01 | 0.0381 |     - |     - |      80 B |
|           LinqFaster |   100 | 1,059.7 ns | 9.54 ns | 7.96 ns |  2.45 |    0.02 | 2.8896 |     - |     - |    6048 B |
|               LinqAF |   100 | 1,119.4 ns | 5.84 ns | 5.46 ns |  2.59 |    0.02 |      - |     - |     - |         - |
|           StructLinq |   100 |   656.1 ns | 3.20 ns | 3.00 ns |  1.52 |    0.01 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |   100 |   544.0 ns | 2.02 ns | 1.68 ns |  1.26 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq |   100 |   508.5 ns | 1.27 ns | 0.99 ns |  1.18 |    0.00 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |   100 |   508.5 ns | 2.27 ns | 2.12 ns |  1.18 |    0.00 |      - |     - |     - |         - |
