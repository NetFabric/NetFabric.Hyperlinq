## Array.Int32.ArrayInt32Distinct

### Source
[ArrayInt32Distinct.cs](../LinqBenchmarks/Array/Int32/ArrayInt32Distinct.cs)

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
|      Method | Duplicates | Count |     Mean |     Error |    StdDev | Ratio | RatioSD | Code Size |  Gen 0 | Gen 1 | Gen 2 | Allocated | CacheMisses/Op | BranchMispredictions/Op |
|------------ |----------- |------ |---------:|----------:|----------:|------:|--------:|----------:|-------:|------:|------:|----------:|---------------:|------------------------:|
|     ForLoop |          4 |   100 | 3.213 μs | 0.0302 μs | 0.0268 μs |  1.00 |    0.00 |    1275 B | 2.8687 |     - |     - |    6008 B |             12 |                       4 |
| ForeachLoop |          4 |   100 | 3.204 μs | 0.0265 μs | 0.0207 μs |  1.00 |    0.01 |    1275 B | 2.8687 |     - |     - |    6008 B |             15 |                       4 |
|        Linq |          4 |   100 | 6.809 μs | 0.0600 μs | 0.0532 μs |  2.12 |    0.03 |     375 B | 2.0599 |     - |     - |    4312 B |             25 |                      11 |
|  StructLinq |          4 |   100 | 5.104 μs | 0.0798 μs | 0.0708 μs |  1.59 |    0.02 |    1926 B |      - |     - |     - |         - |              1 |                       7 |
|   Hyperlinq |          4 |   100 | 3.818 μs | 0.0339 μs | 0.0301 μs |  1.19 |    0.02 |      48 B |      - |     - |     - |         - |              1 |                       4 |
