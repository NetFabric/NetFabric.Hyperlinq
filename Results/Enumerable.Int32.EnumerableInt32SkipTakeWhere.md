## Enumerable.Int32.EnumerableInt32SkipTakeWhere

### Source
[EnumerableInt32SkipTakeWhere.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32SkipTakeWhere.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta37](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta37)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.200-preview.21079.7
  [Host]        : .NET Core 5.0.3 (CoreCLR 5.0.321.7212, CoreFX 5.0.321.7212), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.3 (CoreCLR 5.0.321.7212, CoreFX 5.0.321.7212), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|               Method | Skip | Count |     Mean |     Error |    StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |----- |------ |---------:|----------:|----------:|------:|-------:|------:|------:|----------:|
|          ForeachLoop | 1000 |   100 | 2.587 μs | 0.0056 μs | 0.0052 μs |  1.00 | 0.0191 |     - |     - |      40 B |
|                 Linq | 1000 |   100 | 4.079 μs | 0.0111 μs | 0.0104 μs |  1.58 | 0.0992 |     - |     - |     208 B |
|               LinqAF | 1000 |   100 | 4.963 μs | 0.0199 μs | 0.0186 μs |  1.92 | 0.0153 |     - |     - |      40 B |
|           StructLinq | 1000 |   100 | 3.963 μs | 0.0142 μs | 0.0126 μs |  1.53 | 0.0610 |     - |     - |     128 B |
| StructLinq_IFunction | 1000 |   100 | 3.585 μs | 0.0084 μs | 0.0075 μs |  1.39 | 0.0191 |     - |     - |      40 B |
|            Hyperlinq | 1000 |   100 | 3.725 μs | 0.0099 μs | 0.0083 μs |  1.44 | 0.0191 |     - |     - |      40 B |
|  Hyperlinq_IFunction | 1000 |   100 | 3.094 μs | 0.0110 μs | 0.0103 μs |  1.20 | 0.0191 |     - |     - |      40 B |
