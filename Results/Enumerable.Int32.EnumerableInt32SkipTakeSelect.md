## Enumerable.Int32.EnumerableInt32SkipTakeSelect

### Source
[EnumerableInt32SkipTakeSelect.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32SkipTakeSelect.cs)

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
|                      Method | Skip | Count |     Mean |     Error |    StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------- |----- |------ |---------:|----------:|----------:|------:|-------:|------:|------:|----------:|
|                 ForeachLoop | 1000 |   100 | 3.031 μs | 0.0110 μs | 0.0098 μs |  1.00 | 0.0191 |     - |     - |      40 B |
|                        Linq | 1000 |   100 | 4.162 μs | 0.0136 μs | 0.0113 μs |  1.37 | 0.0992 |     - |     - |     208 B |
|                      LinqAF | 1000 |   100 | 4.957 μs | 0.0147 μs | 0.0131 μs |  1.64 | 0.0153 |     - |     - |      40 B |
|                  StructLinq | 1000 |   100 | 3.318 μs | 0.0094 μs | 0.0079 μs |  1.09 | 0.0610 |     - |     - |     128 B |
|        StructLinq_IFunction | 1000 |   100 | 3.131 μs | 0.0154 μs | 0.0137 μs |  1.03 | 0.0191 |     - |     - |      40 B |
|           Hyperlinq_Foreach | 1000 |   100 | 3.632 μs | 0.0075 μs | 0.0070 μs |  1.20 | 0.0191 |     - |     - |      40 B |
| Hyperlinq_Foreach_IFunction | 1000 |   100 | 3.447 μs | 0.0057 μs | 0.0050 μs |  1.14 | 0.0191 |     - |     - |      40 B |
