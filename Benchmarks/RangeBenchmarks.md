## RangeBenchmarks

### Source
[RangeBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/RangeBenchmarks.cs)

### References:
- Linq: 6.0.0-preview.2.21154.6
- System.Linq.Async: [5.0.0](https://www.nuget.org/packages/System.Linq.Async/5.0.0)
- System.Interactive: [5.0.0](https://www.nuget.org/packages/System.Interactive/5.0.0)
- System.Interactive.Async: [5.0.0](https://www.nuget.org/packages/System.Interactive.Async/5.0.0)
- StructLinq: [0.25.3](https://www.nuget.org/packages/StructLinq/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)

### Results:
``` ini

BenchmarkDotNet=v0.12.1.1521-nightly, OS=Windows 10.0.19043
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.2.21155.3
  [Host]     : .NET 6.0.0 (6.0.21.15406), X64 RyuJIT
  Job-XHOKQA : .NET 6.0.0 (6.0.21.15406), X64 RyuJIT

Runtime=.NET 6.0  

```
|          Method |  Categories | Count |        Mean |     Error |    StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------- |------------ |------ |------------:|----------:|----------:|------:|-------:|------:|------:|----------:|
|            Linq |       Range |   100 |   416.88 ns |  2.728 ns |  2.130 ns |  1.00 | 0.0191 |     - |     - |      40 B |
|      StructLinq |       Range |   100 |    34.04 ns |  0.144 ns |  0.128 ns |  0.08 |      - |     - |     - |         - |
|       Hyperlinq |       Range |   100 |    47.38 ns |  0.148 ns |  0.131 ns |  0.11 |      - |     - |     - |         - |
|                 |             |       |             |           |           |       |        |       |       |           |
|      Linq_Async | Range_Async |   100 | 3,912.38 ns | 22.969 ns | 21.485 ns |  1.00 | 0.0229 |     - |     - |      48 B |
| Hyperlinq_Async | Range_Async |   100 | 1,320.37 ns |  4.421 ns |  4.136 ns |  0.34 | 0.0153 |     - |     - |      32 B |
