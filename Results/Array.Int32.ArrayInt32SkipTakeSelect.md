## Array.Int32.ArrayInt32SkipTakeSelect

### Source
[ArrayInt32SkipTakeSelect.cs](../LinqBenchmarks/Array/Int32/ArrayInt32SkipTakeSelect.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.19.2](https://www.nuget.org/packages/StructLinq.BCL/0.19.2)
- NetFabric.Hyperlinq: [3.0.0-beta26](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta26)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.100-preview.7.20366.6
  [Host]        : .NET Core 5.0.0 (CoreCLR 5.0.20.36411, CoreFX 5.0.20.36411), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.0 (CoreCLR 5.0.20.36411, CoreFX 5.0.20.36411), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|               Method | Skip | Count |        Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |----- |------ |------------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop | 1000 |   100 |    54.05 ns |  0.633 ns |  0.561 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop | 1000 |   100 | 2,347.73 ns | 16.144 ns | 14.311 ns | 43.44 |    0.56 | 0.0153 |     - |     - |      32 B |
|                 Linq | 1000 |   100 | 1,055.54 ns |  8.533 ns |  7.982 ns | 19.51 |    0.26 | 0.0725 |     - |     - |     152 B |
|           LinqFaster | 1000 |   100 |   319.15 ns |  4.430 ns |  4.143 ns |  5.91 |    0.11 | 0.6080 |     - |     - |    1272 B |
|               LinqAF | 1000 |   100 | 2,824.73 ns | 31.404 ns | 26.223 ns | 52.28 |    0.75 |      - |     - |     - |         - |
|           StructLinq | 1000 |   100 |   315.37 ns |  3.594 ns |  2.806 ns |  5.83 |    0.08 | 0.0458 |     - |     - |      96 B |
| StructLinq_IFunction | 1000 |   100 |   164.47 ns |  1.610 ns |  1.506 ns |  3.04 |    0.04 |      - |     - |     - |         - |
|    Hyperlinq_Foreach | 1000 |   100 |   280.00 ns |  2.034 ns |  1.699 ns |  5.18 |    0.07 |      - |     - |     - |         - |
|        Hyperlinq_For | 1000 |   100 |   295.78 ns |  3.532 ns |  3.304 ns |  5.47 |    0.07 |      - |     - |     - |         - |
