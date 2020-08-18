## Enumerable.Int32.EnumerableInt32SkipTakeWhere

### Source
[EnumerableInt32SkipTakeWhere.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32SkipTakeWhere.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.19.1](https://www.nuget.org/packages/StructLinq.BCL/0.19.1)
- NetFabric.Hyperlinq: [3.0.0-beta26](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta26)

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
|          ForeachLoop | 1000 |   100 | 3.573 μs | 0.0158 μs | 0.0147 μs |  1.00 | 0.0191 |     - |     - |      40 B |
|                 Linq | 1000 |   100 | 5.113 μs | 0.0108 μs | 0.0096 μs |  1.43 | 0.0992 |     - |     - |     208 B |
|               LinqAF | 1000 |   100 | 5.295 μs | 0.0200 μs | 0.0187 μs |  1.48 | 0.0153 |     - |     - |      40 B |
|           StructLinq | 1000 |   100 | 4.748 μs | 0.0053 μs | 0.0044 μs |  1.33 | 0.0687 |     - |     - |     152 B |
| StructLinq_IFunction | 1000 |   100 | 4.157 μs | 0.0193 μs | 0.0161 μs |  1.16 | 0.0687 |     - |     - |     152 B |
|            Hyperlinq | 1000 |   100 | 5.116 μs | 0.0153 μs | 0.0135 μs |  1.43 | 0.0992 |     - |     - |     208 B |
