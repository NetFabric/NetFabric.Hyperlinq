## RangeToArrayBenchmarks

### Source
[RangeToArrayBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/RangeToArrayBenchmarks.cs)

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
|          Method |  Categories | Count |      Mean |    Error |   StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------- |------------ |------ |----------:|---------:|---------:|------:|-------:|------:|------:|----------:|
|            Linq |       Range |   100 |  82.74 ns | 0.862 ns | 0.807 ns |  1.00 | 0.2218 |     - |     - |     464 B |
|      StructLinq |       Range |   100 |  89.71 ns | 0.455 ns | 0.403 ns |  1.09 | 0.2142 |     - |     - |     448 B |
| LinqFaster_SIMD |       Range |   100 |  36.82 ns | 0.408 ns | 0.382 ns |  0.45 | 0.2027 |     - |     - |     424 B |
|       Hyperlinq |       Range |   100 |  45.49 ns | 0.218 ns | 0.170 ns |  0.55 | 0.2027 |     - |     - |     424 B |
|                 |             |       |           |          |          |       |        |       |       |           |
|      Linq_Async | Range_Async |   100 | 108.02 ns | 0.607 ns | 0.538 ns |  1.00 | 0.2257 |     - |     - |     472 B |
| Hyperlinq_Async | Range_Async |   100 | 146.15 ns | 0.743 ns | 0.620 ns |  1.35 | 0.2027 |     - |     - |     424 B |
