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

BenchmarkDotNet=v0.12.1.1521-nightly, OS=Windows 10.0.19043
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.4.21255.9
  [Host]     : .NET 6.0.0 (6.0.21.25307), X64 RyuJIT
  Job-ERYMHU : .NET 6.0.0 (6.0.21.25307), X64 RyuJIT

Runtime=.NET 6.0  

```
|           Method | Count |       Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|----------------- |------ |-----------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|       **ArrayClone** |    **10** |  **83.162 ns** | **0.9078 ns** | **0.8491 ns** |  **1.00** |    **0.00** | **0.0303** |     **-** |     **-** |      **64 B** |
|      SpanToArray |    10 |   7.645 ns | 0.0932 ns | 0.0872 ns |  0.09 |    0.00 | 0.0306 |     - |     - |      64 B |
| CollectionCopyTo |    10 |  15.119 ns | 0.3594 ns | 0.2806 ns |  0.18 |    0.00 | 0.0305 |     - |     - |      64 B |
|                  |       |            |           |           |       |         |        |       |       |           |
|       **ArrayClone** |   **100** |  **91.453 ns** | **1.2853 ns** | **1.2023 ns** |  **1.00** |    **0.00** | **0.2021** |     **-** |     **-** |     **424 B** |
|      SpanToArray |   100 |  30.949 ns | 0.6774 ns | 0.6336 ns |  0.34 |    0.01 | 0.2027 |     - |     - |     424 B |
| CollectionCopyTo |   100 |  38.433 ns | 0.7989 ns | 0.8204 ns |  0.42 |    0.01 | 0.2027 |     - |     - |     424 B |
|                  |       |            |           |           |       |         |        |       |       |           |
|       **ArrayClone** |  **1000** | **243.403 ns** | **4.9315 ns** | **5.8706 ns** |  **1.00** |    **0.00** | **1.9155** |     **-** |     **-** |   **4,024 B** |
|      SpanToArray |  1000 | 250.213 ns | 4.9555 ns | 5.5080 ns |  1.03 |    0.03 | 1.9226 |     - |     - |   4,024 B |
| CollectionCopyTo |  1000 | 242.564 ns | 3.3163 ns | 3.1020 ns |  1.00 |    0.02 | 1.9155 |     - |     - |   4,024 B |
