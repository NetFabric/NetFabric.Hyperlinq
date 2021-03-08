## RepeatToArrayBenchmarks

### Source
[RepeatToArrayBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/RepeatToArrayBenchmarks.cs)

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
|          Method |   Categories | Count |      Mean |    Error |   StdDev |       P95 | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------- |------------- |------ |----------:|---------:|---------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|            Linq |       Repeat |   100 | 101.22 ns | 0.326 ns | 0.272 ns | 101.66 ns |  1.00 |    0.00 | 0.2180 |     - |     - |     456 B |
|      StructLinq |       Repeat |   100 | 116.57 ns | 0.635 ns | 0.563 ns | 117.47 ns |  1.15 |    0.01 | 0.2142 |     - |     - |     448 B |
| LinqFaster_SIMD |       Repeat |   100 |  28.98 ns | 0.437 ns | 0.409 ns |  29.40 ns |  0.29 |    0.00 | 0.2027 |     - |     - |     424 B |
|       Hyperlinq |       Repeat |   100 |  56.36 ns | 0.624 ns | 0.583 ns |  57.19 ns |  0.56 |    0.01 | 0.2027 |     - |     - |     424 B |
|  Hyperlinq_SIMD |       Repeat |   100 |  39.78 ns | 0.444 ns | 0.415 ns |  40.23 ns |  0.39 |    0.00 | 0.2027 |     - |     - |     424 B |
|                 |              |       |           |          |          |           |       |         |        |       |       |           |
|      Linq_Async | Repeat_Async |   100 | 105.58 ns | 0.750 ns | 0.664 ns | 106.56 ns |  1.00 |    0.00 | 0.2257 |     - |     - |     472 B |
| Hyperlinq_Async | Repeat_Async |   100 | 174.95 ns | 2.622 ns | 5.588 ns | 191.90 ns |  1.71 |    0.09 | 0.2027 |     - |     - |     424 B |
