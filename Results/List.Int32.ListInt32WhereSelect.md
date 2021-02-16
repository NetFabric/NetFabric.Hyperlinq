## List.Int32.ListInt32WhereSelect

### Source
[ListInt32WhereSelect.cs](../LinqBenchmarks/List/Int32/ListInt32WhereSelect.cs)

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
|               Method | Count |        Mean |    Error |   StdDev |      Median | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |------------:|---------:|---------:|------------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop |   100 |    97.38 ns | 0.246 ns | 0.206 ns |    97.29 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 |   215.99 ns | 2.243 ns | 2.098 ns |   215.80 ns |  2.22 |    0.02 |      - |     - |     - |         - |
|                 Linq |   100 |   992.00 ns | 4.519 ns | 3.528 ns |   991.88 ns | 10.19 |    0.05 | 0.0725 |     - |     - |     152 B |
|           LinqFaster |   100 |   444.84 ns | 1.837 ns | 1.629 ns |   444.57 ns |  4.57 |    0.02 | 0.3095 |     - |     - |     648 B |
|               LinqAF |   100 | 1,034.24 ns | 4.668 ns | 4.138 ns | 1,033.80 ns | 10.61 |    0.05 |      - |     - |     - |         - |
|           StructLinq |   100 |   389.37 ns | 1.790 ns | 1.674 ns |   388.88 ns |  3.99 |    0.01 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction |   100 |   189.63 ns | 3.821 ns | 9.517 ns |   183.69 ns |  1.92 |    0.08 |      - |     - |     - |         - |
|            Hyperlinq |   100 |   368.40 ns | 1.500 ns | 1.330 ns |   368.59 ns |  3.78 |    0.01 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |   100 |   207.82 ns | 0.792 ns | 0.741 ns |   207.47 ns |  2.13 |    0.01 |      - |     - |     - |         - |
