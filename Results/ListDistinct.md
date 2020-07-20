## ListDistinct

### Source
[ListDistinct.cs](../LinqBenchmarks/ListDistinct.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- StructLinq.BCL: [0.1.9](https://www.nuget.org/packages/StructLinq.BCL/0.1.9)
- NetFabric.Hyperlinq: [3.0.0-beta19](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta19)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.100-preview.6.20318.15
  [Host]        : .NET Core 5.0.0 (CoreCLR 5.0.20.30506, CoreFX 5.0.20.30506), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.0 (CoreCLR 5.0.20.30506, CoreFX 5.0.20.30506), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|               Method | Duplicates | Count |       Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |----------- |------ |-----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop |          4 |   100 |   937.4 ns |  8.03 ns |  6.27 ns |  1.00 |    0.00 | 0.6304 |     - |     - |    1320 B |
|          ForeachLoop |          4 |   100 | 1,028.3 ns |  8.72 ns |  6.81 ns |  1.10 |    0.01 | 0.6294 |     - |     - |    1320 B |
|                 Linq |          4 |   100 | 1,855.0 ns | 17.00 ns | 15.07 ns |  1.98 |    0.02 | 0.5569 |     - |     - |    1168 B |
|           LinqFaster |          4 |   100 |   150.2 ns |  1.86 ns |  1.55 ns |  0.16 |    0.00 |      - |     - |     - |         - |
|           StructLinq |          4 |   100 | 1,505.9 ns | 10.30 ns |  9.63 ns |  1.61 |    0.02 |      - |     - |     - |         - |
| StructLinq_IFunction |          4 |   100 | 1,168.4 ns |  5.79 ns |  4.83 ns |  1.25 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq |          4 |   100 | 1,155.2 ns | 13.42 ns | 11.90 ns |  1.23 |    0.01 |      - |     - |     - |         - |
