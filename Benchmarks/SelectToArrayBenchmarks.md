## SelectToArrayBenchmarks

### Source
[SelectToArrayBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/SelectToArrayBenchmarks.cs)

### References:
- Linq: 5.0.2
- System.Linq.Async: [5.0.0](https://www.nuget.org/packages/System.Linq.Async/5.0.0)
- System.Interactive: [5.0.0](https://www.nuget.org/packages/System.Interactive/5.0.0)
- System.Interactive.Async: [5.0.0](https://www.nuget.org/packages/System.Interactive.Async/5.0.0)
- StructLinq: [0.25.3](https://www.nuget.org/packages/StructLinq/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta33](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta33)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.200-preview.20614.14
  [Host]        : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  Categories=Array  

```
|               Method | Count |      Mean |    Error |   StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |----------:|---------:|---------:|------:|-------:|------:|------:|----------:|
|           Linq_Array |   100 | 215.34 ns | 2.635 ns | 2.465 ns |  1.00 | 0.2255 |     - |     - |     472 B |
|     StructLinq_Array |   100 | 223.74 ns | 1.100 ns | 1.029 ns |  1.04 | 0.2027 |     - |     - |     424 B |
| LinqFasterSIMD_Array |   100 |  58.38 ns | 0.571 ns | 0.534 ns |  0.27 | 0.2027 |     - |     - |     424 B |
|      Hyperlinq_Array |   100 | 240.88 ns | 0.726 ns | 0.607 ns |  1.12 | 0.2027 |     - |     - |     424 B |
|       Hyperlinq_Span |   100 | 211.99 ns | 0.602 ns | 0.470 ns |  0.99 | 0.2027 |     - |     - |     424 B |
|  Hyperlinq_Span_SIMD |   100 |  91.01 ns | 1.367 ns | 1.212 ns |  0.42 | 0.2027 |     - |     - |     424 B |
|     Hyperlinq_Memory |   100 | 221.36 ns | 0.988 ns | 0.924 ns |  1.03 | 0.2027 |     - |     - |     424 B |
