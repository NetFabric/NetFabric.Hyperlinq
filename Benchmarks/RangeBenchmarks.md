## RangeBenchmarks

### Source
[RangeBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/RangeBenchmarks.cs)

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
|          Method |  Categories | Count |        Mean |    Error |   StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------- |------------ |------ |------------:|---------:|---------:|------:|-------:|------:|------:|----------:|
|            Linq |       Range |   100 |   439.33 ns | 2.995 ns | 2.655 ns |  1.00 | 0.0191 |     - |     - |      40 B |
|      StructLinq |       Range |   100 |    33.66 ns | 0.137 ns | 0.114 ns |  0.08 |      - |     - |     - |         - |
|       Hyperlinq |       Range |   100 |    41.83 ns | 0.164 ns | 0.145 ns |  0.10 |      - |     - |     - |         - |
|                 |             |       |             |          |          |       |        |       |       |           |
|      Linq_Async | Range_Async |   100 | 3,696.52 ns | 9.939 ns | 8.811 ns |  1.00 | 0.0229 |     - |     - |      48 B |
| Hyperlinq_Async | Range_Async |   100 | 1,232.14 ns | 7.870 ns | 6.977 ns |  0.33 | 0.0153 |     - |     - |      32 B |
