## Array.ValueType.ArrayValueTypeWhereSelect

### Source
[ArrayValueTypeWhereSelect.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhereSelect.cs)

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
|               Method | Count |       Mean |    Error |   StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |-----------:|---------:|---------:|------:|-------:|------:|------:|----------:|
|              ForLoop |   100 |   775.8 ns |  1.15 ns |  1.02 ns |  1.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 |   835.0 ns |  1.29 ns |  1.08 ns |  1.08 |      - |     - |     - |         - |
|                 Linq |   100 | 1,324.4 ns |  4.10 ns |  3.84 ns |  1.71 | 0.0801 |     - |     - |     168 B |
|           LinqFaster |   100 | 1,366.7 ns |  7.96 ns |  6.65 ns |  1.76 | 2.8896 |     - |     - |    6048 B |
|               LinqAF |   100 | 1,706.7 ns | 11.76 ns | 10.42 ns |  2.20 |      - |     - |     - |         - |
|           StructLinq |   100 | 1,078.0 ns |  3.68 ns |  3.26 ns |  1.39 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction |   100 |   879.4 ns |  1.69 ns |  1.50 ns |  1.13 |      - |     - |     - |         - |
|            Hyperlinq |   100 | 1,053.4 ns |  2.27 ns |  2.01 ns |  1.36 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |   100 |   929.8 ns |  0.99 ns |  0.77 ns |  1.20 |      - |     - |     - |         - |
