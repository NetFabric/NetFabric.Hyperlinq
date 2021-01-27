## List.ValueType.ListValueTypeSelect

### Source
[ListValueTypeSelect.cs](../LinqBenchmarks/List/ValueType/ListValueTypeSelect.cs)

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
|                      Method | Count |     Mean |     Error |    StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------- |------ |---------:|----------:|----------:|------:|-------:|------:|------:|----------:|
|                     ForLoop |   100 | 1.602 μs | 0.0039 μs | 0.0037 μs |  1.00 |      - |     - |     - |         - |
|                 ForeachLoop |   100 | 1.791 μs | 0.0055 μs | 0.0049 μs |  1.12 |      - |     - |     - |         - |
|                        Linq |   100 | 2.442 μs | 0.0056 μs | 0.0052 μs |  1.52 | 0.0648 |     - |     - |     136 B |
|                  LinqFaster |   100 | 2.343 μs | 0.0112 μs | 0.0105 μs |  1.46 | 1.9379 |     - |     - |    4056 B |
|                      LinqAF |   100 | 3.187 μs | 0.0104 μs | 0.0097 μs |  1.99 |      - |     - |     - |         - |
|                  StructLinq |   100 | 1.771 μs | 0.0027 μs | 0.0024 μs |  1.11 | 0.0153 |     - |     - |      32 B |
|        StructLinq_IFunction |   100 | 1.554 μs | 0.0044 μs | 0.0039 μs |  0.97 |      - |     - |     - |         - |
|           Hyperlinq_Foreach |   100 | 1.717 μs | 0.0035 μs | 0.0031 μs |  1.07 |      - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction |   100 | 1.589 μs | 0.0043 μs | 0.0040 μs |  0.99 |      - |     - |     - |         - |
|               Hyperlinq_For |   100 | 1.810 μs | 0.0055 μs | 0.0046 μs |  1.13 |      - |     - |     - |         - |
|     Hyperlinq_For_IFunction |   100 | 1.605 μs | 0.0037 μs | 0.0035 μs |  1.00 |      - |     - |     - |         - |
