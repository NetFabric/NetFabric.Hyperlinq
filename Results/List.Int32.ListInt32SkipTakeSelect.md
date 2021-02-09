## List.Int32.ListInt32SkipTakeSelect

### Source
[ListInt32SkipTakeSelect.cs](../LinqBenchmarks/List/Int32/ListInt32SkipTakeSelect.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta34](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta34)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.200-preview.20614.14
  [Host]        : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|                      Method | Skip | Count |         Mean |      Error |       StdDev |  Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------- |----- |------ |-------------:|-----------:|-------------:|-------:|--------:|-------:|------:|------:|----------:|
|                     ForLoop | 1000 |   100 |     71.56 ns |   0.865 ns |     0.767 ns |   1.00 |    0.00 |      - |     - |     - |         - |
|                 ForeachLoop | 1000 |   100 |  7,655.10 ns | 152.104 ns |   373.114 ns | 106.55 |    6.09 | 0.0153 |     - |     - |      40 B |
|                        Linq | 1000 |   100 |  2,073.10 ns |  51.220 ns |   150.219 ns |  28.95 |    2.62 | 0.0725 |     - |     - |     152 B |
|                  LinqFaster | 1000 |   100 |    918.96 ns |   6.581 ns |     6.156 ns |  12.85 |    0.16 | 0.6533 |     - |     - |    1368 B |
|                      LinqAF | 1000 |   100 | 15,530.41 ns | 420.877 ns | 1,240.964 ns | 212.22 |   21.95 |      - |     - |     - |         - |
|                  StructLinq | 1000 |   100 |    485.89 ns |   9.708 ns |    22.693 ns |   6.86 |    0.33 | 0.0458 |     - |     - |      96 B |
|        StructLinq_IFunction | 1000 |   100 |    165.26 ns |   0.197 ns |     0.165 ns |   2.31 |    0.03 |      - |     - |     - |         - |
|           Hyperlinq_Foreach | 1000 |   100 |    452.87 ns |  11.035 ns |    32.537 ns |   6.07 |    0.33 |      - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction | 1000 |   100 |    169.28 ns |   0.701 ns |     0.656 ns |   2.37 |    0.02 |      - |     - |     - |         - |
|               Hyperlinq_For | 1000 |   100 |    504.42 ns |  13.974 ns |    40.983 ns |   7.23 |    0.54 |      - |     - |     - |         - |
