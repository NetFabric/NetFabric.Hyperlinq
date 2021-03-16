## ArrayIterationBenchmarks

### Source
[ArrayIterationBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/ArrayIterationBenchmarks.cs)

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
  Job-PWBPZS : .NET 6.0.0 (6.0.21.15406), X64 RyuJIT

Runtime=.NET 6.0  

```
|                       Method |    Count |      Mean |     Error |    StdDev | Ratio | RatioSD | Gen 0 | Gen 1 | Gen 2 | Allocated |
|----------------------------- |--------- |----------:|----------:|----------:|------:|--------:|------:|------:|------:|----------:|
|                      Foreach | 10000000 |  4.957 ms | 0.0964 ms | 0.0947 ms |  1.00 |    0.00 |     - |     - |     - |      18 B |
|                          For | 10000000 |  5.003 ms | 0.0330 ms | 0.0258 ms |  1.01 |    0.02 |     - |     - |     - |      17 B |
|                   For_Unsafe | 10000000 |  4.963 ms | 0.0788 ms | 0.0844 ms |  1.00 |    0.02 |     - |     - |     - |      17 B |
|               ForAdamczewski | 10000000 |  4.724 ms | 0.0932 ms | 0.0779 ms |  0.96 |    0.03 |     - |     - |     - |      17 B |
|         ForAdamczewskiUnsafe | 10000000 |  4.225 ms | 0.0555 ms | 0.0492 ms |  0.85 |    0.01 |     - |     - |     - |      17 B |
|                         Span | 10000000 |  4.892 ms | 0.0367 ms | 0.0325 ms |  0.99 |    0.02 |     - |     - |     - |      17 B |
|                       Memory | 10000000 |  4.910 ms | 0.0249 ms | 0.0221 ms |  0.99 |    0.02 |     - |     - |     - |      17 B |
|         ArraySegment_Foreach | 10000000 | 29.163 ms | 0.0954 ms | 0.0892 ms |  5.89 |    0.11 |     - |     - |     - |      68 B |
|             ArraySegment_For | 10000000 |  8.499 ms | 0.0435 ms | 0.0364 ms |  1.72 |    0.03 |     - |     - |     - |      34 B |
| ArraySegment_Wrapper_Foreach | 10000000 | 15.324 ms | 0.0627 ms | 0.0587 ms |  3.10 |    0.06 |     - |     - |     - |      34 B |
