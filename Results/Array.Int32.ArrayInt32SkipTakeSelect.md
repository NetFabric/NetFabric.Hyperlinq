## Array.Int32.ArrayInt32SkipTakeSelect

### Source
[ArrayInt32SkipTakeSelect.cs](../LinqBenchmarks/Array/Int32/ArrayInt32SkipTakeSelect.cs)

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
|              ForLoop | 1000 |   100 |    53.70 ns |  0.435 ns |  0.407 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop | 1000 |   100 | 2,312.24 ns | 14.718 ns | 13.767 ns | 43.06 |    0.44 | 0.0153 |     - |     - |      32 B |
|                 Linq | 1000 |   100 |   960.89 ns | 10.916 ns | 10.211 ns | 17.89 |    0.29 | 0.0725 |     - |     - |     152 B |
|           LinqFaster | 1000 |   100 |   340.29 ns |  6.585 ns |  5.838 ns |  6.33 |    0.11 | 0.6080 |     - |     - |    1272 B |
|           StructLinq | 1000 |   100 | 1,122.47 ns |  7.676 ns |  7.180 ns | 20.90 |    0.20 | 0.0458 |     - |     - |      96 B |
| StructLinq_IFunction | 1000 |   100 |   835.55 ns |  5.632 ns |  5.268 ns | 15.56 |    0.17 | 0.0458 |     - |     - |      96 B |
|    Hyperlinq_Foreach | 1000 |   100 |   302.59 ns |  1.938 ns |  1.813 ns |  5.63 |    0.05 |      - |     - |     - |         - |
|        Hyperlinq_For | 1000 |   100 |   301.53 ns |  1.727 ns |  1.615 ns |  5.62 |    0.06 |      - |     - |     - |         - |
