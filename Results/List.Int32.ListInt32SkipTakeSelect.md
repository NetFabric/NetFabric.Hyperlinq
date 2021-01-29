## List.Int32.ListInt32SkipTakeSelect

### Source
[ListInt32SkipTakeSelect.cs](../LinqBenchmarks/List/Int32/ListInt32SkipTakeSelect.cs)

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
|                      Method | Skip | Count |        Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------- |----- |------ |------------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|                     ForLoop | 1000 |   100 |    77.73 ns |  0.215 ns |  0.168 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|                 ForeachLoop | 1000 |   100 | 4,981.72 ns | 26.185 ns | 23.213 ns | 64.06 |    0.38 | 0.0153 |     - |     - |      40 B |
|                        Linq | 1000 |   100 | 1,045.66 ns |  3.714 ns |  3.101 ns | 13.45 |    0.06 | 0.0725 |     - |     - |     152 B |
|                  LinqFaster | 1000 |   100 |   925.25 ns |  5.951 ns |  5.276 ns | 11.92 |    0.07 | 0.6533 |     - |     - |    1368 B |
|                      LinqAF | 1000 |   100 | 6,259.98 ns | 23.904 ns | 18.663 ns | 80.54 |    0.30 |      - |     - |     - |         - |
|                  StructLinq | 1000 |   100 |   303.56 ns |  1.485 ns |  1.240 ns |  3.91 |    0.02 | 0.0458 |     - |     - |      96 B |
|        StructLinq_IFunction | 1000 |   100 |   183.32 ns |  0.936 ns |  0.781 ns |  2.36 |    0.01 |      - |     - |     - |         - |
|           Hyperlinq_Foreach | 1000 |   100 |   217.31 ns |  0.640 ns |  0.568 ns |  2.80 |    0.01 |      - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction | 1000 |   100 |   177.75 ns |  1.242 ns |  1.162 ns |  2.29 |    0.02 |      - |     - |     - |         - |
|               Hyperlinq_For | 1000 |   100 |   247.22 ns |  1.117 ns |  0.990 ns |  3.18 |    0.01 |      - |     - |     - |         - |
