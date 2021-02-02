## List.Int32.ListInt32Distinct

### Source
[ListInt32Distinct.cs](../LinqBenchmarks/List/Int32/ListInt32Distinct.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta30](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta30)

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
|              ForLoop |          4 |   100 | 3,212.7 ns | 10.42 ns |  9.23 ns |  1.00 | 2.8687 |     - |     - |    6008 B |
|          ForeachLoop |          4 |   100 | 4,170.1 ns | 14.02 ns | 12.43 ns |  1.30 | 2.8687 |     - |     - |    6008 B |
|                 Linq |          4 |   100 | 7,932.6 ns | 43.30 ns | 36.16 ns |  2.47 | 2.0599 |     - |     - |    4320 B |
|           LinqFaster |          4 |   100 |   726.9 ns |  2.15 ns |  1.91 ns |  0.23 |      - |     - |     - |         - |
|               LinqAF |          4 |   100 | 9,322.7 ns | 46.28 ns | 41.03 ns |  2.90 | 5.9204 |     - |     - |   12400 B |
|           StructLinq |          4 |   100 | 3,379.6 ns |  7.61 ns |  6.36 ns |  1.05 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |          4 |   100 | 3,399.6 ns | 11.21 ns |  9.94 ns |  1.06 |      - |     - |     - |         - |
|            Hyperlinq |          4 |   100 | 3,923.4 ns | 11.35 ns | 10.62 ns |  1.22 |      - |     - |     - |         - |
