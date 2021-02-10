## Array.ValueType.ArrayValueTypeWhereSelect

### Source
[ArrayValueTypeWhereSelect.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhereSelect.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta35](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta35)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.200-preview.20614.14
  [Host]        : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|               Method | Count |       Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |-----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop |   100 |   830.0 ns |  2.02 ns |  1.79 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 |   910.0 ns |  2.07 ns |  1.84 ns |  1.10 |    0.00 |      - |     - |     - |         - |
|                 Linq |   100 | 1,425.1 ns |  5.89 ns |  4.91 ns |  1.72 |    0.01 | 0.0801 |     - |     - |     168 B |
|           LinqFaster |   100 | 1,453.3 ns | 10.19 ns |  9.04 ns |  1.75 |    0.01 | 2.9659 |     - |     - |    6208 B |
|               LinqAF |   100 | 1,896.0 ns | 14.59 ns | 12.94 ns |  2.28 |    0.02 |      - |     - |     - |         - |
|           StructLinq |   100 | 1,160.1 ns |  4.48 ns |  3.97 ns |  1.40 |    0.01 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction |   100 |   940.5 ns |  2.31 ns |  2.05 ns |  1.13 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq |   100 | 1,142.2 ns |  2.83 ns |  2.51 ns |  1.38 |    0.00 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |   100 |   990.6 ns |  2.85 ns |  2.53 ns |  1.19 |    0.00 |      - |     - |     - |         - |
