## Array.Int32.ArrayInt32SkipTakeSelect

### Source
[ArrayInt32SkipTakeSelect.cs](../LinqBenchmarks/Array/Int32/ArrayInt32SkipTakeSelect.cs)

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
|                      Method | Skip | Count |        Mean |      Error |     StdDev |      Median | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------- |----- |------ |------------:|-----------:|-----------:|------------:|------:|--------:|-------:|------:|------:|----------:|
|                     ForLoop | 1000 |   100 |    55.76 ns |   0.405 ns |   0.338 ns |    55.78 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|                 ForeachLoop | 1000 |   100 | 3,901.87 ns | 129.340 ns | 377.291 ns | 3,898.35 ns | 70.35 |    5.96 | 0.0153 |     - |     - |      32 B |
|                        Linq | 1000 |   100 | 1,561.50 ns |  31.152 ns |  90.378 ns | 1,558.19 ns | 27.94 |    1.24 | 0.0725 |     - |     - |     152 B |
|                  LinqFaster | 1000 |   100 |   364.87 ns |   3.735 ns |   3.119 ns |   365.10 ns |  6.54 |    0.07 | 0.6080 |     - |     - |    1272 B |
|                      LinqAF | 1000 |   100 | 3,958.36 ns |  78.876 ns | 202.190 ns | 3,962.93 ns | 69.89 |    3.63 |      - |     - |     - |         - |
|                  StructLinq | 1000 |   100 |   422.77 ns |  16.204 ns |  47.524 ns |   438.04 ns |  6.78 |    0.55 | 0.0458 |     - |     - |      96 B |
|        StructLinq_IFunction | 1000 |   100 |   174.96 ns |   0.474 ns |   0.420 ns |   174.81 ns |  3.14 |    0.02 |      - |     - |     - |         - |
|           Hyperlinq_Foreach | 1000 |   100 |   519.70 ns |  18.921 ns |  55.790 ns |   517.92 ns |  9.26 |    1.23 |      - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction | 1000 |   100 |   168.22 ns |   0.621 ns |   0.485 ns |   168.33 ns |  3.02 |    0.02 |      - |     - |     - |         - |
|               Hyperlinq_For | 1000 |   100 |   552.97 ns |  12.521 ns |  36.721 ns |   555.76 ns | 10.02 |    0.91 |      - |     - |     - |         - |
|     Hyperlinq_For_IFunction | 1000 |   100 |   138.92 ns |   0.507 ns |   0.475 ns |   138.83 ns |  2.49 |    0.02 |      - |     - |     - |         - |
