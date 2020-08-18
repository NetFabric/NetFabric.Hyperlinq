## List.ValueType.ListValueTypeWhereSelectToArray

### Source
[ListValueTypeWhereSelectToArray.cs](../LinqBenchmarks/List/ValueType/ListValueTypeWhereSelectToArray.cs)

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
|               Method | Count |       Mean |   Error |  StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |-----------:|--------:|--------:|------:|-------:|------:|------:|----------:|
|              ForLoop |   100 | 1,146.9 ns | 2.96 ns | 2.47 ns |  1.00 | 3.4122 |     - |     - |    7136 B |
|          ForeachLoop |   100 | 1,407.6 ns | 5.66 ns | 5.02 ns |  1.23 | 3.4122 |     - |     - |    7136 B |
|                 Linq |   100 | 1,471.1 ns | 2.42 ns | 2.02 ns |  1.28 | 2.4853 |     - |     - |    5200 B |
|           LinqFaster |   100 | 1,544.1 ns | 4.68 ns | 4.15 ns |  1.35 | 3.4122 |     - |     - |    7136 B |
|               LinqAF |   100 | 2,947.2 ns | 5.72 ns | 4.77 ns |  2.57 | 3.3951 |     - |     - |    7104 B |
|           StructLinq |   100 | 1,609.2 ns | 3.51 ns | 3.28 ns |  1.40 | 0.9899 |     - |     - |    2072 B |
| StructLinq_IFunction |   100 |   945.9 ns | 1.37 ns | 1.29 ns |  0.82 | 0.9899 |     - |     - |    2072 B |
|            Hyperlinq |   100 | 1,417.4 ns | 1.79 ns | 1.40 ns |  1.24 | 0.9670 |     - |     - |    2024 B |
|       Hyperlinq_Pool |   100 | 1,299.4 ns | 2.99 ns | 2.80 ns |  1.13 | 0.0267 |     - |     - |      56 B |
