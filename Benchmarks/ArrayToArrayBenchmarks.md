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
  Job-SUCOWF : .NET 6.0.0 (6.0.21.25307), X64 RyuJIT

Runtime=.NET 6.0  

```
|           Method | Count |       Mean |     Error |    StdDev |     Median | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|----------------- |------ |-----------:|----------:|----------:|-----------:|------:|--------:|-------:|------:|------:|----------:|
|       **ArrayClone** |    **10** |  **83.187 ns** | **0.5856 ns** | **0.5191 ns** |  **83.125 ns** |  **1.00** |    **0.00** | **0.0303** |     **-** |     **-** |      **64 B** |
|      SpanToArray |    10 |   7.938 ns | 0.1489 ns | 0.1320 ns |   7.921 ns |  0.10 |    0.00 | 0.0306 |     - |     - |      64 B |
| CollectionCopyTo |    10 |  16.725 ns | 0.1057 ns | 0.0989 ns |  16.735 ns |  0.20 |    0.00 | 0.0305 |     - |     - |      64 B |
|                  |       |            |           |           |            |       |         |        |       |       |           |
|       **ArrayClone** |   **100** |  **91.920 ns** | **0.4655 ns** | **0.4127 ns** |  **91.959 ns** |  **1.00** |    **0.00** | **0.2021** |     **-** |     **-** |     **424 B** |
|      SpanToArray |   100 |  33.381 ns | 0.7700 ns | 2.2702 ns |  32.260 ns |  0.39 |    0.02 | 0.2027 |     - |     - |     424 B |
| CollectionCopyTo |   100 |  39.932 ns | 0.7754 ns | 0.6874 ns |  39.978 ns |  0.43 |    0.01 | 0.2027 |     - |     - |     424 B |
|                  |       |            |           |           |            |       |         |        |       |       |           |
|       **ArrayClone** |  **1000** | **284.629 ns** | **3.2346 ns** | **2.7010 ns** | **284.130 ns** |  **1.00** |    **0.00** | **1.9155** |     **-** |     **-** |   **4,024 B** |
|      SpanToArray |  1000 | 258.078 ns | 1.8823 ns | 1.6686 ns | 258.441 ns |  0.91 |    0.01 | 1.9226 |     - |     - |   4,024 B |
| CollectionCopyTo |  1000 | 245.347 ns | 3.6884 ns | 3.4501 ns | 244.683 ns |  0.86 |    0.01 | 1.9155 |     - |     - |   4,024 B |
