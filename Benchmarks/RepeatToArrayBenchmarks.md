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
|          Method |   Categories | Count |      Mean |    Error |   StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------- |------------- |------ |----------:|---------:|---------:|------:|-------:|------:|------:|----------:|
|            Linq |       Repeat |   100 |  94.97 ns | 0.552 ns | 0.461 ns |  1.00 | 0.2180 |     - |     - |     456 B |
|      StructLinq |       Repeat |   100 | 110.09 ns | 0.441 ns | 0.368 ns |  1.16 | 0.2142 |     - |     - |     448 B |
| LinqFaster_SIMD |       Repeat |   100 |  26.88 ns | 0.414 ns | 0.367 ns |  0.28 | 0.2027 |     - |     - |     424 B |
|       Hyperlinq |       Repeat |   100 |  52.58 ns | 0.396 ns | 0.371 ns |  0.55 | 0.2027 |     - |     - |     424 B |
|  Hyperlinq_SIMD |       Repeat |   100 |  37.14 ns | 0.165 ns | 0.129 ns |  0.39 | 0.2027 |     - |     - |     424 B |
|                 |              |       |           |          |          |       |        |       |       |           |
|      Linq_Async | Repeat_Async |   100 |  98.63 ns | 0.675 ns | 0.598 ns |  1.00 | 0.2257 |     - |     - |     472 B |
| Hyperlinq_Async | Repeat_Async |   100 | 163.81 ns | 0.743 ns | 0.659 ns |  1.66 | 0.2027 |     - |     - |     424 B |
