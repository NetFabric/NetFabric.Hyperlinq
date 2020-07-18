## ArrayWhere

### Source
[ArrayWhere.cs](../LinqBenchmarks/ArrayWhere.cs)

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
|               Method | Count |      Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop |   100 |  78.82 ns | 0.235 ns | 0.196 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 |  64.20 ns | 0.231 ns | 0.205 ns |  0.81 |    0.00 |      - |     - |     - |         - |
|                 Linq |   100 | 442.69 ns | 0.912 ns | 0.761 ns |  5.62 |    0.02 | 0.0229 |     - |     - |      48 B |
|           LinqFaster |   100 | 289.50 ns | 2.971 ns | 2.779 ns |  3.68 |    0.03 | 0.3095 |     - |     - |     648 B |
|           StructLinq |   100 | 309.57 ns | 0.785 ns | 0.695 ns |  3.93 |    0.01 |      - |     - |     - |         - |
| StructLinq_IFunction |   100 | 161.77 ns | 0.399 ns | 0.354 ns |  2.05 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq |   100 | 330.99 ns | 0.492 ns | 0.436 ns |  4.20 |    0.01 |      - |     - |     - |         - |
