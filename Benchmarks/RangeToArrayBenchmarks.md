## RangeToArrayBenchmarks

### Source
[RangeToArrayBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/RangeToArrayBenchmarks.cs)

### References:
- Linq: 5.0.3
- System.Linq.Async: [5.0.0](https://www.nuget.org/packages/System.Linq.Async/5.0.0)
- System.Interactive: [5.0.0](https://www.nuget.org/packages/System.Interactive/5.0.0)
- System.Interactive.Async: [5.0.0](https://www.nuget.org/packages/System.Interactive.Async/5.0.0)
- StructLinq: [0.25.3](https://www.nuget.org/packages/StructLinq/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19043
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=6.0.100-preview.1.21103.13
  [Host]        : .NET Core 5.0.3 (CoreCLR 5.0.321.7212, CoreFX 5.0.321.7212), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.3 (CoreCLR 5.0.321.7212, CoreFX 5.0.321.7212), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|          Method |  Categories | Count |      Mean |    Error |   StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------- |------------ |------ |----------:|---------:|---------:|------:|-------:|------:|------:|----------:|
|            Linq |       Range |   100 |  85.25 ns | 0.771 ns | 0.643 ns |  1.00 | 0.2218 |     - |     - |     464 B |
|      StructLinq |       Range |   100 |  87.87 ns | 0.429 ns | 0.380 ns |  1.03 | 0.2142 |     - |     - |     448 B |
| LinqFaster_SIMD |       Range |   100 |  35.89 ns | 0.766 ns | 0.786 ns |  0.42 | 0.2027 |     - |     - |     424 B |
|       Hyperlinq |       Range |   100 |  43.59 ns | 0.593 ns | 0.526 ns |  0.51 | 0.2027 |     - |     - |     424 B |
|                 |             |       |           |          |          |       |        |       |       |           |
|      Linq_Async | Range_Async |   100 | 108.88 ns | 0.460 ns | 0.408 ns |  1.00 | 0.2257 |     - |     - |     472 B |
| Hyperlinq_Async | Range_Async |   100 | 109.33 ns | 1.108 ns | 0.865 ns |  1.00 | 0.2027 |     - |     - |     424 B |
