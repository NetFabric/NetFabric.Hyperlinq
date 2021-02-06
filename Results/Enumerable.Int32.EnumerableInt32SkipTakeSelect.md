## Enumerable.Int32.EnumerableInt32SkipTakeSelect

### Source
[EnumerableInt32SkipTakeSelect.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32SkipTakeSelect.cs)

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
|                      Method | Skip | Count |     Mean |     Error |    StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------- |----- |------ |---------:|----------:|----------:|------:|-------:|------:|------:|----------:|
|                 ForeachLoop | 1000 |   100 | 3.086 μs | 0.0086 μs | 0.0072 μs |  1.00 | 0.0191 |     - |     - |      40 B |
|                        Linq | 1000 |   100 | 4.708 μs | 0.0287 μs | 0.0269 μs |  1.53 | 0.0992 |     - |     - |     208 B |
|                      LinqAF | 1000 |   100 | 4.219 μs | 0.0179 μs | 0.0159 μs |  1.37 | 0.0153 |     - |     - |      40 B |
|                  StructLinq | 1000 |   100 | 3.814 μs | 0.0094 μs | 0.0088 μs |  1.24 | 0.0610 |     - |     - |     128 B |
|        StructLinq_IFunction | 1000 |   100 | 3.379 μs | 0.0090 μs | 0.0080 μs |  1.09 | 0.0191 |     - |     - |      40 B |
|           Hyperlinq_Foreach | 1000 |   100 | 3.921 μs | 0.0113 μs | 0.0100 μs |  1.27 | 0.0153 |     - |     - |      40 B |
| Hyperlinq_Foreach_IFunction | 1000 |   100 | 3.713 μs | 0.0066 μs | 0.0055 μs |  1.20 | 0.0191 |     - |     - |      40 B |
