## Array.ValueType.ArrayValueTypeWhere

### Source
[ArrayValueTypeWhere.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhere.cs)

### References:
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
|               Method | Count |       Mean |   Error |  StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |-----------:|--------:|--------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop |   100 |   443.6 ns | 1.67 ns | 1.48 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 |   486.9 ns | 2.00 ns | 1.78 ns |  1.10 |    0.00 |      - |     - |     - |         - |
|                 Linq |   100 |   919.4 ns | 3.69 ns | 3.46 ns |  2.07 |    0.01 | 0.0381 |     - |     - |      80 B |
|           LinqFaster |   100 | 1,059.5 ns | 9.83 ns | 9.19 ns |  2.39 |    0.02 | 2.8896 |     - |     - |    6048 B |
|               LinqAF |   100 | 1,116.0 ns | 6.77 ns | 6.00 ns |  2.52 |    0.01 |      - |     - |     - |         - |
|           StructLinq |   100 |   660.9 ns | 2.87 ns | 2.40 ns |  1.49 |    0.01 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |   100 |   534.6 ns | 2.10 ns | 1.75 ns |  1.20 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq |   100 |   644.6 ns | 1.85 ns | 1.55 ns |  1.45 |    0.00 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |   100 |   552.2 ns | 2.34 ns | 2.19 ns |  1.24 |    0.01 |      - |     - |     - |         - |
