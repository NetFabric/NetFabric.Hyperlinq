## Array.ValueType.ArrayValueTypeDistinct

### Source
[ArrayValueTypeDistinct.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeDistinct.cs)

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
|      Method | Duplicates | Count |     Mean |   Error |  StdDev | Ratio | Code Size |     Gen 0 | Gen 1 | Gen 2 | Allocated | CacheMisses/Op | BranchMispredictions/Op |
|------------ |----------- |------ |---------:|--------:|--------:|------:|----------:|----------:|------:|------:|----------:|---------------:|------------------------:|
|     ForLoop |          4 |   100 | 559.7 μs | 3.02 μs | 2.83 μs |  1.00 |      0 MB | 1095.7031 |     - |     - |   2.19 MB |          3,542 |                     716 |
| ForeachLoop |          4 |   100 | 566.7 μs | 4.41 μs | 3.68 μs |  1.01 |      0 MB | 1095.7031 |     - |     - |   2.19 MB |          3,602 |                     793 |
|        Linq |          4 |   100 | 586.6 μs | 4.53 μs | 4.01 μs |  1.05 |      0 MB | 1092.7734 |     - |     - |   2.18 MB |          4,049 |                     856 |
|  StructLinq |          4 |   100 | 622.0 μs | 6.81 μs | 6.03 μs |  1.11 |      0 MB | 1086.9141 |     - |     - |   2.17 MB |          4,447 |                     851 |
|   Hyperlinq |          4 |   100 | 542.2 μs | 6.43 μs | 6.02 μs |  0.97 |      0 MB | 1045.8984 |     - |     - |   2.09 MB |          3,895 |                     610 |
