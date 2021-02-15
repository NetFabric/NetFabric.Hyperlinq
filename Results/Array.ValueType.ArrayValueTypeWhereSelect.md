## Array.ValueType.ArrayValueTypeWhereSelect

### Source
[ArrayValueTypeWhereSelect.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhereSelect.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta36](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta36)

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
|              ForLoop |   100 |   855.1 ns |  1.50 ns |  1.26 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 |   931.1 ns |  3.04 ns |  2.85 ns |  1.09 |    0.00 |      - |     - |     - |         - |
|                 Linq |   100 | 1,465.6 ns |  3.66 ns |  3.24 ns |  1.71 |    0.01 | 0.0801 |     - |     - |     168 B |
|           LinqFaster |   100 | 1,530.7 ns |  4.90 ns |  4.10 ns |  1.79 |    0.01 | 2.9659 |     - |     - |    6208 B |
|               LinqAF |   100 | 2,053.3 ns | 16.26 ns | 15.21 ns |  2.40 |    0.02 |      - |     - |     - |         - |
|           StructLinq |   100 | 1,201.4 ns |  4.98 ns |  4.41 ns |  1.41 |    0.01 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction |   100 |   968.4 ns |  3.60 ns |  3.19 ns |  1.13 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq |   100 | 1,163.9 ns |  2.25 ns |  1.75 ns |  1.36 |    0.00 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |   100 | 1,026.4 ns |  3.68 ns |  3.45 ns |  1.20 |    0.00 |      - |     - |     - |         - |
