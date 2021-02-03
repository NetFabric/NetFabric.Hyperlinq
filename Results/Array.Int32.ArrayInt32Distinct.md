## Array.Int32.ArrayInt32Distinct

### Source
[ArrayInt32Distinct.cs](../LinqBenchmarks/Array/Int32/ArrayInt32Distinct.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta31](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta31)

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
|              ForLoop |          4 |   100 | 3.045 μs | 0.0495 μs | 0.0463 μs |  1.00 |    0.00 | 2.8687 |     - |     - |    6008 B |
|          ForeachLoop |          4 |   100 | 3.230 μs | 0.0192 μs | 0.0180 μs |  1.06 |    0.02 | 2.8687 |     - |     - |    6008 B |
|                 Linq |          4 |   100 | 7.631 μs | 0.1355 μs | 0.1202 μs |  2.51 |    0.06 | 2.0599 |     - |     - |    4312 B |
|               LinqAF |          4 |   100 | 8.673 μs | 0.0918 μs | 0.0859 μs |  2.85 |    0.06 | 5.9204 |     - |     - |   12400 B |
|           StructLinq |          4 |   100 | 4.537 μs | 0.0896 μs | 0.1570 μs |  1.50 |    0.06 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |          4 |   100 | 4.840 μs | 0.0962 μs | 0.1660 μs |  1.60 |    0.06 |      - |     - |     - |         - |
|            Hyperlinq |          4 |   100 | 5.590 μs | 0.1113 μs | 0.2324 μs |  1.85 |    0.09 |      - |     - |     - |         - |
