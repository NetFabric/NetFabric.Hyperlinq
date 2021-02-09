## List.Int32.ListInt32WhereSelect

### Source
[ListInt32WhereSelect.cs](../LinqBenchmarks/List/Int32/ListInt32WhereSelect.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta34](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta34)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.200-preview.20614.14
  [Host]        : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|               Method | Count |        Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |------------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop |   100 |    97.76 ns | 0.345 ns | 0.306 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 |   251.28 ns | 0.887 ns | 0.786 ns |  2.57 |    0.01 |      - |     - |     - |         - |
|                 Linq |   100 |   986.63 ns | 6.745 ns | 5.979 ns | 10.09 |    0.07 | 0.0725 |     - |     - |     152 B |
|           LinqFaster |   100 |   505.68 ns | 1.572 ns | 1.227 ns |  5.17 |    0.02 | 0.3090 |     - |     - |     648 B |
|               LinqAF |   100 | 1,052.98 ns | 3.222 ns | 2.690 ns | 10.77 |    0.03 |      - |     - |     - |         - |
|           StructLinq |   100 |   365.50 ns | 1.048 ns | 0.929 ns |  3.74 |    0.01 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction |   100 |   181.78 ns | 0.430 ns | 0.381 ns |  1.86 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq |   100 |   380.03 ns | 1.626 ns | 1.521 ns |  3.89 |    0.02 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |   100 |   198.71 ns | 1.530 ns | 1.357 ns |  2.03 |    0.02 |      - |     - |     - |         - |
