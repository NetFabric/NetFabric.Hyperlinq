## Array.ValueType.ArrayValueTypeWhere

### Source
[ArrayValueTypeWhere.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhere.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta29](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta29)

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
|              ForLoop |   100 |   409.1 ns |  0.86 ns |  0.72 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 |   460.9 ns |  0.37 ns |  0.31 ns |  1.13 |    0.00 |      - |     - |     - |         - |
|                 Linq |   100 |   845.2 ns |  3.93 ns |  3.48 ns |  2.07 |    0.01 | 0.0381 |     - |     - |      80 B |
|           LinqFaster |   100 |   923.4 ns |  7.77 ns |  6.89 ns |  2.26 |    0.02 | 2.8896 |     - |     - |    6048 B |
|               LinqAF |   100 | 1,014.4 ns | 12.00 ns | 11.23 ns |  2.48 |    0.03 |      - |     - |     - |         - |
|           StructLinq |   100 |   576.3 ns |  2.96 ns |  2.47 ns |  1.41 |    0.01 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |   100 |   487.9 ns |  0.87 ns |  0.77 ns |  1.19 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq |   100 |   527.9 ns |  0.77 ns |  0.64 ns |  1.29 |    0.00 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |   100 |   480.6 ns |  0.95 ns |  0.84 ns |  1.18 |    0.00 |      - |     - |     - |         - |
