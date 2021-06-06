## ReturnBenchmarks

### Source
[ReturnBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/ReturnBenchmarks.cs)

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
|                 Method |   Categories |      Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|----------------------- |------------- |----------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|            Linq_Return |       Return | 15.486 ns | 0.1401 ns | 0.1311 ns |  1.00 |    0.00 | 0.0191 |     - |     - |      40 B |
|       Hyperlinq_Return |       Return |  8.736 ns | 0.0199 ns | 0.0186 ns |  0.56 |    0.00 |      - |     - |     - |         - |
|                        |              |           |           |           |       |         |        |       |       |           |
|      Linq_Return_Async | Return_Async | 58.705 ns | 1.1953 ns | 2.5729 ns |  1.00 |    0.00 | 0.0229 |     - |     - |      48 B |
| Hyperlinq_Return_Async | Return_Async | 40.121 ns | 0.2094 ns | 0.1959 ns |  0.68 |    0.02 |      - |     - |     - |         - |
