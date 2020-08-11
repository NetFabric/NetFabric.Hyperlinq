## Enumerable.Int32.EnumerableInt32SkipTakeWhere

### Source
[EnumerableInt32SkipTakeWhere.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32SkipTakeWhere.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- StructLinq.BCL: [0.19.1](https://www.nuget.org/packages/StructLinq.BCL/0.19.1)
- NetFabric.Hyperlinq: [3.0.0-beta24](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta24)

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
|          ForeachLoop | 1000 |   100 | 3.936 μs | 0.0155 μs | 0.0129 μs |  1.00 | 0.0153 |     - |     - |      40 B |
|                 Linq | 1000 |   100 | 4.514 μs | 0.0154 μs | 0.0144 μs |  1.15 | 0.0992 |     - |     - |     208 B |
|               LinqAF | 1000 |   100 | 5.409 μs | 0.0207 μs | 0.0194 μs |  1.37 | 0.0153 |     - |     - |      40 B |
|           StructLinq | 1000 |   100 | 4.208 μs | 0.0039 μs | 0.0033 μs |  1.07 | 0.0687 |     - |     - |     152 B |
| StructLinq_IFunction | 1000 |   100 | 4.285 μs | 0.0193 μs | 0.0180 μs |  1.09 | 0.0687 |     - |     - |     152 B |
|            Hyperlinq | 1000 |   100 | 4.488 μs | 0.0111 μs | 0.0099 μs |  1.14 | 0.0992 |     - |     - |     208 B |
