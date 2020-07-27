## Enumerable.Int32.EnumerableInt32Distinct

### Source
[EnumerableInt32Distinct.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32Distinct.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- StructLinq.BCL: [0.19.1](https://www.nuget.org/packages/StructLinq.BCL/0.19.1)
- NetFabric.Hyperlinq: [3.0.0-beta20](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta20)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.100-preview.7.20366.6
  [Host]        : .NET Core 5.0.0 (CoreCLR 5.0.20.36411, CoreFX 5.0.20.36411), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.0 (CoreCLR 5.0.20.36411, CoreFX 5.0.20.36411), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|      Method | Count |     Mean |     Error |    StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated | CacheMisses/Op | BranchMispredictions/Op |
|------------ |------ |---------:|----------:|----------:|------:|-------:|------:|------:|----------:|---------------:|------------------------:|
| ForeachLoop |   100 | 1.735 μs | 0.0065 μs | 0.0054 μs |  1.00 | 2.8896 |     - |     - |    6048 B |              6 |                       4 |
|        Linq |   100 | 2.395 μs | 0.0153 μs | 0.0135 μs |  1.38 | 2.0638 |     - |     - |    4320 B |              9 |                       4 |
|  StructLinq |   100 | 2.436 μs | 0.0161 μs | 0.0151 μs |  1.40 | 0.0191 |     - |     - |      40 B |              1 |                       4 |
|   Hyperlinq |   100 | 2.223 μs | 0.0132 μs | 0.0123 μs |  1.28 | 0.0191 |     - |     - |      40 B |              1 |                       2 |
