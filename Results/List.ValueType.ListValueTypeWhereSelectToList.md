## List.ValueType.ListValueTypeWhereSelectToList

### Source
[ListValueTypeWhereSelectToList.cs](../LinqBenchmarks/List/ValueType/ListValueTypeWhereSelectToList.cs)

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
|              ForLoop |   100 | 1,002.0 ns |  1.52 ns |  1.27 ns |  1.00 |    0.00 | 2.4433 |     - |     - |   4.99 KB |
|          ForeachLoop |   100 | 1,251.4 ns |  1.50 ns |  1.17 ns |  1.25 |    0.00 | 2.4433 |     - |     - |   4.99 KB |
|                 Linq |   100 | 1,439.7 ns |  4.02 ns |  3.76 ns |  1.44 |    0.00 | 2.5768 |     - |     - |   5.27 KB |
|           LinqFaster |   100 | 1,589.5 ns |  6.99 ns |  6.54 ns |  1.59 |    0.01 | 3.4237 |     - |     - |      7 KB |
|               LinqAF |   100 | 2,993.9 ns | 51.40 ns | 48.08 ns |  2.99 |    0.05 | 2.4414 |     - |     - |   4.99 KB |
|           StructLinq |   100 | 1,577.3 ns |  4.66 ns |  3.63 ns |  1.57 |    0.00 | 1.0052 |     - |     - |   2.05 KB |
| StructLinq_IFunction |   100 |   936.7 ns |  2.71 ns |  2.40 ns |  0.93 |    0.00 | 1.0052 |     - |     - |   2.05 KB |
|            Hyperlinq |   100 | 1,405.6 ns |  5.13 ns |  4.54 ns |  1.40 |    0.00 | 1.0166 |     - |     - |   2.08 KB |
