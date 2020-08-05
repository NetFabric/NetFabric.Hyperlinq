## Array.Int32.ArrayInt32Distinct

### Source
[ArrayInt32Distinct.cs](../LinqBenchmarks/Array/Int32/ArrayInt32Distinct.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- StructLinq.BCL: [0.19.1](https://www.nuget.org/packages/StructLinq.BCL/0.19.1)
- NetFabric.Hyperlinq: [3.0.0-beta22](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta22)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.100-preview.7.20366.6
  [Host]        : .NET Core 5.0.0 (CoreCLR 5.0.20.36411, CoreFX 5.0.20.36411), X64 RyuJIT
  .NET 4.8      : .NET Framework 4.8 (4.8.4180.0), X64 RyuJIT
  .NET Core 3.1 : .NET Core 3.1.2 (CoreCLR 4.700.20.6602, CoreFX 4.700.20.6702), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.0 (CoreCLR 5.0.20.36411, CoreFX 5.0.20.36411), X64 RyuJIT


```
|      Method |           Job |       Runtime | Duplicates | Count |     Mean |     Error |    StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated | Code Size | CacheMisses/Op | BranchMispredictions/Op |
|------------ |-------------- |-------------- |----------- |------ |---------:|----------:|----------:|------:|-------:|------:|------:|----------:|----------:|---------------:|------------------------:|
|     ForLoop |      .NET 4.8 |      .NET 4.8 |          4 |   100 | 5.659 μs | 0.0531 μs | 0.0443 μs |  1.00 | 2.8610 |     - |     - |    6019 B |     697 B |             14 |                       7 |
| ForeachLoop |      .NET 4.8 |      .NET 4.8 |          4 |   100 | 5.685 μs | 0.0486 μs | 0.0406 μs |  1.00 | 2.8610 |     - |     - |    6019 B |     697 B |              9 |                       6 |
|        Linq |      .NET 4.8 |      .NET 4.8 |          4 |   100 | 6.960 μs | 0.0652 μs | 0.0544 μs |  1.23 | 2.0676 |     - |     - |    4341 B |     283 B |             11 |                       6 |
|  StructLinq |      .NET 4.8 |      .NET 4.8 |          4 |   100 | 6.632 μs | 0.0682 μs | 0.0638 μs |  1.17 |      - |     - |     - |         - |    1792 B |              1 |                       5 |
|   Hyperlinq |      .NET 4.8 |      .NET 4.8 |          4 |   100 | 5.225 μs | 0.0481 μs | 0.0450 μs |  0.92 |      - |     - |     - |         - |     834 B |              1 |                       6 |
|     ForLoop | .NET Core 3.1 | .NET Core 3.1 |          4 |   100 | 4.957 μs | 0.0731 μs | 0.0648 μs |  0.88 | 2.8610 |     - |     - |    6000 B |     652 B |              9 |                       6 |
| ForeachLoop | .NET Core 3.1 | .NET Core 3.1 |          4 |   100 | 4.901 μs | 0.0493 μs | 0.0437 μs |  0.87 | 2.8610 |     - |     - |    6000 B |     652 B |              9 |                       6 |
|        Linq | .NET Core 3.1 | .NET Core 3.1 |          4 |   100 | 6.468 μs | 0.0722 μs | 0.0603 μs |  1.14 | 2.0599 |     - |     - |    4312 B |     345 B |             11 |                       6 |
|  StructLinq | .NET Core 3.1 | .NET Core 3.1 |          4 |   100 | 5.218 μs | 0.0264 μs | 0.0247 μs |  0.92 |      - |     - |     - |         - |    1562 B |              1 |                       5 |
|   Hyperlinq | .NET Core 3.1 | .NET Core 3.1 |          4 |   100 | 3.912 μs | 0.0406 μs | 0.0380 μs |  0.69 |      - |     - |     - |         - |     649 B |              1 |                       3 |
|     ForLoop | .NET Core 5.0 | .NET Core 5.0 |          4 |   100 | 3.033 μs | 0.0397 μs | 0.0310 μs |  0.54 | 2.8687 |     - |     - |    6008 B |     865 B |              6 |                       3 |
| ForeachLoop | .NET Core 5.0 | .NET Core 5.0 |          4 |   100 | 3.025 μs | 0.0311 μs | 0.0276 μs |  0.53 | 2.8687 |     - |     - |    6008 B |     865 B |              5 |                       3 |
|        Linq | .NET Core 5.0 | .NET Core 5.0 |          4 |   100 | 6.337 μs | 0.0596 μs | 0.0558 μs |  1.12 | 2.0599 |     - |     - |    4312 B |     333 B |             18 |                       9 |
|  StructLinq | .NET Core 5.0 | .NET Core 5.0 |          4 |   100 | 5.196 μs | 0.0178 μs | 0.0166 μs |  0.92 |      - |     - |     - |         - |    1580 B |              2 |                       5 |
|   Hyperlinq | .NET Core 5.0 | .NET Core 5.0 |          4 |   100 | 3.804 μs | 0.0105 μs | 0.0093 μs |  0.67 |      - |     - |     - |         - |     637 B |              1 |                       3 |
