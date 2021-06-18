## RangeToArrayBenchmarks

### Source
[RangeToArrayBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/RangeToArrayBenchmarks.cs)

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
|          Method |  Categories | Count |      Mean |    Error |   StdDev |    Median | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------- |------------ |------ |----------:|---------:|---------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|            Linq |       Range |   100 |  91.33 ns | 0.704 ns | 0.588 ns |  91.48 ns |  1.00 |    0.00 | 0.2218 |     - |     - |     464 B |
|      StructLinq |       Range |   100 |  86.82 ns | 1.396 ns | 1.305 ns |  86.72 ns |  0.95 |    0.01 | 0.2142 |     - |     - |     448 B |
| LinqFaster_SIMD |       Range |   100 |  40.31 ns | 0.879 ns | 2.452 ns |  39.02 ns |  0.44 |    0.02 | 0.2027 |     - |     - |     424 B |
|       Hyperlinq |       Range |   100 |  45.34 ns | 0.366 ns | 0.342 ns |  45.35 ns |  0.50 |    0.01 | 0.2027 |     - |     - |     424 B |
|                 |             |       |           |          |          |           |       |         |        |       |       |           |
|      Linq_Async | Range_Async |   100 | 105.08 ns | 1.318 ns | 1.232 ns | 105.44 ns |  1.00 |    0.00 | 0.2257 |     - |     - |     472 B |
| Hyperlinq_Async | Range_Async |   100 | 145.72 ns | 0.949 ns | 0.793 ns | 145.54 ns |  1.39 |    0.02 | 0.2027 |     - |     - |     424 B |
