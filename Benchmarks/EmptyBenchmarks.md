## EmptyBenchmarks

### Source
[EmptyBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/EmptyBenchmarks.cs)

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
|                Method |  Categories |       Mean |     Error |    StdDev | Ratio | Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------- |------------ |-----------:|----------:|----------:|------:|------:|------:|------:|----------:|
|            Linq_Empty |       Empty |  6.5910 ns | 0.0492 ns | 0.0436 ns | 1.000 |     - |     - |     - |         - |
|       Hyperlinq_Empty |       Empty |  0.0215 ns | 0.0074 ns | 0.0069 ns | 0.003 |     - |     - |     - |         - |
|                       |             |            |           |           |       |       |       |       |           |
|      Linq_Empty_Async | Empty_Async | 42.3852 ns | 0.1774 ns | 0.1573 ns |  1.00 |     - |     - |     - |         - |
| Hyperlinq_Empty_Async | Empty_Async | 21.7739 ns | 0.1665 ns | 0.1391 ns |  0.51 |     - |     - |     - |         - |
