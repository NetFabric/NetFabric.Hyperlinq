## RangeToArrayBenchmarks

### Source
[RangeToArrayBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/RangeToArrayBenchmarks.cs)

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
  Job-SUCOWF : .NET 6.0.0 (6.0.21.25307), X64 RyuJIT

Runtime=.NET 6.0  

```
|          Method |  Categories | Count |      Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------- |------------ |------ |----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|            Linq |       Range |   100 |  83.82 ns | 1.079 ns | 0.957 ns |  1.00 |    0.00 | 0.2218 |     - |     - |     464 B |
|      StructLinq |       Range |   100 |  87.92 ns | 1.112 ns | 1.040 ns |  1.05 |    0.02 | 0.2142 |     - |     - |     448 B |
| LinqFaster_SIMD |       Range |   100 |  44.87 ns | 0.414 ns | 0.388 ns |  0.54 |    0.01 | 0.2027 |     - |     - |     424 B |
|       Hyperlinq |       Range |   100 |  45.34 ns | 0.845 ns | 0.791 ns |  0.54 |    0.01 | 0.2027 |     - |     - |     424 B |
|                 |             |       |           |          |          |       |         |        |       |       |           |
|      Linq_Async | Range_Async |   100 | 107.52 ns | 1.990 ns | 3.738 ns |  1.00 |    0.00 | 0.2257 |     - |     - |     472 B |
| Hyperlinq_Async | Range_Async |   100 | 159.51 ns | 3.245 ns | 3.737 ns |  1.46 |    0.08 | 0.2027 |     - |     - |     424 B |
