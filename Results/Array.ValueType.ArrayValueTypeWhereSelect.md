## Array.ValueType.ArrayValueTypeWhereSelect

### Source
[ArrayValueTypeWhereSelect.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhereSelect.cs)

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
|               Method | Count |       Mean |    Error |  StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |-----------:|---------:|--------:|------:|-------:|------:|------:|----------:|
|              ForLoop |   100 |   774.4 ns |  0.93 ns | 0.83 ns |  1.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 |   838.1 ns |  2.00 ns | 1.67 ns |  1.08 |      - |     - |     - |         - |
|                 Linq |   100 | 1,342.5 ns |  2.73 ns | 2.28 ns |  1.73 | 0.0801 |     - |     - |     168 B |
|           LinqFaster |   100 | 1,356.1 ns |  7.73 ns | 6.85 ns |  1.75 | 2.8896 |     - |     - |    6048 B |
|               LinqAF |   100 | 1,797.6 ns | 10.87 ns | 9.64 ns |  2.32 |      - |     - |     - |         - |
|           StructLinq |   100 | 1,087.4 ns |  3.68 ns | 3.26 ns |  1.40 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction |   100 |   879.3 ns |  0.86 ns | 0.72 ns |  1.14 |      - |     - |     - |         - |
|            Hyperlinq |   100 | 1,166.4 ns |  3.64 ns | 3.04 ns |  1.51 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |   100 |   930.1 ns |  1.66 ns | 1.56 ns |  1.20 |      - |     - |     - |         - |
