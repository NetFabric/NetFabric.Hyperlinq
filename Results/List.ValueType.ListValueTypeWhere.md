## List.ValueType.ListValueTypeWhere

### Source
[ListValueTypeWhere.cs](../LinqBenchmarks/List/ValueType/ListValueTypeWhere.cs)

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
|               Method | Count |       Mean |    Error |  StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |-----------:|---------:|--------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop |   100 |   516.5 ns |  0.19 ns | 0.16 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 |   727.0 ns |  0.23 ns | 0.20 ns |  1.41 |    0.00 |      - |     - |     - |         - |
|                 Linq |   100 | 1,174.7 ns |  3.24 ns | 2.87 ns |  2.27 |    0.01 | 0.0648 |     - |     - |     136 B |
|           LinqFaster |   100 | 1,290.2 ns |  1.34 ns | 1.12 ns |  2.50 |    0.00 | 2.4433 |     - |     - |    5112 B |
|               LinqAF |   100 | 1,715.2 ns | 10.07 ns | 9.42 ns |  3.32 |    0.02 |      - |     - |     - |         - |
|           StructLinq |   100 |   901.3 ns |  0.40 ns | 0.32 ns |  1.74 |    0.00 |      - |     - |     - |         - |
| StructLinq_IFunction |   100 |   525.2 ns |  0.15 ns | 0.12 ns |  1.02 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq |   100 |   759.9 ns |  0.58 ns | 0.48 ns |  1.47 |    0.00 |      - |     - |     - |         - |
