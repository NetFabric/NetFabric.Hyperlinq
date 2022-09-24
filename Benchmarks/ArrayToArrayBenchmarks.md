## ArrayToArrayBenchmarks

### Source
[ArrayToArrayBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/ArrayToArrayBenchmarks.cs)

### References:
- Linq: 6.0.0-preview.7.21377.19
- System.Linq.Async: [5.0.0](https://www.nuget.org/packages/System.Linq.Async/5.0.0)
- System.Interactive: [5.0.0](https://www.nuget.org/packages/System.Interactive/5.0.0)
- System.Interactive.Async: [5.0.0](https://www.nuget.org/packages/System.Interactive.Async/5.0.0)
- StructLinq: [0.27.0](https://www.nuget.org/packages/StructLinq/0.27.0)
- NetFabric.Hyperlinq: [3.0.0-beta45](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta45)

### Results:
``` ini

BenchmarkDotNet=v0.13.0.1561-nightly, OS=macOS Catalina 10.15.7 (19H1323) [Darwin 19.6.0]
Intel Core i5-7360U CPU 2.30GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.7.21379.14
  [Host]     : .NET 6.0.0 (6.0.21.37719), X64 RyuJIT
  .NET 6 PGO : .NET 6.0.0 (6.0.21.37719), X64 RyuJIT

Job=.NET 6 PGO  EnvironmentVariables=COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1  Runtime=.NET 6.0  

```
|           Method | Count |      Mean |    Error |   StdDev |        Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|----------------- |------ |----------:|---------:|---------:|-------------:|--------:|-------:|------:|------:|----------:|
|       **ArrayClone** |    **10** | **106.79 ns** | **0.520 ns** | **0.486 ns** |     **baseline** |        **** | **0.0305** |     **-** |     **-** |      **64 B** |
|      SpanToArray |    10 |  11.76 ns | 0.116 ns | 0.097 ns | 9.08x faster |   0.09x | 0.0306 |     - |     - |      64 B |
|       SpanCopyTo |    10 |  12.71 ns | 0.228 ns | 0.213 ns | 8.41x faster |   0.15x | 0.0306 |     - |     - |      64 B |
| CollectionCopyTo |    10 |  16.74 ns | 0.099 ns | 0.093 ns | 6.38x faster |   0.04x | 0.0306 |     - |     - |      64 B |
|                  |       |           |          |          |              |         |        |       |       |           |
|       **ArrayClone** |   **100** | **115.18 ns** | **0.865 ns** | **0.810 ns** |     **baseline** |        **** | **0.2019** |     **-** |     **-** |     **424 B** |
|      SpanToArray |   100 |  38.58 ns | 0.355 ns | 0.297 ns | 2.98x faster |   0.03x | 0.2027 |     - |     - |     424 B |
|       SpanCopyTo |   100 |  40.01 ns | 0.462 ns | 0.432 ns | 2.88x faster |   0.03x | 0.2027 |     - |     - |     424 B |
| CollectionCopyTo |   100 |  43.68 ns | 0.381 ns | 0.356 ns | 2.64x faster |   0.03x | 0.2027 |     - |     - |     424 B |
|                  |       |           |          |          |              |         |        |       |       |           |
|       **ArrayClone** |  **1000** | **310.98 ns** | **3.725 ns** | **3.302 ns** |     **baseline** |        **** | **1.9155** |     **-** |     **-** |   **4,024 B** |
|      SpanToArray |  1000 | 308.84 ns | 1.502 ns | 1.254 ns | 1.01x faster |   0.01x | 1.9226 |     - |     - |   4,024 B |
|       SpanCopyTo |  1000 | 295.58 ns | 5.032 ns | 4.707 ns | 1.05x faster |   0.01x | 1.9155 |     - |     - |   4,024 B |
| CollectionCopyTo |  1000 | 299.15 ns | 3.317 ns | 3.102 ns | 1.04x faster |   0.01x | 1.9155 |     - |     - |   4,024 B |
