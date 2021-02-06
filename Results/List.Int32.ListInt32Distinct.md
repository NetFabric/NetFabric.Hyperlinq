## List.Int32.ListInt32Distinct

### Source
[ListInt32Distinct.cs](../LinqBenchmarks/List/Int32/ListInt32Distinct.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta32](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta32)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.200-preview.20614.14
  [Host]        : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|               Method | Duplicates | Count |      Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |----------- |------ |----------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop |          4 |   100 |  3.667 μs | 0.0113 μs | 0.0095 μs |  1.00 |    0.00 | 2.8687 |     - |     - |    6008 B |
|          ForeachLoop |          4 |   100 |  4.286 μs | 0.0202 μs | 0.0169 μs |  1.17 |    0.01 | 2.8687 |     - |     - |    6008 B |
|                 Linq |          4 |   100 | 10.865 μs | 0.2167 μs | 0.3738 μs |  2.92 |    0.09 | 2.0599 |     - |     - |    4320 B |
|           LinqFaster |          4 |   100 |  1.047 μs | 0.0209 μs | 0.0462 μs |  0.27 |    0.01 |      - |     - |     - |         - |
|               LinqAF |          4 |   100 | 12.087 μs | 0.1569 μs | 0.1310 μs |  3.30 |    0.04 | 5.9204 |     - |     - |   12400 B |
|           StructLinq |          4 |   100 |  5.647 μs | 0.1098 μs | 0.1643 μs |  1.53 |    0.04 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |          4 |   100 |  5.447 μs | 0.1078 μs | 0.1710 μs |  1.47 |    0.06 |      - |     - |     - |         - |
|            Hyperlinq |          4 |   100 |  6.548 μs | 0.1305 μs | 0.2753 μs |  1.78 |    0.06 |      - |     - |     - |         - |
