## ArrayDistinct

### Source
[ArrayDistinct.cs](../LinqBenchmarks/Int32/Array/ArrayDistinct.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- StructLinq.BCL: [0.1.9](https://www.nuget.org/packages/StructLinq.BCL/0.1.9)
- NetFabric.Hyperlinq: [3.0.0-beta19](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta19)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.100-preview.6.20318.15
  [Host]        : .NET Core 5.0.0 (CoreCLR 5.0.20.30506, CoreFX 5.0.20.30506), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.0 (CoreCLR 5.0.20.30506, CoreFX 5.0.20.30506), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|      Method | Count |     Mean |     Error |    StdDev |   Median | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------ |------ |---------:|----------:|----------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|     ForLoop |   100 | 1.829 μs | 0.0318 μs | 0.0774 μs | 1.796 μs |  1.00 |    0.00 | 2.8687 |     - |     - |    6008 B |
| ForeachLoop |   100 | 1.876 μs | 0.1064 μs | 0.3054 μs | 1.706 μs |  1.06 |    0.20 | 2.8706 |     - |     - |    6008 B |
|        Linq |   100 | 2.982 μs | 0.0604 μs | 0.1773 μs | 2.903 μs |  1.64 |    0.11 | 2.0599 |     - |     - |    4312 B |
|  StructLinq |   100 | 2.412 μs | 0.1199 μs | 0.3535 μs | 2.248 μs |  1.29 |    0.18 |      - |     - |     - |         - |
|   Hyperlinq |   100 | 2.138 μs | 0.0681 μs | 0.1942 μs | 2.052 μs |  1.18 |    0.12 |      - |     - |     - |         - |
