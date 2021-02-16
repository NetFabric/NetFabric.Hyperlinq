## List.Int32.ListInt32SelectToList

### Source
[ListInt32SelectToList.cs](../LinqBenchmarks/List/Int32/ListInt32SelectToList.cs)

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
|                   Method | Count |        Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |------ |------------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|                  ForLoop |   100 |   336.51 ns | 2.324 ns | 1.814 ns |  1.00 |    0.00 | 0.5660 |     - |     - |    1184 B |
|              ForeachLoop |   100 |   456.45 ns | 2.441 ns | 2.283 ns |  1.36 |    0.01 | 0.5660 |     - |     - |    1184 B |
|                     Linq |   100 |   306.24 ns | 0.862 ns | 0.764 ns |  0.91 |    0.00 | 0.2522 |     - |     - |     528 B |
|               LinqFaster |   100 |   346.35 ns | 1.872 ns | 1.563 ns |  1.03 |    0.01 | 0.4358 |     - |     - |     912 B |
|                   LinqAF |   100 | 1,030.38 ns | 4.957 ns | 4.637 ns |  3.06 |    0.02 | 0.5646 |     - |     - |    1184 B |
|               StructLinq |   100 |   244.17 ns | 0.837 ns | 0.783 ns |  0.73 |    0.00 | 0.2484 |     - |     - |     520 B |
|     StructLinq_IFunction |   100 |   132.20 ns | 0.545 ns | 0.510 ns |  0.39 |    0.00 | 0.2370 |     - |     - |     496 B |
|                Hyperlinq |   100 |   222.61 ns | 1.104 ns | 1.032 ns |  0.66 |    0.00 | 0.2179 |     - |     - |     456 B |
|      Hyperlinq_IFunction |   100 |   106.67 ns | 0.350 ns | 0.292 ns |  0.32 |    0.00 | 0.2180 |     - |     - |     456 B |
|           Hyperlinq_SIMD |   100 |    88.22 ns | 0.399 ns | 0.333 ns |  0.26 |    0.00 | 0.2180 |     - |     - |     456 B |
| Hyperlinq_IFunction_SIMD |   100 |    59.19 ns | 0.182 ns | 0.152 ns |  0.18 |    0.00 | 0.2180 |     - |     - |     456 B |
