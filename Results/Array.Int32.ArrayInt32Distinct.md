## Array.Int32.ArrayInt32Distinct

### Source
[ArrayInt32Distinct.cs](../LinqBenchmarks/Array/Int32/ArrayInt32Distinct.cs)

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
|               Method | Duplicates | Count |     Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |----------- |------ |---------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop |          4 |   100 | 3.023 μs | 0.0402 μs | 0.0335 μs |  1.00 |    0.00 | 2.8687 |     - |     - |    6008 B |
|          ForeachLoop |          4 |   100 | 3.188 μs | 0.0104 μs | 0.0092 μs |  1.05 |    0.01 | 2.8687 |     - |     - |    6008 B |
|                 Linq |          4 |   100 | 7.598 μs | 0.0634 μs | 0.0495 μs |  2.51 |    0.04 | 2.0599 |     - |     - |    4312 B |
|               LinqAF |          4 |   100 | 8.642 μs | 0.0591 μs | 0.0494 μs |  2.86 |    0.04 | 5.9204 |     - |     - |   12400 B |
|           StructLinq |          4 |   100 | 4.345 μs | 0.0868 μs | 0.1544 μs |  1.44 |    0.04 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |          4 |   100 | 4.539 μs | 0.0893 μs | 0.1824 μs |  1.50 |    0.07 |      - |     - |     - |         - |
|            Hyperlinq |          4 |   100 | 5.614 μs | 0.1115 μs | 0.2672 μs |  1.87 |    0.09 |      - |     - |     - |         - |
