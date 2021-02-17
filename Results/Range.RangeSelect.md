## Range.RangeSelect

### Source
[RangeSelect.cs](../LinqBenchmarks/Range/RangeSelect.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta38](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta38)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.200-preview.21079.7
  [Host]        : .NET Core 5.0.3 (CoreCLR 5.0.321.7212, CoreFX 5.0.321.7212), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.3 (CoreCLR 5.0.321.7212, CoreFX 5.0.321.7212), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|               Method | Start | Count |           Mean |       Error |      StdDev |  Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |------ |---------------:|------------:|------------:|-------:|--------:|-------:|------:|------:|----------:|
|              **ForLoop** |     **0** |     **0** |      **0.0000 ns** |   **0.0000 ns** |   **0.0000 ns** |      **?** |       **?** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |     0 |     0 |     21.7101 ns |   0.1560 ns |   0.1382 ns |      ? |       ? | 0.0268 |     - |     - |      56 B |
|                 Linq |     0 |     0 |     40.9794 ns |   0.9468 ns |   2.7468 ns |      ? |       ? |      - |     - |     - |         - |
|           LinqFaster |     0 |     0 |      9.7555 ns |   0.1150 ns |   0.1076 ns |      ? |       ? | 0.0229 |     - |     - |      48 B |
|      LinqFaster_SIMD |     0 |     0 |     12.6013 ns |   0.0815 ns |   0.0762 ns |      ? |       ? | 0.0229 |     - |     - |      48 B |
|               LinqAF |     0 |     0 |     40.4577 ns |   0.7907 ns |   1.4458 ns |      ? |       ? |      - |     - |     - |         - |
|           StructLinq |     0 |     0 |     14.0866 ns |   0.0579 ns |   0.0541 ns |      ? |       ? | 0.0115 |     - |     - |      24 B |
| StructLinq_IFunction |     0 |     0 |     12.6138 ns |   0.0424 ns |   0.0376 ns |      ? |       ? |      - |     - |     - |         - |
|            Hyperlinq |     0 |     0 |     21.2577 ns |   0.0464 ns |   0.0434 ns |      ? |       ? |      - |     - |     - |         - |
|  Hyperlinq_IFunction |     0 |     0 |     19.0325 ns |   0.0431 ns |   0.0382 ns |      ? |       ? |      - |     - |     - |         - |
|                      |       |       |                |             |             |        |         |        |       |       |           |
|              **ForLoop** |     **0** |    **10** |      **1.3933 ns** |   **0.0164 ns** |   **0.0145 ns** |   **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |     0 |    10 |     70.9910 ns |   1.2365 ns |   1.0961 ns |  50.96 |    1.20 | 0.0267 |     - |     - |      56 B |
|                 Linq |     0 |    10 |    132.8292 ns |   1.8152 ns |   1.6091 ns |  95.34 |    1.14 | 0.0420 |     - |     - |      88 B |
|           LinqFaster |     0 |    10 |     41.7407 ns |   0.5408 ns |   0.4794 ns |  29.96 |    0.42 | 0.0612 |     - |     - |     128 B |
|      LinqFaster_SIMD |     0 |    10 |     34.3061 ns |   0.1636 ns |   0.1531 ns |  24.63 |    0.32 | 0.0612 |     - |     - |     128 B |
|               LinqAF |     0 |    10 |    148.8819 ns |   3.5470 ns |  10.4028 ns | 108.07 |    7.79 |      - |     - |     - |         - |
|           StructLinq |     0 |    10 |     40.9412 ns |   0.2576 ns |   0.2011 ns |  29.34 |    0.35 | 0.0114 |     - |     - |      24 B |
| StructLinq_IFunction |     0 |    10 |     26.1468 ns |   0.0398 ns |   0.0353 ns |  18.77 |    0.20 |      - |     - |     - |         - |
|            Hyperlinq |     0 |    10 |     59.9073 ns |   1.2428 ns |   3.4231 ns |  42.49 |    2.54 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |     0 |    10 |     32.8550 ns |   0.0729 ns |   0.0646 ns |  23.58 |    0.24 |      - |     - |     - |         - |
|                      |       |       |                |             |             |        |         |        |       |       |           |
|              **ForLoop** |     **0** |  **1000** |    **306.6072 ns** |   **0.9733 ns** |   **0.9104 ns** |   **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|          ForeachLoop |     0 |  1000 |  6,477.3337 ns | 127.7318 ns | 277.6784 ns |  21.04 |    0.89 | 0.0229 |     - |     - |      56 B |
|                 Linq |     0 |  1000 | 10,010.6018 ns | 284.3815 ns | 825.0422 ns |  33.58 |    3.22 | 0.0305 |     - |     - |      88 B |
|           LinqFaster |     0 |  1000 |  3,750.8205 ns |  31.6979 ns |  29.6502 ns |  12.23 |    0.10 | 3.8452 |     - |     - |    8048 B |
|      LinqFaster_SIMD |     0 |  1000 |  1,351.7557 ns |  14.6857 ns |  13.7370 ns |   4.41 |    0.04 | 3.8452 |     - |     - |    8048 B |
|               LinqAF |     0 |  1000 | 10,742.8383 ns | 252.2148 ns | 739.7024 ns |  35.14 |    2.20 |      - |     - |     - |         - |
|           StructLinq |     0 |  1000 |  3,237.4695 ns |  64.7530 ns | 189.9093 ns |  10.43 |    0.64 | 0.0114 |     - |     - |      24 B |
| StructLinq_IFunction |     0 |  1000 |  1,426.0534 ns |   1.3150 ns |   1.2300 ns |   4.65 |    0.02 |      - |     - |     - |         - |
|            Hyperlinq |     0 |  1000 |  3,440.0256 ns |  79.5948 ns | 233.4377 ns |  11.53 |    0.89 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |     0 |  1000 |  1,437.5536 ns |   2.4397 ns |   2.2821 ns |   4.69 |    0.02 |      - |     - |     - |         - |
