## List.Int32.ListInt32Distinct

### Source
[ListInt32Distinct.cs](../LinqBenchmarks/List/Int32/ListInt32Distinct.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta33](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta33)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.200-preview.20614.14
  [Host]        : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|               Method | Duplicates | Count |       Mean |    Error |   StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |----------- |------ |-----------:|---------:|---------:|------:|-------:|------:|------:|----------:|
|              ForLoop |          4 |   100 | 3,194.5 ns |  7.20 ns |  6.73 ns |  1.00 | 2.8687 |     - |     - |    6008 B |
|          ForeachLoop |          4 |   100 | 4,132.5 ns | 21.43 ns | 18.99 ns |  1.29 | 2.8687 |     - |     - |    6008 B |
|                 Linq |          4 |   100 | 7,850.2 ns | 18.35 ns | 16.26 ns |  2.46 | 2.0599 |     - |     - |    4320 B |
|           LinqFaster |          4 |   100 |   721.8 ns |  1.58 ns |  1.48 ns |  0.23 |      - |     - |     - |         - |
|               LinqAF |          4 |   100 | 9,171.9 ns | 36.48 ns | 30.46 ns |  2.87 | 5.9204 |     - |     - |   12400 B |
|           StructLinq |          4 |   100 | 3,379.6 ns | 10.78 ns |  9.56 ns |  1.06 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |          4 |   100 | 3,380.3 ns |  8.51 ns |  7.54 ns |  1.06 |      - |     - |     - |         - |
|            Hyperlinq |          4 |   100 | 3,793.1 ns |  8.30 ns |  7.76 ns |  1.19 |      - |     - |     - |         - |
