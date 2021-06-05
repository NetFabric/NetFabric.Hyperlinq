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
  Job-DUCAQD : .NET 6.0.0 (6.0.21.25307), X64 RyuJIT

Runtime=.NET 6.0  

```
|          Method |   Categories | Count |      Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------- |------------- |------ |----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|            Linq |       Repeat |   100 |  75.53 ns | 0.909 ns | 0.851 ns |  1.00 |    0.00 | 0.2180 |     - |     - |     456 B |
|      StructLinq |       Repeat |   100 |  79.08 ns | 0.694 ns | 0.649 ns |  1.05 |    0.02 | 0.2142 |     - |     - |     448 B |
| LinqFaster_SIMD |       Repeat |   100 |  27.64 ns | 0.234 ns | 0.195 ns |  0.37 |    0.01 | 0.2027 |     - |     - |     424 B |
|       Hyperlinq |       Repeat |   100 |  53.12 ns | 0.632 ns | 0.528 ns |  0.70 |    0.01 | 0.2027 |     - |     - |     424 B |
|  Hyperlinq_SIMD |       Repeat |   100 |  37.55 ns | 0.457 ns | 0.405 ns |  0.50 |    0.01 | 0.2027 |     - |     - |     424 B |
|                 |              |       |           |          |          |       |         |        |       |       |           |
|      Linq_Async | Repeat_Async |   100 |  90.23 ns | 0.866 ns | 0.723 ns |  1.00 |    0.00 | 0.2257 |     - |     - |     472 B |
| Hyperlinq_Async | Repeat_Async |   100 | 117.80 ns | 1.777 ns | 1.576 ns |  1.31 |    0.02 | 0.2027 |     - |     - |     424 B |
