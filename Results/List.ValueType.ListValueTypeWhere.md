## List.ValueType.ListValueTypeWhere

### Source
[ListValueTypeWhere.cs](../LinqBenchmarks/List/ValueType/ListValueTypeWhere.cs)

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
|               Method | Count |       Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |-----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop |   100 |   531.2 ns |  0.53 ns |  0.44 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 |   728.1 ns |  0.33 ns |  0.26 ns |  1.37 |    0.00 |      - |     - |     - |         - |
|                 Linq |   100 | 1,177.6 ns |  0.83 ns |  0.70 ns |  2.22 |    0.00 | 0.0648 |     - |     - |     136 B |
|           LinqFaster |   100 | 1,318.7 ns |  3.70 ns |  3.28 ns |  2.48 |    0.01 | 2.4433 |     - |     - |    5112 B |
|               LinqAF |   100 | 1,691.9 ns | 15.21 ns | 14.22 ns |  3.19 |    0.03 |      - |     - |     - |         - |
|           StructLinq |   100 |   902.9 ns |  1.27 ns |  1.06 ns |  1.70 |    0.00 |      - |     - |     - |         - |
| StructLinq_IFunction |   100 |   524.2 ns |  0.15 ns |  0.13 ns |  0.99 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq |   100 |   758.5 ns |  0.30 ns |  0.24 ns |  1.43 |    0.00 |      - |     - |     - |         - |
