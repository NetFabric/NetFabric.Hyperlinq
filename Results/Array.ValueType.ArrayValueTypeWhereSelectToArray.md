## Array.ValueType.ArrayValueTypeWhereSelectToArray

### Source
[ArrayValueTypeWhereSelectToArray.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhereSelectToArray.cs)

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
|              ForLoop |   100 | 1,166.8 ns | 1.54 ns | 1.20 ns |  1.00 | 3.4122 |     - |     - |    7136 B |
|          ForeachLoop |   100 | 1,137.3 ns | 4.36 ns | 4.08 ns |  0.97 | 3.4122 |     - |     - |    7136 B |
|                 Linq |   100 | 1,415.3 ns | 3.67 ns | 3.25 ns |  1.21 | 2.4319 |     - |     - |    5088 B |
|           LinqFaster |   100 | 1,171.9 ns | 3.47 ns | 3.08 ns |  1.00 | 2.8896 |     - |     - |    6048 B |
|               LinqAF |   100 | 2,408.4 ns | 2.42 ns | 1.89 ns |  2.06 | 3.3951 |     - |     - |    7104 B |
|           StructLinq |   100 | 1,575.7 ns | 2.97 ns | 2.63 ns |  1.35 | 0.9899 |     - |     - |    2072 B |
| StructLinq_IFunction |   100 |   939.1 ns | 2.55 ns | 2.26 ns |  0.81 | 0.9899 |     - |     - |    2072 B |
|            Hyperlinq |   100 | 1,383.9 ns | 5.75 ns | 5.10 ns |  1.19 | 0.9670 |     - |     - |    2024 B |
|       Hyperlinq_Pool |   100 | 1,324.6 ns | 1.06 ns | 0.83 ns |  1.14 | 0.0267 |     - |     - |      56 B |
