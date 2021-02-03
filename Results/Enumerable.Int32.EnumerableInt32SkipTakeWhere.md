## Enumerable.Int32.EnumerableInt32SkipTakeWhere

### Source
[EnumerableInt32SkipTakeWhere.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32SkipTakeWhere.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta31](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta31)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.200-preview.20614.14
  [Host]        : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|               Method | Skip | Count |     Mean |     Error |    StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |----- |------ |---------:|----------:|----------:|------:|-------:|------:|------:|----------:|
|          ForeachLoop | 1000 |   100 | 3.097 μs | 0.0063 μs | 0.0052 μs |  1.00 | 0.0191 |     - |     - |      40 B |
|                 Linq | 1000 |   100 | 3.999 μs | 0.0131 μs | 0.0116 μs |  1.29 | 0.0992 |     - |     - |     208 B |
|               LinqAF | 1000 |   100 | 4.628 μs | 0.0167 μs | 0.0148 μs |  1.50 | 0.0153 |     - |     - |      40 B |
|           StructLinq | 1000 |   100 | 3.955 μs | 0.0062 μs | 0.0048 μs |  1.28 | 0.0610 |     - |     - |     128 B |
| StructLinq_IFunction | 1000 |   100 | 3.500 μs | 0.0079 μs | 0.0070 μs |  1.13 | 0.0191 |     - |     - |      40 B |
|            Hyperlinq | 1000 |   100 | 3.701 μs | 0.0145 μs | 0.0128 μs |  1.20 | 0.0191 |     - |     - |      40 B |
|  Hyperlinq_IFunction | 1000 |   100 | 3.415 μs | 0.0156 μs | 0.0139 μs |  1.10 | 0.0191 |     - |     - |      40 B |
