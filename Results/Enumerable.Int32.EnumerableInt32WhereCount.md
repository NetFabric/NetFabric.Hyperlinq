## Enumerable.Int32.EnumerableInt32WhereCount

### Source
[EnumerableInt32WhereCount.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32WhereCount.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- StructLinq.BCL: [0.19.1](https://www.nuget.org/packages/StructLinq.BCL/0.19.1)
- NetFabric.Hyperlinq: [3.0.0-beta24](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta24)

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
|          ForeachLoop |   100 | 523.6 ns | 0.93 ns | 0.83 ns |  1.00 | 0.0191 |     - |     - |      40 B |
|                 Linq |   100 | 704.8 ns | 1.83 ns | 1.72 ns |  1.35 | 0.0191 |     - |     - |      40 B |
|               LinqAF |   100 | 780.4 ns | 2.02 ns | 1.79 ns |  1.49 | 0.0191 |     - |     - |      40 B |
|           StructLinq |   100 | 842.4 ns | 0.74 ns | 0.58 ns |  1.61 | 0.0343 |     - |     - |      72 B |
| StructLinq_IFunction |   100 | 629.1 ns | 1.60 ns | 1.42 ns |  1.20 | 0.0343 |     - |     - |      72 B |
|            Hyperlinq |   100 | 695.8 ns | 2.29 ns | 1.79 ns |  1.33 | 0.0191 |     - |     - |      40 B |
