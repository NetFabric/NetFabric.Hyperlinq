## List.ValueType.ListValueTypeWhereSelectToList

### Source
[ListValueTypeWhereSelectToList.cs](../LinqBenchmarks/List/ValueType/ListValueTypeWhereSelectToList.cs)

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
|               Method | Count |       Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |-----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop |   100 |   978.4 ns |  2.55 ns |  2.13 ns |  1.00 |    0.00 | 2.4433 |     - |     - |   4.99 KB |
|          ForeachLoop |   100 | 1,242.1 ns |  2.80 ns |  2.62 ns |  1.27 |    0.00 | 2.4433 |     - |     - |   4.99 KB |
|                 Linq |   100 | 1,404.7 ns |  6.44 ns |  6.03 ns |  1.44 |    0.01 | 2.5768 |     - |     - |   5.27 KB |
|           LinqFaster |   100 | 1,551.3 ns |  7.65 ns |  7.16 ns |  1.59 |    0.01 | 3.4237 |     - |     - |      7 KB |
|               LinqAF |   100 | 2,938.2 ns | 32.68 ns | 30.57 ns |  3.01 |    0.03 | 2.4414 |     - |     - |   4.99 KB |
|           StructLinq |   100 | 1,619.9 ns |  3.83 ns |  3.59 ns |  1.66 |    0.01 | 1.0052 |     - |     - |   2.05 KB |
| StructLinq_IFunction |   100 |   920.7 ns |  1.76 ns |  1.47 ns |  0.94 |    0.00 | 1.0052 |     - |     - |   2.05 KB |
|            Hyperlinq |   100 | 1,405.1 ns |  2.72 ns |  2.41 ns |  1.44 |    0.00 | 1.0166 |     - |     - |   2.08 KB |
