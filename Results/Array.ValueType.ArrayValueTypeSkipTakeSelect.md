## Array.ValueType.ArrayValueTypeSkipTakeSelect

### Source
[ArrayValueTypeSkipTakeSelect.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeSkipTakeSelect.cs)

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
|                      Method | Skip | Count |     Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------- |----- |------ |---------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|                     ForLoop | 1000 |   100 | 1.529 μs | 0.0037 μs | 0.0031 μs |  1.00 |    0.00 |      - |     - |     - |         - |
|                 ForeachLoop | 1000 |   100 | 4.021 μs | 0.0267 μs | 0.0223 μs |  2.63 |    0.01 | 0.0153 |     - |     - |      32 B |
|                        Linq | 1000 |   100 | 2.542 μs | 0.0037 μs | 0.0031 μs |  1.66 |    0.00 | 0.1183 |     - |     - |     248 B |
|                  LinqFaster | 1000 |   100 | 2.454 μs | 0.0175 μs | 0.0155 μs |  1.61 |    0.01 | 5.7678 |     - |     - |   12072 B |
|                      LinqAF | 1000 |   100 | 6.742 μs | 0.1108 μs | 0.1037 μs |  4.40 |    0.07 |      - |     - |     - |         - |
|                  StructLinq | 1000 |   100 | 3.107 μs | 0.0031 μs | 0.0029 μs |  2.03 |    0.00 | 0.0458 |     - |     - |      96 B |
|        StructLinq_IFunction | 1000 |   100 | 2.874 μs | 0.0069 μs | 0.0065 μs |  1.88 |    0.01 |      - |     - |     - |         - |
|           Hyperlinq_Foreach | 1000 |   100 | 1.770 μs | 0.0027 μs | 0.0025 μs |  1.16 |    0.00 |      - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction | 1000 |   100 | 1.625 μs | 0.0025 μs | 0.0022 μs |  1.06 |    0.00 |      - |     - |     - |         - |
|               Hyperlinq_For | 1000 |   100 | 1.839 μs | 0.0044 μs | 0.0037 μs |  1.20 |    0.00 |      - |     - |     - |         - |
|     Hyperlinq_For_IFunction | 1000 |   100 | 1.638 μs | 0.0032 μs | 0.0030 μs |  1.07 |    0.00 |      - |     - |     - |         - |
