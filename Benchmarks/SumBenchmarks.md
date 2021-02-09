## SumBenchmarks

### Source
[SumBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/SumBenchmarks.cs)

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

Job=.NET Core 5.0  Runtime=.NET Core 5.0  Categories=Array  

```
|               Method | Count |      Mean |    Error |   StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |----------:|---------:|---------:|------:|-------:|------:|------:|----------:|
|           Linq_Array |   100 | 445.32 ns | 2.467 ns | 4.753 ns |  1.00 | 0.0153 |     - |     - |      32 B |
|     StructLinq_Array |   100 |  62.74 ns | 0.297 ns | 0.248 ns |  0.14 |      - |     - |     - |         - |
| LinqFasterSIMD_Array |   100 |  12.16 ns | 0.072 ns | 0.067 ns |  0.03 |      - |     - |     - |         - |
|      Hyperlinq_Array |   100 |  19.54 ns | 0.143 ns | 0.134 ns |  0.04 |      - |     - |     - |         - |
|       Hyperlinq_Span |   100 |  19.53 ns | 0.138 ns | 0.129 ns |  0.04 |      - |     - |     - |         - |
