## Array.Int32.ArrayInt32Distinct

### Source
[ArrayInt32Distinct.cs](../LinqBenchmarks/Array/Int32/ArrayInt32Distinct.cs)

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
|               Method | Duplicates | Count |      Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |----------- |------ |----------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop |          4 |   100 |  3.558 μs | 0.0276 μs | 0.0258 μs |  1.00 |    0.00 | 2.8687 |     - |     - |    6008 B |
|          ForeachLoop |          4 |   100 |  3.522 μs | 0.0501 μs | 0.0391 μs |  0.99 |    0.02 | 2.8687 |     - |     - |    6008 B |
|                 Linq |          4 |   100 |  8.878 μs | 0.0714 μs | 0.0668 μs |  2.50 |    0.02 | 2.0599 |     - |     - |    4312 B |
|               LinqAF |          4 |   100 | 11.634 μs | 0.1514 μs | 0.1416 μs |  3.27 |    0.04 | 5.9204 |     - |     - |   12400 B |
|           StructLinq |          4 |   100 |  5.713 μs | 0.1040 μs | 0.1423 μs |  1.59 |    0.05 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |          4 |   100 |  5.391 μs | 0.1014 μs | 0.0948 μs |  1.52 |    0.03 |      - |     - |     - |         - |
|            Hyperlinq |          4 |   100 |  5.168 μs | 0.0582 μs | 0.0516 μs |  1.45 |    0.02 |      - |     - |     - |         - |
