## Enumerable.Int32.EnumerableInt32Select

### Source
[EnumerableInt32Select.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32Select.cs)

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
|          ForeachLoop |   100 |   509.6 ns | 0.60 ns | 0.53 ns |  1.00 | 0.0191 |     - |     - |      40 B |
|                 Linq |   100 | 1,136.2 ns | 1.87 ns | 1.56 ns |  2.23 | 0.0458 |     - |     - |      96 B |
|               LinqAF |   100 |   931.2 ns | 3.61 ns | 3.38 ns |  1.83 | 0.0191 |     - |     - |      40 B |
|           StructLinq |   100 |   742.6 ns | 0.44 ns | 0.35 ns |  1.46 | 0.0191 |     - |     - |      40 B |
| StructLinq_IFunction |   100 |   594.2 ns | 1.80 ns | 1.68 ns |  1.17 | 0.0191 |     - |     - |      40 B |
|    Hyperlinq_Foreach |   100 |   849.6 ns | 5.45 ns | 4.83 ns |  1.67 | 0.0191 |     - |     - |      40 B |
