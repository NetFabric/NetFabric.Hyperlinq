## Array.ValueType.ArrayValueTypeWhereSelect

### Source
[ArrayValueTypeWhereSelect.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhereSelect.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta30](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta30)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.200-preview.20614.14
  [Host]        : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|               Method | Count |       Mean |   Error |  StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |-----------:|--------:|--------:|------:|-------:|------:|------:|----------:|
|              ForLoop |   100 |   771.4 ns | 0.89 ns | 0.83 ns |  1.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 |   827.8 ns | 1.51 ns | 1.42 ns |  1.07 |      - |     - |     - |         - |
|                 Linq |   100 | 1,344.5 ns | 4.96 ns | 4.40 ns |  1.74 | 0.0801 |     - |     - |     168 B |
|           LinqFaster |   100 | 1,373.1 ns | 9.20 ns | 8.61 ns |  1.78 | 2.8896 |     - |     - |    6048 B |
|               LinqAF |   100 | 1,758.9 ns | 9.58 ns | 8.50 ns |  2.28 |      - |     - |     - |         - |
|           StructLinq |   100 | 1,119.0 ns | 2.66 ns | 2.49 ns |  1.45 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction |   100 |   874.4 ns | 0.87 ns | 0.73 ns |  1.13 |      - |     - |     - |         - |
|            Hyperlinq |   100 | 1,040.6 ns | 1.93 ns | 1.61 ns |  1.35 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |   100 |   921.2 ns | 1.30 ns | 1.15 ns |  1.19 |      - |     - |     - |         - |
