## List.ValueType.ListValueTypeSkipTakeSelect

### Source
[ListValueTypeSkipTakeSelect.cs](../LinqBenchmarks/List/ValueType/ListValueTypeSkipTakeSelect.cs)

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
|                      Method | Skip | Count |      Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------- |----- |------ |----------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|                     ForLoop | 1000 |   100 |  1.590 μs | 0.0035 μs | 0.0033 μs |  1.00 |    0.00 |      - |     - |     - |         - |
|                 ForeachLoop | 1000 |   100 |  6.689 μs | 0.0242 μs | 0.0215 μs |  4.21 |    0.01 | 0.0305 |     - |     - |      72 B |
|                        Linq | 1000 |   100 |  2.487 μs | 0.0080 μs | 0.0074 μs |  1.56 |    0.01 | 0.1183 |     - |     - |     248 B |
|                  LinqFaster | 1000 |   100 |  3.529 μs | 0.0228 μs | 0.0178 μs |  2.22 |    0.01 | 5.8136 |     - |     - |   12168 B |
|                      LinqAF | 1000 |   100 | 10.357 μs | 0.0478 μs | 0.0424 μs |  6.51 |    0.03 |      - |     - |     - |         - |
|                  StructLinq | 1000 |   100 |  1.831 μs | 0.0035 μs | 0.0031 μs |  1.15 |    0.00 | 0.0572 |     - |     - |     120 B |
|        StructLinq_IFunction | 1000 |   100 |  1.590 μs | 0.0051 μs | 0.0043 μs |  1.00 |    0.00 |      - |     - |     - |         - |
|           Hyperlinq_Foreach | 1000 |   100 |  1.687 μs | 0.0038 μs | 0.0036 μs |  1.06 |    0.00 |      - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction | 1000 |   100 |  1.538 μs | 0.0018 μs | 0.0016 μs |  0.97 |    0.00 |      - |     - |     - |         - |
|               Hyperlinq_For | 1000 |   100 |  1.682 μs | 0.0025 μs | 0.0022 μs |  1.06 |    0.00 |      - |     - |     - |         - |
|     Hyperlinq_For_IFunction | 1000 |   100 |  1.532 μs | 0.0029 μs | 0.0026 μs |  0.96 |    0.00 |      - |     - |     - |         - |
