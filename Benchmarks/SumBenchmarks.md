## SumBenchmarks

### Source
[SumBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/SumBenchmarks.cs)

### References:
- Linq: 4.8.4300.0
- System.Linq.Async: [5.0.0](https://www.nuget.org/packages/System.Linq.Async/5.0.0)
- System.Interactive: [5.0.0](https://www.nuget.org/packages/System.Interactive/5.0.0)
- System.Interactive.Async: [5.0.0](https://www.nuget.org/packages/System.Interactive.Async/5.0.0)
- StructLinq: [0.25.3](https://www.nuget.org/packages/StructLinq/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta33](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta33)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
  [Host]        : .NET Framework 4.8 (4.8.4300.0), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  Categories=Array  

```
|               Method | Count |      Mean |    Error |   StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |----------:|---------:|---------:|------:|-------:|------:|------:|----------:|
|           Linq_Array |   100 | 404.58 ns | 2.233 ns | 1.864 ns |  1.00 | 0.0153 |     - |     - |      32 B |
|     StructLinq_Array |   100 |  60.98 ns | 0.237 ns | 0.222 ns |  0.15 |      - |     - |     - |         - |
| LinqFasterSIMD_Array |   100 |  12.03 ns | 0.189 ns | 0.158 ns |  0.03 |      - |     - |     - |         - |
|      Hyperlinq_Array |   100 |  20.75 ns | 0.228 ns | 0.202 ns |  0.05 |      - |     - |     - |         - |
|       Hyperlinq_Span |   100 |  21.20 ns | 0.432 ns | 0.425 ns |  0.05 |      - |     - |     - |         - |
