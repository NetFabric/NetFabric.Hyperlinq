## Array.ValueType.ArrayValueTypeWhereCount

### Source
[ArrayValueTypeWhereCount.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhereCount.cs)

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
|               Method | Count |     Mean |   Error |  StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |---------:|--------:|--------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop |   100 | 101.0 ns | 0.18 ns | 0.16 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 | 101.0 ns | 0.19 ns | 0.16 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|                 Linq |   100 | 795.8 ns | 0.96 ns | 0.85 ns |  7.88 |    0.02 | 0.0153 |     - |     - |      32 B |
|           LinqFaster |   100 | 274.0 ns | 0.26 ns | 0.22 ns |  2.71 |    0.00 |      - |     - |     - |         - |
|               LinqAF |   100 | 674.5 ns | 1.27 ns | 1.12 ns |  6.68 |    0.01 |      - |     - |     - |         - |
|           StructLinq |   100 | 546.8 ns | 0.31 ns | 0.24 ns |  5.42 |    0.01 | 0.0191 |     - |     - |      40 B |
| StructLinq_IFunction |   100 | 204.9 ns | 0.83 ns | 0.77 ns |  2.03 |    0.01 | 0.0191 |     - |     - |      40 B |
|            Hyperlinq |   100 | 240.9 ns | 0.07 ns | 0.06 ns |  2.39 |    0.00 |      - |     - |     - |         - |
