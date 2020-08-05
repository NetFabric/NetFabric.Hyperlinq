## Enumerable.Int32.EnumerableInt32Distinct

### Source
[EnumerableInt32Distinct.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32Distinct.cs)

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
|      Method | Count |     Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------ |------ |---------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
| ForeachLoop |   100 | 1.753 μs | 0.0151 μs | 0.0141 μs |  1.00 |    0.00 | 2.8896 |     - |     - |    6048 B |
|        Linq |   100 | 2.411 μs | 0.0120 μs | 0.0106 μs |  1.38 |    0.01 | 2.0638 |     - |     - |    4320 B |
|  StructLinq |   100 | 2.433 μs | 0.0265 μs | 0.0221 μs |  1.39 |    0.02 | 0.0191 |     - |     - |      40 B |
|   Hyperlinq |   100 | 2.241 μs | 0.0111 μs | 0.0099 μs |  1.28 |    0.01 | 0.0191 |     - |     - |      40 B |
