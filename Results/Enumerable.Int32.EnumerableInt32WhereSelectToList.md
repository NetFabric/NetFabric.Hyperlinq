## Enumerable.Int32.EnumerableInt32WhereSelectToList

### Source
[EnumerableInt32WhereSelectToList.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32WhereSelectToList.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [1.0.0](https://www.nuget.org/packages/LinqAF/1.0.0)
- StructLinq.BCL: [0.19.1](https://www.nuget.org/packages/StructLinq.BCL/0.19.1)
- NetFabric.Hyperlinq: [3.0.0-beta25](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta25)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=macOS Catalina 10.15.6 (19G73) [Darwin 19.6.0]
Intel Core i5-7360U CPU 2.30GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.100-preview.6.20318.15
  [Host]        : .NET Core 5.0.0 (CoreCLR 5.0.20.30506, CoreFX 5.0.20.30506), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.0 (CoreCLR 5.0.20.30506, CoreFX 5.0.20.30506), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|               Method | Count |       Mean |    Error |   StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |-----------:|---------:|---------:|------:|-------:|------:|------:|----------:|
|          ForeachLoop |   100 |   767.5 ns |  1.45 ns |  1.28 ns |  1.00 | 0.3281 |     - |     - |     688 B |
|                 Linq |   100 | 1,137.9 ns |  6.79 ns |  6.35 ns |  1.48 | 0.3853 |     - |     - |     808 B |
|               LinqAF |   100 | 1,353.9 ns |  2.75 ns |  2.15 ns |  1.76 | 0.3281 |     - |     - |     688 B |
|           StructLinq |   100 | 1,212.7 ns |  1.29 ns |  1.08 ns |  1.58 | 0.1602 |     - |     - |     336 B |
| StructLinq_IFunction |   100 |   921.9 ns | 11.28 ns | 10.55 ns |  1.20 | 0.1602 |     - |     - |     336 B |
|            Hyperlinq |   100 | 1,219.9 ns |  4.49 ns |  3.75 ns |  1.59 | 0.1755 |     - |     - |     368 B |
