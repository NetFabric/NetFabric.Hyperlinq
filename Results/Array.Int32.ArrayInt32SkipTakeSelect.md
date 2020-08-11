## Array.Int32.ArrayInt32SkipTakeSelect

### Source
[ArrayInt32SkipTakeSelect.cs](../LinqBenchmarks/Array/Int32/ArrayInt32SkipTakeSelect.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- StructLinq.BCL: [0.19.1](https://www.nuget.org/packages/StructLinq.BCL/0.19.1)
- NetFabric.Hyperlinq: [3.0.0-beta24](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta24)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=macOS Catalina 10.15.6 (19G73) [Darwin 19.6.0]
Intel Core i5-7360U CPU 2.30GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.100-preview.6.20318.15
  [Host]        : .NET Core 5.0.0 (CoreCLR 5.0.20.30506, CoreFX 5.0.20.30506), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.0 (CoreCLR 5.0.20.30506, CoreFX 5.0.20.30506), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|               Method | Skip | Count |        Mean |     Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |----- |------ |------------:|----------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop | 1000 |   100 |    63.52 ns |  0.123 ns | 0.096 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop | 1000 |   100 | 2,836.79 ns | 10.788 ns | 9.563 ns | 44.68 |    0.17 | 0.0153 |     - |     - |      32 B |
|                 Linq | 1000 |   100 | 1,202.00 ns |  1.872 ns | 1.564 ns | 18.92 |    0.04 | 0.0725 |     - |     - |     152 B |
|           LinqFaster | 1000 |   100 |   379.44 ns |  3.014 ns | 2.671 ns |  5.97 |    0.04 | 0.6080 |     - |     - |    1272 B |
|               LinqAF | 1000 |   100 | 3,142.55 ns |  3.527 ns | 3.126 ns | 49.47 |    0.07 |      - |     - |     - |         - |
|           StructLinq | 1000 |   100 | 1,212.29 ns |  1.440 ns | 1.202 ns | 19.09 |    0.03 | 0.0458 |     - |     - |      96 B |
| StructLinq_IFunction | 1000 |   100 | 1,070.45 ns |  2.102 ns | 1.756 ns | 16.85 |    0.04 | 0.0458 |     - |     - |      96 B |
|    Hyperlinq_Foreach | 1000 |   100 |   298.31 ns |  0.673 ns | 0.525 ns |  4.70 |    0.01 |      - |     - |     - |         - |
|        Hyperlinq_For | 1000 |   100 |   355.17 ns |  0.762 ns | 0.713 ns |  5.59 |    0.01 |      - |     - |     - |         - |
