## List.ValueType.ListValueTypeSkipTakeSelect

### Source
[ListValueTypeSkipTakeSelect.cs](../LinqBenchmarks/List/ValueType/ListValueTypeSkipTakeSelect.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta36](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta36)

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
|                     ForLoop | 1000 |   100 |  1.653 μs | 0.0053 μs | 0.0049 μs |  1.00 |    0.00 |      - |     - |     - |         - |
|                 ForeachLoop | 1000 |   100 |  6.867 μs | 0.0269 μs | 0.0225 μs |  4.15 |    0.02 | 0.0305 |     - |     - |      72 B |
|                        Linq | 1000 |   100 |  2.514 μs | 0.0086 μs | 0.0081 μs |  1.52 |    0.01 | 0.1183 |     - |     - |     248 B |
|                  LinqFaster | 1000 |   100 |  3.643 μs | 0.0240 μs | 0.0225 μs |  2.20 |    0.02 | 5.8136 |     - |     - |   12168 B |
|                      LinqAF | 1000 |   100 | 10.693 μs | 0.1522 μs | 0.1424 μs |  6.47 |    0.08 |      - |     - |     - |         - |
|                  StructLinq | 1000 |   100 |  1.903 μs | 0.0081 μs | 0.0072 μs |  1.15 |    0.00 | 0.0572 |     - |     - |     120 B |
|        StructLinq_IFunction | 1000 |   100 |  1.601 μs | 0.0038 μs | 0.0034 μs |  0.97 |    0.00 |      - |     - |     - |         - |
|           Hyperlinq_Foreach | 1000 |   100 |  1.716 μs | 0.0045 μs | 0.0038 μs |  1.04 |    0.00 |      - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction | 1000 |   100 |  1.571 μs | 0.0075 μs | 0.0063 μs |  0.95 |    0.00 |      - |     - |     - |         - |
|               Hyperlinq_For | 1000 |   100 |  1.713 μs | 0.0037 μs | 0.0032 μs |  1.04 |    0.00 |      - |     - |     - |         - |
|     Hyperlinq_For_IFunction | 1000 |   100 |  1.572 μs | 0.0052 μs | 0.0046 μs |  0.95 |    0.00 |      - |     - |     - |         - |
