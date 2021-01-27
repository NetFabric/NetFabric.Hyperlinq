## List.Int32.ListInt32Distinct

### Source
[ListInt32Distinct.cs](../LinqBenchmarks/List/Int32/ListInt32Distinct.cs)

### References:
- Cistern.ValueLinq: [0.0.11](https://www.nuget.org/packages/Cistern.ValueLinq/0.0.11)
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
|               Method | Duplicates | Count |       Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |----------- |------ |-----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop |          4 |   100 | 3,203.8 ns | 10.66 ns |  9.45 ns |  1.00 |    0.00 | 2.8687 |     - |     - |    6008 B |
|          ForeachLoop |          4 |   100 | 4,109.8 ns | 15.21 ns | 12.70 ns |  1.28 |    0.01 | 2.8687 |     - |     - |    6008 B |
|                 Linq |          4 |   100 | 7,874.7 ns | 22.74 ns | 20.16 ns |  2.46 |    0.01 | 2.0599 |     - |     - |    4320 B |
|           LinqFaster |          4 |   100 |   723.4 ns |  2.34 ns |  2.19 ns |  0.23 |    0.00 |      - |     - |     - |         - |
|               LinqAF |          4 |   100 | 9,249.5 ns | 48.04 ns | 42.58 ns |  2.89 |    0.02 | 5.9204 |     - |     - |   12400 B |
|           StructLinq |          4 |   100 | 3,931.6 ns |  8.32 ns |  7.37 ns |  1.23 |    0.00 | 0.0153 |     - |     - |      40 B |
| StructLinq_IFunction |          4 |   100 | 4,021.6 ns | 22.97 ns | 17.94 ns |  1.26 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq |          4 |   100 | 4,140.5 ns | 12.92 ns | 11.45 ns |  1.29 |    0.01 |      - |     - |     - |         - |
