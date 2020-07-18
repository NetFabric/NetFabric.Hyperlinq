## ListSelect

- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- StructLinq.BCL: [0.1.9](https://www.nuget.org/packages/StructLinq.BCL/0.1.9)
- NetFabric.Hyperlinq: [3.0.0-beta19](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta19)

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
|              ForLoop |   100 | 105.2 ns | 0.98 ns | 0.92 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 | 220.7 ns | 1.10 ns | 1.03 ns |  2.10 |    0.02 |      - |     - |     - |         - |
|                 Linq |   100 | 745.7 ns | 5.82 ns | 5.44 ns |  7.09 |    0.08 | 0.0343 |     - |     - |      72 B |
|           LinqFaster |   100 | 341.3 ns | 3.12 ns | 2.92 ns |  3.24 |    0.04 | 0.2179 |     - |     - |     456 B |
|           StructLinq |   100 | 272.4 ns | 2.57 ns | 2.41 ns |  2.59 |    0.03 |      - |     - |     - |         - |
| StructLinq_IFunction |   100 | 160.0 ns | 1.84 ns | 1.64 ns |  1.52 |    0.02 |      - |     - |     - |         - |
|    Hyperlinq_Foreach |   100 | 281.0 ns | 2.57 ns | 2.14 ns |  2.67 |    0.03 |      - |     - |     - |         - |
|        Hyperlinq_For |   100 | 456.5 ns | 4.51 ns | 4.21 ns |  4.34 |    0.05 |      - |     - |     - |         - |
