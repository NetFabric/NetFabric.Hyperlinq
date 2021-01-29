## List.ValueType.ListValueTypeSkipTakeSelect

### Source
[ListValueTypeSkipTakeSelect.cs](../LinqBenchmarks/List/ValueType/ListValueTypeSkipTakeSelect.cs)

### References:
- Cistern.ValueLinq: [0.0.11](https://www.nuget.org/packages/Cistern.ValueLinq/0.0.11)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta28](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta28)

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
|                     ForLoop | 1000 |   100 |  1.736 μs | 0.0034 μs | 0.0032 μs |  1.00 |    0.00 |      - |     - |     - |         - |
|                 ForeachLoop | 1000 |   100 |  7.476 μs | 0.0191 μs | 0.0169 μs |  4.31 |    0.01 | 0.0305 |     - |     - |      72 B |
|                        Linq | 1000 |   100 |  2.695 μs | 0.0134 μs | 0.0119 μs |  1.55 |    0.01 | 0.1183 |     - |     - |     248 B |
|                  LinqFaster | 1000 |   100 |  3.979 μs | 0.0182 μs | 0.0161 μs |  2.29 |    0.01 | 5.8136 |     - |     - |   12168 B |
|                      LinqAF | 1000 |   100 | 11.465 μs | 0.0398 μs | 0.0333 μs |  6.61 |    0.02 |      - |     - |     - |         - |
|                  StructLinq | 1000 |   100 |  1.982 μs | 0.0185 μs | 0.0173 μs |  1.14 |    0.01 | 0.0572 |     - |     - |     120 B |
|        StructLinq_IFunction | 1000 |   100 |  1.709 μs | 0.0045 μs | 0.0042 μs |  0.98 |    0.00 |      - |     - |     - |         - |
|           Hyperlinq_Foreach | 1000 |   100 |  1.900 μs | 0.0102 μs | 0.0095 μs |  1.09 |    0.01 |      - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction | 1000 |   100 |  1.750 μs | 0.0053 μs | 0.0050 μs |  1.01 |    0.00 |      - |     - |     - |         - |
|               Hyperlinq_For | 1000 |   100 |  2.018 μs | 0.0072 μs | 0.0067 μs |  1.16 |    0.00 |      - |     - |     - |         - |
|     Hyperlinq_For_IFunction | 1000 |   100 |  1.747 μs | 0.0064 μs | 0.0060 μs |  1.01 |    0.00 |      - |     - |     - |         - |
