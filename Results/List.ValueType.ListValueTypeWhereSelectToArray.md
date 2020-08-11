## List.ValueType.ListValueTypeWhereSelectToArray

### Source
[ListValueTypeWhereSelectToArray.cs](../LinqBenchmarks/List/ValueType/ListValueTypeWhereSelectToArray.cs)

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
|              ForLoop |   100 | 1,148.4 ns | 2.43 ns | 2.03 ns |  1.00 | 3.4122 |     - |     - |    7136 B |
|          ForeachLoop |   100 | 1,418.2 ns | 7.05 ns | 6.25 ns |  1.23 | 3.4122 |     - |     - |    7136 B |
|                 Linq |   100 | 1,475.3 ns | 5.29 ns | 4.69 ns |  1.28 | 2.4853 |     - |     - |    5200 B |
|           LinqFaster |   100 | 1,550.9 ns | 5.06 ns | 4.73 ns |  1.35 | 3.4122 |     - |     - |    7136 B |
|               LinqAF |   100 | 2,964.8 ns | 4.33 ns | 3.38 ns |  2.58 | 3.3951 |     - |     - |    7104 B |
|           StructLinq |   100 | 1,572.2 ns | 2.43 ns | 2.03 ns |  1.37 | 0.9899 |     - |     - |    2072 B |
| StructLinq_IFunction |   100 |   926.6 ns | 1.81 ns | 1.61 ns |  0.81 | 0.9899 |     - |     - |    2072 B |
|            Hyperlinq |   100 | 1,401.9 ns | 1.82 ns | 1.52 ns |  1.22 | 0.9670 |     - |     - |    2024 B |
|       Hyperlinq_Pool |   100 | 1,348.5 ns | 2.75 ns | 2.58 ns |  1.17 | 0.0267 |     - |     - |      56 B |
