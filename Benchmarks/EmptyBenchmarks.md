## EmptyBenchmarks

### Source
[EmptyBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/EmptyBenchmarks.cs)

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
|                Method |  Categories |       Mean |     Error |    StdDev | Ratio | Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------- |------------ |-----------:|----------:|----------:|------:|------:|------:|------:|----------:|
|            Linq_Empty |       Empty |  6.3669 ns | 0.0298 ns | 0.0278 ns | 1.000 |     - |     - |     - |         - |
|       Hyperlinq_Empty |       Empty |  0.0000 ns | 0.0000 ns | 0.0000 ns | 0.000 |     - |     - |     - |         - |
|                       |             |            |           |           |       |       |       |       |           |
|      Linq_Empty_Async | Empty_Async | 40.5218 ns | 0.0720 ns | 0.0638 ns |  1.00 |     - |     - |     - |         - |
| Hyperlinq_Empty_Async | Empty_Async | 20.7372 ns | 0.0697 ns | 0.0618 ns |  0.51 |     - |     - |     - |         - |
