## ReturnBenchmarks

### Source
[ReturnBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/ReturnBenchmarks.cs)

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
|                 Method |   Categories |      Mean |     Error |    StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|----------------------- |------------- |----------:|----------:|----------:|------:|-------:|------:|------:|----------:|
|            Linq_Return |       Return | 15.684 ns | 0.1203 ns | 0.1067 ns |  1.00 | 0.0191 |     - |     - |      40 B |
|       Hyperlinq_Return |       Return |  8.965 ns | 0.0158 ns | 0.0140 ns |  0.57 |      - |     - |     - |         - |
|                        |              |           |           |           |       |        |       |       |           |
|      Linq_Return_Async | Return_Async | 56.114 ns | 0.1545 ns | 0.1370 ns |  1.00 | 0.0229 |     - |     - |      48 B |
| Hyperlinq_Return_Async | Return_Async | 42.330 ns | 0.0832 ns | 0.0738 ns |  0.75 |      - |     - |     - |         - |
