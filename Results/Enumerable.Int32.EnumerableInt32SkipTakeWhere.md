## Enumerable.Int32.EnumerableInt32SkipTakeWhere

### Source
[EnumerableInt32SkipTakeWhere.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32SkipTakeWhere.cs)

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
|          ForeachLoop | 1000 |   100 | 3.557 μs | 0.0121 μs | 0.0114 μs |  1.00 | 0.0191 |     - |     - |      40 B |
|                 Linq | 1000 |   100 | 5.101 μs | 0.0061 μs | 0.0048 μs |  1.43 | 0.0992 |     - |     - |     208 B |
|               LinqAF | 1000 |   100 | 5.312 μs | 0.0170 μs | 0.0159 μs |  1.49 | 0.0153 |     - |     - |      40 B |
|           StructLinq | 1000 |   100 | 4.743 μs | 0.0074 μs | 0.0058 μs |  1.33 | 0.0687 |     - |     - |     152 B |
| StructLinq_IFunction | 1000 |   100 | 4.151 μs | 0.0116 μs | 0.0103 μs |  1.17 | 0.0687 |     - |     - |     152 B |
|            Hyperlinq | 1000 |   100 | 5.103 μs | 0.0084 μs | 0.0070 μs |  1.43 | 0.0992 |     - |     - |     208 B |
