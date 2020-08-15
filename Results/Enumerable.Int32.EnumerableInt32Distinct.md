## Enumerable.Int32.EnumerableInt32Distinct

### Source
[EnumerableInt32Distinct.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32Distinct.cs)

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
|      Method | Count |     Mean |     Error |    StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------ |------ |---------:|----------:|----------:|------:|-------:|------:|------:|----------:|
| ForeachLoop |   100 | 2.327 μs | 0.0057 μs | 0.0048 μs |  1.00 | 2.8915 |     - |     - |    6048 B |
|        Linq |   100 | 3.001 μs | 0.0038 μs | 0.0032 μs |  1.29 | 2.0638 |     - |     - |    4320 B |
|      LinqAF |   100 | 4.422 μs | 0.0182 μs | 0.0152 μs |  1.90 | 2.5024 |     - |     - |    5240 B |
|  StructLinq |   100 | 2.891 μs | 0.0110 μs | 0.0092 μs |  1.24 | 0.0191 |     - |     - |      40 B |
|   Hyperlinq |   100 | 2.577 μs | 0.0033 μs | 0.0027 μs |  1.11 | 0.0191 |     - |     - |      40 B |
