## Array.ValueType.ArrayValueTypeWhereSelect

### Source
[ArrayValueTypeWhereSelect.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhereSelect.cs)

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
|               Method | Count |       Mean |    Error |  StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |-----------:|---------:|--------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop |   100 |   842.7 ns |  2.96 ns | 2.62 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 |   913.0 ns |  1.47 ns | 1.38 ns |  1.08 |    0.00 |      - |     - |     - |         - |
|                 Linq |   100 | 1,460.8 ns |  5.77 ns | 5.39 ns |  1.73 |    0.01 | 0.0801 |     - |     - |     168 B |
|           LinqFaster |   100 | 1,552.1 ns |  9.05 ns | 8.47 ns |  1.84 |    0.01 | 2.8896 |     - |     - |    6048 B |
|               LinqAF |   100 | 1,965.4 ns | 10.70 ns | 8.94 ns |  2.33 |    0.02 |      - |     - |     - |         - |
|           StructLinq |   100 | 1,228.1 ns |  7.11 ns | 6.30 ns |  1.46 |    0.00 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction |   100 |   952.7 ns |  2.62 ns | 2.32 ns |  1.13 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq |   100 | 1,288.8 ns |  5.31 ns | 4.71 ns |  1.53 |    0.01 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |   100 | 1,013.3 ns |  5.06 ns | 4.73 ns |  1.20 |    0.01 |      - |     - |     - |         - |
