## Array.Int32.ArrayInt32Distinct

### Source
[ArrayInt32Distinct.cs](../LinqBenchmarks/Array/Int32/ArrayInt32Distinct.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta37](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta37)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.200-preview.21079.7
  [Host]        : .NET Core 5.0.3 (CoreCLR 5.0.321.7212, CoreFX 5.0.321.7212), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.3 (CoreCLR 5.0.321.7212, CoreFX 5.0.321.7212), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|               Method | Duplicates | Count |     Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |----------- |------ |---------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop |          4 |   100 | 3.038 μs | 0.0177 μs | 0.0166 μs |  1.00 |    0.00 | 2.8687 |     - |     - |    6008 B |
|          ForeachLoop |          4 |   100 | 3.028 μs | 0.0107 μs | 0.0089 μs |  1.00 |    0.01 | 2.8687 |     - |     - |    6008 B |
|                 Linq |          4 |   100 | 6.644 μs | 0.0253 μs | 0.0225 μs |  2.19 |    0.02 | 2.0599 |     - |     - |    4312 B |
|               LinqAF |          4 |   100 | 8.135 μs | 0.0360 μs | 0.0319 μs |  2.68 |    0.02 | 5.9204 |     - |     - |   12400 B |
|           StructLinq |          4 |   100 | 3.431 μs | 0.0095 μs | 0.0084 μs |  1.13 |    0.01 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |          4 |   100 | 3.567 μs | 0.0149 μs | 0.0125 μs |  1.17 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq |          4 |   100 | 3.911 μs | 0.0121 μs | 0.0107 μs |  1.29 |    0.01 |      - |     - |     - |         - |
