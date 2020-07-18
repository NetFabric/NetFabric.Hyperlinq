## ListSkipTakeSelect

### Source
[ListSkipTakeSelect.cs](../LinqBenchmarks/ListSkipTakeSelect.cs)

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
|            Method | Skip | Count |        Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------ |----- |------ |------------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|           ForLoop | 1000 |   100 |    70.17 ns | 0.223 ns | 0.197 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|       ForeachLoop | 1000 |   100 | 3,424.27 ns | 6.035 ns | 5.040 ns | 48.79 |    0.18 | 0.0191 |     - |     - |      40 B |
|              Linq | 1000 |   100 |   939.25 ns | 2.616 ns | 2.319 ns | 13.38 |    0.05 | 0.0725 |     - |     - |     152 B |
| Hyperlinq_Foreach | 1000 |   100 |   238.18 ns | 1.285 ns | 1.202 ns |  3.39 |    0.02 |      - |     - |     - |         - |
|     Hyperlinq_For | 1000 |   100 |   459.77 ns | 1.216 ns | 1.015 ns |  6.55 |    0.03 |      - |     - |     - |         - |
