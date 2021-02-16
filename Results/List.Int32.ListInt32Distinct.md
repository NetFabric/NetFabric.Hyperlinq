## List.Int32.ListInt32Distinct

### Source
[ListInt32Distinct.cs](../LinqBenchmarks/List/Int32/ListInt32Distinct.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta37](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta37)

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
|              ForLoop |          4 |   100 | 3,215.3 ns | 13.09 ns | 11.60 ns |  1.00 |    0.00 | 2.8687 |     - |     - |    6008 B |
|          ForeachLoop |          4 |   100 | 3,932.9 ns | 13.65 ns | 12.10 ns |  1.22 |    0.01 | 2.8687 |     - |     - |    6008 B |
|                 Linq |          4 |   100 | 7,101.3 ns | 22.85 ns | 20.26 ns |  2.21 |    0.01 | 2.0599 |     - |     - |    4320 B |
|           LinqFaster |          4 |   100 |   754.3 ns |  3.63 ns |  3.22 ns |  0.23 |    0.00 |      - |     - |     - |         - |
|               LinqAF |          4 |   100 | 9,143.3 ns | 53.34 ns | 47.29 ns |  2.84 |    0.02 | 5.9204 |     - |     - |   12400 B |
|           StructLinq |          4 |   100 | 3,548.4 ns | 15.59 ns | 13.82 ns |  1.10 |    0.01 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |          4 |   100 | 3,486.8 ns | 10.59 ns |  9.39 ns |  1.08 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq |          4 |   100 | 3,899.5 ns | 15.79 ns | 13.18 ns |  1.21 |    0.01 |      - |     - |     - |         - |
