## Array.Int32.ArrayInt32SkipTakeSelect

### Source
[ArrayInt32SkipTakeSelect.cs](../LinqBenchmarks/Array/Int32/ArrayInt32SkipTakeSelect.cs)

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
|                      Method | Skip | Count |        Mean |      Error |     StdDev |      Median | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------- |----- |------ |------------:|-----------:|-----------:|------------:|------:|--------:|-------:|------:|------:|----------:|
|                     ForLoop | 1000 |   100 |    55.68 ns |   0.242 ns |   0.215 ns |    55.60 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|                 ForeachLoop | 1000 |   100 | 4,365.62 ns | 253.747 ns | 748.179 ns | 4,061.97 ns | 72.73 |    7.29 | 0.0153 |     - |     - |      32 B |
|                        Linq | 1000 |   100 | 1,992.76 ns |  47.144 ns | 137.521 ns | 1,973.08 ns | 35.55 |    3.19 | 0.0725 |     - |     - |     152 B |
|                  LinqFaster | 1000 |   100 |   338.02 ns |   2.539 ns |   2.121 ns |   339.03 ns |  6.07 |    0.04 | 0.6080 |     - |     - |    1272 B |
|                      LinqAF | 1000 |   100 | 4,632.38 ns |  89.069 ns | 225.088 ns | 4,614.12 ns | 83.86 |    5.63 |      - |     - |     - |         - |
|                  StructLinq | 1000 |   100 |   433.53 ns |   8.676 ns |  18.490 ns |   433.27 ns |  7.79 |    0.41 | 0.0458 |     - |     - |      96 B |
|        StructLinq_IFunction | 1000 |   100 |   174.75 ns |   0.423 ns |   0.353 ns |   174.68 ns |  3.14 |    0.01 |      - |     - |     - |         - |
|           Hyperlinq_Foreach | 1000 |   100 |   443.31 ns |  12.286 ns |  36.033 ns |   445.21 ns |  7.70 |    0.73 |      - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction | 1000 |   100 |   165.98 ns |   0.415 ns |   0.388 ns |   165.99 ns |  2.98 |    0.01 |      - |     - |     - |         - |
|               Hyperlinq_For | 1000 |   100 |   522.51 ns |  13.488 ns |  39.770 ns |   521.24 ns |  9.22 |    0.71 |      - |     - |     - |         - |
|     Hyperlinq_For_IFunction | 1000 |   100 |   138.93 ns |   0.521 ns |   0.462 ns |   138.88 ns |  2.50 |    0.01 |      - |     - |     - |         - |
