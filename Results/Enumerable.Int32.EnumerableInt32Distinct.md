## Enumerable.Int32.EnumerableInt32Distinct

### Source
[EnumerableInt32Distinct.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32Distinct.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta37](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta37)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.200-preview.21079.7
  [Host]        : .NET Core 5.0.3 (CoreCLR 5.0.321.7212, CoreFX 5.0.321.7212), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.3 (CoreCLR 5.0.321.7212, CoreFX 5.0.321.7212), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|               Method | Count |     Mean |     Error |    StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |---------:|----------:|----------:|------:|-------:|------:|------:|----------:|
|          ForeachLoop |   100 | 1.789 μs | 0.0083 μs | 0.0073 μs |  1.00 | 2.8896 |     - |     - |    6048 B |
|                 Linq |   100 | 2.594 μs | 0.0142 μs | 0.0126 μs |  1.45 | 2.0638 |     - |     - |    4320 B |
|               LinqAF |   100 | 3.663 μs | 0.0165 μs | 0.0146 μs |  2.05 | 2.5024 |     - |     - |    5240 B |
|           StructLinq |   100 | 2.183 μs | 0.0045 μs | 0.0038 μs |  1.22 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction |   100 | 2.037 μs | 0.0071 μs | 0.0067 μs |  1.14 | 0.0191 |     - |     - |      40 B |
|            Hyperlinq |   100 | 2.142 μs | 0.0095 μs | 0.0085 μs |  1.20 | 0.0191 |     - |     - |      40 B |
