## Array.ValueType.ArrayValueTypeSkipTakeSelect

### Source
[ArrayValueTypeSkipTakeSelect.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeSkipTakeSelect.cs)

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
|                      Method | Skip | Count |     Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------- |----- |------ |---------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|                     ForLoop | 1000 |   100 | 1.616 μs | 0.0034 μs | 0.0030 μs |  1.00 |    0.00 |      - |     - |     - |         - |
|                 ForeachLoop | 1000 |   100 | 4.453 μs | 0.0263 μs | 0.0219 μs |  2.76 |    0.02 | 0.0153 |     - |     - |      32 B |
|                        Linq | 1000 |   100 | 2.771 μs | 0.0125 μs | 0.0111 μs |  1.72 |    0.01 | 0.1183 |     - |     - |     248 B |
|                  LinqFaster | 1000 |   100 | 2.812 μs | 0.0143 μs | 0.0127 μs |  1.74 |    0.01 | 5.7678 |     - |     - |   12072 B |
|                      LinqAF | 1000 |   100 | 7.104 μs | 0.0219 μs | 0.0194 μs |  4.40 |    0.01 |      - |     - |     - |         - |
|                  StructLinq | 1000 |   100 | 3.355 μs | 0.0118 μs | 0.0110 μs |  2.08 |    0.01 | 0.0458 |     - |     - |      96 B |
|        StructLinq_IFunction | 1000 |   100 | 3.125 μs | 0.0110 μs | 0.0103 μs |  1.93 |    0.01 |      - |     - |     - |         - |
|           Hyperlinq_Foreach | 1000 |   100 | 1.942 μs | 0.0101 μs | 0.0095 μs |  1.20 |    0.01 |      - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction | 1000 |   100 | 1.751 μs | 0.0049 μs | 0.0043 μs |  1.08 |    0.00 |      - |     - |     - |         - |
|               Hyperlinq_For | 1000 |   100 | 1.996 μs | 0.0113 μs | 0.0106 μs |  1.24 |    0.01 |      - |     - |     - |         - |
|     Hyperlinq_For_IFunction | 1000 |   100 | 1.742 μs | 0.0040 μs | 0.0035 μs |  1.08 |    0.00 |      - |     - |     - |         - |
