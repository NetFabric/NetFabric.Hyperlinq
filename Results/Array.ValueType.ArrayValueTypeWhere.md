## Array.ValueType.ArrayValueTypeWhere

### Source
[ArrayValueTypeWhere.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhere.cs)

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
|              ForLoop |   100 |   505.8 ns | 0.66 ns | 0.55 ns |  1.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 |   505.6 ns | 0.43 ns | 0.36 ns |  1.00 |      - |     - |     - |         - |
|                 Linq |   100 |   942.9 ns | 0.94 ns | 0.73 ns |  1.86 | 0.0381 |     - |     - |      80 B |
|           LinqFaster |   100 | 1,082.3 ns | 2.35 ns | 2.08 ns |  2.14 | 2.8896 |     - |     - |    6048 B |
|               LinqAF |   100 | 1,174.9 ns | 2.35 ns | 2.08 ns |  2.32 |      - |     - |     - |         - |
|           StructLinq |   100 |   881.7 ns | 1.61 ns | 1.50 ns |  1.74 |      - |     - |     - |         - |
| StructLinq_IFunction |   100 |   527.4 ns | 0.79 ns | 0.70 ns |  1.04 |      - |     - |     - |         - |
|            Hyperlinq |   100 |   762.3 ns | 0.95 ns | 0.84 ns |  1.51 |      - |     - |     - |         - |
