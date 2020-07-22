## Array.Int32.Distinct

### Source
[Distinct.cs](../LinqBenchmarks/Array/Int32/Distinct.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- StructLinq.BCL: [0.1.9](https://www.nuget.org/packages/StructLinq.BCL/0.1.9)
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
|      Method | Duplicates | Count |     Mean |     Error |    StdDev |   Median | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------ |----------- |------ |---------:|----------:|----------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|     ForLoop |          4 |   100 | 1.127 μs | 0.0275 μs | 0.0789 μs | 1.129 μs |  1.00 |    0.00 | 0.6294 |     - |     - |    1320 B |
| ForeachLoop |          4 |   100 | 1.128 μs | 0.0483 μs | 0.1418 μs | 1.109 μs |  1.00 |    0.12 | 0.6294 |     - |     - |    1320 B |
|        Linq |          4 |   100 | 2.530 μs | 0.0728 μs | 0.2147 μs | 2.512 μs |  2.23 |    0.18 | 0.5531 |     - |     - |    1160 B |
|  StructLinq |          4 |   100 | 2.025 μs | 0.0931 μs | 0.2688 μs | 2.116 μs |  1.81 |    0.30 |      - |     - |     - |         - |
|   Hyperlinq |          4 |   100 | 1.187 μs | 0.0112 μs | 0.0100 μs | 1.188 μs |  1.11 |    0.05 |      - |     - |     - |         - |
