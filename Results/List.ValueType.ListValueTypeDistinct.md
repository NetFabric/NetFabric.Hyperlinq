## List.ValueType.ListValueTypeDistinct

### Source
[ListValueTypeDistinct.cs](../LinqBenchmarks/List/ValueType/ListValueTypeDistinct.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- StructLinq.BCL: [0.19.1](https://www.nuget.org/packages/StructLinq.BCL/0.19.1)
- NetFabric.Hyperlinq: [3.0.0-beta23](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta23)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.100-preview.7.20366.6
  [Host]        : .NET Core 5.0.0 (CoreCLR 5.0.20.36411, CoreFX 5.0.20.36411), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.0 (CoreCLR 5.0.20.36411, CoreFX 5.0.20.36411), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|               Method | Duplicates | Count |       Mean |     Error |    StdDev | Ratio | RatioSD |     Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |----------- |------ |-----------:|----------:|----------:|------:|--------:|----------:|------:|------:|----------:|
|              ForLoop |          4 |   100 | 517.235 μs | 8.6759 μs | 8.1155 μs | 1.000 |    0.00 | 1095.7031 |     - |     - | 2292184 B |
|          ForeachLoop |          4 |   100 | 540.062 μs | 8.6113 μs | 8.0550 μs | 1.044 |    0.02 | 1095.7031 |     - |     - | 2292184 B |
|                 Linq |          4 |   100 | 518.883 μs | 7.8847 μs | 7.3754 μs | 1.003 |    0.02 | 1092.7734 |     - |     - | 2286712 B |
|           LinqFaster |          4 |   100 |   2.405 μs | 0.0251 μs | 0.0234 μs | 0.005 |    0.00 |    0.0114 |     - |     - |      24 B |
|           StructLinq |          4 |   100 | 572.192 μs | 9.3784 μs | 8.7725 μs | 1.106 |    0.02 | 1086.9141 |     - |     - | 2273601 B |
| StructLinq_IFunction |          4 |   100 |  22.581 μs | 0.0645 μs | 0.0539 μs | 0.044 |    0.00 |         - |     - |     - |         - |
|            Hyperlinq |          4 |   100 | 494.006 μs | 3.5787 μs | 3.1724 μs | 0.955 |    0.02 | 1045.8984 |     - |     - | 2187585 B |
