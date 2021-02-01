## RangeBenchmarks

### Source
[RangeBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/RangeBenchmarks.cs)

### References:
- Linq: 4.8.4300.0
- System.Linq.Async: [5.0.0](https://www.nuget.org/packages/System.Linq.Async/5.0.0)
- System.Interactive: [5.0.0](https://www.nuget.org/packages/System.Interactive/5.0.0)
- System.Interactive.Async: [5.0.0](https://www.nuget.org/packages/System.Interactive.Async/5.0.0)
- StructLinq: [0.25.3](https://www.nuget.org/packages/StructLinq/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta29](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta29)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
  [Host]        : .NET Framework 4.8 (4.8.4300.0), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|                Method |  Categories | Count |        Mean |    Error |   StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------- |------------ |------ |------------:|---------:|---------:|------:|-------:|------:|------:|----------:|
|            Linq_Range |       Range |   100 |   417.46 ns | 1.612 ns | 1.258 ns |  1.00 | 0.0191 |     - |     - |      40 B |
|      StructLinq_Range |       Range |   100 |    33.49 ns | 0.058 ns | 0.049 ns |  0.08 |      - |     - |     - |         - |
|       Hyperlinq_Range |       Range |   100 |    43.61 ns | 0.065 ns | 0.061 ns |  0.10 |      - |     - |     - |         - |
|                       |             |       |             |          |          |       |        |       |       |           |
|      Linq_Range_Async | Range_Async |   100 | 4,228.69 ns | 9.630 ns | 8.042 ns |  1.00 | 0.0229 |     - |     - |      48 B |
| Hyperlinq_Range_Async | Range_Async |   100 | 1,295.62 ns | 1.944 ns | 1.819 ns |  0.31 | 0.0153 |     - |     - |      32 B |
