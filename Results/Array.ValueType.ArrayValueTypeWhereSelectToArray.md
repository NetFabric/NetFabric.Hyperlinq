## Array.ValueType.ArrayValueTypeWhereSelectToArray

### Source
[ArrayValueTypeWhereSelectToArray.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhereSelectToArray.cs)

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
|              ForLoop |   100 | 1,171.8 ns | 4.77 ns | 4.46 ns |  1.00 | 3.4122 |     - |     - |    7136 B |
|          ForeachLoop |   100 | 1,172.4 ns | 3.57 ns | 3.34 ns |  1.00 | 3.4122 |     - |     - |    7136 B |
|                 Linq |   100 | 1,417.8 ns | 4.53 ns | 4.24 ns |  1.21 | 2.4319 |     - |     - |    5088 B |
|           LinqFaster |   100 | 1,206.4 ns | 5.36 ns | 5.01 ns |  1.03 | 2.8896 |     - |     - |    6048 B |
|               LinqAF |   100 | 2,446.8 ns | 4.71 ns | 3.94 ns |  2.09 | 3.3951 |     - |     - |    7104 B |
|           StructLinq |   100 | 1,581.4 ns | 3.07 ns | 2.87 ns |  1.35 | 0.9899 |     - |     - |    2072 B |
| StructLinq_IFunction |   100 |   945.4 ns | 1.60 ns | 1.50 ns |  0.81 | 0.9899 |     - |     - |    2072 B |
|            Hyperlinq |   100 | 1,380.1 ns | 3.52 ns | 3.29 ns |  1.18 | 0.9670 |     - |     - |    2024 B |
|       Hyperlinq_Pool |   100 | 1,312.8 ns | 2.97 ns | 2.77 ns |  1.12 | 0.0267 |     - |     - |      56 B |
