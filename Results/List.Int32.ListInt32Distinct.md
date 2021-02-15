## List.Int32.ListInt32Distinct

### Source
[ListInt32Distinct.cs](../LinqBenchmarks/List/Int32/ListInt32Distinct.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta36](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta36)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.200-preview.21079.7
  [Host]        : .NET Core 5.0.3 (CoreCLR 5.0.321.7212, CoreFX 5.0.321.7212), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.3 (CoreCLR 5.0.321.7212, CoreFX 5.0.321.7212), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|               Method | Duplicates | Count |       Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |----------- |------ |-----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop |          4 |   100 | 3,340.8 ns | 30.33 ns | 25.33 ns |  1.00 |    0.00 | 2.8687 |     - |     - |    6008 B |
|          ForeachLoop |          4 |   100 | 4,260.6 ns | 20.41 ns | 18.09 ns |  1.28 |    0.01 | 2.8687 |     - |     - |    6008 B |
|                 Linq |          4 |   100 | 7,343.2 ns | 17.17 ns | 15.22 ns |  2.20 |    0.02 | 2.0599 |     - |     - |    4320 B |
|           LinqFaster |          4 |   100 |   764.4 ns |  3.44 ns |  3.05 ns |  0.23 |    0.00 |      - |     - |     - |         - |
|               LinqAF |          4 |   100 | 9,569.9 ns | 61.70 ns | 54.70 ns |  2.87 |    0.03 | 5.9204 |     - |     - |   12400 B |
|           StructLinq |          4 |   100 | 3,601.1 ns | 23.35 ns | 21.85 ns |  1.08 |    0.01 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |          4 |   100 | 3,605.5 ns | 15.57 ns | 13.80 ns |  1.08 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq |          4 |   100 | 4,200.2 ns | 12.18 ns | 10.17 ns |  1.26 |    0.01 |      - |     - |     - |         - |
