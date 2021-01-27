## List.ValueType.ListValueTypeSkipTakeSelect

### Source
[ListValueTypeSkipTakeSelect.cs](../LinqBenchmarks/List/ValueType/ListValueTypeSkipTakeSelect.cs)

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
|                      Method | Skip | Count |      Mean |     Error |    StdDev |    Median | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------- |----- |------ |----------:|----------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|                     ForLoop | 1000 |   100 |  1.571 μs | 0.0039 μs | 0.0036 μs |  1.570 μs |  1.00 |    0.00 |      - |     - |     - |         - |
|                 ForeachLoop | 1000 |   100 |  5.939 μs | 0.0112 μs | 0.0099 μs |  5.939 μs |  3.78 |    0.01 | 0.0305 |     - |     - |      72 B |
|                        Linq | 1000 |   100 |  2.485 μs | 0.0080 μs | 0.0075 μs |  2.483 μs |  1.58 |    0.01 | 0.1183 |     - |     - |     248 B |
|                  LinqFaster | 1000 |   100 |  3.515 μs | 0.0319 μs | 0.0298 μs |  3.519 μs |  2.24 |    0.02 | 5.8136 |     - |     - |   12168 B |
|                      LinqAF | 1000 |   100 | 10.415 μs | 0.1566 μs | 0.1308 μs | 10.397 μs |  6.63 |    0.08 |      - |     - |     - |         - |
|                  StructLinq | 1000 |   100 |  3.143 μs | 0.0073 μs | 0.0065 μs |  3.144 μs |  2.00 |    0.01 | 0.0458 |     - |     - |      96 B |
|        StructLinq_IFunction | 1000 |   100 |  2.895 μs | 0.0333 μs | 0.0260 μs |  2.887 μs |  1.84 |    0.02 |      - |     - |     - |         - |
|           Hyperlinq_Foreach | 1000 |   100 |  1.773 μs | 0.0033 μs | 0.0028 μs |  1.773 μs |  1.13 |    0.00 |      - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction | 1000 |   100 |  1.631 μs | 0.0326 μs | 0.0619 μs |  1.594 μs |  1.09 |    0.04 |      - |     - |     - |         - |
|               Hyperlinq_For | 1000 |   100 |  1.801 μs | 0.0016 μs | 0.0015 μs |  1.801 μs |  1.15 |    0.00 |      - |     - |     - |         - |
|     Hyperlinq_For_IFunction | 1000 |   100 |  1.616 μs | 0.0031 μs | 0.0027 μs |  1.616 μs |  1.03 |    0.00 |      - |     - |     - |         - |
