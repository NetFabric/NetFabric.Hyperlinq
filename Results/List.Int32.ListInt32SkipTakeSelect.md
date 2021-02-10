## List.Int32.ListInt32SkipTakeSelect

### Source
[ListInt32SkipTakeSelect.cs](../LinqBenchmarks/List/Int32/ListInt32SkipTakeSelect.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta35](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta35)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.200-preview.20614.14
  [Host]        : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|                      Method | Skip | Count |         Mean |      Error |     StdDev |  Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------- |----- |------ |-------------:|-----------:|-----------:|-------:|--------:|-------:|------:|------:|----------:|
|                     ForLoop | 1000 |   100 |     70.52 ns |   0.702 ns |   0.623 ns |   1.00 |    0.00 |      - |     - |     - |         - |
|                 ForeachLoop | 1000 |   100 |  8,451.90 ns | 168.267 ns | 457.782 ns | 118.32 |    6.49 | 0.0153 |     - |     - |      40 B |
|                        Linq | 1000 |   100 |  1,955.71 ns |  48.779 ns | 143.060 ns |  27.78 |    1.77 | 0.0725 |     - |     - |     152 B |
|                  LinqFaster | 1000 |   100 |    916.58 ns |   5.295 ns |   4.694 ns |  13.00 |    0.15 | 0.6533 |     - |     - |    1368 B |
|                      LinqAF | 1000 |   100 | 14,560.60 ns | 329.476 ns | 955.871 ns | 214.31 |   11.91 |      - |     - |     - |         - |
|                  StructLinq | 1000 |   100 |    475.19 ns |   9.515 ns |  22.796 ns |   6.75 |    0.30 | 0.0458 |     - |     - |      96 B |
|        StructLinq_IFunction | 1000 |   100 |    165.25 ns |   0.467 ns |   0.414 ns |   2.34 |    0.02 |      - |     - |     - |         - |
|           Hyperlinq_Foreach | 1000 |   100 |    439.53 ns |  10.649 ns |  31.398 ns |   6.45 |    0.44 |      - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction | 1000 |   100 |    166.37 ns |   0.548 ns |   0.512 ns |   2.36 |    0.02 |      - |     - |     - |         - |
|               Hyperlinq_For | 1000 |   100 |    498.44 ns |  11.747 ns |  34.636 ns |   7.10 |    0.51 |      - |     - |     - |         - |
