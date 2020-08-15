## Array.ValueType.ArrayValueTypeWhereCount

### Source
[ArrayValueTypeWhereCount.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhereCount.cs)

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
|               Method | Count |     Mean |   Error |  StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |---------:|--------:|--------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop |   100 | 117.3 ns | 0.23 ns | 0.21 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 | 116.3 ns | 0.19 ns | 0.16 ns |  0.99 |    0.00 |      - |     - |     - |         - |
|                 Linq |   100 | 716.7 ns | 1.70 ns | 1.42 ns |  6.11 |    0.01 | 0.0153 |     - |     - |      32 B |
|           LinqFaster |   100 | 295.1 ns | 1.17 ns | 1.09 ns |  2.52 |    0.01 |      - |     - |     - |         - |
|               LinqAF |   100 | 679.8 ns | 1.09 ns | 0.97 ns |  5.80 |    0.01 |      - |     - |     - |         - |
|           StructLinq |   100 | 547.6 ns | 1.61 ns | 1.51 ns |  4.67 |    0.02 | 0.0191 |     - |     - |      40 B |
| StructLinq_IFunction |   100 | 206.7 ns | 0.60 ns | 0.56 ns |  1.76 |    0.01 | 0.0191 |     - |     - |      40 B |
|            Hyperlinq |   100 | 238.5 ns | 0.71 ns | 0.59 ns |  2.03 |    0.01 |      - |     - |     - |         - |
