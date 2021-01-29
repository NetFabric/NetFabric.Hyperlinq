## List.Int32.ListInt32Distinct

### Source
[ListInt32Distinct.cs](../LinqBenchmarks/List/Int32/ListInt32Distinct.cs)

### References:
- Cistern.ValueLinq: [0.0.11](https://www.nuget.org/packages/Cistern.ValueLinq/0.0.11)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta28](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta28)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.200-preview.20614.14
  [Host]        : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|               Method | Duplicates | Count |        Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |----------- |------ |------------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop |          4 |   100 |  3,618.3 ns | 19.70 ns | 17.46 ns |  1.00 |    0.00 | 2.8687 |     - |     - |    6008 B |
|          ForeachLoop |          4 |   100 |  4,697.3 ns | 16.07 ns | 13.42 ns |  1.30 |    0.01 | 2.8687 |     - |     - |    6008 B |
|                 Linq |          4 |   100 |  8,869.2 ns | 86.04 ns | 71.84 ns |  2.45 |    0.02 | 2.0599 |     - |     - |    4320 B |
|           LinqFaster |          4 |   100 |    806.3 ns |  3.26 ns |  2.89 ns |  0.22 |    0.00 |      - |     - |     - |         - |
|               LinqAF |          4 |   100 | 10,833.0 ns | 51.01 ns | 45.22 ns |  2.99 |    0.02 | 5.9204 |     - |     - |   12400 B |
|           StructLinq |          4 |   100 |  3,780.8 ns | 16.46 ns | 14.60 ns |  1.04 |    0.01 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |          4 |   100 |  3,775.1 ns | 23.53 ns | 20.86 ns |  1.04 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq |          4 |   100 |  4,443.6 ns | 15.93 ns | 14.12 ns |  1.23 |    0.01 |      - |     - |     - |         - |
