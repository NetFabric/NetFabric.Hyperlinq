## Enumerable.Int32.EnumerableInt32SkipTakeWhere

### Source
[EnumerableInt32SkipTakeWhere.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32SkipTakeWhere.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.19.2](https://www.nuget.org/packages/StructLinq.BCL/0.19.2)
- NetFabric.Hyperlinq: [3.0.0-beta27](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta27)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.200-preview.20614.14
  [Host]        : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|               Method | Skip | Count |     Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |----- |------ |---------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|          ForeachLoop | 1000 |   100 | 3.798 μs | 0.0186 μs | 0.0165 μs |  1.00 |    0.00 | 0.0191 |     - |     - |      40 B |
|                 Linq | 1000 |   100 | 5.192 μs | 0.1001 μs | 0.1191 μs |  1.36 |    0.03 | 0.0992 |     - |     - |     208 B |
|               LinqAF | 1000 |   100 | 5.196 μs | 0.0448 μs | 0.0397 μs |  1.37 |    0.01 | 0.0153 |     - |     - |      40 B |
|           StructLinq | 1000 |   100 | 4.290 μs | 0.0427 μs | 0.0400 μs |  1.13 |    0.01 | 0.0610 |     - |     - |     128 B |
| StructLinq_IFunction | 1000 |   100 | 3.877 μs | 0.0519 μs | 0.0460 μs |  1.02 |    0.01 | 0.0153 |     - |     - |      40 B |
|            Hyperlinq | 1000 |   100 | 5.180 μs | 0.0817 μs | 0.0724 μs |  1.36 |    0.02 | 0.0992 |     - |     - |     208 B |
