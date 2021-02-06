## Enumerable.Int32.EnumerableInt32Distinct

### Source
[EnumerableInt32Distinct.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32Distinct.cs)

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
|               Method | Count |     Mean |     Error |    StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |---------:|----------:|----------:|------:|-------:|------:|------:|----------:|
|          ForeachLoop |   100 | 1.844 μs | 0.0104 μs | 0.0092 μs |  1.00 | 2.8896 |     - |     - |    6048 B |
|                 Linq |   100 | 2.715 μs | 0.0172 μs | 0.0153 μs |  1.47 | 2.0638 |     - |     - |    4320 B |
|               LinqAF |   100 | 3.668 μs | 0.0200 μs | 0.0167 μs |  1.99 | 2.5024 |     - |     - |    5240 B |
|           StructLinq |   100 | 2.056 μs | 0.0048 μs | 0.0040 μs |  1.12 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction |   100 | 2.076 μs | 0.0057 μs | 0.0045 μs |  1.13 | 0.0191 |     - |     - |      40 B |
|            Hyperlinq |   100 | 2.057 μs | 0.0147 μs | 0.0130 μs |  1.12 | 0.0191 |     - |     - |      40 B |
