## Enumerable.Int32.EnumerableInt32SkipTakeSelect

### Source
[EnumerableInt32SkipTakeSelect.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32SkipTakeSelect.cs)

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
|                      Method | Skip | Count |     Mean |     Error |    StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------- |----- |------ |---------:|----------:|----------:|------:|-------:|------:|------:|----------:|
|                 ForeachLoop | 1000 |   100 | 3.072 μs | 0.0043 μs | 0.0038 μs |  1.00 | 0.0191 |     - |     - |      40 B |
|                        Linq | 1000 |   100 | 4.683 μs | 0.0157 μs | 0.0131 μs |  1.52 | 0.0992 |     - |     - |     208 B |
|                      LinqAF | 1000 |   100 | 4.628 μs | 0.0223 μs | 0.0198 μs |  1.51 | 0.0153 |     - |     - |      40 B |
|                  StructLinq | 1000 |   100 | 3.800 μs | 0.0103 μs | 0.0091 μs |  1.24 | 0.0610 |     - |     - |     128 B |
|        StructLinq_IFunction | 1000 |   100 | 3.373 μs | 0.0148 μs | 0.0124 μs |  1.10 | 0.0191 |     - |     - |      40 B |
|           Hyperlinq_Foreach | 1000 |   100 | 3.112 μs | 0.0107 μs | 0.0084 μs |  1.01 | 0.0191 |     - |     - |      40 B |
| Hyperlinq_Foreach_IFunction | 1000 |   100 | 3.743 μs | 0.0076 μs | 0.0059 μs |  1.22 | 0.0191 |     - |     - |      40 B |
