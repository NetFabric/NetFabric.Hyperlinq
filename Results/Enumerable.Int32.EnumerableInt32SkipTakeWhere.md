## Enumerable.Int32.EnumerableInt32SkipTakeWhere

### Source
[EnumerableInt32SkipTakeWhere.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32SkipTakeWhere.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta30](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta30)

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
|          ForeachLoop | 1000 |   100 | 3.073 μs | 0.0119 μs | 0.0106 μs |  1.00 | 0.0191 |     - |     - |      40 B |
|                 Linq | 1000 |   100 | 4.533 μs | 0.0105 μs | 0.0093 μs |  1.48 | 0.0992 |     - |     - |     208 B |
|               LinqAF | 1000 |   100 | 4.529 μs | 0.0181 μs | 0.0161 μs |  1.47 | 0.0153 |     - |     - |      40 B |
|           StructLinq | 1000 |   100 | 3.467 μs | 0.0219 μs | 0.0194 μs |  1.13 | 0.0610 |     - |     - |     128 B |
| StructLinq_IFunction | 1000 |   100 | 3.514 μs | 0.0125 μs | 0.0111 μs |  1.14 | 0.0191 |     - |     - |      40 B |
|            Hyperlinq | 1000 |   100 | 3.223 μs | 0.0057 μs | 0.0050 μs |  1.05 | 0.0191 |     - |     - |      40 B |
|  Hyperlinq_IFunction | 1000 |   100 | 3.415 μs | 0.0149 μs | 0.0139 μs |  1.11 | 0.0191 |     - |     - |      40 B |
