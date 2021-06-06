## EmptyBenchmarks

### Source
[EmptyBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/EmptyBenchmarks.cs)

### References:
- Linq: 6.0.0-preview.4.21253.7
- System.Linq.Async: [5.0.0](https://www.nuget.org/packages/System.Linq.Async/5.0.0)
- System.Interactive: [5.0.0](https://www.nuget.org/packages/System.Interactive/5.0.0)
- System.Interactive.Async: [5.0.0](https://www.nuget.org/packages/System.Interactive.Async/5.0.0)
- StructLinq: [0.26.0](https://www.nuget.org/packages/StructLinq/0.26.0)
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)

### Results:
``` ini

BenchmarkDotNet=v0.13.0.1555-nightly, OS=Windows 10.0.19043.1023 (21H1/May2021Update)
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.4.21255.9
  [Host]     : .NET 6.0.0 (6.0.21.25307), X64 RyuJIT
  Job-FXRHUT : .NET 6.0.0 (6.0.21.25307), X64 RyuJIT

Runtime=.NET 6.0  

```
|                Method |  Categories |       Mean |     Error |    StdDev | Ratio | Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------- |------------ |-----------:|----------:|----------:|------:|------:|------:|------:|----------:|
|            Linq_Empty |       Empty |  6.4999 ns | 0.0496 ns | 0.0439 ns | 1.000 |     - |     - |     - |         - |
|       Hyperlinq_Empty |       Empty |  0.0066 ns | 0.0055 ns | 0.0048 ns | 0.001 |     - |     - |     - |         - |
|                       |             |            |           |           |       |       |       |       |           |
|      Linq_Empty_Async | Empty_Async | 41.3903 ns | 0.1669 ns | 0.1480 ns |  1.00 |     - |     - |     - |         - |
| Hyperlinq_Empty_Async | Empty_Async | 20.8240 ns | 0.1316 ns | 0.1099 ns |  0.50 |     - |     - |     - |         - |
