## Enumerable.Int32.EnumerableInt32SkipTakeWhere

### Source
[EnumerableInt32SkipTakeWhere.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32SkipTakeWhere.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)

### Results:
``` ini

BenchmarkDotNet=v0.12.1.1527-nightly, OS=Windows 10.0.19043
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.3.21202.5
  [Host]   : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT
  .NET 5.0 : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT

Job=.NET 5.0  Runtime=.NET 5.0  

```
|               Method | Skip | Count |      Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |----- |------ |----------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|          **ForeachLoop** | **1000** |    **10** |  **2.981 μs** | **0.0098 μs** | **0.0087 μs** |  **1.00** |    **0.00** | **0.0191** |     **-** |     **-** |      **40 B** |
|                 Linq | 1000 |    10 |  2.976 μs | 0.0193 μs | 0.0161 μs |  1.00 |    0.01 | 0.0992 |     - |     - |     208 B |
|               LinqAF | 1000 |    10 |  4.004 μs | 0.0203 μs | 0.0158 μs |  1.34 |    0.01 | 0.0153 |     - |     - |      40 B |
|           StructLinq | 1000 |    10 |  2.978 μs | 0.0207 μs | 0.0183 μs |  1.00 |    0.01 | 0.0610 |     - |     - |     128 B |
| StructLinq_IFunction | 1000 |    10 |  3.090 μs | 0.0182 μs | 0.0152 μs |  1.04 |    0.01 | 0.0191 |     - |     - |      40 B |
|            Hyperlinq | 1000 |    10 |  2.626 μs | 0.0114 μs | 0.0107 μs |  0.88 |    0.00 | 0.0191 |     - |     - |      40 B |
|  Hyperlinq_IFunction | 1000 |    10 |  3.052 μs | 0.0198 μs | 0.0175 μs |  1.02 |    0.01 | 0.0191 |     - |     - |      40 B |
|                      |      |       |           |           |           |       |         |        |       |       |           |
|          **ForeachLoop** | **1000** |  **1000** |  **5.463 μs** | **0.0484 μs** | **0.0429 μs** |  **1.00** |    **0.00** | **0.0153** |     **-** |     **-** |      **40 B** |
|                 Linq | 1000 |  1000 | 15.996 μs | 0.1092 μs | 0.1021 μs |  2.93 |    0.03 | 0.0916 |     - |     - |     208 B |
|               LinqAF | 1000 |  1000 | 16.548 μs | 0.0735 μs | 0.0688 μs |  3.03 |    0.02 |      - |     - |     - |      40 B |
|           StructLinq | 1000 |  1000 | 10.200 μs | 0.0684 μs | 0.0606 μs |  1.87 |    0.02 | 0.0610 |     - |     - |     128 B |
| StructLinq_IFunction | 1000 |  1000 |  9.416 μs | 0.1368 μs | 0.1212 μs |  1.72 |    0.02 | 0.0153 |     - |     - |      40 B |
|            Hyperlinq | 1000 |  1000 | 11.912 μs | 0.0778 μs | 0.0649 μs |  2.18 |    0.02 | 0.0153 |     - |     - |      40 B |
|  Hyperlinq_IFunction | 1000 |  1000 |  9.499 μs | 0.0537 μs | 0.0476 μs |  1.74 |    0.02 | 0.0153 |     - |     - |      40 B |
