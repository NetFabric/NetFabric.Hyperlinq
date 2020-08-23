## Enumerable.Int32.EnumerableInt32SkipTakeSelect

### Source
[EnumerableInt32SkipTakeSelect.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32SkipTakeSelect.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.19.2](https://www.nuget.org/packages/StructLinq.BCL/0.19.2)
- NetFabric.Hyperlinq: [3.0.0-beta26](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta26)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.100-preview.7.20366.6
  [Host]        : .NET Core 5.0.0 (CoreCLR 5.0.20.36411, CoreFX 5.0.20.36411), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.0 (CoreCLR 5.0.20.36411, CoreFX 5.0.20.36411), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|               Method | Skip | Count |     Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |----- |------ |---------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|          ForeachLoop | 1000 |   100 | 2.622 μs | 0.0236 μs | 0.0221 μs |  1.00 |    0.00 | 0.0191 |     - |     - |      40 B |
|                 Linq | 1000 |   100 | 4.759 μs | 0.0289 μs | 0.0256 μs |  1.81 |    0.01 | 0.0992 |     - |     - |     208 B |
|               LinqAF | 1000 |   100 | 5.045 μs | 0.0433 μs | 0.0405 μs |  1.92 |    0.02 | 0.0153 |     - |     - |      40 B |
|           StructLinq | 1000 |   100 | 3.477 μs | 0.0287 μs | 0.0254 μs |  1.33 |    0.01 | 0.0610 |     - |     - |     128 B |
| StructLinq_IFunction | 1000 |   100 | 3.453 μs | 0.0186 μs | 0.0174 μs |  1.32 |    0.01 | 0.0191 |     - |     - |      40 B |
|    Hyperlinq_Foreach | 1000 |   100 | 3.375 μs | 0.0188 μs | 0.0166 μs |  1.29 |    0.01 | 0.0191 |     - |     - |      40 B |
