## SelectBenchmarks

### Source
[SelectBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/SelectBenchmarks.cs)

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
|                   Method | Count |     Mean |   Error |  StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |------ |---------:|--------:|--------:|------:|-------:|------:|------:|----------:|
|               Linq_Array |   100 | 642.1 ns | 2.04 ns | 1.81 ns |  1.00 | 0.0229 |     - |     - |      48 B |
|         StructLinq_Array |   100 | 228.1 ns | 0.33 ns | 0.26 ns |  0.36 |      - |     - |     - |         - |
|       Hyperlinq_Span_For |   100 | 170.3 ns | 1.06 ns | 0.99 ns |  0.27 |      - |     - |     - |         - |
|   Hyperlinq_Span_Foreach |   100 | 202.8 ns | 0.68 ns | 0.60 ns |  0.32 |      - |     - |     - |         - |
|      Hyperlinq_Span_SIMD |   100 | 411.2 ns | 2.49 ns | 2.33 ns |  0.64 |      - |     - |     - |         - |
|     Hyperlinq_Memory_For |   100 | 344.4 ns | 2.31 ns | 2.05 ns |  0.54 |      - |     - |     - |         - |
| Hyperlinq_Memory_Foreach |   100 | 231.5 ns | 1.13 ns | 0.88 ns |  0.36 |      - |     - |     - |         - |
|    Hyperlinq_Memory_SIMD |   100 | 451.4 ns | 2.79 ns | 2.61 ns |  0.70 |      - |     - |     - |         - |
