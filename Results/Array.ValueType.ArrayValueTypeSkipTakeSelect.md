## Array.ValueType.ArrayValueTypeSkipTakeSelect

### Source
[ArrayValueTypeSkipTakeSelect.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeSkipTakeSelect.cs)

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
|                      Method | Skip | Count |     Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------- |----- |------ |---------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|                     ForLoop | 1000 |   100 | 1.661 μs | 0.0025 μs | 0.0023 μs |  1.00 |    0.00 |      - |     - |     - |         - |
|                 ForeachLoop | 1000 |   100 | 4.366 μs | 0.0440 μs | 0.0412 μs |  2.63 |    0.02 | 0.0153 |     - |     - |      32 B |
|                        Linq | 1000 |   100 | 2.787 μs | 0.0057 μs | 0.0048 μs |  1.68 |    0.00 | 0.1183 |     - |     - |     248 B |
|                  LinqFaster | 1000 |   100 | 2.780 μs | 0.0163 μs | 0.0144 μs |  1.67 |    0.01 | 5.7678 |     - |     - |   12072 B |
|                      LinqAF | 1000 |   100 | 8.249 μs | 0.0730 μs | 0.0647 μs |  4.97 |    0.04 |      - |     - |     - |         - |
|                  StructLinq | 1000 |   100 | 1.977 μs | 0.0055 μs | 0.0052 μs |  1.19 |    0.00 | 0.0458 |     - |     - |      96 B |
|        StructLinq_IFunction | 1000 |   100 | 1.688 μs | 0.0040 μs | 0.0037 μs |  1.02 |    0.00 |      - |     - |     - |         - |
|           Hyperlinq_Foreach | 1000 |   100 | 1.959 μs | 0.0115 μs | 0.0102 μs |  1.18 |    0.01 |      - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction | 1000 |   100 | 1.745 μs | 0.0058 μs | 0.0055 μs |  1.05 |    0.00 |      - |     - |     - |         - |
|               Hyperlinq_For | 1000 |   100 | 1.991 μs | 0.0093 μs | 0.0087 μs |  1.20 |    0.01 |      - |     - |     - |         - |
|     Hyperlinq_For_IFunction | 1000 |   100 | 1.782 μs | 0.0057 μs | 0.0050 μs |  1.07 |    0.00 |      - |     - |     - |         - |
