## Enumerable.Int32.EnumerableInt32SkipTakeWhere

### Source
[EnumerableInt32SkipTakeWhere.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32SkipTakeWhere.cs)

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
|               Method | Skip | Count |     Mean |     Error |    StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |----- |------ |---------:|----------:|----------:|------:|-------:|------:|------:|----------:|
|          ForeachLoop | 1000 |   100 | 2.600 μs | 0.0179 μs | 0.0150 μs |  1.00 | 0.0191 |     - |     - |      40 B |
|                 Linq | 1000 |   100 | 3.830 μs | 0.0123 μs | 0.0115 μs |  1.47 | 0.0992 |     - |     - |     208 B |
|               LinqAF | 1000 |   100 | 4.888 μs | 0.0130 μs | 0.0122 μs |  1.88 | 0.0153 |     - |     - |      40 B |
|           StructLinq | 1000 |   100 | 3.459 μs | 0.0084 μs | 0.0079 μs |  1.33 | 0.0610 |     - |     - |     128 B |
| StructLinq_IFunction | 1000 |   100 | 3.519 μs | 0.0080 μs | 0.0067 μs |  1.35 | 0.0191 |     - |     - |      40 B |
|            Hyperlinq | 1000 |   100 | 3.692 μs | 0.0159 μs | 0.0133 μs |  1.42 | 0.0191 |     - |     - |      40 B |
|  Hyperlinq_IFunction | 1000 |   100 | 3.399 μs | 0.0151 μs | 0.0134 μs |  1.31 | 0.0191 |     - |     - |      40 B |
