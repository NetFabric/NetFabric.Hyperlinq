## SumBenchmarks

### Source
[SumBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/SumBenchmarks.cs)

### References:
- Linq: 4.8.4300.0
- System.Linq.Async: [5.0.0](https://www.nuget.org/packages/System.Linq.Async/5.0.0)
- System.Interactive: [5.0.0](https://www.nuget.org/packages/System.Interactive/5.0.0)
- System.Interactive.Async: [5.0.0](https://www.nuget.org/packages/System.Interactive.Async/5.0.0)
- StructLinq: [0.25.3](https://www.nuget.org/packages/StructLinq/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta31](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta31)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
  [Host]        : .NET Framework 4.8 (4.8.4300.0), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  Categories=Array  

```
|           Method | Count |      Mean |     Error |     StdDev |    Median | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|----------------- |------ |----------:|----------:|-----------:|----------:|------:|-------:|------:|------:|----------:|
|       Linq_Array |   100 | 565.57 ns | 41.802 ns | 123.255 ns | 501.19 ns |  1.00 | 0.0153 |     - |     - |      32 B |
| StructLinq_Array |   100 |  62.63 ns |  0.266 ns |   0.236 ns |  62.66 ns |  0.09 |      - |     - |     - |         - |
|  Hyperlinq_Array |   100 |  52.99 ns |  0.169 ns |   0.158 ns |  53.02 ns |  0.08 |      - |     - |     - |         - |
|   Hyperlinq_Span |   100 |  53.97 ns |  0.468 ns |   0.438 ns |  53.85 ns |  0.08 |      - |     - |     - |         - |
