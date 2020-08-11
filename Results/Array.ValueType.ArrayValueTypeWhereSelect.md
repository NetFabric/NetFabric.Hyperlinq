## Array.ValueType.ArrayValueTypeWhereSelect

### Source
[ArrayValueTypeWhereSelect.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhereSelect.cs)

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
|              ForLoop |   100 |   904.9 ns | 1.65 ns | 1.54 ns |  1.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 |   900.7 ns | 1.29 ns | 1.21 ns |  1.00 |      - |     - |     - |         - |
|                 Linq |   100 | 1,449.9 ns | 1.96 ns | 1.64 ns |  1.60 | 0.0801 |     - |     - |     168 B |
|           LinqFaster |   100 | 1,550.4 ns | 3.07 ns | 2.57 ns |  1.71 | 2.8896 |     - |     - |    6048 B |
|               LinqAF |   100 | 1,905.6 ns | 1.15 ns | 0.96 ns |  2.11 |      - |     - |     - |         - |
|           StructLinq |   100 | 1,425.9 ns | 1.00 ns | 0.78 ns |  1.58 |      - |     - |     - |         - |
| StructLinq_IFunction |   100 |   951.9 ns | 0.44 ns | 0.39 ns |  1.05 |      - |     - |     - |         - |
|            Hyperlinq |   100 | 1,423.8 ns | 0.64 ns | 0.54 ns |  1.57 |      - |     - |     - |         - |
