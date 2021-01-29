## Array.Int32.ArrayInt32Distinct

### Source
[ArrayInt32Distinct.cs](../LinqBenchmarks/Array/Int32/ArrayInt32Distinct.cs)

### References:
- Cistern.ValueLinq: [0.0.11](https://www.nuget.org/packages/Cistern.ValueLinq/0.0.11)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta28](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta28)

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
|              ForLoop |          4 |   100 | 3.333 μs | 0.0367 μs | 0.0343 μs |  1.00 |    0.00 | 2.8687 |     - |     - |    6008 B |
|          ForeachLoop |          4 |   100 | 3.338 μs | 0.0374 μs | 0.0292 μs |  1.00 |    0.02 | 2.8687 |     - |     - |    6008 B |
|                 Linq |          4 |   100 | 7.322 μs | 0.0759 μs | 0.0710 μs |  2.20 |    0.03 | 2.0599 |     - |     - |    4312 B |
|               LinqAF |          4 |   100 | 9.395 μs | 0.1203 μs | 0.1126 μs |  2.82 |    0.05 | 5.9204 |     - |     - |   12400 B |
|           StructLinq |          4 |   100 | 3.786 μs | 0.0562 μs | 0.0469 μs |  1.14 |    0.02 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |          4 |   100 | 3.929 μs | 0.0742 μs | 0.0762 μs |  1.18 |    0.03 |      - |     - |     - |         - |
|            Hyperlinq |          4 |   100 | 4.159 μs | 0.0582 μs | 0.0545 μs |  1.25 |    0.02 |      - |     - |     - |         - |
