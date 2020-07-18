## ArraySkipTakeSelect

### Source
[ArraySkipTakeSelect.cs](../LinqBenchmarks/ArraySkipTakeSelect.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- StructLinq.BCL: [0.1.9](https://www.nuget.org/packages/StructLinq.BCL/0.1.9)
- NetFabric.Hyperlinq: [3.0.0-beta19](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta19)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.100-preview.6.20318.15
  [Host]        : .NET Core 5.0.0 (CoreCLR 5.0.20.30506, CoreFX 5.0.20.30506), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.0 (CoreCLR 5.0.20.30506, CoreFX 5.0.20.30506), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|            Method | Skip | Count |        Mean |    Error |    StdDev |      Median | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------ |----- |------ |------------:|---------:|----------:|------------:|------:|--------:|-------:|------:|------:|----------:|
|           ForLoop | 1000 |   100 |    62.14 ns | 3.682 ns | 10.798 ns |    56.45 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|       ForeachLoop | 1000 |   100 | 2,567.41 ns | 8.404 ns |  7.861 ns | 2,565.09 ns | 34.74 |    4.34 | 0.0153 |     - |     - |      32 B |
|              Linq | 1000 |   100 | 1,036.12 ns | 2.422 ns |  2.022 ns | 1,036.55 ns | 14.27 |    1.73 | 0.0725 |     - |     - |     152 B |
|        LinqFaster | 1000 |   100 |   243.25 ns | 1.081 ns |  0.903 ns |   243.07 ns |  3.35 |    0.41 | 0.2027 |     - |     - |     424 B |
| Hyperlinq_Foreach | 1000 |   100 |   257.36 ns | 0.729 ns |  0.646 ns |   257.23 ns |  3.52 |    0.43 |      - |     - |     - |         - |
|     Hyperlinq_For | 1000 |   100 |   456.97 ns | 0.889 ns |  0.788 ns |   456.94 ns |  6.24 |    0.76 |      - |     - |     - |         - |
