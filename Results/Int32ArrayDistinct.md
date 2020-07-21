## Int32ArrayDistinct

### Source
[Int32ArrayDistinct.cs](../LinqBenchmarks/Int32/Array/Int32ArrayDistinct.cs)

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
|      Method | Count |     Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------ |------ |---------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|     ForLoop |   100 | 1.467 μs | 0.0152 μs | 0.0134 μs |  1.00 |    0.00 | 2.8706 |     - |     - |    6008 B |
| ForeachLoop |   100 | 1.414 μs | 0.0146 μs | 0.0137 μs |  0.97 |    0.01 | 2.8706 |     - |     - |    6008 B |
|        Linq |   100 | 2.613 μs | 0.0350 μs | 0.0292 μs |  1.78 |    0.02 | 2.0599 |     - |     - |    4312 B |
|  StructLinq |   100 | 2.197 μs | 0.0229 μs | 0.0191 μs |  1.50 |    0.01 |      - |     - |     - |         - |
|   Hyperlinq |   100 | 1.839 μs | 0.0214 μs | 0.0178 μs |  1.25 |    0.02 |      - |     - |     - |         - |
