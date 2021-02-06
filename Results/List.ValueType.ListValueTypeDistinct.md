## List.ValueType.ListValueTypeDistinct

### Source
[ListValueTypeDistinct.cs](../LinqBenchmarks/List/ValueType/ListValueTypeDistinct.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta32](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta32)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.200-preview.20614.14
  [Host]        : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|               Method | Duplicates | Count |         Mean |      Error |     StdDev | Ratio | RatioSD |     Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |----------- |------ |-------------:|-----------:|-----------:|------:|--------:|----------:|------:|------:|----------:|
|              ForLoop |          4 |   100 |   526.385 μs |  2.2086 μs |  1.8443 μs | 1.000 |    0.00 | 1095.7031 |     - |     - | 2292184 B |
|          ForeachLoop |          4 |   100 |   530.849 μs |  2.8042 μs |  2.3416 μs | 1.008 |    0.01 | 1095.7031 |     - |     - | 2292184 B |
|                 Linq |          4 |   100 |   540.652 μs |  1.9933 μs |  1.8645 μs | 1.027 |    0.00 | 1092.7734 |     - |     - | 2286712 B |
|           LinqFaster |          4 |   100 |     2.507 μs |  0.0101 μs |  0.0085 μs | 0.005 |    0.00 |    0.0114 |     - |     - |      24 B |
|               LinqAF |          4 |   100 | 1,729.284 μs | 26.8421 μs | 25.1081 μs | 3.291 |    0.05 | 2187.5000 |     - |     - | 4575072 B |
|           StructLinq |          4 |   100 |   593.143 μs |  2.0200 μs |  1.7907 μs | 1.127 |    0.00 | 1086.9141 |     - |     - | 2273665 B |
| StructLinq_IFunction |          4 |   100 |     4.552 μs |  0.0459 μs |  0.0430 μs | 0.009 |    0.00 |         - |     - |     - |         - |
|            Hyperlinq |          4 |   100 |   494.708 μs |  5.3697 μs |  4.7601 μs | 0.939 |    0.01 | 1045.8984 |     - |     - | 2187585 B |
