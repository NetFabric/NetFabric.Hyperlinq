## Array.ValueType.ArrayValueTypeWhere

### Source
[ArrayValueTypeWhere.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhere.cs)

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
|              ForLoop |   100 |   489.3 ns | 0.42 ns | 0.33 ns |  1.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 |   490.8 ns | 0.45 ns | 0.40 ns |  1.00 |      - |     - |     - |         - |
|                 Linq |   100 |   950.1 ns | 1.20 ns | 1.13 ns |  1.94 | 0.0381 |     - |     - |      80 B |
|           LinqFaster |   100 | 1,084.5 ns | 2.63 ns | 2.33 ns |  2.22 | 2.8896 |     - |     - |    6048 B |
|               LinqAF |   100 | 1,176.1 ns | 1.90 ns | 1.68 ns |  2.40 |      - |     - |     - |         - |
|           StructLinq |   100 |   887.3 ns | 6.85 ns | 6.41 ns |  1.81 |      - |     - |     - |         - |
| StructLinq_IFunction |   100 |   526.2 ns | 0.70 ns | 0.65 ns |  1.08 |      - |     - |     - |         - |
|            Hyperlinq |   100 |   781.6 ns | 0.61 ns | 0.51 ns |  1.60 |      - |     - |     - |         - |
