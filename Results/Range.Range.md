## Range.Range

### Source
[Range.cs](../LinqBenchmarks/Range/Range.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta39](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta39)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=6.0.100-preview.1.21103.13
  [Host]        : .NET Core 5.0.3 (CoreCLR 5.0.321.7212, CoreFX 5.0.321.7212), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.3 (CoreCLR 5.0.321.7212, CoreFX 5.0.321.7212), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|          Method | Start | Count |         Mean |      Error |     StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------- |------ |------ |-------------:|-----------:|-----------:|------:|--------:|-------:|------:|------:|----------:|
|         **ForLoop** |     **0** |    **10** |     **3.170 ns** |  **0.0206 ns** |  **0.0183 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|     ForeachLoop |     0 |    10 |    67.528 ns |  0.2042 ns |  0.1810 ns | 21.30 |    0.12 | 0.0267 |     - |     - |      56 B |
|            Linq |     0 |    10 |    59.553 ns |  0.2405 ns |  0.2132 ns | 18.79 |    0.15 | 0.0191 |     - |     - |      40 B |
|      LinqFaster |     0 |    10 |    14.181 ns |  0.1283 ns |  0.1200 ns |  4.48 |    0.04 | 0.0306 |     - |     - |      64 B |
| LinqFaster_SIMD |     0 |    10 |    17.406 ns |  0.0538 ns |  0.0477 ns |  5.49 |    0.04 | 0.0306 |     - |     - |      64 B |
|          LinqAF |     0 |    10 |    30.840 ns |  0.0882 ns |  0.0782 ns |  9.73 |    0.07 |      - |     - |     - |         - |
|      StructLinq |     0 |    10 |     3.675 ns |  0.0187 ns |  0.0156 ns |  1.16 |    0.01 |      - |     - |     - |         - |
|       Hyperlinq |     0 |    10 |    11.715 ns |  0.0231 ns |  0.0216 ns |  3.70 |    0.02 |      - |     - |     - |         - |
|                 |       |       |              |            |            |       |         |        |       |       |           |
|         **ForLoop** |     **0** |  **1000** |   **265.855 ns** |  **0.7200 ns** |  **0.6735 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|     ForeachLoop |     0 |  1000 | 4,442.501 ns | 15.2685 ns | 12.7499 ns | 16.71 |    0.07 | 0.0229 |     - |     - |      56 B |
|            Linq |     0 |  1000 | 3,928.312 ns | 12.8869 ns | 10.7612 ns | 14.78 |    0.05 | 0.0153 |     - |     - |      40 B |
|      LinqFaster |     0 |  1000 | 1,229.749 ns |  6.1990 ns |  5.7986 ns |  4.63 |    0.03 | 1.9226 |     - |     - |    4024 B |
| LinqFaster_SIMD |     0 |  1000 |   788.342 ns |  5.7753 ns |  4.8226 ns |  2.97 |    0.02 | 1.9226 |     - |     - |    4024 B |
|          LinqAF |     0 |  1000 | 1,578.363 ns |  2.5909 ns |  2.2968 ns |  5.94 |    0.02 |      - |     - |     - |         - |
|      StructLinq |     0 |  1000 |   266.397 ns |  0.6561 ns |  0.5479 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|       Hyperlinq |     0 |  1000 |   278.843 ns |  0.7187 ns |  0.6372 ns |  1.05 |    0.00 |      - |     - |     - |         - |
