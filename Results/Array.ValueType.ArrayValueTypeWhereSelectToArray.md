## Array.ValueType.ArrayValueTypeWhereSelectToArray

### Source
[ArrayValueTypeWhereSelectToArray.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhereSelectToArray.cs)

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
|               Method | Count |       Mean |    Error |  StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |-----------:|---------:|--------:|------:|-------:|------:|------:|----------:|
|              ForLoop |   100 | 1,149.7 ns |  4.12 ns | 3.44 ns |  1.00 | 3.4122 |     - |     - |    7136 B |
|          ForeachLoop |   100 | 1,150.5 ns |  3.27 ns | 2.73 ns |  1.00 | 3.4122 |     - |     - |    7136 B |
|                 Linq |   100 | 1,453.4 ns |  5.25 ns | 4.91 ns |  1.26 | 2.4319 |     - |     - |    5088 B |
|           LinqFaster |   100 | 1,201.2 ns |  4.01 ns | 3.55 ns |  1.04 | 2.8896 |     - |     - |    6048 B |
|               LinqAF |   100 | 2,474.3 ns | 10.60 ns | 9.40 ns |  2.15 | 3.3951 |     - |     - |    7104 B |
|           StructLinq |   100 | 1,610.8 ns |  1.98 ns | 1.55 ns |  1.40 | 0.9899 |     - |     - |    2072 B |
| StructLinq_IFunction |   100 |   964.3 ns |  3.17 ns | 2.81 ns |  0.84 | 0.9899 |     - |     - |    2072 B |
|            Hyperlinq |   100 | 1,394.3 ns |  2.73 ns | 2.28 ns |  1.21 | 0.9670 |     - |     - |    2024 B |
|       Hyperlinq_Pool |   100 | 1,342.2 ns |  3.38 ns | 3.00 ns |  1.17 | 0.0267 |     - |     - |      56 B |
