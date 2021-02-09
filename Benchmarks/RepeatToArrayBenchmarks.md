## RepeatToArrayBenchmarks

### Source
[RepeatToArrayBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/RepeatToArrayBenchmarks.cs)

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
|          Method |   Categories | Count |      Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------- |------------- |------ |----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|            Linq |       Repeat |   100 | 140.08 ns | 2.839 ns | 2.915 ns |  1.00 |    0.00 | 0.2179 |     - |     - |     456 B |
|      StructLinq |       Repeat |   100 | 164.29 ns | 3.302 ns | 3.391 ns |  1.17 |    0.03 | 0.2141 |     - |     - |     448 B |
| LinqFaster_SIMD |       Repeat |   100 |  36.61 ns | 0.810 ns | 1.053 ns |  0.26 |    0.01 | 0.2027 |     - |     - |     424 B |
|       Hyperlinq |       Repeat |   100 |  63.87 ns | 1.072 ns | 1.053 ns |  0.46 |    0.01 | 0.2027 |     - |     - |     424 B |
|  Hyperlinq_SIMD |       Repeat |   100 |  52.59 ns | 0.871 ns | 0.815 ns |  0.38 |    0.01 | 0.2027 |     - |     - |     424 B |
|                 |              |       |           |          |          |       |         |        |       |       |           |
|      Linq_Async | Repeat_Async |   100 | 162.26 ns | 3.103 ns | 3.048 ns |  1.00 |    0.00 | 0.2255 |     - |     - |     472 B |
| Hyperlinq_Async | Repeat_Async |   100 | 178.38 ns | 1.134 ns | 0.947 ns |  1.10 |    0.02 | 0.2027 |     - |     - |     424 B |
