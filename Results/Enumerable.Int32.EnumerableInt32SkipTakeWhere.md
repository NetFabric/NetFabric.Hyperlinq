## Enumerable.Int32.EnumerableInt32SkipTakeWhere

### Source
[EnumerableInt32SkipTakeWhere.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32SkipTakeWhere.cs)

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
|               Method | Skip | Count |     Mean |     Error |    StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |----- |------ |---------:|----------:|----------:|------:|-------:|------:|------:|----------:|
|          ForeachLoop | 1000 |   100 | 3.158 μs | 0.0164 μs | 0.0153 μs |  1.00 | 0.0191 |     - |     - |      40 B |
|                 Linq | 1000 |   100 | 3.809 μs | 0.0277 μs | 0.0259 μs |  1.21 | 0.0992 |     - |     - |     208 B |
|               LinqAF | 1000 |   100 | 4.235 μs | 0.0388 μs | 0.0344 μs |  1.34 | 0.0153 |     - |     - |      40 B |
|           StructLinq | 1000 |   100 | 3.863 μs | 0.0286 μs | 0.0268 μs |  1.22 | 0.0610 |     - |     - |     128 B |
| StructLinq_IFunction | 1000 |   100 | 3.614 μs | 0.0311 μs | 0.0259 μs |  1.14 | 0.0191 |     - |     - |      40 B |
|            Hyperlinq | 1000 |   100 | 3.880 μs | 0.0274 μs | 0.0243 μs |  1.23 | 0.0992 |     - |     - |     208 B |
