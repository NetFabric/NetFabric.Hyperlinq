## List.ValueType.ListValueTypeWhereSelect

### Source
[ListValueTypeWhereSelect.cs](../LinqBenchmarks/List/ValueType/ListValueTypeWhereSelect.cs)

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
|              ForLoop |   100 |   926.3 ns | 0.69 ns | 0.58 ns |  1.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 | 1,134.7 ns | 1.02 ns | 0.85 ns |  1.22 |      - |     - |     - |         - |
|                 Linq |   100 | 1,699.7 ns | 5.66 ns | 5.29 ns |  1.84 | 0.1335 |     - |     - |     280 B |
|           LinqFaster |   100 | 1,836.6 ns | 4.40 ns | 3.90 ns |  1.98 | 2.4433 |     - |     - |    5112 B |
|               LinqAF |   100 | 2,432.4 ns | 1.83 ns | 1.52 ns |  2.63 |      - |     - |     - |         - |
|           StructLinq |   100 | 1,455.1 ns | 1.69 ns | 1.50 ns |  1.57 |      - |     - |     - |         - |
| StructLinq_IFunction |   100 |   968.9 ns | 1.55 ns | 1.38 ns |  1.05 |      - |     - |     - |         - |
|            Hyperlinq |   100 | 1,383.2 ns | 0.70 ns | 0.59 ns |  1.49 |      - |     - |     - |         - |
