## ArrayToArrayBenchmarks

### Source
[ArrayToArrayBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/ArrayToArrayBenchmarks.cs)

### References:
- Linq: 6.0.0-preview.4.21253.7
- System.Linq.Async: [5.0.0](https://www.nuget.org/packages/System.Linq.Async/5.0.0)
- System.Interactive: [5.0.0](https://www.nuget.org/packages/System.Interactive/5.0.0)
- System.Interactive.Async: [5.0.0](https://www.nuget.org/packages/System.Interactive.Async/5.0.0)
- StructLinq: [0.26.0](https://www.nuget.org/packages/StructLinq/0.26.0)
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)

### Results:
``` ini

BenchmarkDotNet=v0.13.0.1555-nightly, OS=Windows 10.0.19043.1023 (21H1/May2021Update)
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.4.21255.9
  [Host]     : .NET 6.0.0 (6.0.21.25307), X64 RyuJIT
  Job-ZXXAXW : .NET 6.0.0 (6.0.21.25307), X64 RyuJIT

Runtime=.NET 6.0  

```
|           Method | Count |      Mean |     Error |    StdDev |    Median | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|----------------- |------ |----------:|----------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|       **ArrayClone** |    **10** | **131.36 ns** |  **7.707 ns** | **22.724 ns** | **134.45 ns** |  **1.00** |    **0.00** | **0.0303** |     **-** |     **-** |      **64 B** |
|      SpanToArray |    10 |  12.59 ns |  0.804 ns |  2.370 ns |  12.90 ns |  0.10 |    0.02 | 0.0306 |     - |     - |      64 B |
|       SpanCopyTo |    10 |  12.86 ns |  0.750 ns |  2.212 ns |  13.18 ns |  0.10 |    0.03 | 0.0306 |     - |     - |      64 B |
| CollectionCopyTo |    10 |  19.71 ns |  1.111 ns |  3.276 ns |  19.25 ns |  0.16 |    0.04 | 0.0305 |     - |     - |      64 B |
|                  |       |           |           |           |           |       |         |        |       |       |           |
|       **ArrayClone** |   **100** | **131.39 ns** |  **7.409 ns** | **21.846 ns** | **120.03 ns** |  **1.00** |    **0.00** | **0.2019** |     **-** |     **-** |     **424 B** |
|      SpanToArray |   100 |  43.71 ns |  2.028 ns |  5.979 ns |  43.53 ns |  0.34 |    0.07 | 0.2027 |     - |     - |     424 B |
|       SpanCopyTo |   100 |  45.43 ns |  1.786 ns |  5.238 ns |  45.30 ns |  0.35 |    0.06 | 0.2027 |     - |     - |     424 B |
| CollectionCopyTo |   100 |  52.84 ns |  2.653 ns |  7.822 ns |  48.41 ns |  0.41 |    0.09 | 0.2027 |     - |     - |     424 B |
|                  |       |           |           |           |           |       |         |        |       |       |           |
|       **ArrayClone** |  **1000** | **339.56 ns** | **16.058 ns** | **47.348 ns** | **336.98 ns** |  **1.00** |    **0.00** | **1.9155** |     **-** |     **-** |   **4,024 B** |
|      SpanToArray |  1000 | 342.84 ns | 12.889 ns | 38.002 ns | 359.05 ns |  1.03 |    0.18 | 1.9226 |     - |     - |   4,024 B |
|       SpanCopyTo |  1000 | 313.68 ns | 13.129 ns | 38.710 ns | 327.16 ns |  0.94 |    0.19 | 1.9155 |     - |     - |   4,024 B |
| CollectionCopyTo |  1000 | 322.00 ns | 12.162 ns | 35.670 ns | 315.88 ns |  0.97 |    0.17 | 1.9155 |     - |     - |   4,024 B |
