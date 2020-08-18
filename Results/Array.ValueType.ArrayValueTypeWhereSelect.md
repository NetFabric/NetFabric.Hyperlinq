## Array.ValueType.ArrayValueTypeWhereSelect

### Source
[ArrayValueTypeWhereSelect.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhereSelect.cs)

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
|              ForLoop |   100 |   901.4 ns | 1.93 ns | 1.62 ns |  1.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 |   899.8 ns | 0.99 ns | 0.88 ns |  1.00 |      - |     - |     - |         - |
|                 Linq |   100 | 1,461.6 ns | 2.27 ns | 2.01 ns |  1.62 | 0.0801 |     - |     - |     168 B |
|           LinqFaster |   100 | 1,583.7 ns | 5.55 ns | 5.19 ns |  1.76 | 2.8896 |     - |     - |    6048 B |
|               LinqAF |   100 | 1,951.2 ns | 4.95 ns | 4.39 ns |  2.16 |      - |     - |     - |         - |
|           StructLinq |   100 | 1,446.0 ns | 3.16 ns | 2.95 ns |  1.60 |      - |     - |     - |         - |
| StructLinq_IFunction |   100 |   961.2 ns | 1.96 ns | 1.73 ns |  1.07 |      - |     - |     - |         - |
|            Hyperlinq |   100 | 1,415.4 ns | 2.51 ns | 2.35 ns |  1.57 |      - |     - |     - |         - |
