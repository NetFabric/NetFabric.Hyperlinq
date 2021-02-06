## Array.ValueType.ArrayValueTypeSkipTakeSelect

### Source
[ArrayValueTypeSkipTakeSelect.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeSkipTakeSelect.cs)

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
|                     ForLoop | 1000 |   100 | 1.530 μs | 0.0034 μs | 0.0030 μs |  1.00 |    0.00 |      - |     - |     - |         - |
|                 ForeachLoop | 1000 |   100 | 3.827 μs | 0.0067 μs | 0.0056 μs |  2.50 |    0.00 | 0.0153 |     - |     - |      32 B |
|                        Linq | 1000 |   100 | 2.530 μs | 0.0078 μs | 0.0065 μs |  1.65 |    0.01 | 0.1183 |     - |     - |     248 B |
|                  LinqFaster | 1000 |   100 | 2.514 μs | 0.0335 μs | 0.0279 μs |  1.64 |    0.02 | 5.7678 |     - |     - |   12072 B |
|                      LinqAF | 1000 |   100 | 6.424 μs | 0.0627 μs | 0.0556 μs |  4.20 |    0.04 |      - |     - |     - |         - |
|                  StructLinq | 1000 |   100 | 1.816 μs | 0.0025 μs | 0.0021 μs |  1.19 |    0.00 | 0.0458 |     - |     - |      96 B |
|        StructLinq_IFunction | 1000 |   100 | 1.553 μs | 0.0047 μs | 0.0037 μs |  1.01 |    0.00 |      - |     - |     - |         - |
|           Hyperlinq_Foreach | 1000 |   100 | 1.650 μs | 0.0022 μs | 0.0019 μs |  1.08 |    0.00 |      - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction | 1000 |   100 | 1.600 μs | 0.0042 μs | 0.0037 μs |  1.05 |    0.00 |      - |     - |     - |         - |
|               Hyperlinq_For | 1000 |   100 | 1.675 μs | 0.0042 μs | 0.0037 μs |  1.09 |    0.00 |      - |     - |     - |         - |
|     Hyperlinq_For_IFunction | 1000 |   100 | 1.638 μs | 0.0033 μs | 0.0028 μs |  1.07 |    0.00 |      - |     - |     - |         - |
