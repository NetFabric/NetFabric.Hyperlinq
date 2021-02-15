## Array.Int32.ArrayInt32SkipTakeSelect

### Source
[ArrayInt32SkipTakeSelect.cs](../LinqBenchmarks/Array/Int32/ArrayInt32SkipTakeSelect.cs)

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
|                     ForLoop | 1000 |   100 |    67.23 ns |  0.413 ns |  0.366 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|                 ForeachLoop | 1000 |   100 | 2,926.14 ns | 28.085 ns | 26.271 ns | 43.56 |    0.36 | 0.0153 |     - |     - |      32 B |
|                        Linq | 1000 |   100 | 1,274.67 ns | 10.788 ns |  9.563 ns | 18.96 |    0.13 | 0.0725 |     - |     - |     152 B |
|                  LinqFaster | 1000 |   100 |   351.04 ns |  4.212 ns |  3.940 ns |  5.22 |    0.08 | 0.6080 |     - |     - |    1272 B |
|                      LinqAF | 1000 |   100 | 3,146.13 ns | 28.854 ns | 25.579 ns | 46.80 |    0.50 |      - |     - |     - |         - |
|                  StructLinq | 1000 |   100 |   335.04 ns |  2.916 ns |  2.727 ns |  4.98 |    0.05 | 0.0458 |     - |     - |      96 B |
|        StructLinq_IFunction | 1000 |   100 |   177.90 ns |  0.435 ns |  0.385 ns |  2.65 |    0.01 |      - |     - |     - |         - |
|           Hyperlinq_Foreach | 1000 |   100 |   271.79 ns |  1.609 ns |  1.426 ns |  4.04 |    0.03 |      - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction | 1000 |   100 |   166.87 ns |  0.640 ns |  0.568 ns |  2.48 |    0.02 |      - |     - |     - |         - |
|               Hyperlinq_For | 1000 |   100 |   305.01 ns |  2.801 ns |  2.483 ns |  4.54 |    0.05 |      - |     - |     - |         - |
|     Hyperlinq_For_IFunction | 1000 |   100 |   142.10 ns |  0.416 ns |  0.369 ns |  2.11 |    0.01 |      - |     - |     - |         - |
