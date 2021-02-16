## List.ValueType.ListValueTypeWhereSelect

### Source
[ListValueTypeWhereSelect.cs](../LinqBenchmarks/List/ValueType/ListValueTypeWhereSelect.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta37](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta37)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.200-preview.21079.7
  [Host]        : .NET Core 5.0.3 (CoreCLR 5.0.321.7212, CoreFX 5.0.321.7212), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.3 (CoreCLR 5.0.321.7212, CoreFX 5.0.321.7212), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|               Method | Count |       Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |-----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop |   100 |   905.4 ns |  1.82 ns |  1.52 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 | 1,111.1 ns |  2.32 ns |  2.17 ns |  1.23 |    0.00 |      - |     - |     - |         - |
|                 Linq |   100 | 1,762.8 ns |  6.85 ns |  6.07 ns |  1.95 |    0.01 | 0.1335 |     - |     - |     280 B |
|           LinqFaster |   100 | 1,713.1 ns | 11.20 ns | 10.48 ns |  1.89 |    0.01 | 2.4433 |     - |     - |    5112 B |
|               LinqAF |   100 | 2,467.1 ns | 16.92 ns | 15.83 ns |  2.72 |    0.02 |      - |     - |     - |         - |
|           StructLinq |   100 | 1,172.1 ns |  4.63 ns |  4.33 ns |  1.29 |    0.01 | 0.0343 |     - |     - |      72 B |
| StructLinq_IFunction |   100 |   945.7 ns |  1.23 ns |  1.03 ns |  1.04 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq |   100 | 1,100.0 ns |  2.65 ns |  2.35 ns |  1.21 |    0.00 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |   100 | 2,172.3 ns |  3.68 ns |  3.07 ns |  2.40 |    0.01 |      - |     - |     - |         - |
