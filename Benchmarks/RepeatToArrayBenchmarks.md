## RepeatToArrayBenchmarks

### Source
[RepeatToArrayBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/RepeatToArrayBenchmarks.cs)

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
|          Method |   Categories | Count |      Mean |    Error |   StdDev |    Median | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------- |------------- |------ |----------:|---------:|---------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|            Linq |       Repeat |   100 |  92.29 ns | 0.656 ns | 0.582 ns |  92.23 ns |  1.00 |    0.00 | 0.2180 |     - |     - |     456 B |
|      StructLinq |       Repeat |   100 | 110.61 ns | 0.756 ns | 0.631 ns | 110.42 ns |  1.20 |    0.01 | 0.2142 |     - |     - |     448 B |
| LinqFaster_SIMD |       Repeat |   100 |  28.17 ns | 0.569 ns | 0.504 ns |  28.10 ns |  0.31 |    0.01 | 0.2027 |     - |     - |     424 B |
|       Hyperlinq |       Repeat |   100 |  55.52 ns | 0.252 ns | 0.223 ns |  55.53 ns |  0.60 |    0.00 | 0.2027 |     - |     - |     424 B |
|  Hyperlinq_SIMD |       Repeat |   100 |  41.57 ns | 0.774 ns | 1.928 ns |  40.74 ns |  0.48 |    0.03 | 0.2027 |     - |     - |     424 B |
|                 |              |       |           |          |          |           |       |         |        |       |       |           |
|      Linq_Async | Repeat_Async |   100 |  91.33 ns | 0.327 ns | 0.256 ns |  91.29 ns |  1.00 |    0.00 | 0.2257 |     - |     - |     472 B |
| Hyperlinq_Async | Repeat_Async |   100 | 119.23 ns | 0.548 ns | 0.428 ns | 119.24 ns |  1.31 |    0.00 | 0.2027 |     - |     - |     424 B |
