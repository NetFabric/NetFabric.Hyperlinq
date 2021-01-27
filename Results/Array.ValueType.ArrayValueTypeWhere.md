## Array.ValueType.ArrayValueTypeWhere

### Source
[ArrayValueTypeWhere.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhere.cs)

### References:
- Cistern.ValueLinq: [0.0.11](https://www.nuget.org/packages/Cistern.ValueLinq/0.0.11)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.19.2](https://www.nuget.org/packages/StructLinq.BCL/0.19.2)
- NetFabric.Hyperlinq: [3.0.0-beta27](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta27)

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
|              ForLoop |   100 |   396.5 ns |  0.60 ns |  0.53 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 |   448.7 ns |  0.67 ns |  0.63 ns |  1.13 |    0.00 |      - |     - |     - |         - |
|                 Linq |   100 |   839.1 ns |  2.17 ns |  2.03 ns |  2.12 |    0.00 | 0.0381 |     - |     - |      80 B |
|           LinqFaster |   100 |   934.5 ns |  7.53 ns |  6.28 ns |  2.36 |    0.02 | 2.8896 |     - |     - |    6048 B |
|               LinqAF |   100 | 1,034.9 ns | 20.01 ns | 19.65 ns |  2.61 |    0.05 |      - |     - |     - |         - |
|           StructLinq |   100 |   596.9 ns |  1.25 ns |  1.17 ns |  1.51 |    0.00 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |   100 |   494.8 ns |  1.21 ns |  1.07 ns |  1.25 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq |   100 |   592.5 ns |  1.35 ns |  1.20 ns |  1.49 |    0.00 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |   100 |   508.2 ns |  1.51 ns |  1.34 ns |  1.28 |    0.00 |      - |     - |     - |         - |
