## List.Int32.ListInt32SkipTakeSelect

### Source
[ListInt32SkipTakeSelect.cs](../LinqBenchmarks/List/Int32/ListInt32SkipTakeSelect.cs)

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
|                      Method | Skip | Count |        Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------- |----- |------ |------------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|                     ForLoop | 1000 |   100 |    67.32 ns |  0.784 ns |  0.695 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|                 ForeachLoop | 1000 |   100 | 4,465.88 ns | 12.841 ns | 11.383 ns | 66.34 |    0.66 | 0.0153 |     - |     - |      40 B |
|                        Linq | 1000 |   100 |   896.49 ns |  2.125 ns |  1.988 ns | 13.32 |    0.14 | 0.0725 |     - |     - |     152 B |
|                  LinqFaster | 1000 |   100 |   777.59 ns |  2.741 ns |  2.430 ns | 11.55 |    0.14 | 0.6533 |     - |     - |    1368 B |
|                      LinqAF | 1000 |   100 | 5,452.17 ns | 17.409 ns | 15.433 ns | 81.00 |    0.71 |      - |     - |     - |         - |
|                  StructLinq | 1000 |   100 |   256.94 ns |  0.947 ns |  0.886 ns |  3.82 |    0.04 | 0.0458 |     - |     - |      96 B |
|        StructLinq_IFunction | 1000 |   100 |   168.45 ns |  0.533 ns |  0.498 ns |  2.50 |    0.02 |      - |     - |     - |         - |
|           Hyperlinq_Foreach | 1000 |   100 |   170.40 ns |  0.321 ns |  0.285 ns |  2.53 |    0.03 |      - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction | 1000 |   100 |   163.90 ns |  0.268 ns |  0.251 ns |  2.44 |    0.03 |      - |     - |     - |         - |
|               Hyperlinq_For | 1000 |   100 |   222.08 ns |  0.715 ns |  0.597 ns |  3.29 |    0.03 |      - |     - |     - |         - |
