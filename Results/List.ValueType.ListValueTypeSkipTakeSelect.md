## List.ValueType.ListValueTypeSkipTakeSelect

### Source
[ListValueTypeSkipTakeSelect.cs](../LinqBenchmarks/List/ValueType/ListValueTypeSkipTakeSelect.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta35](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta35)

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
|                     ForLoop | 1000 |   100 |  1.593 μs | 0.0030 μs | 0.0028 μs |  1.00 |    0.00 |      - |     - |     - |         - |
|                 ForeachLoop | 1000 |   100 |  6.697 μs | 0.0169 μs | 0.0150 μs |  4.20 |    0.01 | 0.0305 |     - |     - |      72 B |
|                        Linq | 1000 |   100 |  2.464 μs | 0.0103 μs | 0.0086 μs |  1.55 |    0.00 | 0.1183 |     - |     - |     248 B |
|                  LinqFaster | 1000 |   100 |  3.555 μs | 0.0257 μs | 0.0240 μs |  2.23 |    0.02 | 5.8136 |     - |     - |   12168 B |
|                      LinqAF | 1000 |   100 | 10.279 μs | 0.0597 μs | 0.0559 μs |  6.45 |    0.04 |      - |     - |     - |         - |
|                  StructLinq | 1000 |   100 |  1.864 μs | 0.0038 μs | 0.0032 μs |  1.17 |    0.00 | 0.0572 |     - |     - |     120 B |
|        StructLinq_IFunction | 1000 |   100 |  1.568 μs | 0.0026 μs | 0.0023 μs |  0.98 |    0.00 |      - |     - |     - |         - |
|           Hyperlinq_Foreach | 1000 |   100 |  1.654 μs | 0.0025 μs | 0.0022 μs |  1.04 |    0.00 |      - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction | 1000 |   100 |  1.547 μs | 0.0031 μs | 0.0027 μs |  0.97 |    0.00 |      - |     - |     - |         - |
|               Hyperlinq_For | 1000 |   100 |  1.681 μs | 0.0029 μs | 0.0027 μs |  1.05 |    0.00 |      - |     - |     - |         - |
|     Hyperlinq_For_IFunction | 1000 |   100 |  1.526 μs | 0.0029 μs | 0.0027 μs |  0.96 |    0.00 |      - |     - |     - |         - |
