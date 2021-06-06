## RepeatToArrayBenchmarks

### Source
[RepeatToArrayBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/RepeatToArrayBenchmarks.cs)

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
|          Method |   Categories | Count |      Mean |    Error |   StdDev |    Median | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------- |------------- |------ |----------:|---------:|---------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|            Linq |       Repeat |   100 |  92.02 ns | 1.863 ns | 2.356 ns |  91.28 ns |  1.00 |    0.00 | 0.2180 |     - |     - |     456 B |
|      StructLinq |       Repeat |   100 |  82.20 ns | 0.970 ns | 0.907 ns |  81.84 ns |  0.89 |    0.03 | 0.2142 |     - |     - |     448 B |
| LinqFaster_SIMD |       Repeat |   100 |  33.45 ns | 0.318 ns | 0.282 ns |  33.40 ns |  0.36 |    0.01 | 0.2027 |     - |     - |     424 B |
|       Hyperlinq |       Repeat |   100 |  56.99 ns | 0.730 ns | 0.683 ns |  56.87 ns |  0.62 |    0.02 | 0.2027 |     - |     - |     424 B |
|  Hyperlinq_SIMD |       Repeat |   100 |  41.44 ns | 0.897 ns | 2.266 ns |  40.31 ns |  0.45 |    0.03 | 0.2027 |     - |     - |     424 B |
|                 |              |       |           |          |          |           |       |         |        |       |       |           |
|      Linq_Async | Repeat_Async |   100 |  93.83 ns | 1.475 ns | 1.379 ns |  94.28 ns |  1.00 |    0.00 | 0.2257 |     - |     - |     472 B |
| Hyperlinq_Async | Repeat_Async |   100 | 119.13 ns | 1.828 ns | 1.710 ns | 119.07 ns |  1.27 |    0.03 | 0.2027 |     - |     - |     424 B |
