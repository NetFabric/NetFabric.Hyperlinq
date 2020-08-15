## Array.ValueType.ArrayValueTypeWhereSelect

### Source
[ArrayValueTypeWhereSelect.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhereSelect.cs)

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
|              ForLoop |   100 |   915.2 ns | 0.66 ns | 0.55 ns |  1.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 |   901.5 ns | 1.12 ns | 0.93 ns |  0.99 |      - |     - |     - |         - |
|                 Linq |   100 | 1,454.1 ns | 1.62 ns | 1.36 ns |  1.59 | 0.0801 |     - |     - |     168 B |
|           LinqFaster |   100 | 1,560.8 ns | 4.61 ns | 4.32 ns |  1.71 | 2.8896 |     - |     - |    6048 B |
|               LinqAF |   100 | 1,971.8 ns | 2.03 ns | 1.58 ns |  2.15 |      - |     - |     - |         - |
|           StructLinq |   100 | 1,452.3 ns | 1.92 ns | 1.79 ns |  1.59 |      - |     - |     - |         - |
| StructLinq_IFunction |   100 |   956.2 ns | 1.53 ns | 1.36 ns |  1.04 |      - |     - |     - |         - |
|            Hyperlinq |   100 | 1,393.8 ns | 8.56 ns | 7.15 ns |  1.52 |      - |     - |     - |         - |
