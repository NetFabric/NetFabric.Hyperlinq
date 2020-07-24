## Array.ValueType.ArrayValueTypeDistinct

### Source
[ArrayValueTypeDistinct.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeDistinct.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- StructLinq.BCL: [0.19.1](https://www.nuget.org/packages/StructLinq.BCL/0.19.1)
- NetFabric.Hyperlinq: [3.0.0-beta19](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta19)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.100-preview.7.20366.6
  [Host]        : .NET Core 5.0.0 (CoreCLR 5.0.20.36411, CoreFX 5.0.20.36411), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.0 (CoreCLR 5.0.20.36411, CoreFX 5.0.20.36411), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|      Method | Duplicates | Count |     Mean |    Error |   StdDev | Ratio |   Gen 0 | Gen 1 | Gen 2 | Allocated | CacheMisses/Op | BranchMispredictions/Op |
|------------ |----------- |------ |---------:|---------:|---------:|------:|--------:|------:|------:|----------:|---------------:|------------------------:|
|     ForLoop |          4 |   100 | 38.40 μs | 0.217 μs | 0.193 μs |  1.00 | 72.6929 |     - |     - | 148.45 KB |            161 |                      70 |
| ForeachLoop |          4 |   100 | 37.24 μs | 0.403 μs | 0.336 μs |  0.97 | 72.6929 |     - |     - | 148.45 KB |            158 |                      64 |
|        Linq |          4 |   100 | 39.32 μs | 0.540 μs | 0.479 μs |  1.02 | 72.3877 |     - |     - | 147.94 KB |            252 |                      88 |
|  StructLinq |          4 |   100 | 41.57 μs | 0.248 μs | 0.220 μs |  1.08 | 70.9229 |     - |     - | 144.92 KB |            188 |                      73 |
|   Hyperlinq |          4 |   100 | 38.11 μs | 0.344 μs | 0.287 μs |  0.99 | 70.9229 |     - |     - | 144.92 KB |            182 |                      64 |
