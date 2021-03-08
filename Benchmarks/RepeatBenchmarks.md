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
|            Linq |       Repeat |   100 |   425.26 ns |  1.228 ns |  0.959 ns |  1.00 | 0.0153 |     - |     - |      32 B |
|      StructLinq |       Repeat |   100 |    35.73 ns |  0.105 ns |  0.093 ns |  0.08 |      - |     - |     - |         - |
|       Hyperlinq |       Repeat |   100 |   151.47 ns |  0.301 ns |  0.281 ns |  0.36 |      - |     - |     - |         - |
|                 |              |       |             |           |           |       |        |       |       |           |
|      Linq_Async | Repeat_Async |   100 | 5,744.35 ns | 14.467 ns | 13.532 ns |  1.00 | 0.0229 |     - |     - |      48 B |
| Hyperlinq_Async | Repeat_Async |   100 |   961.22 ns |  3.062 ns |  2.864 ns |  0.17 |      - |     - |     - |         - |
