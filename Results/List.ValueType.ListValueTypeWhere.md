## List.ValueType.ListValueTypeWhere

### Source
[ListValueTypeWhere.cs](../LinqBenchmarks/List/ValueType/ListValueTypeWhere.cs)

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
|              ForLoop |   100 |   517.4 ns | 0.19 ns | 0.15 ns |  1.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 |   743.3 ns | 1.04 ns | 0.87 ns |  1.44 |      - |     - |     - |         - |
|                 Linq |   100 | 1,186.3 ns | 1.04 ns | 0.81 ns |  2.29 | 0.0648 |     - |     - |     136 B |
|           LinqFaster |   100 | 1,337.0 ns | 2.28 ns | 2.02 ns |  2.58 | 2.4433 |     - |     - |    5112 B |
|               LinqAF |   100 | 1,672.7 ns | 2.11 ns | 1.76 ns |  3.23 |      - |     - |     - |         - |
|           StructLinq |   100 |   881.9 ns | 2.16 ns | 1.91 ns |  1.70 |      - |     - |     - |         - |
| StructLinq_IFunction |   100 |   542.8 ns | 7.40 ns | 6.93 ns |  1.05 |      - |     - |     - |         - |
|            Hyperlinq |   100 |   777.0 ns | 0.43 ns | 0.34 ns |  1.50 |      - |     - |     - |         - |
