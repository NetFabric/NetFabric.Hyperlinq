## Array.ValueType.ArrayValueTypeSkipTakeSelect

### Source
[ArrayValueTypeSkipTakeSelect.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeSkipTakeSelect.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta31](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta31)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.200-preview.20614.14
  [Host]        : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|                      Method | Skip | Count |     Mean |     Error |    StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------- |----- |------ |---------:|----------:|----------:|------:|-------:|------:|------:|----------:|
|                     ForLoop | 1000 |   100 | 1.508 μs | 0.0018 μs | 0.0014 μs |  1.00 |      - |     - |     - |         - |
|                 ForeachLoop | 1000 |   100 | 3.762 μs | 0.0070 μs | 0.0062 μs |  2.50 | 0.0153 |     - |     - |      32 B |
|                        Linq | 1000 |   100 | 2.552 μs | 0.0080 μs | 0.0071 μs |  1.69 | 0.1183 |     - |     - |     248 B |
|                  LinqFaster | 1000 |   100 | 2.464 μs | 0.0097 μs | 0.0091 μs |  1.64 | 5.7678 |     - |     - |   12072 B |
|                      LinqAF | 1000 |   100 | 7.405 μs | 0.0137 μs | 0.0122 μs |  4.91 |      - |     - |     - |         - |
|                  StructLinq | 1000 |   100 | 1.856 μs | 0.0036 μs | 0.0034 μs |  1.23 | 0.0458 |     - |     - |      96 B |
|        StructLinq_IFunction | 1000 |   100 | 1.547 μs | 0.0025 μs | 0.0022 μs |  1.03 |      - |     - |     - |         - |
|           Hyperlinq_Foreach | 1000 |   100 | 1.768 μs | 0.0020 μs | 0.0017 μs |  1.17 |      - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction | 1000 |   100 | 1.538 μs | 0.0022 μs | 0.0021 μs |  1.02 |      - |     - |     - |         - |
|               Hyperlinq_For | 1000 |   100 | 1.693 μs | 0.0036 μs | 0.0034 μs |  1.12 |      - |     - |     - |         - |
|     Hyperlinq_For_IFunction | 1000 |   100 | 1.540 μs | 0.0020 μs | 0.0019 μs |  1.02 |      - |     - |     - |         - |
