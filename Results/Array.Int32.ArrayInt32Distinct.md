## Array.Int32.ArrayInt32Distinct

### Source
[ArrayInt32Distinct.cs](../LinqBenchmarks/Array/Int32/ArrayInt32Distinct.cs)

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
|               Method | Duplicates | Count |     Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |----------- |------ |---------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop |          4 |   100 | 3.023 μs | 0.0198 μs | 0.0175 μs |  1.00 |    0.00 | 2.8687 |     - |     - |    6008 B |
|          ForeachLoop |          4 |   100 | 3.201 μs | 0.0151 μs | 0.0141 μs |  1.06 |    0.01 | 2.8687 |     - |     - |    6008 B |
|                 Linq |          4 |   100 | 7.690 μs | 0.1528 μs | 0.1276 μs |  2.54 |    0.05 | 2.0599 |     - |     - |    4312 B |
|               LinqAF |          4 |   100 | 8.540 μs | 0.0570 μs | 0.0533 μs |  2.82 |    0.02 | 5.9204 |     - |     - |   12400 B |
|           StructLinq |          4 |   100 | 4.745 μs | 0.0934 μs | 0.1887 μs |  1.57 |    0.06 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |          4 |   100 | 4.812 μs | 0.0960 μs | 0.1779 μs |  1.58 |    0.06 |      - |     - |     - |         - |
|            Hyperlinq |          4 |   100 | 5.915 μs | 0.1182 μs | 0.2877 μs |  1.95 |    0.10 |      - |     - |     - |         - |
