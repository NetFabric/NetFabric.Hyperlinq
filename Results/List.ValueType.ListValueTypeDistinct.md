## List.ValueType.ListValueTypeDistinct

### Source
[ListValueTypeDistinct.cs](../LinqBenchmarks/List/ValueType/ListValueTypeDistinct.cs)

### References:
- Cistern.ValueLinq: [0.0.11](https://www.nuget.org/packages/Cistern.ValueLinq/0.0.11)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.19.2](https://www.nuget.org/packages/StructLinq.BCL/0.19.2)
- NetFabric.Hyperlinq: [3.0.0-beta27](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta27)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.200-preview.20614.14
  [Host]        : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|               Method | Duplicates | Count |         Mean |     Error |    StdDev | Ratio |     Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |----------- |------ |-------------:|----------:|----------:|------:|----------:|------:|------:|----------:|
|              ForLoop |          4 |   100 |   518.784 μs | 1.7394 μs | 1.6270 μs | 1.000 | 1095.7031 |     - |     - | 2292184 B |
|          ForeachLoop |          4 |   100 |   520.100 μs | 2.0130 μs | 1.8830 μs | 1.003 | 1095.7031 |     - |     - | 2292184 B |
|                 Linq |          4 |   100 |   546.503 μs | 1.7439 μs | 1.5459 μs | 1.053 | 1092.7734 |     - |     - | 2286712 B |
|           LinqFaster |          4 |   100 |     2.918 μs | 0.0073 μs | 0.0064 μs | 0.006 |    0.0114 |     - |     - |      24 B |
|               LinqAF |          4 |   100 | 1,789.656 μs | 5.1959 μs | 4.3388 μs | 3.448 | 2187.5000 |     - |     - | 4575075 B |
|           StructLinq |          4 |   100 |   590.054 μs | 3.8882 μs | 3.4468 μs | 1.137 | 1086.9141 |     - |     - | 2273633 B |
| StructLinq_IFunction |          4 |   100 |     4.940 μs | 0.0136 μs | 0.0121 μs | 0.010 |         - |     - |     - |         - |
|            Hyperlinq |          4 |   100 |   487.800 μs | 2.6742 μs | 2.3706 μs | 0.940 | 1045.8984 |     - |     - | 2187584 B |
