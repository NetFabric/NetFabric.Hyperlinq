## Array.Int32.ArrayInt32Distinct

### Source
[ArrayInt32Distinct.cs](../LinqBenchmarks/Array/Int32/ArrayInt32Distinct.cs)

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
|               Method | Duplicates | Count |     Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |----------- |------ |---------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop |          4 |   100 | 3.015 μs | 0.0074 μs | 0.0062 μs |  1.00 |    0.00 | 2.8687 |     - |     - |    6008 B |
|          ForeachLoop |          4 |   100 | 3.210 μs | 0.0102 μs | 0.0095 μs |  1.07 |    0.00 | 2.8687 |     - |     - |    6008 B |
|                 Linq |          4 |   100 | 7.719 μs | 0.0940 μs | 0.0880 μs |  2.55 |    0.02 | 2.0599 |     - |     - |    4312 B |
|               LinqAF |          4 |   100 | 8.604 μs | 0.0436 μs | 0.0387 μs |  2.85 |    0.01 | 5.9204 |     - |     - |   12400 B |
|           StructLinq |          4 |   100 | 4.548 μs | 0.0904 μs | 0.1460 μs |  1.50 |    0.05 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |          4 |   100 | 4.724 μs | 0.0915 μs | 0.1053 μs |  1.57 |    0.04 |      - |     - |     - |         - |
|            Hyperlinq |          4 |   100 | 5.770 μs | 0.1141 μs | 0.2842 μs |  1.92 |    0.08 |      - |     - |     - |         - |
