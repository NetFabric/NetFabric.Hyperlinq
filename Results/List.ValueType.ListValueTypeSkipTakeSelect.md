## List.ValueType.ListValueTypeSkipTakeSelect

### Source
[ListValueTypeSkipTakeSelect.cs](../LinqBenchmarks/List/ValueType/ListValueTypeSkipTakeSelect.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta30](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta30)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.200-preview.20614.14
  [Host]        : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|               Method | Skip | Count |      Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |----- |------ |----------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop | 1000 |   100 |  1.585 μs | 0.0017 μs | 0.0013 μs |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop | 1000 |   100 |  7.383 μs | 0.0166 μs | 0.0139 μs |  4.66 |    0.01 | 0.0305 |     - |     - |      72 B |
|                 Linq | 1000 |   100 |  2.483 μs | 0.0049 μs | 0.0041 μs |  1.57 |    0.00 | 0.1183 |     - |     - |     248 B |
|           LinqFaster | 1000 |   100 |  3.494 μs | 0.0208 μs | 0.0195 μs |  2.20 |    0.01 | 5.8136 |     - |     - |   12168 B |
|               LinqAF | 1000 |   100 | 10.332 μs | 0.1155 μs | 0.1024 μs |  6.52 |    0.07 |      - |     - |     - |         - |
|           StructLinq | 1000 |   100 |  1.856 μs | 0.0019 μs | 0.0017 μs |  1.17 |    0.00 | 0.0572 |     - |     - |     120 B |
| StructLinq_IFunction | 1000 |   100 |  1.589 μs | 0.0027 μs | 0.0023 μs |  1.00 |    0.00 |      - |     - |     - |         - |
|    Hyperlinq_Foreach | 1000 |   100 |  1.824 μs | 0.0032 μs | 0.0028 μs |  1.15 |    0.00 |      - |     - |     - |         - |
|        Hyperlinq_For | 1000 |   100 |  1.927 μs | 0.0046 μs | 0.0041 μs |  1.22 |    0.00 |      - |     - |     - |         - |
