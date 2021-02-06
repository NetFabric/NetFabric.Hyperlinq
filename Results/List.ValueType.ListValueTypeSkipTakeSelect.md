## List.ValueType.ListValueTypeSkipTakeSelect

### Source
[ListValueTypeSkipTakeSelect.cs](../LinqBenchmarks/List/ValueType/ListValueTypeSkipTakeSelect.cs)

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
|                      Method | Skip | Count |     Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------- |----- |------ |---------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|                     ForLoop | 1000 |   100 | 1.598 μs | 0.0040 μs | 0.0037 μs |  1.00 |    0.00 |      - |     - |     - |         - |
|                 ForeachLoop | 1000 |   100 | 6.748 μs | 0.0272 μs | 0.0227 μs |  4.22 |    0.02 | 0.0305 |     - |     - |      72 B |
|                        Linq | 1000 |   100 | 2.482 μs | 0.0078 μs | 0.0061 μs |  1.55 |    0.00 | 0.1183 |     - |     - |     248 B |
|                  LinqFaster | 1000 |   100 | 3.526 μs | 0.0278 μs | 0.0247 μs |  2.21 |    0.01 | 5.8136 |     - |     - |   12168 B |
|                      LinqAF | 1000 |   100 | 9.644 μs | 0.0644 μs | 0.0571 μs |  6.04 |    0.04 |      - |     - |     - |         - |
|                  StructLinq | 1000 |   100 | 1.868 μs | 0.0055 μs | 0.0049 μs |  1.17 |    0.00 | 0.0572 |     - |     - |     120 B |
|        StructLinq_IFunction | 1000 |   100 | 1.576 μs | 0.0092 μs | 0.0077 μs |  0.99 |    0.01 |      - |     - |     - |         - |
|           Hyperlinq_Foreach | 1000 |   100 | 1.688 μs | 0.0064 μs | 0.0054 μs |  1.06 |    0.00 |      - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction | 1000 |   100 | 1.545 μs | 0.0038 μs | 0.0035 μs |  0.97 |    0.00 |      - |     - |     - |         - |
|               Hyperlinq_For | 1000 |   100 | 1.704 μs | 0.0017 μs | 0.0015 μs |  1.07 |    0.00 |      - |     - |     - |         - |
|     Hyperlinq_For_IFunction | 1000 |   100 | 1.531 μs | 0.0028 μs | 0.0025 μs |  0.96 |    0.00 |      - |     - |     - |         - |
