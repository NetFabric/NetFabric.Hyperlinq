## RepeatBenchmarks

### Source
[RepeatBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/RepeatBenchmarks.cs)

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
|          Method |   Categories | Count |        Mean |     Error |    StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------- |------------- |------ |------------:|----------:|----------:|------:|-------:|------:|------:|----------:|
|            Linq |       Repeat |   100 |   426.51 ns |  1.483 ns |  1.315 ns |  1.00 | 0.0153 |     - |     - |      32 B |
|      StructLinq |       Repeat |   100 |    34.54 ns |  0.299 ns |  0.265 ns |  0.08 |      - |     - |     - |         - |
|       Hyperlinq |       Repeat |   100 |   144.81 ns |  0.397 ns |  0.372 ns |  0.34 |      - |     - |     - |         - |
|                 |              |       |             |           |           |       |        |       |       |           |
|      Linq_Async | Repeat_Async |   100 | 5,964.82 ns | 16.050 ns | 14.228 ns |  1.00 | 0.0229 |     - |     - |      48 B |
| Hyperlinq_Async | Repeat_Async |   100 |   929.00 ns |  1.959 ns |  1.636 ns |  0.16 |      - |     - |     - |         - |
