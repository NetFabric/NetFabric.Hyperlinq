## List.Int32.ListInt32SkipTakeSelect

### Source
[ListInt32SkipTakeSelect.cs](../LinqBenchmarks/List/Int32/ListInt32SkipTakeSelect.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- StructLinq.BCL: [0.19.1](https://www.nuget.org/packages/StructLinq.BCL/0.19.1)
- NetFabric.Hyperlinq: [3.0.0-beta23](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta23)

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
|              ForLoop | 1000 |   100 |    70.80 ns |  0.193 ns |  0.151 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop | 1000 |   100 | 3,466.60 ns | 21.721 ns | 19.255 ns | 48.96 |    0.31 | 0.0191 |     - |     - |      40 B |
|                 Linq | 1000 |   100 |   936.92 ns |  6.115 ns |  5.720 ns | 13.24 |    0.08 | 0.0725 |     - |     - |     152 B |
|           LinqFaster | 1000 |   100 |   765.46 ns |  4.737 ns |  4.199 ns | 10.82 |    0.06 | 0.6533 |     - |     - |    1368 B |
|           StructLinq | 1000 |   100 |   983.54 ns |  3.743 ns |  3.318 ns | 13.89 |    0.07 | 0.0458 |     - |     - |      96 B |
| StructLinq_IFunction | 1000 |   100 |   783.49 ns |  6.704 ns |  5.943 ns | 11.08 |    0.08 | 0.0458 |     - |     - |      96 B |
|    Hyperlinq_Foreach | 1000 |   100 |   280.31 ns |  1.965 ns |  1.641 ns |  3.96 |    0.03 |      - |     - |     - |         - |
|        Hyperlinq_For | 1000 |   100 |   248.88 ns |  0.952 ns |  0.795 ns |  3.52 |    0.01 |      - |     - |     - |         - |
