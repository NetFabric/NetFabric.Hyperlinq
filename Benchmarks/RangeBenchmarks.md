## RangeBenchmarks

### Source
[RangeBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/RangeBenchmarks.cs)

### References:
- Linq: 5.0.3
- System.Linq.Async: [5.0.0](https://www.nuget.org/packages/System.Linq.Async/5.0.0)
- System.Interactive: [5.0.0](https://www.nuget.org/packages/System.Interactive/5.0.0)
- System.Interactive.Async: [5.0.0](https://www.nuget.org/packages/System.Interactive.Async/5.0.0)
- StructLinq: [0.25.3](https://www.nuget.org/packages/StructLinq/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19043
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=6.0.100-preview.1.21103.13
  [Host]        : .NET Core 5.0.3 (CoreCLR 5.0.321.7212, CoreFX 5.0.321.7212), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.3 (CoreCLR 5.0.321.7212, CoreFX 5.0.321.7212), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|          Method |  Categories | Count |        Mean |     Error |    StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------- |------------ |------ |------------:|----------:|----------:|------:|-------:|------:|------:|----------:|
|            Linq |       Range |   100 |   450.44 ns |  1.413 ns |  1.253 ns |  1.00 | 0.0191 |     - |     - |      40 B |
|      StructLinq |       Range |   100 |    34.07 ns |  0.196 ns |  0.164 ns |  0.08 |      - |     - |     - |         - |
|       Hyperlinq |       Range |   100 |    43.85 ns |  0.176 ns |  0.147 ns |  0.10 |      - |     - |     - |         - |
|                 |             |       |             |           |           |       |        |       |       |           |
|      Linq_Async | Range_Async |   100 | 4,309.32 ns | 13.995 ns | 12.406 ns |  1.00 | 0.0229 |     - |     - |      48 B |
| Hyperlinq_Async | Range_Async |   100 | 1,294.45 ns |  4.176 ns |  3.907 ns |  0.30 | 0.0153 |     - |     - |      32 B |
