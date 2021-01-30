## List.ValueType.ListValueTypeSkipTakeSelect

### Source
[ListValueTypeSkipTakeSelect.cs](../LinqBenchmarks/List/ValueType/ListValueTypeSkipTakeSelect.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta29](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta29)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.200-preview.20614.14
  [Host]        : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|                      Method | Skip | Count |      Mean |     Error |    StdDev |    Median | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------- |----- |------ |----------:|----------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|                     ForLoop | 1000 |   100 |  1.694 μs | 0.0375 μs | 0.1106 μs |  1.623 μs |  1.00 |    0.00 |      - |     - |     - |         - |
|                 ForeachLoop | 1000 |   100 |  6.737 μs | 0.0178 μs | 0.0139 μs |  6.740 μs |  3.71 |    0.17 | 0.0305 |     - |     - |      72 B |
|                        Linq | 1000 |   100 |  2.484 μs | 0.0061 μs | 0.0057 μs |  2.483 μs |  1.38 |    0.07 | 0.1183 |     - |     - |     248 B |
|                  LinqFaster | 1000 |   100 |  3.526 μs | 0.0178 μs | 0.0167 μs |  3.534 μs |  1.96 |    0.09 | 5.8136 |     - |     - |   12168 B |
|                      LinqAF | 1000 |   100 | 10.254 μs | 0.1730 μs | 0.1534 μs | 10.177 μs |  5.67 |    0.29 |      - |     - |     - |         - |
|                  StructLinq | 1000 |   100 |  1.817 μs | 0.0032 μs | 0.0028 μs |  1.817 μs |  1.00 |    0.05 | 0.0572 |     - |     - |     120 B |
|        StructLinq_IFunction | 1000 |   100 |  1.593 μs | 0.0021 μs | 0.0019 μs |  1.593 μs |  0.88 |    0.04 |      - |     - |     - |         - |
|           Hyperlinq_Foreach | 1000 |   100 |  1.749 μs | 0.0039 μs | 0.0034 μs |  1.748 μs |  0.97 |    0.04 |      - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction | 1000 |   100 |  1.591 μs | 0.0022 μs | 0.0018 μs |  1.591 μs |  0.87 |    0.04 |      - |     - |     - |         - |
|               Hyperlinq_For | 1000 |   100 |  1.827 μs | 0.0022 μs | 0.0020 μs |  1.828 μs |  1.01 |    0.05 |      - |     - |     - |         - |
|     Hyperlinq_For_IFunction | 1000 |   100 |  1.636 μs | 0.0032 μs | 0.0028 μs |  1.636 μs |  0.90 |    0.04 |      - |     - |     - |         - |
