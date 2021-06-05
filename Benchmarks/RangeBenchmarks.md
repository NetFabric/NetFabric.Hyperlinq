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
  Job-SUCOWF : .NET 6.0.0 (6.0.21.25307), X64 RyuJIT

Runtime=.NET 6.0  

```
|          Method |  Categories | Count |        Mean |     Error |   StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------- |------------ |------ |------------:|----------:|---------:|------:|-------:|------:|------:|----------:|
|            Linq |       Range |   100 |   397.16 ns |  4.535 ns | 4.242 ns |  1.00 | 0.0191 |     - |     - |      40 B |
|      StructLinq |       Range |   100 |    33.81 ns |  0.143 ns | 0.126 ns |  0.09 |      - |     - |     - |         - |
|       Hyperlinq |       Range |   100 |    42.34 ns |  0.192 ns | 0.170 ns |  0.11 |      - |     - |     - |         - |
|                 |             |       |             |           |          |       |        |       |       |           |
|      Linq_Async | Range_Async |   100 | 3,689.77 ns | 10.303 ns | 9.133 ns |  1.00 | 0.0229 |     - |     - |      48 B |
| Hyperlinq_Async | Range_Async |   100 | 1,230.03 ns |  4.703 ns | 3.927 ns |  0.33 | 0.0153 |     - |     - |      32 B |
