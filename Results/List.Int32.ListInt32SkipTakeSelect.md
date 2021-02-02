## List.Int32.ListInt32SkipTakeSelect

### Source
[ListInt32SkipTakeSelect.cs](../LinqBenchmarks/List/Int32/ListInt32SkipTakeSelect.cs)

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
|                      Method | Skip | Count |        Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------- |----- |------ |------------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|                     ForLoop | 1000 |   100 |    82.24 ns |  0.199 ns |  0.187 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|                 ForeachLoop | 1000 |   100 | 4,467.22 ns | 16.475 ns | 15.411 ns | 54.32 |    0.22 | 0.0153 |     - |     - |      40 B |
|                        Linq | 1000 |   100 |   941.76 ns |  1.629 ns |  1.360 ns | 11.45 |    0.03 | 0.0725 |     - |     - |     152 B |
|                  LinqFaster | 1000 |   100 |   795.44 ns |  3.069 ns |  2.721 ns |  9.67 |    0.04 | 0.6533 |     - |     - |    1368 B |
|                      LinqAF | 1000 |   100 | 5,050.61 ns | 12.610 ns | 11.796 ns | 61.41 |    0.21 |      - |     - |     - |         - |
|                  StructLinq | 1000 |   100 |   252.11 ns |  0.285 ns |  0.238 ns |  3.07 |    0.01 | 0.0458 |     - |     - |      96 B |
|        StructLinq_IFunction | 1000 |   100 |   166.64 ns |  0.422 ns |  0.395 ns |  2.03 |    0.01 |      - |     - |     - |         - |
|           Hyperlinq_Foreach | 1000 |   100 |   229.28 ns |  0.649 ns |  0.575 ns |  2.79 |    0.01 |      - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction | 1000 |   100 |   173.48 ns |  0.337 ns |  0.315 ns |  2.11 |    0.01 |      - |     - |     - |         - |
|               Hyperlinq_For | 1000 |   100 |   322.66 ns |  0.725 ns |  0.643 ns |  3.92 |    0.01 |      - |     - |     - |         - |
