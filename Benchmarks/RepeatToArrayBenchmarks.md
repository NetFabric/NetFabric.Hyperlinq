## RepeatToArrayBenchmarks

### Source
[RepeatToArrayBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/RepeatToArrayBenchmarks.cs)

### References:
- Linq: 6.0.0-preview.5.21301.5
- System.Linq.Async: [5.0.0](https://www.nuget.org/packages/System.Linq.Async/5.0.0)
- System.Interactive: [5.0.0](https://www.nuget.org/packages/System.Interactive/5.0.0)
- System.Interactive.Async: [5.0.0](https://www.nuget.org/packages/System.Interactive.Async/5.0.0)
- StructLinq: [0.26.0](https://www.nuget.org/packages/StructLinq/0.26.0)
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)

### Results:
``` ini

BenchmarkDotNet=v0.13.0.1555-nightly, OS=Windows 10.0.19043.1055 (21H1/May2021Update)
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.5.21302.13
  [Host]     : .NET 6.0.0 (6.0.21.30105), X64 RyuJIT
  Job-UNTOJZ : .NET 6.0.0 (6.0.21.30105), X64 RyuJIT

Runtime=.NET 6.0  

```
|          Method |   Categories | Count |      Mean |    Error |   StdDev |    Median | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------- |------------- |------ |----------:|---------:|---------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|            Linq |       Repeat |   100 |  90.72 ns | 1.491 ns | 2.450 ns |  90.20 ns |  1.00 |    0.00 | 0.2180 |     - |     - |     456 B |
|      StructLinq |       Repeat |   100 |  77.89 ns | 1.265 ns | 1.183 ns |  77.83 ns |  0.86 |    0.03 | 0.2142 |     - |     - |     448 B |
| LinqFaster_SIMD |       Repeat |   100 |  29.47 ns | 0.658 ns | 0.808 ns |  29.45 ns |  0.32 |    0.01 | 0.2027 |     - |     - |     424 B |
|       Hyperlinq |       Repeat |   100 |  34.85 ns | 0.589 ns | 0.522 ns |  34.97 ns |  0.38 |    0.01 | 0.2027 |     - |     - |     424 B |
|  Hyperlinq_SIMD |       Repeat |   100 |  42.00 ns | 0.914 ns | 2.593 ns |  40.72 ns |  0.46 |    0.03 | 0.2027 |     - |     - |     424 B |
|                 |              |       |           |          |          |           |       |         |        |       |       |           |
|      Linq_Async | Repeat_Async |   100 | 101.03 ns | 1.027 ns | 0.961 ns | 101.12 ns |  1.00 |    0.00 | 0.2257 |     - |     - |     472 B |
| Hyperlinq_Async | Repeat_Async |   100 | 166.58 ns | 1.317 ns | 1.100 ns | 166.15 ns |  1.65 |    0.01 | 0.2027 |     - |     - |     424 B |
