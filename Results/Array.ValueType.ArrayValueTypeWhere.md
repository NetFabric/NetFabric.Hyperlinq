## Array.ValueType.ArrayValueTypeWhere

### Source
[ArrayValueTypeWhere.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhere.cs)

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
|              ForLoop |   100 |   489.9 ns | 0.33 ns | 0.27 ns |  1.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 |   504.3 ns | 0.86 ns | 0.76 ns |  1.03 |      - |     - |     - |         - |
|                 Linq |   100 |   935.8 ns | 0.92 ns | 0.77 ns |  1.91 | 0.0381 |     - |     - |      80 B |
|           LinqFaster |   100 | 1,086.9 ns | 3.61 ns | 3.20 ns |  2.22 | 2.8896 |     - |     - |    6048 B |
|               LinqAF |   100 | 1,169.6 ns | 1.24 ns | 1.03 ns |  2.39 |      - |     - |     - |         - |
|           StructLinq |   100 |   880.6 ns | 1.45 ns | 1.21 ns |  1.80 |      - |     - |     - |         - |
| StructLinq_IFunction |   100 |   525.7 ns | 0.20 ns | 0.15 ns |  1.07 |      - |     - |     - |         - |
|            Hyperlinq |   100 |   758.6 ns | 1.04 ns | 0.93 ns |  1.55 |      - |     - |     - |         - |
