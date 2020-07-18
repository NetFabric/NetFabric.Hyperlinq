## ListSelect

### Source
[ListSelect.cs](../LinqBenchmarks/ListSelect.cs)

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
|               Method | Count |     Mean |   Error |  StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |---------:|--------:|--------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop |   100 | 103.9 ns | 0.28 ns | 0.26 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 | 198.3 ns | 4.00 ns | 3.93 ns |  1.91 |    0.04 |      - |     - |     - |         - |
|                 Linq |   100 | 728.8 ns | 2.60 ns | 2.17 ns |  7.02 |    0.03 | 0.0343 |     - |     - |      72 B |
|           LinqFaster |   100 | 337.8 ns | 1.14 ns | 1.01 ns |  3.25 |    0.01 | 0.2179 |     - |     - |     456 B |
|           StructLinq |   100 | 268.9 ns | 0.87 ns | 0.77 ns |  2.59 |    0.01 |      - |     - |     - |         - |
| StructLinq_IFunction |   100 | 157.4 ns | 0.33 ns | 0.29 ns |  1.51 |    0.00 |      - |     - |     - |         - |
|    Hyperlinq_Foreach |   100 | 277.0 ns | 1.11 ns | 1.04 ns |  2.67 |    0.01 |      - |     - |     - |         - |
|        Hyperlinq_For |   100 | 451.4 ns | 0.89 ns | 0.84 ns |  4.34 |    0.02 |      - |     - |     - |         - |
