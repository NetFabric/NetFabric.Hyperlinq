## Array.Int32.ArrayInt32SkipTakeSelect

### Source
[ArrayInt32SkipTakeSelect.cs](../LinqBenchmarks/Array/Int32/ArrayInt32SkipTakeSelect.cs)

### References:
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
|                     ForLoop | 1000 |   100 |    57.76 ns |  0.598 ns |  0.559 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|                 ForeachLoop | 1000 |   100 | 2,873.12 ns | 27.941 ns | 26.136 ns | 49.74 |    0.58 | 0.0153 |     - |     - |      32 B |
|                        Linq | 1000 |   100 | 1,548.95 ns | 30.788 ns | 43.161 ns | 26.91 |    0.85 | 0.0725 |     - |     - |     152 B |
|                  LinqFaster | 1000 |   100 |   384.88 ns |  5.932 ns |  5.548 ns |  6.66 |    0.11 | 0.6080 |     - |     - |    1272 B |
|                      LinqAF | 1000 |   100 | 3,033.10 ns | 28.079 ns | 26.265 ns | 52.52 |    0.77 |      - |     - |     - |         - |
|                  StructLinq | 1000 |   100 |   259.82 ns |  2.885 ns |  2.698 ns |  4.50 |    0.06 | 0.0458 |     - |     - |      96 B |
|        StructLinq_IFunction | 1000 |   100 |   171.02 ns |  2.043 ns |  1.911 ns |  2.96 |    0.05 |      - |     - |     - |         - |
|           Hyperlinq_Foreach | 1000 |   100 |   321.09 ns |  6.097 ns |  6.261 ns |  5.55 |    0.13 |      - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction | 1000 |   100 |   172.77 ns |  2.512 ns |  2.350 ns |  2.99 |    0.04 |      - |     - |     - |         - |
|               Hyperlinq_For | 1000 |   100 |   305.76 ns |  6.069 ns |  7.453 ns |  5.30 |    0.13 |      - |     - |     - |         - |
|     Hyperlinq_For_IFunction | 1000 |   100 |    96.95 ns |  1.305 ns |  1.157 ns |  1.68 |    0.03 |      - |     - |     - |         - |
