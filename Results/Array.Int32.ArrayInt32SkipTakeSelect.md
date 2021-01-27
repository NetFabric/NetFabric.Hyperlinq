## Array.Int32.ArrayInt32SkipTakeSelect

### Source
[ArrayInt32SkipTakeSelect.cs](../LinqBenchmarks/Array/Int32/ArrayInt32SkipTakeSelect.cs)

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
|                      Method | Skip | Count |        Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------- |----- |------ |------------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|                     ForLoop | 1000 |   100 |    66.49 ns |  1.329 ns |  1.774 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|                 ForeachLoop | 1000 |   100 | 2,609.25 ns | 51.709 ns | 57.475 ns | 39.41 |    1.52 | 0.0153 |     - |     - |      32 B |
|                        Linq | 1000 |   100 | 2,091.06 ns | 36.361 ns | 47.280 ns | 31.48 |    1.22 | 0.0725 |     - |     - |     152 B |
|                  LinqFaster | 1000 |   100 |   353.69 ns |  6.940 ns | 11.971 ns |  5.31 |    0.25 | 0.6080 |     - |     - |    1272 B |
|                      LinqAF | 1000 |   100 | 2,850.55 ns | 15.653 ns | 12.221 ns | 42.92 |    1.29 |      - |     - |     - |         - |
|                  StructLinq | 1000 |   100 |   217.19 ns |  0.500 ns |  0.467 ns |  3.26 |    0.09 | 0.0458 |     - |     - |      96 B |
|        StructLinq_IFunction | 1000 |   100 |   158.72 ns |  0.470 ns |  0.416 ns |  2.39 |    0.07 |      - |     - |     - |         - |
|           Hyperlinq_Foreach | 1000 |   100 |   192.93 ns |  1.589 ns |  1.327 ns |  2.91 |    0.08 |      - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction | 1000 |   100 |   159.62 ns |  0.320 ns |  0.299 ns |  2.40 |    0.06 |      - |     - |     - |         - |
|               Hyperlinq_For | 1000 |   100 |   217.30 ns |  0.485 ns |  0.405 ns |  3.27 |    0.09 |      - |     - |     - |         - |
|     Hyperlinq_For_IFunction | 1000 |   100 |    88.36 ns |  0.284 ns |  0.222 ns |  1.33 |    0.04 |      - |     - |     - |         - |
