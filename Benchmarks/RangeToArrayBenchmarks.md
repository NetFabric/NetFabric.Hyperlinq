## RangeToArrayBenchmarks

### Source
[RangeToArrayBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/RangeToArrayBenchmarks.cs)

### References:
- Linq: 5.0.2
- System.Linq.Async: [5.0.0](https://www.nuget.org/packages/System.Linq.Async/5.0.0)
- System.Interactive: [5.0.0](https://www.nuget.org/packages/System.Interactive/5.0.0)
- System.Interactive.Async: [5.0.0](https://www.nuget.org/packages/System.Interactive.Async/5.0.0)
- StructLinq: [0.25.3](https://www.nuget.org/packages/StructLinq/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta34](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta34)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.200-preview.20614.14
  [Host]        : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|          Method |  Categories | Count |      Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------- |------------ |------ |----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|            Linq |       Range |   100 |  96.63 ns | 0.862 ns | 0.764 ns |  1.00 |    0.00 | 0.2218 |     - |     - |     464 B |
|      StructLinq |       Range |   100 |  99.00 ns | 0.820 ns | 0.640 ns |  1.03 |    0.01 | 0.2142 |     - |     - |     448 B |
| LinqFaster_SIMD |       Range |   100 |  45.58 ns | 0.948 ns | 1.054 ns |  0.47 |    0.01 | 0.2027 |     - |     - |     424 B |
|       Hyperlinq |       Range |   100 |  62.69 ns | 0.764 ns | 0.677 ns |  0.65 |    0.01 | 0.2027 |     - |     - |     424 B |
|                 |             |       |           |          |          |       |         |        |       |       |           |
|      Linq_Async | Range_Async |   100 | 119.78 ns | 2.043 ns | 1.911 ns |  1.00 |    0.00 | 0.2255 |     - |     - |     472 B |
| Hyperlinq_Async | Range_Async |   100 | 122.04 ns | 0.868 ns | 0.769 ns |  1.02 |    0.02 | 0.2027 |     - |     - |     424 B |
