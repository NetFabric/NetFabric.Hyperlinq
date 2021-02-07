## List.ValueType.ListValueTypeSkipTakeSelect

### Source
[ListValueTypeSkipTakeSelect.cs](../LinqBenchmarks/List/ValueType/ListValueTypeSkipTakeSelect.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta33](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta33)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.200-preview.20614.14
  [Host]        : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|                      Method | Skip | Count |      Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------- |----- |------ |----------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|                     ForLoop | 1000 |   100 |  1.568 μs | 0.0021 μs | 0.0019 μs |  1.00 |    0.00 |      - |     - |     - |         - |
|                 ForeachLoop | 1000 |   100 |  6.680 μs | 0.0119 μs | 0.0105 μs |  4.26 |    0.01 | 0.0305 |     - |     - |      72 B |
|                        Linq | 1000 |   100 |  2.487 μs | 0.0069 μs | 0.0061 μs |  1.59 |    0.00 | 0.1183 |     - |     - |     248 B |
|                  LinqFaster | 1000 |   100 |  3.537 μs | 0.0268 μs | 0.0250 μs |  2.26 |    0.02 | 5.8136 |     - |     - |   12168 B |
|                      LinqAF | 1000 |   100 | 10.408 μs | 0.1257 μs | 0.1176 μs |  6.64 |    0.07 |      - |     - |     - |         - |
|                  StructLinq | 1000 |   100 |  1.818 μs | 0.0048 μs | 0.0045 μs |  1.16 |    0.00 | 0.0572 |     - |     - |     120 B |
|        StructLinq_IFunction | 1000 |   100 |  1.569 μs | 0.0054 μs | 0.0045 μs |  1.00 |    0.00 |      - |     - |     - |         - |
|           Hyperlinq_Foreach | 1000 |   100 |  1.647 μs | 0.0020 μs | 0.0018 μs |  1.05 |    0.00 |      - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction | 1000 |   100 |  1.537 μs | 0.0049 μs | 0.0043 μs |  0.98 |    0.00 |      - |     - |     - |         - |
|               Hyperlinq_For | 1000 |   100 |  1.700 μs | 0.0039 μs | 0.0035 μs |  1.08 |    0.00 |      - |     - |     - |         - |
|     Hyperlinq_For_IFunction | 1000 |   100 |  1.539 μs | 0.0029 μs | 0.0025 μs |  0.98 |    0.00 |      - |     - |     - |         - |
