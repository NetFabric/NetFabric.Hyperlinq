## RepeatBenchmarks

### Source
[RepeatBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/RepeatBenchmarks.cs)

### References:
- Linq: 5.0.2
- System.Linq.Async: [5.0.0](https://www.nuget.org/packages/System.Linq.Async/5.0.0)
- System.Interactive: [5.0.0](https://www.nuget.org/packages/System.Interactive/5.0.0)
- System.Interactive.Async: [5.0.0](https://www.nuget.org/packages/System.Interactive.Async/5.0.0)
- StructLinq: [0.25.3](https://www.nuget.org/packages/StructLinq/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta34](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta34)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.200-preview.20614.14
  [Host]        : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|          Method |   Categories | Count |        Mean |     Error |    StdDev |      Median | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------- |------------- |------ |------------:|----------:|----------:|------------:|------:|-------:|------:|------:|----------:|
|      Linq_Count |       Repeat |   100 |   578.38 ns | 32.322 ns | 95.302 ns |   623.45 ns |  1.00 | 0.0153 |     - |     - |      32 B |
|      StructLinq |       Repeat |   100 |    57.71 ns |  0.545 ns |  0.455 ns |    57.55 ns |  0.10 |      - |     - |     - |         - |
|       Hyperlinq |       Repeat |   100 |    41.23 ns |  0.145 ns |  0.121 ns |    41.18 ns |  0.07 |      - |     - |     - |         - |
|                 |              |       |             |           |           |             |       |        |       |       |           |
|      Linq_Async | Repeat_Async |   100 | 6,120.12 ns | 93.560 ns | 87.516 ns | 6,088.82 ns |  1.00 | 0.0229 |     - |     - |      48 B |
| Hyperlinq_Async | Repeat_Async |   100 |   945.28 ns |  7.413 ns |  6.572 ns |   944.56 ns |  0.15 |      - |     - |     - |         - |
