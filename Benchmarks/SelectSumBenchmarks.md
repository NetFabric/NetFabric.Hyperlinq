## SelectSumBenchmarks

### Source
[SelectSumBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/SelectSumBenchmarks.cs)

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
|              Method | Count |      Mean |    Error |   StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|-------------------- |------ |----------:|---------:|---------:|------:|-------:|------:|------:|----------:|
|          Linq_Array |   100 | 667.37 ns | 6.329 ns | 7.773 ns |  1.00 | 0.0229 |     - |     - |      48 B |
|    StructLinq_Array |   100 | 187.38 ns | 0.992 ns | 0.828 ns |  0.28 |      - |     - |     - |         - |
|     Hyperlinq_Array |   100 | 173.83 ns | 2.209 ns | 1.845 ns |  0.26 |      - |     - |     - |         - |
|      Hyperlinq_Span |   100 | 170.41 ns | 0.836 ns | 0.698 ns |  0.25 |      - |     - |     - |         - |
| Hyperlinq_Span_SIMD |   100 |  63.81 ns | 1.143 ns | 1.013 ns |  0.10 |      - |     - |     - |         - |
