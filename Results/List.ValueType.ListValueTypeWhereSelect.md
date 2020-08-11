## List.ValueType.ListValueTypeWhereSelect

### Source
[ListValueTypeWhereSelect.cs](../LinqBenchmarks/List/ValueType/ListValueTypeWhereSelect.cs)

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
|              ForLoop |   100 |   936.3 ns | 1.45 ns | 1.29 ns |  1.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 | 1,124.3 ns | 0.54 ns | 0.45 ns |  1.20 |      - |     - |     - |         - |
|                 Linq |   100 | 1,684.7 ns | 1.53 ns | 1.28 ns |  1.80 | 0.1335 |     - |     - |     280 B |
|           LinqFaster |   100 | 1,812.1 ns | 3.00 ns | 2.51 ns |  1.94 | 2.4433 |     - |     - |    5112 B |
|               LinqAF |   100 | 2,444.1 ns | 3.72 ns | 3.48 ns |  2.61 |      - |     - |     - |         - |
|           StructLinq |   100 | 1,435.6 ns | 0.85 ns | 0.71 ns |  1.53 |      - |     - |     - |         - |
| StructLinq_IFunction |   100 |   972.0 ns | 0.81 ns | 0.67 ns |  1.04 |      - |     - |     - |         - |
|            Hyperlinq |   100 | 1,434.2 ns | 1.96 ns | 1.74 ns |  1.53 |      - |     - |     - |         - |
