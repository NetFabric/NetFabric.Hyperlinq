## List.Int32.ListInt32Select

### Source
[ListInt32Select.cs](../LinqBenchmarks/List/Int32/ListInt32Select.cs)

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
|               Method | Count |     Mean |   Error |  StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |---------:|--------:|--------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop |   100 | 104.9 ns | 0.43 ns | 0.39 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 | 221.6 ns | 1.22 ns | 1.02 ns |  2.11 |    0.01 |      - |     - |     - |         - |
|                 Linq |   100 | 800.2 ns | 6.15 ns | 5.75 ns |  7.63 |    0.07 | 0.0343 |     - |     - |      72 B |
|           LinqFaster |   100 | 325.7 ns | 2.57 ns | 2.40 ns |  3.11 |    0.02 | 0.2179 |     - |     - |     456 B |
|           StructLinq |   100 | 273.2 ns | 2.90 ns | 2.42 ns |  2.61 |    0.02 |      - |     - |     - |         - |
| StructLinq_IFunction |   100 | 159.6 ns | 0.40 ns | 0.35 ns |  1.52 |    0.01 |      - |     - |     - |         - |
|    Hyperlinq_Foreach |   100 | 225.4 ns | 2.23 ns | 1.98 ns |  2.15 |    0.02 |      - |     - |     - |         - |
|        Hyperlinq_For |   100 | 252.1 ns | 0.70 ns | 0.62 ns |  2.40 |    0.01 |      - |     - |     - |         - |
