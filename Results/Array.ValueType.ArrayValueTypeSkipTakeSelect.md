## Array.ValueType.ArrayValueTypeSkipTakeSelect

### Source
[ArrayValueTypeSkipTakeSelect.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeSkipTakeSelect.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta37](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta37)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.200-preview.21079.7
  [Host]        : .NET Core 5.0.3 (CoreCLR 5.0.321.7212, CoreFX 5.0.321.7212), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.3 (CoreCLR 5.0.321.7212, CoreFX 5.0.321.7212), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|                      Method | Skip | Count |     Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------- |----- |------ |---------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|                     ForLoop | 1000 |   100 | 1.496 μs | 0.0024 μs | 0.0022 μs |  1.00 |    0.00 |      - |     - |     - |         - |
|                 ForeachLoop | 1000 |   100 | 3.775 μs | 0.0187 μs | 0.0166 μs |  2.52 |    0.01 | 0.0153 |     - |     - |      32 B |
|                        Linq | 1000 |   100 | 2.522 μs | 0.0051 μs | 0.0045 μs |  1.69 |    0.00 | 0.1183 |     - |     - |     248 B |
|                  LinqFaster | 1000 |   100 | 2.521 μs | 0.0504 μs | 0.0471 μs |  1.68 |    0.03 | 5.7678 |     - |     - |   12072 B |
|                      LinqAF | 1000 |   100 | 6.375 μs | 0.0554 μs | 0.0463 μs |  4.26 |    0.03 |      - |     - |     - |         - |
|                  StructLinq | 1000 |   100 | 2.543 μs | 0.0031 μs | 0.0027 μs |  1.70 |    0.00 | 0.0458 |     - |     - |      96 B |
|        StructLinq_IFunction | 1000 |   100 | 1.550 μs | 0.0031 μs | 0.0027 μs |  1.04 |    0.00 |      - |     - |     - |         - |
|           Hyperlinq_Foreach | 1000 |   100 | 1.670 μs | 0.0028 μs | 0.0025 μs |  1.12 |    0.00 |      - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction | 1000 |   100 | 1.607 μs | 0.0025 μs | 0.0022 μs |  1.07 |    0.00 |      - |     - |     - |         - |
|               Hyperlinq_For | 1000 |   100 | 1.696 μs | 0.0026 μs | 0.0023 μs |  1.13 |    0.00 |      - |     - |     - |         - |
|     Hyperlinq_For_IFunction | 1000 |   100 | 1.640 μs | 0.0023 μs | 0.0020 μs |  1.10 |    0.00 |      - |     - |     - |         - |
