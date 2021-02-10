## Array.ValueType.ArrayValueTypeWhere

### Source
[ArrayValueTypeWhere.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhere.cs)

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
|              ForLoop |   100 |   442.5 ns |  0.61 ns |  0.54 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 |   472.2 ns |  1.00 ns |  0.78 ns |  1.07 |    0.00 |      - |     - |     - |         - |
|                 Linq |   100 |   911.5 ns |  3.21 ns |  2.51 ns |  2.06 |    0.01 | 0.0381 |     - |     - |      80 B |
|           LinqFaster |   100 |   975.9 ns |  9.64 ns |  8.05 ns |  2.21 |    0.02 | 2.9659 |     - |     - |    6208 B |
|               LinqAF |   100 | 1,089.8 ns | 13.89 ns | 13.00 ns |  2.47 |    0.03 |      - |     - |     - |         - |
|           StructLinq |   100 |   624.6 ns |  1.64 ns |  1.45 ns |  1.41 |    0.00 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |   100 |   532.9 ns |  1.11 ns |  0.99 ns |  1.20 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq |   100 |   544.5 ns |  1.83 ns |  1.53 ns |  1.23 |    0.00 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |   100 |   514.7 ns |  1.26 ns |  1.18 ns |  1.16 |    0.00 |      - |     - |     - |         - |
