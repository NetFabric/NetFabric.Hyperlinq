## List.ValueType.ListValueTypeSkipTakeWhere

### Source
[ListValueTypeSkipTakeWhere.cs](../LinqBenchmarks/List/ValueType/ListValueTypeSkipTakeWhere.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- LinqOptimizer.CSharp: [](https://www.nuget.org/packages/LinqOptimizer.CSharp/)
- Streams.CSharp: [0.6.0](https://www.nuget.org/packages/Streams.CSharp/0.6.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)

### Results:
``` ini

BenchmarkDotNet=v0.12.1.1527-nightly, OS=Windows 10.0.19043
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.3.21202.5
  [Host] : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT
  .NET 5 : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT
  .NET 6 : .NET 6.0.0 (6.0.21.20104), X64 RyuJIT

EnvironmentVariables=COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1  

```
|               Method |    Job |  Runtime | Skip | Count |       Mean |     Error |    StdDev | Ratio | RatioSD |   Gen 0 |   Gen 1 | Gen 2 | Allocated |
|--------------------- |------- |--------- |----- |------ |-----------:|----------:|----------:|------:|--------:|--------:|--------:|------:|----------:|
|              ForLoop | .NET 5 | .NET 5.0 | 1000 |  1000 |   6.029 μs | 0.0143 μs | 0.0133 μs |  1.00 |    0.00 |       - |       - |     - |         - |
|          ForeachLoop | .NET 5 | .NET 5.0 | 1000 |  1000 |   8.251 μs | 0.0434 μs | 0.0385 μs |  1.37 |    0.01 |  0.0458 |       - |     - |      96 B |
|                 Linq | .NET 5 | .NET 5.0 | 1000 |  1000 |  20.795 μs | 0.1142 μs | 0.1012 μs |  3.45 |    0.02 |  0.1526 |       - |     - |     320 B |
|           LinqFaster | .NET 5 | .NET 5.0 | 1000 |  1000 |  35.178 μs | 0.6857 μs | 0.8421 μs |  5.85 |    0.15 | 90.8813 |       - |     - | 193,616 B |
|               LinqAF | .NET 5 | .NET 5.0 | 1000 |  1000 |  41.439 μs | 0.6891 μs | 0.6446 μs |  6.87 |    0.11 |       - |       - |     - |         - |
|        LinqOptimizer | .NET 5 | .NET 5.0 | 1000 |  1000 | 105.008 μs | 1.1807 μs | 1.8031 μs | 17.42 |    0.28 | 72.7539 | 18.0664 |     - | 187,630 B |
|              Streams | .NET 5 | .NET 5.0 | 1000 |  1000 |  40.478 μs | 0.1509 μs | 0.1412 μs |  6.71 |    0.03 |  0.5493 |       - |     - |   1,176 B |
|           StructLinq | .NET 5 | .NET 5.0 | 1000 |  1000 |   8.707 μs | 0.0505 μs | 0.0448 μs |  1.44 |    0.01 |  0.0458 |       - |     - |     120 B |
| StructLinq_IFunction | .NET 5 | .NET 5.0 | 1000 |  1000 |   7.569 μs | 0.0519 μs | 0.0460 μs |  1.26 |    0.01 |       - |       - |     - |         - |
|            Hyperlinq | .NET 5 | .NET 5.0 | 1000 |  1000 |  11.347 μs | 0.0468 μs | 0.0438 μs |  1.88 |    0.01 |       - |       - |     - |         - |
|  Hyperlinq_IFunction | .NET 5 | .NET 5.0 | 1000 |  1000 |   8.651 μs | 0.0342 μs | 0.0285 μs |  1.43 |    0.01 |       - |       - |     - |         - |
|                      |        |          |      |       |            |           |           |       |         |         |         |       |           |
|              ForLoop | .NET 6 | .NET 6.0 | 1000 |  1000 |   6.142 μs | 0.0214 μs | 0.0190 μs |  1.00 |    0.00 |       - |       - |     - |         - |
|          ForeachLoop | .NET 6 | .NET 6.0 | 1000 |  1000 |   8.452 μs | 0.0508 μs | 0.0424 μs |  1.38 |    0.01 |  0.0458 |       - |     - |      96 B |
|                 Linq | .NET 6 | .NET 6.0 | 1000 |  1000 |  16.226 μs | 0.1109 μs | 0.1038 μs |  2.64 |    0.01 |  0.1526 |       - |     - |     320 B |
|           LinqFaster | .NET 6 | .NET 6.0 | 1000 |  1000 |  38.978 μs | 0.2249 μs | 0.2104 μs |  6.34 |    0.03 | 90.8813 |       - |     - | 193,616 B |
|               LinqAF | .NET 6 | .NET 6.0 | 1000 |  1000 |  39.788 μs | 0.7464 μs | 0.7987 μs |  6.51 |    0.12 |       - |       - |     - |         - |
|        LinqOptimizer | .NET 6 | .NET 6.0 | 1000 |  1000 |  96.816 μs | 1.5074 μs | 3.6976 μs | 16.01 |    0.67 | 71.0449 | 19.7754 |     - | 187,188 B |
|              Streams | .NET 6 | .NET 6.0 | 1000 |  1000 |  31.843 μs | 0.1636 μs | 0.1450 μs |  5.18 |    0.03 |  0.5493 |       - |     - |   1,176 B |
|           StructLinq | .NET 6 | .NET 6.0 | 1000 |  1000 |   8.069 μs | 0.0492 μs | 0.0461 μs |  1.31 |    0.01 |  0.0458 |       - |     - |     120 B |
| StructLinq_IFunction | .NET 6 | .NET 6.0 | 1000 |  1000 |   5.719 μs | 0.0240 μs | 0.0213 μs |  0.93 |    0.00 |       - |       - |     - |         - |
|            Hyperlinq | .NET 6 | .NET 6.0 | 1000 |  1000 |  12.890 μs | 0.0805 μs | 0.0713 μs |  2.10 |    0.01 |       - |       - |     - |         - |
|  Hyperlinq_IFunction | .NET 6 | .NET 6.0 | 1000 |  1000 |  10.677 μs | 0.0867 μs | 0.0769 μs |  1.74 |    0.01 |       - |       - |     - |         - |
