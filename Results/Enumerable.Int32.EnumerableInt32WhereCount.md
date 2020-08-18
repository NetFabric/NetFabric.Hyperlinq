## Enumerable.Int32.EnumerableInt32WhereCount

### Source
[EnumerableInt32WhereCount.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32WhereCount.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.19.1](https://www.nuget.org/packages/StructLinq.BCL/0.19.1)
- NetFabric.Hyperlinq: [3.0.0-beta26](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta26)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=macOS Catalina 10.15.6 (19G73) [Darwin 19.6.0]
Intel Core i5-7360U CPU 2.30GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.100-preview.6.20318.15
  [Host]        : .NET Core 5.0.0 (CoreCLR 5.0.20.30506, CoreFX 5.0.20.30506), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.0 (CoreCLR 5.0.20.30506, CoreFX 5.0.20.30506), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|               Method | Count |     Mean |   Error |  StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |---------:|--------:|--------:|------:|-------:|------:|------:|----------:|
|          ForeachLoop |   100 | 524.2 ns | 0.75 ns | 0.63 ns |  1.00 | 0.0191 |     - |     - |      40 B |
|                 Linq |   100 | 704.3 ns | 1.08 ns | 0.90 ns |  1.34 | 0.0191 |     - |     - |      40 B |
|               LinqAF |   100 | 765.9 ns | 1.54 ns | 1.36 ns |  1.46 | 0.0191 |     - |     - |      40 B |
|           StructLinq |   100 | 843.4 ns | 1.88 ns | 1.67 ns |  1.61 | 0.0343 |     - |     - |      72 B |
| StructLinq_IFunction |   100 | 560.5 ns | 1.66 ns | 1.55 ns |  1.07 | 0.0343 |     - |     - |      72 B |
|            Hyperlinq |   100 | 681.9 ns | 1.10 ns | 0.98 ns |  1.30 | 0.0191 |     - |     - |      40 B |
