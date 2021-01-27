## Enumerable.Int32.EnumerableInt32Distinct

### Source
[EnumerableInt32Distinct.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32Distinct.cs)

### References:
- Cistern.ValueLinq: [0.0.11](https://www.nuget.org/packages/Cistern.ValueLinq/0.0.11)
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
|               Method | Count |     Mean |     Error |    StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |---------:|----------:|----------:|------:|-------:|------:|------:|----------:|
|          ForeachLoop |   100 | 1.822 μs | 0.0073 μs | 0.0061 μs |  1.00 | 2.8896 |     - |     - |    6048 B |
|                 Linq |   100 | 2.600 μs | 0.0112 μs | 0.0099 μs |  1.43 | 2.0638 |     - |     - |    4320 B |
|               LinqAF |   100 | 3.814 μs | 0.0158 μs | 0.0140 μs |  2.09 | 2.5024 |     - |     - |    5240 B |
|           StructLinq |   100 | 2.192 μs | 0.0089 μs | 0.0079 μs |  1.20 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction |   100 | 2.315 μs | 0.0085 μs | 0.0075 μs |  1.27 | 0.0191 |     - |     - |      40 B |
|            Hyperlinq |   100 | 2.038 μs | 0.0091 μs | 0.0071 μs |  1.12 | 0.0191 |     - |     - |      40 B |
