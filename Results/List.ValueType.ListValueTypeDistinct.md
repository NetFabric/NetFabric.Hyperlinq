## List.ValueType.ListValueTypeDistinct

### Source
[ListValueTypeDistinct.cs](../LinqBenchmarks/List/ValueType/ListValueTypeDistinct.cs)

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
|               Method | Duplicates | Count |       Mean |     Error |    StdDev | Ratio | Code Size |     Gen 0 | Gen 1 | Gen 2 | Allocated | CacheMisses/Op | BranchMispredictions/Op |
|--------------------- |----------- |------ |-----------:|----------:|----------:|------:|----------:|----------:|------:|------:|----------:|---------------:|------------------------:|
|              ForLoop |          4 |   100 | 556.194 μs | 4.4615 μs | 3.9550 μs | 1.000 |    2428 B | 1095.7031 |     - |     - | 2292184 B |          3,741 |                     767 |
|          ForeachLoop |          4 |   100 | 561.040 μs | 7.9989 μs | 7.0908 μs | 1.009 |    2692 B | 1095.7031 |     - |     - | 2292184 B |          3,111 |                     644 |
|                 Linq |          4 |   100 | 570.380 μs | 4.1707 μs | 3.6972 μs | 1.026 |     575 B | 1092.7734 |     - |     - | 2286712 B |          3,599 |                     750 |
|           LinqFaster |          4 |   100 |   2.315 μs | 0.0113 μs | 0.0105 μs | 0.004 |    1347 B |    0.0114 |     - |     - |      24 B |              1 |                       2 |
|           StructLinq |          4 |   100 | 605.850 μs | 6.3908 μs | 5.9780 μs | 1.090 |    2125 B | 1086.9141 |     - |     - | 2273601 B |          4,236 |                     803 |
| StructLinq_IFunction |          4 |   100 |  23.224 μs | 0.1399 μs | 0.1168 μs | 0.042 |    2283 B |         - |     - |     - |         - |              9 |                      47 |
|            Hyperlinq |          4 |   100 | 525.792 μs | 3.7661 μs | 3.3385 μs | 0.945 |    2194 B | 1045.8984 |     - |     - | 2187585 B |          3,754 |                     645 |
