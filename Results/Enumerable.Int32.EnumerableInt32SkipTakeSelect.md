## Enumerable.Int32.EnumerableInt32SkipTakeSelect

### Source
[EnumerableInt32SkipTakeSelect.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32SkipTakeSelect.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [1.0.0](https://www.nuget.org/packages/LinqAF/1.0.0)
- StructLinq.BCL: [0.19.1](https://www.nuget.org/packages/StructLinq.BCL/0.19.1)
- NetFabric.Hyperlinq: [3.0.0-beta25](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta25)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=macOS Catalina 10.15.6 (19G73) [Darwin 19.6.0]
Intel Core i5-7360U CPU 2.30GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.100-preview.6.20318.15
  [Host]        : .NET Core 5.0.0 (CoreCLR 5.0.20.30506, CoreFX 5.0.20.30506), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.0 (CoreCLR 5.0.20.30506, CoreFX 5.0.20.30506), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|               Method | Skip | Count |     Mean |     Error |    StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |----- |------ |---------:|----------:|----------:|------:|-------:|------:|------:|----------:|
|          ForeachLoop | 1000 |   100 | 3.472 μs | 0.0136 μs | 0.0113 μs |  1.00 | 0.0191 |     - |     - |      40 B |
|                 Linq | 1000 |   100 | 4.644 μs | 0.0051 μs | 0.0043 μs |  1.34 | 0.0992 |     - |     - |     208 B |
|               LinqAF | 1000 |   100 | 5.394 μs | 0.0105 μs | 0.0087 μs |  1.55 | 0.0153 |     - |     - |      40 B |
|           StructLinq | 1000 |   100 | 4.774 μs | 0.0128 μs | 0.0120 μs |  1.37 | 0.0687 |     - |     - |     152 B |
| StructLinq_IFunction | 1000 |   100 | 4.683 μs | 0.0087 μs | 0.0077 μs |  1.35 | 0.0687 |     - |     - |     152 B |
|    Hyperlinq_Foreach | 1000 |   100 | 4.498 μs | 0.0071 μs | 0.0059 μs |  1.30 | 0.0153 |     - |     - |      40 B |
