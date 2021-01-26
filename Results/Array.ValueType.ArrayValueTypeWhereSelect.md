## Array.ValueType.ArrayValueTypeWhereSelect

### Source
[ArrayValueTypeWhereSelect.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhereSelect.cs)

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
|               Method | Count |       Mean |   Error |  StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |-----------:|--------:|--------:|------:|-------:|------:|------:|----------:|
|              ForLoop |   100 |   839.4 ns | 2.50 ns | 2.34 ns |  1.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 |   906.5 ns | 3.24 ns | 3.03 ns |  1.08 |      - |     - |     - |         - |
|                 Linq |   100 | 1,470.6 ns | 5.51 ns | 4.88 ns |  1.75 | 0.0801 |     - |     - |     168 B |
|           LinqFaster |   100 | 1,545.6 ns | 7.03 ns | 5.87 ns |  1.84 | 2.8896 |     - |     - |    6048 B |
|               LinqAF |   100 | 1,950.7 ns | 9.66 ns | 9.04 ns |  2.32 |      - |     - |     - |         - |
|           StructLinq |   100 | 1,184.7 ns | 4.53 ns | 4.02 ns |  1.41 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction |   100 |   948.8 ns | 3.30 ns | 2.92 ns |  1.13 |      - |     - |     - |         - |
|            Hyperlinq |   100 | 1,285.1 ns | 6.11 ns | 5.42 ns |  1.53 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |   100 |   996.4 ns | 4.45 ns | 4.16 ns |  1.19 |      - |     - |     - |         - |
