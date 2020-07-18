## ArrayDistinct

### Source
[ArrayDistinct.cs](../LinqBenchmarks/ArrayDistinct.cs)

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
|      Method | Count |     Mean |     Error |    StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------ |------ |---------:|----------:|----------:|------:|-------:|------:|------:|----------:|
|     ForLoop |   100 | 1.433 μs | 0.0112 μs | 0.0093 μs |  1.00 | 2.8706 |     - |     - |    6008 B |
| ForeachLoop |   100 | 1.386 μs | 0.0119 μs | 0.0099 μs |  0.97 | 2.8706 |     - |     - |    6008 B |
|        Linq |   100 | 2.562 μs | 0.0060 μs | 0.0050 μs |  1.79 | 2.0599 |     - |     - |    4312 B |
|  StructLinq |   100 | 1.953 μs | 0.0071 μs | 0.0063 μs |  1.36 |      - |     - |     - |         - |
|   Hyperlinq |   100 | 1.822 μs | 0.0032 μs | 0.0030 μs |  1.27 |      - |     - |     - |         - |
