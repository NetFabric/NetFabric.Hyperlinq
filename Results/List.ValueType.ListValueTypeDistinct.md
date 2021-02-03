## List.ValueType.ListValueTypeDistinct

### Source
[ListValueTypeDistinct.cs](../LinqBenchmarks/List/ValueType/ListValueTypeDistinct.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta31](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta31)

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
|              ForLoop |          4 |   100 |   520.885 μs | 2.1408 μs | 1.8978 μs | 1.000 | 1095.7031 |     - |     - | 2292184 B |
|          ForeachLoop |          4 |   100 |   529.195 μs | 1.5643 μs | 1.4632 μs | 1.016 | 1095.7031 |     - |     - | 2292184 B |
|                 Linq |          4 |   100 |   548.891 μs | 1.4317 μs | 1.1178 μs | 1.053 | 1092.7734 |     - |     - | 2286712 B |
|           LinqFaster |          4 |   100 |     2.229 μs | 0.0104 μs | 0.0092 μs | 0.004 |    0.0114 |     - |     - |      24 B |
|               LinqAF |          4 |   100 | 1,710.073 μs | 6.2948 μs | 5.2564 μs | 3.282 | 2187.5000 |     - |     - | 4575073 B |
|           StructLinq |          4 |   100 |   595.039 μs | 2.7590 μs | 2.3039 μs | 1.142 | 1086.9141 |     - |     - | 2273665 B |
| StructLinq_IFunction |          4 |   100 |     4.458 μs | 0.0117 μs | 0.0098 μs | 0.009 |         - |     - |     - |         - |
|            Hyperlinq |          4 |   100 |   481.441 μs | 3.2236 μs | 3.0154 μs | 0.925 | 1045.8984 |     - |     - | 2187584 B |
