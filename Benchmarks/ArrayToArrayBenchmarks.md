## ArrayToArrayBenchmarks

### Source
[ArrayToArrayBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/ArrayToArrayBenchmarks.cs)

### References:
- Linq: 6.0.0-preview.5.21301.5
- System.Linq.Async: [5.0.0](https://www.nuget.org/packages/System.Linq.Async/5.0.0)
- System.Interactive: [5.0.0](https://www.nuget.org/packages/System.Interactive/5.0.0)
- System.Interactive.Async: [5.0.0](https://www.nuget.org/packages/System.Interactive.Async/5.0.0)
- StructLinq: [0.26.0](https://www.nuget.org/packages/StructLinq/0.26.0)
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)

### Results:
``` ini

BenchmarkDotNet=v0.13.0.1555-nightly, OS=Windows 10.0.19043.1055 (21H1/May2021Update)
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.5.21302.13
  [Host]     : .NET 6.0.0 (6.0.21.30105), X64 RyuJIT
  Job-UNTOJZ : .NET 6.0.0 (6.0.21.30105), X64 RyuJIT

Runtime=.NET 6.0  

```
|           Method | Count |       Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|----------------- |------ |-----------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|       **ArrayClone** |    **10** |  **92.985 ns** | **1.9170 ns** | **2.4926 ns** |  **1.00** |    **0.00** | **0.0303** |     **-** |     **-** |      **64 B** |
|      SpanToArray |    10 |   7.493 ns | 0.1325 ns | 0.1175 ns |  0.08 |    0.00 | 0.0306 |     - |     - |      64 B |
|       SpanCopyTo |    10 |   8.646 ns | 0.1475 ns | 0.1307 ns |  0.09 |    0.00 | 0.0306 |     - |     - |      64 B |
| CollectionCopyTo |    10 |  14.323 ns | 0.1582 ns | 0.1403 ns |  0.16 |    0.01 | 0.0305 |     - |     - |      64 B |
|                  |       |            |           |           |       |         |        |       |       |           |
|       **ArrayClone** |   **100** |  **92.451 ns** | **1.1867 ns** | **1.1101 ns** |  **1.00** |    **0.00** | **0.2021** |     **-** |     **-** |     **424 B** |
|      SpanToArray |   100 |  31.352 ns | 0.6448 ns | 0.6031 ns |  0.34 |    0.01 | 0.2027 |     - |     - |     424 B |
|       SpanCopyTo |   100 |  33.141 ns | 0.8588 ns | 2.4914 ns |  0.36 |    0.02 | 0.2027 |     - |     - |     424 B |
| CollectionCopyTo |   100 |  34.238 ns | 0.5767 ns | 0.5394 ns |  0.37 |    0.01 | 0.2027 |     - |     - |     424 B |
|                  |       |            |           |           |       |         |        |       |       |           |
|       **ArrayClone** |  **1000** | **286.609 ns** | **2.1636 ns** | **1.8067 ns** |  **1.00** |    **0.00** | **1.9155** |     **-** |     **-** |   **4,024 B** |
|      SpanToArray |  1000 | 269.321 ns | 4.8332 ns | 4.5210 ns |  0.94 |    0.01 | 1.9226 |     - |     - |   4,024 B |
|       SpanCopyTo |  1000 | 242.775 ns | 3.5268 ns | 3.2990 ns |  0.85 |    0.01 | 1.9155 |     - |     - |   4,024 B |
| CollectionCopyTo |  1000 | 243.677 ns | 4.2879 ns | 4.0109 ns |  0.85 |    0.02 | 1.9155 |     - |     - |   4,024 B |
