## Array.Int32.ArrayInt32SkipTakeSelect

### Source
[ArrayInt32SkipTakeSelect.cs](../LinqBenchmarks/Array/Int32/ArrayInt32SkipTakeSelect.cs)

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
|                      Method | Skip | Count |        Mean |     Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------- |----- |------ |------------:|----------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|                     ForLoop | 1000 |   100 |    57.61 ns |  0.099 ns | 0.093 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|                 ForeachLoop | 1000 |   100 | 2,488.99 ns | 11.771 ns | 9.829 ns | 43.19 |    0.14 | 0.0153 |     - |     - |      32 B |
|                        Linq | 1000 |   100 | 1,052.66 ns |  4.170 ns | 3.900 ns | 18.27 |    0.08 | 0.0725 |     - |     - |     152 B |
|                  LinqFaster | 1000 |   100 |   356.87 ns |  1.089 ns | 1.018 ns |  6.19 |    0.02 | 0.6080 |     - |     - |    1272 B |
|                      LinqAF | 1000 |   100 | 2,747.11 ns |  9.439 ns | 7.882 ns | 47.67 |    0.15 |      - |     - |     - |         - |
|                  StructLinq | 1000 |   100 |   247.94 ns |  0.500 ns | 0.444 ns |  4.30 |    0.01 | 0.0458 |     - |     - |      96 B |
|        StructLinq_IFunction | 1000 |   100 |   164.06 ns |  0.217 ns | 0.170 ns |  2.85 |    0.01 |      - |     - |     - |         - |
|           Hyperlinq_Foreach | 1000 |   100 |   203.54 ns |  0.553 ns | 0.431 ns |  3.53 |    0.01 |      - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction | 1000 |   100 |   166.19 ns |  0.287 ns | 0.268 ns |  2.88 |    0.01 |      - |     - |     - |         - |
|               Hyperlinq_For | 1000 |   100 |   219.96 ns |  0.370 ns | 0.328 ns |  3.82 |    0.01 |      - |     - |     - |         - |
|     Hyperlinq_For_IFunction | 1000 |   100 |    90.05 ns |  0.572 ns | 0.507 ns |  1.56 |    0.01 |      - |     - |     - |         - |
