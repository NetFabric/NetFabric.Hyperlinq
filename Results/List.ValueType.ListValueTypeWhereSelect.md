## List.ValueType.ListValueTypeWhereSelect

### Source
[ListValueTypeWhereSelect.cs](../LinqBenchmarks/List/ValueType/ListValueTypeWhereSelect.cs)

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
|              ForLoop |   100 |   930.5 ns | 1.14 ns | 1.01 ns |  1.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 | 1,155.5 ns | 1.00 ns | 0.83 ns |  1.24 |      - |     - |     - |         - |
|                 Linq |   100 | 1,694.5 ns | 2.52 ns | 2.36 ns |  1.82 | 0.1335 |     - |     - |     280 B |
|           LinqFaster |   100 | 1,804.1 ns | 2.49 ns | 2.08 ns |  1.94 | 2.4433 |     - |     - |    5112 B |
|               LinqAF |   100 | 2,445.3 ns | 4.11 ns | 3.64 ns |  2.63 |      - |     - |     - |         - |
|           StructLinq |   100 | 1,450.2 ns | 0.68 ns | 0.53 ns |  1.56 |      - |     - |     - |         - |
| StructLinq_IFunction |   100 |   955.2 ns | 2.19 ns | 1.94 ns |  1.03 |      - |     - |     - |         - |
|            Hyperlinq |   100 | 1,407.1 ns | 1.31 ns | 1.16 ns |  1.51 |      - |     - |     - |         - |
