## Enumerable.Int32.EnumerableInt32SkipTakeSelect

### Source
[EnumerableInt32SkipTakeSelect.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32SkipTakeSelect.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta42](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta42)

### Results:
``` ini

BenchmarkDotNet=v0.12.1.1516-nightly, OS=Windows 10.0.19042.844 (20H2/October2020Update)
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.1.21103.13
  [Host]   : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT
  .NET 5.0 : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT

Job=.NET 5.0  Runtime=.NET 5.0  

```
|                      Method | Skip | Count |      Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------- |----- |------ |----------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|                 **ForeachLoop** | **1000** |    **10** |  **2.384 μs** | **0.0074 μs** | **0.0066 μs** |  **1.00** |    **0.00** | **0.0191** |     **-** |     **-** |      **40 B** |
|                        Linq | 1000 |    10 |  2.646 μs | 0.0067 μs | 0.0063 μs |  1.11 |    0.00 | 0.0992 |     - |     - |     208 B |
|                      LinqAF | 1000 |    10 |  3.562 μs | 0.0111 μs | 0.0099 μs |  1.49 |    0.00 | 0.0191 |     - |     - |      40 B |
|                  StructLinq | 1000 |    10 |  2.761 μs | 0.0071 μs | 0.0063 μs |  1.16 |    0.00 | 0.0610 |     - |     - |     128 B |
|        StructLinq_IFunction | 1000 |    10 |  2.944 μs | 0.0059 μs | 0.0052 μs |  1.23 |    0.00 | 0.0191 |     - |     - |      40 B |
|           Hyperlinq_Foreach | 1000 |    10 |  2.490 μs | 0.0044 μs | 0.0041 μs |  1.04 |    0.00 | 0.0191 |     - |     - |      40 B |
| Hyperlinq_Foreach_IFunction | 1000 |    10 |  3.217 μs | 0.0054 μs | 0.0048 μs |  1.35 |    0.00 | 0.0191 |     - |     - |      40 B |
|                             |      |       |           |           |           |       |         |        |       |       |           |
|                 **ForeachLoop** | **1000** |  **1000** |  **4.198 μs** | **0.0188 μs** | **0.0167 μs** |  **1.00** |    **0.00** | **0.0153** |     **-** |     **-** |      **40 B** |
|                        Linq | 1000 |  1000 | 18.253 μs | 0.0667 μs | 0.0557 μs |  4.35 |    0.02 | 0.0916 |     - |     - |     208 B |
|                      LinqAF | 1000 |  1000 | 14.831 μs | 0.0310 μs | 0.0259 μs |  3.53 |    0.02 | 0.0153 |     - |     - |      40 B |
|                  StructLinq | 1000 |  1000 |  9.420 μs | 0.0229 μs | 0.0203 μs |  2.24 |    0.01 | 0.0610 |     - |     - |     128 B |
|        StructLinq_IFunction | 1000 |  1000 |  7.839 μs | 0.0181 μs | 0.0151 μs |  1.87 |    0.01 | 0.0153 |     - |     - |      40 B |
|           Hyperlinq_Foreach | 1000 |  1000 |  9.911 μs | 0.0305 μs | 0.0238 μs |  2.36 |    0.01 | 0.0153 |     - |     - |      40 B |
| Hyperlinq_Foreach_IFunction | 1000 |  1000 |  9.115 μs | 0.0137 μs | 0.0114 μs |  2.17 |    0.01 | 0.0153 |     - |     - |      40 B |
