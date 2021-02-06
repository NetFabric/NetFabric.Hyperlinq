## List.ValueType.ListValueTypeSelect

### Source
[ListValueTypeSelect.cs](../LinqBenchmarks/List/ValueType/ListValueTypeSelect.cs)

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
|                      Method | Count |     Mean |     Error |    StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------- |------ |---------:|----------:|----------:|------:|-------:|------:|------:|----------:|
|                     ForLoop |   100 | 1.608 μs | 0.0036 μs | 0.0032 μs |  1.00 |      - |     - |     - |         - |
|                 ForeachLoop |   100 | 1.795 μs | 0.0037 μs | 0.0032 μs |  1.12 |      - |     - |     - |         - |
|                        Linq |   100 | 2.452 μs | 0.0097 μs | 0.0086 μs |  1.52 | 0.0648 |     - |     - |     136 B |
|                  LinqFaster |   100 | 2.371 μs | 0.0141 μs | 0.0125 μs |  1.47 | 1.9379 |     - |     - |    4056 B |
|                      LinqAF |   100 | 2.928 μs | 0.0124 μs | 0.0116 μs |  1.82 |      - |     - |     - |         - |
|                  StructLinq |   100 | 1.825 μs | 0.0038 μs | 0.0032 μs |  1.13 | 0.0191 |     - |     - |      40 B |
|        StructLinq_IFunction |   100 | 2.035 μs | 0.0138 μs | 0.0115 μs |  1.26 |      - |     - |     - |         - |
|           Hyperlinq_Foreach |   100 | 1.663 μs | 0.0039 μs | 0.0034 μs |  1.03 |      - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction |   100 | 1.549 μs | 0.0031 μs | 0.0026 μs |  0.96 |      - |     - |     - |         - |
|               Hyperlinq_For |   100 | 1.701 μs | 0.0032 μs | 0.0029 μs |  1.06 |      - |     - |     - |         - |
|     Hyperlinq_For_IFunction |   100 | 1.572 μs | 0.0034 μs | 0.0030 μs |  0.98 |      - |     - |     - |         - |
