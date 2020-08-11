## Enumerable.Int32.EnumerableInt32WhereSelect

### Source
[EnumerableInt32WhereSelect.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32WhereSelect.cs)

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
|               Method | Count |       Mean |   Error |  StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |-----------:|--------:|--------:|------:|-------:|------:|------:|----------:|
|          ForeachLoop |   100 |   524.7 ns | 0.57 ns | 0.48 ns |  1.00 | 0.0191 |     - |     - |      40 B |
|                 Linq |   100 | 1,177.8 ns | 1.26 ns | 1.05 ns |  2.24 | 0.0763 |     - |     - |     160 B |
|               LinqAF |   100 | 1,193.0 ns | 3.94 ns | 3.50 ns |  2.27 | 0.0191 |     - |     - |      40 B |
|           StructLinq |   100 | 1,025.9 ns | 0.56 ns | 0.50 ns |  1.96 | 0.0191 |     - |     - |      40 B |
| StructLinq_IFunction |   100 |   617.2 ns | 0.62 ns | 0.48 ns |  1.18 | 0.0191 |     - |     - |      40 B |
|            Hyperlinq |   100 | 1,037.4 ns | 2.51 ns | 2.34 ns |  1.98 | 0.0191 |     - |     - |      40 B |
