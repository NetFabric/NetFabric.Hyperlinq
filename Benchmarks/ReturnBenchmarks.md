## ReturnBenchmarks

### Source
[ReturnBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/ReturnBenchmarks.cs)

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
|                 Method |   Categories |      Mean |     Error |    StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|----------------------- |------------- |----------:|----------:|----------:|------:|-------:|------:|------:|----------:|
|            Linq_Return |       Return | 23.422 ns | 0.1310 ns | 0.1094 ns |  1.00 | 0.0191 |     - |     - |      40 B |
|       Hyperlinq_Return |       Return |  8.737 ns | 0.0278 ns | 0.0260 ns |  0.37 |      - |     - |     - |         - |
|                        |              |           |           |           |       |        |       |       |           |
|      Linq_Return_Async | Return_Async | 56.316 ns | 0.1989 ns | 0.1860 ns |  1.00 | 0.0229 |     - |     - |      48 B |
| Hyperlinq_Return_Async | Return_Async | 42.231 ns | 0.1004 ns | 0.0939 ns |  0.75 |      - |     - |     - |         - |
