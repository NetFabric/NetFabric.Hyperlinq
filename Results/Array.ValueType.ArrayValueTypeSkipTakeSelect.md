## Array.ValueType.ArrayValueTypeSkipTakeSelect

### Source
[ArrayValueTypeSkipTakeSelect.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeSkipTakeSelect.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta34](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta34)

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
|                     ForLoop | 1000 |   100 | 1.510 μs | 0.0026 μs | 0.0023 μs |  1.00 |    0.00 |      - |     - |     - |         - |
|                 ForeachLoop | 1000 |   100 | 4.074 μs | 0.0091 μs | 0.0076 μs |  2.70 |    0.01 | 0.0153 |     - |     - |      32 B |
|                        Linq | 1000 |   100 | 2.533 μs | 0.0052 μs | 0.0049 μs |  1.68 |    0.00 | 0.1183 |     - |     - |     248 B |
|                  LinqFaster | 1000 |   100 | 2.493 μs | 0.0101 μs | 0.0089 μs |  1.65 |    0.01 | 5.7678 |     - |     - |   12072 B |
|                      LinqAF | 1000 |   100 | 6.709 μs | 0.0785 μs | 0.0696 μs |  4.44 |    0.05 |      - |     - |     - |         - |
|                  StructLinq | 1000 |   100 | 1.817 μs | 0.0076 μs | 0.0071 μs |  1.20 |    0.00 | 0.0458 |     - |     - |      96 B |
|        StructLinq_IFunction | 1000 |   100 | 1.553 μs | 0.0030 μs | 0.0028 μs |  1.03 |    0.00 |      - |     - |     - |         - |
|           Hyperlinq_Foreach | 1000 |   100 | 1.680 μs | 0.0032 μs | 0.0028 μs |  1.11 |    0.00 |      - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction | 1000 |   100 | 1.617 μs | 0.0035 μs | 0.0032 μs |  1.07 |    0.00 |      - |     - |     - |         - |
|               Hyperlinq_For | 1000 |   100 | 1.692 μs | 0.0036 μs | 0.0033 μs |  1.12 |    0.00 |      - |     - |     - |         - |
|     Hyperlinq_For_IFunction | 1000 |   100 | 1.642 μs | 0.0031 μs | 0.0026 μs |  1.09 |    0.00 |      - |     - |     - |         - |
