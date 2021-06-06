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
  Job-FXRHUT : .NET 6.0.0 (6.0.21.25307), X64 RyuJIT

Runtime=.NET 6.0  

```
|          Method |  Categories | Count |      Mean |    Error |   StdDev |    Median | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------- |------------ |------ |----------:|---------:|---------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|            Linq |       Range |   100 |  83.93 ns | 1.194 ns | 1.635 ns |  83.73 ns |  1.00 |    0.00 | 0.2218 |     - |     - |     464 B |
|      StructLinq |       Range |   100 |  92.26 ns | 1.910 ns | 3.859 ns |  91.20 ns |  1.10 |    0.05 | 0.2142 |     - |     - |     448 B |
| LinqFaster_SIMD |       Range |   100 |  40.19 ns | 0.874 ns | 2.493 ns |  39.14 ns |  0.48 |    0.03 | 0.2027 |     - |     - |     424 B |
|       Hyperlinq |       Range |   100 |  44.88 ns | 0.802 ns | 0.711 ns |  45.15 ns |  0.53 |    0.01 | 0.2027 |     - |     - |     424 B |
|                 |             |       |           |          |          |           |       |         |        |       |       |           |
|      Linq_Async | Range_Async |   100 | 105.70 ns | 0.993 ns | 0.880 ns | 105.84 ns |  1.00 |    0.00 | 0.2257 |     - |     - |     472 B |
| Hyperlinq_Async | Range_Async |   100 | 152.75 ns | 3.112 ns | 7.807 ns | 147.54 ns |  1.44 |    0.07 | 0.2027 |     - |     - |     424 B |
