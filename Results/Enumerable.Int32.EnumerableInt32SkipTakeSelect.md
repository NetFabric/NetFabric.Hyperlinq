## Enumerable.Int32.EnumerableInt32SkipTakeSelect

### Source
[EnumerableInt32SkipTakeSelect.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32SkipTakeSelect.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- StructLinq.BCL: [0.19.1](https://www.nuget.org/packages/StructLinq.BCL/0.19.1)
- NetFabric.Hyperlinq: [3.0.0-beta21](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta21)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.100-preview.7.20366.6
  [Host]        : .NET Core 5.0.0 (CoreCLR 5.0.20.36411, CoreFX 5.0.20.36411), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.0 (CoreCLR 5.0.20.36411, CoreFX 5.0.20.36411), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|               Method | Skip | Count |     Mean |     Error |    StdDev | Ratio | Code Size |  Gen 0 | Gen 1 | Gen 2 | Allocated | CacheMisses/Op | BranchMispredictions/Op |
|--------------------- |----- |------ |---------:|----------:|----------:|------:|----------:|-------:|------:|------:|----------:|---------------:|------------------------:|
|          ForeachLoop | 1000 |   100 | 2.943 μs | 0.0165 μs | 0.0138 μs |  1.00 |     215 B | 0.0191 |     - |     - |      40 B |              1 |                       2 |
|                 Linq | 1000 |   100 | 4.278 μs | 0.0167 μs | 0.0148 μs |  1.45 |    1886 B | 0.0992 |     - |     - |     208 B |              4 |                       4 |
|           StructLinq | 1000 |   100 | 3.897 μs | 0.0363 μs | 0.0322 μs |  1.32 |    1256 B | 0.0687 |     - |     - |     152 B |              3 |                       4 |
| StructLinq_IFunction | 1000 |   100 | 3.404 μs | 0.0146 μs | 0.0122 μs |  1.16 |    1319 B | 0.0725 |     - |     - |     152 B |              3 |                       3 |
|    Hyperlinq_Foreach | 1000 |   100 | 4.090 μs | 0.0229 μs | 0.0203 μs |  1.39 |     814 B | 0.0153 |     - |     - |      40 B |              2 |                       3 |
