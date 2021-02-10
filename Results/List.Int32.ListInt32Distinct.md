## List.Int32.ListInt32Distinct

### Source
[ListInt32Distinct.cs](../LinqBenchmarks/List/Int32/ListInt32Distinct.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta35](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta35)

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
|              ForLoop |          4 |   100 | 3,207.7 ns |  8.57 ns |  8.01 ns |  1.00 |    0.00 | 2.8687 |     - |     - |    6008 B |
|          ForeachLoop |          4 |   100 | 4,124.3 ns | 13.75 ns | 12.19 ns |  1.29 |    0.00 | 2.8687 |     - |     - |    6008 B |
|                 Linq |          4 |   100 | 7,186.5 ns | 19.85 ns | 16.58 ns |  2.24 |    0.01 | 2.0599 |     - |     - |    4320 B |
|           LinqFaster |          4 |   100 |   733.3 ns |  1.86 ns |  1.74 ns |  0.23 |    0.00 |      - |     - |     - |         - |
|               LinqAF |          4 |   100 | 9,341.3 ns | 45.78 ns | 38.23 ns |  2.91 |    0.02 | 5.9204 |     - |     - |   12400 B |
|           StructLinq |          4 |   100 | 3,460.7 ns |  9.58 ns |  8.49 ns |  1.08 |    0.00 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |          4 |   100 | 3,534.5 ns | 11.71 ns | 10.38 ns |  1.10 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq |          4 |   100 | 4,073.4 ns |  9.14 ns |  8.10 ns |  1.27 |    0.00 |      - |     - |     - |         - |
