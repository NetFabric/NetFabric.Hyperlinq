## Enumerable.Int32.EnumerableInt32SkipTakeSelect

### Source
[EnumerableInt32SkipTakeSelect.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32SkipTakeSelect.cs)

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
|          ForeachLoop | 1000 |   100 | 3.456 μs | 0.0233 μs | 0.0206 μs |  1.00 |    0.00 | 0.0191 |     - |     - |      40 B |
|                 Linq | 1000 |   100 | 5.465 μs | 0.0608 μs | 0.0569 μs |  1.58 |    0.02 | 0.0992 |     - |     - |     208 B |
|               LinqAF | 1000 |   100 | 4.961 μs | 0.0299 μs | 0.0280 μs |  1.43 |    0.01 | 0.0153 |     - |     - |      40 B |
|           StructLinq | 1000 |   100 | 4.150 μs | 0.0546 μs | 0.0511 μs |  1.20 |    0.02 | 0.0610 |     - |     - |     128 B |
| StructLinq_IFunction | 1000 |   100 | 4.250 μs | 0.0209 μs | 0.0196 μs |  1.23 |    0.01 | 0.0153 |     - |     - |      40 B |
|    Hyperlinq_Foreach | 1000 |   100 | 4.189 μs | 0.0709 μs | 0.0628 μs |  1.21 |    0.02 | 0.0153 |     - |     - |      40 B |
