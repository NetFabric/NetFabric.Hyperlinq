## Enumerable.Int32.EnumerableInt32WhereSelect

### Source
[EnumerableInt32WhereSelect.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32WhereSelect.cs)

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
|               Method | Count |       Mean |   Error |  StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |-----------:|--------:|--------:|------:|-------:|------:|------:|----------:|
|          ForeachLoop |   100 |   524.1 ns | 1.28 ns | 1.13 ns |  1.00 | 0.0191 |     - |     - |      40 B |
|                 Linq |   100 | 1,101.0 ns | 3.15 ns | 2.63 ns |  2.10 | 0.0763 |     - |     - |     160 B |
|               LinqAF |   100 | 1,159.0 ns | 1.87 ns | 1.56 ns |  2.21 | 0.0191 |     - |     - |      40 B |
|           StructLinq |   100 | 1,008.1 ns | 1.63 ns | 1.36 ns |  1.92 | 0.0191 |     - |     - |      40 B |
| StructLinq_IFunction |   100 |   621.5 ns | 3.24 ns | 2.70 ns |  1.19 | 0.0191 |     - |     - |      40 B |
|            Hyperlinq |   100 | 1,078.2 ns | 2.16 ns | 2.02 ns |  2.06 | 0.0191 |     - |     - |      40 B |
