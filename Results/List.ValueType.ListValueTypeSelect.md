## List.ValueType.ListValueTypeSelect

### Source
[ListValueTypeSelect.cs](../LinqBenchmarks/List/ValueType/ListValueTypeSelect.cs)

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
|                      Method | Count |     Mean |     Error |    StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------- |------ |---------:|----------:|----------:|------:|-------:|------:|------:|----------:|
|                     ForLoop |   100 | 1.740 μs | 0.0063 μs | 0.0056 μs |  1.00 |      - |     - |     - |         - |
|                 ForeachLoop |   100 | 1.952 μs | 0.0095 μs | 0.0084 μs |  1.12 |      - |     - |     - |         - |
|                        Linq |   100 | 2.677 μs | 0.0058 μs | 0.0054 μs |  1.54 | 0.0648 |     - |     - |     136 B |
|                  LinqFaster |   100 | 3.302 μs | 0.0087 μs | 0.0081 μs |  1.90 | 1.9379 |     - |     - |    4056 B |
|                      LinqAF |   100 | 3.461 μs | 0.0063 μs | 0.0056 μs |  1.99 |      - |     - |     - |         - |
|                  StructLinq |   100 | 1.984 μs | 0.0084 μs | 0.0078 μs |  1.14 | 0.0191 |     - |     - |      40 B |
|        StructLinq_IFunction |   100 | 1.691 μs | 0.0042 μs | 0.0037 μs |  0.97 |      - |     - |     - |         - |
|           Hyperlinq_Foreach |   100 | 1.872 μs | 0.0077 μs | 0.0072 μs |  1.08 |      - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction |   100 | 1.736 μs | 0.0029 μs | 0.0024 μs |  1.00 |      - |     - |     - |         - |
|               Hyperlinq_For |   100 | 1.979 μs | 0.0090 μs | 0.0084 μs |  1.14 |      - |     - |     - |         - |
|     Hyperlinq_For_IFunction |   100 | 1.752 μs | 0.0048 μs | 0.0045 μs |  1.01 |      - |     - |     - |         - |
