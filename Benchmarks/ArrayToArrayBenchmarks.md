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
  Job-FXRHUT : .NET 6.0.0 (6.0.21.25307), X64 RyuJIT

Runtime=.NET 6.0  

```
|           Method | Count |       Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|----------------- |------ |-----------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|       **ArrayClone** |    **10** |  **82.746 ns** | **0.8458 ns** | **0.7912 ns** |  **1.00** |    **0.00** | **0.0303** |     **-** |     **-** |      **64 B** |
|      SpanToArray |    10 |   7.750 ns | 0.1196 ns | 0.0998 ns |  0.09 |    0.00 | 0.0306 |     - |     - |      64 B |
|       SpanCopyTo |    10 |   9.042 ns | 0.0833 ns | 0.0739 ns |  0.11 |    0.00 | 0.0306 |     - |     - |      64 B |
| CollectionCopyTo |    10 |  12.964 ns | 0.3123 ns | 0.2921 ns |  0.16 |    0.00 | 0.0305 |     - |     - |      64 B |
|                  |       |            |           |           |       |         |        |       |       |           |
|       **ArrayClone** |   **100** |  **93.642 ns** | **1.5195 ns** | **2.8909 ns** |  **1.00** |    **0.00** | **0.2021** |     **-** |     **-** |     **424 B** |
|      SpanToArray |   100 |  33.333 ns | 0.7550 ns | 2.2262 ns |  0.36 |    0.03 | 0.2027 |     - |     - |     424 B |
|       SpanCopyTo |   100 |  33.050 ns | 0.5890 ns | 0.5510 ns |  0.35 |    0.01 | 0.2027 |     - |     - |     424 B |
| CollectionCopyTo |   100 |  36.857 ns | 0.7987 ns | 0.7471 ns |  0.39 |    0.02 | 0.2027 |     - |     - |     424 B |
|                  |       |            |           |           |       |         |        |       |       |           |
|       **ArrayClone** |  **1000** | **289.606 ns** | **2.5042 ns** | **2.3424 ns** |  **1.00** |    **0.00** | **1.9155** |     **-** |     **-** |   **4,024 B** |
|      SpanToArray |  1000 | 262.557 ns | 4.3460 ns | 3.8526 ns |  0.91 |    0.02 | 1.9226 |     - |     - |   4,024 B |
|       SpanCopyTo |  1000 | 242.143 ns | 3.5619 ns | 3.1575 ns |  0.84 |    0.01 | 1.9155 |     - |     - |   4,024 B |
| CollectionCopyTo |  1000 | 245.507 ns | 4.1489 ns | 3.8809 ns |  0.85 |    0.01 | 1.9155 |     - |     - |   4,024 B |
