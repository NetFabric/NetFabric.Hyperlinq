## Array.ValueType.ArrayValueTypeDistinct

### Source
[ArrayValueTypeDistinct.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeDistinct.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- StructLinq.BCL: [0.19.1](https://www.nuget.org/packages/StructLinq.BCL/0.19.1)
- NetFabric.Hyperlinq: [3.0.0-beta23](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta23)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.100-preview.7.20366.6
  [Host]        : .NET Core 5.0.0 (CoreCLR 5.0.20.36411, CoreFX 5.0.20.36411), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.0 (CoreCLR 5.0.20.36411, CoreFX 5.0.20.36411), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|      Method | Duplicates | Count |     Mean |   Error |  StdDev | Ratio |     Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------ |----------- |------ |---------:|--------:|--------:|------:|----------:|------:|------:|----------:|
|     ForLoop |          4 |   100 | 523.3 μs | 1.76 μs | 1.37 μs |  1.00 | 1095.7031 |     - |     - |   2.19 MB |
| ForeachLoop |          4 |   100 | 523.1 μs | 2.65 μs | 2.48 μs |  1.00 | 1095.7031 |     - |     - |   2.19 MB |
|        Linq |          4 |   100 | 528.7 μs | 3.52 μs | 3.12 μs |  1.01 | 1092.7734 |     - |     - |   2.18 MB |
|  StructLinq |          4 |   100 | 577.9 μs | 3.51 μs | 3.28 μs |  1.10 | 1086.9141 |     - |     - |   2.17 MB |
|   Hyperlinq |          4 |   100 | 494.4 μs | 3.10 μs | 2.90 μs |  0.94 | 1045.8984 |     - |     - |   2.09 MB |
