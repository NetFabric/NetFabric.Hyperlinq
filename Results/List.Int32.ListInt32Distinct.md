## List.Int32.ListInt32Distinct

### Source
[ListInt32Distinct.cs](../LinqBenchmarks/List/Int32/ListInt32Distinct.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.19.2](https://www.nuget.org/packages/StructLinq.BCL/0.19.2)
- NetFabric.Hyperlinq: [3.0.0-beta27](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta27)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.200-preview.20614.14
  [Host]        : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|               Method | Duplicates | Count |        Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |----------- |------ |------------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop |          4 |   100 |  4,179.2 ns |  25.04 ns |  23.42 ns |  1.00 |    0.00 | 2.8687 |     - |     - |    6008 B |
|          ForeachLoop |          4 |   100 |  4,860.8 ns |  41.54 ns |  36.82 ns |  1.16 |    0.01 | 2.8687 |     - |     - |    6008 B |
|                 Linq |          4 |   100 | 11,335.7 ns | 225.86 ns | 293.68 ns |  2.73 |    0.06 | 2.0599 |     - |     - |    4320 B |
|           LinqFaster |          4 |   100 |    917.0 ns |  14.84 ns |  13.88 ns |  0.22 |    0.00 |      - |     - |     - |         - |
|               LinqAF |          4 |   100 | 14,420.3 ns | 177.42 ns | 157.28 ns |  3.45 |    0.04 | 5.9204 |     - |     - |   12400 B |
|           StructLinq |          4 |   100 |  5,991.4 ns |  53.06 ns |  47.03 ns |  1.43 |    0.01 | 0.0153 |     - |     - |      40 B |
| StructLinq_IFunction |          4 |   100 |  5,328.4 ns |  68.60 ns |  64.17 ns |  1.28 |    0.02 |      - |     - |     - |         - |
|            Hyperlinq |          4 |   100 |  5,547.7 ns | 108.13 ns | 106.20 ns |  1.33 |    0.03 |      - |     - |     - |         - |
