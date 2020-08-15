## List.ValueType.ListValueTypeWhereSelectToArray

### Source
[ListValueTypeWhereSelectToArray.cs](../LinqBenchmarks/List/ValueType/ListValueTypeWhereSelectToArray.cs)

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
|              ForLoop |   100 | 1,171.4 ns |  5.05 ns |  4.72 ns |  1.00 | 3.4122 |     - |     - |    7136 B |
|          ForeachLoop |   100 | 1,419.3 ns |  5.52 ns |  4.61 ns |  1.21 | 3.4122 |     - |     - |    7136 B |
|                 Linq |   100 | 1,484.2 ns |  5.03 ns |  4.70 ns |  1.27 | 2.4853 |     - |     - |    5200 B |
|           LinqFaster |   100 | 1,595.3 ns |  5.10 ns |  4.26 ns |  1.36 | 3.4122 |     - |     - |    7136 B |
|               LinqAF |   100 | 2,972.9 ns | 11.46 ns | 10.15 ns |  2.54 | 3.3951 |     - |     - |    7104 B |
|           StructLinq |   100 | 1,584.3 ns |  3.60 ns |  3.19 ns |  1.35 | 0.9899 |     - |     - |    2072 B |
| StructLinq_IFunction |   100 |   939.8 ns |  3.74 ns |  3.32 ns |  0.80 | 0.9899 |     - |     - |    2072 B |
|            Hyperlinq |   100 | 1,370.4 ns |  5.49 ns |  5.14 ns |  1.17 | 0.9670 |     - |     - |    2024 B |
|       Hyperlinq_Pool |   100 | 1,315.2 ns |  1.03 ns |  0.81 ns |  1.12 | 0.0267 |     - |     - |      56 B |
