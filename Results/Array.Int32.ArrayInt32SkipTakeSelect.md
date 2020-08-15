## Array.Int32.ArrayInt32SkipTakeSelect

### Source
[ArrayInt32SkipTakeSelect.cs](../LinqBenchmarks/Array/Int32/ArrayInt32SkipTakeSelect.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [1.0.0](https://www.nuget.org/packages/LinqAF/1.0.0)
- StructLinq.BCL: [0.19.1](https://www.nuget.org/packages/StructLinq.BCL/0.19.1)
- NetFabric.Hyperlinq: [3.0.0-beta25](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta25)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=macOS Catalina 10.15.6 (19G73) [Darwin 19.6.0]
Intel Core i5-7360U CPU 2.30GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.100-preview.6.20318.15
  [Host]        : .NET Core 5.0.0 (CoreCLR 5.0.20.30506, CoreFX 5.0.20.30506), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.0 (CoreCLR 5.0.20.30506, CoreFX 5.0.20.30506), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|               Method | Skip | Count |        Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |----- |------ |------------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop | 1000 |   100 |    62.78 ns |  0.692 ns |  0.613 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop | 1000 |   100 | 3,025.30 ns | 15.459 ns | 14.460 ns | 48.18 |    0.62 | 0.0153 |     - |     - |      32 B |
|                 Linq | 1000 |   100 | 1,260.11 ns |  3.186 ns |  2.660 ns | 20.06 |    0.20 | 0.0725 |     - |     - |     152 B |
|           LinqFaster | 1000 |   100 |   411.22 ns |  0.879 ns |  0.734 ns |  6.55 |    0.07 | 0.6080 |     - |     - |    1272 B |
|               LinqAF | 1000 |   100 | 3,076.08 ns |  3.113 ns |  2.430 ns | 48.95 |    0.48 |      - |     - |     - |         - |
|           StructLinq | 1000 |   100 | 1,240.64 ns |  3.734 ns |  3.118 ns | 19.75 |    0.22 | 0.0458 |     - |     - |      96 B |
| StructLinq_IFunction | 1000 |   100 | 1,060.05 ns | 11.169 ns |  9.326 ns | 16.88 |    0.22 | 0.0458 |     - |     - |      96 B |
|    Hyperlinq_Foreach | 1000 |   100 |   271.40 ns |  0.327 ns |  0.256 ns |  4.32 |    0.04 |      - |     - |     - |         - |
|        Hyperlinq_For | 1000 |   100 |   274.65 ns |  0.507 ns |  0.396 ns |  4.37 |    0.04 |      - |     - |     - |         - |
