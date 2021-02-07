## Array.Int32.ArrayInt32Distinct

### Source
[ArrayInt32Distinct.cs](../LinqBenchmarks/Array/Int32/ArrayInt32Distinct.cs)

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
|               Method | Duplicates | Count |     Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |----------- |------ |---------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop |          4 |   100 | 3.023 μs | 0.0110 μs | 0.0086 μs |  1.00 |    0.00 | 2.8687 |     - |     - |    6008 B |
|          ForeachLoop |          4 |   100 | 3.012 μs | 0.0056 μs | 0.0052 μs |  1.00 |    0.00 | 2.8687 |     - |     - |    6008 B |
|                 Linq |          4 |   100 | 6.764 μs | 0.0388 μs | 0.0626 μs |  2.23 |    0.02 | 2.0599 |     - |     - |    4312 B |
|               LinqAF |          4 |   100 | 8.101 μs | 0.0457 μs | 0.0381 μs |  2.68 |    0.02 | 5.9204 |     - |     - |   12400 B |
|           StructLinq |          4 |   100 | 3.664 μs | 0.0294 μs | 0.0260 μs |  1.21 |    0.01 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |          4 |   100 | 3.583 μs | 0.0066 μs | 0.0062 μs |  1.19 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq |          4 |   100 | 3.753 μs | 0.0107 μs | 0.0089 μs |  1.24 |    0.01 |      - |     - |     - |         - |
