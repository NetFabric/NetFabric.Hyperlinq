## List.Int32.ListInt32Distinct

### Source
[ListInt32Distinct.cs](../LinqBenchmarks/List/Int32/ListInt32Distinct.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta34](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta34)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.200-preview.20614.14
  [Host]        : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|               Method | Duplicates | Count |       Mean |    Error |   StdDev |     Median | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |----------- |------ |-----------:|---------:|---------:|-----------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop |          4 |   100 | 3,212.0 ns | 12.50 ns | 11.08 ns | 3,209.8 ns |  1.00 |    0.00 | 2.8687 |     - |     - |    6008 B |
|          ForeachLoop |          4 |   100 | 3,938.3 ns | 13.51 ns | 12.64 ns | 3,934.4 ns |  1.23 |    0.01 | 2.8687 |     - |     - |    6008 B |
|                 Linq |          4 |   100 | 7,088.7 ns | 15.35 ns | 14.36 ns | 7,083.3 ns |  2.21 |    0.01 | 2.0599 |     - |     - |    4320 B |
|           LinqFaster |          4 |   100 |   747.8 ns |  1.73 ns |  1.53 ns |   747.2 ns |  0.23 |    0.00 |      - |     - |     - |         - |
|               LinqAF |          4 |   100 | 9,677.3 ns | 18.89 ns | 14.75 ns | 9,673.9 ns |  3.01 |    0.01 | 5.9204 |     - |     - |   12400 B |
|           StructLinq |          4 |   100 | 3,454.7 ns |  7.25 ns |  6.05 ns | 3,454.6 ns |  1.08 |    0.00 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |          4 |   100 | 3,568.6 ns | 70.36 ns | 91.49 ns | 3,512.0 ns |  1.13 |    0.03 |      - |     - |     - |         - |
|            Hyperlinq |          4 |   100 | 3,841.3 ns | 16.85 ns | 15.76 ns | 3,838.3 ns |  1.20 |    0.01 |      - |     - |     - |         - |
