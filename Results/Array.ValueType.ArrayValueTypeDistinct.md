## Array.ValueType.ArrayValueTypeDistinct

### Source
[ArrayValueTypeDistinct.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeDistinct.cs)

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
|      Method | Duplicates | Count |     Mean |    Error |   StdDev | Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated | CacheMisses/Op | BranchMispredictions/Op |
|------------ |----------- |------ |---------:|---------:|---------:|------:|--------:|--------:|------:|------:|----------:|---------------:|------------------------:|
|     ForLoop |          4 |   100 | 36.25 μs | 0.268 μs | 0.251 μs |  1.00 |    0.00 | 72.6929 |     - |     - | 148.45 KB |            135 |                      63 |
| ForeachLoop |          4 |   100 | 37.82 μs | 0.235 μs | 0.208 μs |  1.04 |    0.01 | 72.6929 |     - |     - | 148.45 KB |            131 |                      57 |
|        Linq |          4 |   100 | 38.34 μs | 0.499 μs | 0.442 μs |  1.06 |    0.02 | 72.3877 |     - |     - | 147.94 KB |            155 |                      68 |
|  StructLinq |          4 |   100 | 41.13 μs | 0.262 μs | 0.245 μs |  1.13 |    0.01 | 70.9229 |     - |     - | 144.92 KB |            159 |                      71 |
|   Hyperlinq |          4 |   100 | 36.57 μs | 0.309 μs | 0.289 μs |  1.01 |    0.01 | 70.9229 |     - |     - | 144.92 KB |            205 |                      70 |
