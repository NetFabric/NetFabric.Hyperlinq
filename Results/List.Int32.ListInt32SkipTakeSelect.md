## List.Int32.ListInt32SkipTakeSelect

### Source
[ListInt32SkipTakeSelect.cs](../LinqBenchmarks/List/Int32/ListInt32SkipTakeSelect.cs)

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
|                      Method | Skip | Count |        Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------- |----- |------ |------------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|                     ForLoop | 1000 |   100 |    74.87 ns |  0.478 ns |  0.399 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|                 ForeachLoop | 1000 |   100 | 4,861.83 ns | 35.014 ns | 31.039 ns | 64.92 |    0.47 | 0.0153 |     - |     - |      40 B |
|                        Linq | 1000 |   100 | 1,246.41 ns | 24.721 ns | 23.124 ns | 16.69 |    0.31 | 0.0725 |     - |     - |     152 B |
|                  LinqFaster | 1000 |   100 |   945.67 ns |  4.169 ns |  3.255 ns | 12.63 |    0.10 | 0.6533 |     - |     - |    1368 B |
|                      LinqAF | 1000 |   100 | 7,014.90 ns | 41.462 ns | 34.622 ns | 93.70 |    0.64 |      - |     - |     - |         - |
|                  StructLinq | 1000 |   100 |   364.14 ns |  3.564 ns |  2.976 ns |  4.86 |    0.04 | 0.0458 |     - |     - |      96 B |
|        StructLinq_IFunction | 1000 |   100 |   169.15 ns |  0.718 ns |  0.671 ns |  2.26 |    0.02 |      - |     - |     - |         - |
|           Hyperlinq_Foreach | 1000 |   100 |   274.72 ns |  2.821 ns |  2.501 ns |  3.67 |    0.04 |      - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction | 1000 |   100 |   165.79 ns |  1.043 ns |  0.871 ns |  2.21 |    0.02 |      - |     - |     - |         - |
|               Hyperlinq_For | 1000 |   100 |   284.12 ns |  5.400 ns |  5.051 ns |  3.79 |    0.08 |      - |     - |     - |         - |
