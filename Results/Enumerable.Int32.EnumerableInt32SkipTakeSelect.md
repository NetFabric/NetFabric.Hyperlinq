## Enumerable.Int32.EnumerableInt32SkipTakeSelect

### Source
[EnumerableInt32SkipTakeSelect.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32SkipTakeSelect.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta39](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta39)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=6.0.100-preview.1.21103.13
  [Host]        : .NET Core 5.0.3 (CoreCLR 5.0.321.7212, CoreFX 5.0.321.7212), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.3 (CoreCLR 5.0.321.7212, CoreFX 5.0.321.7212), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|                      Method | Skip | Count |      Mean |     Error |    StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------- |----- |------ |----------:|----------:|----------:|------:|-------:|------:|------:|----------:|
|                 **ForeachLoop** | **1000** |    **10** |  **2.895 μs** | **0.0173 μs** | **0.0153 μs** |  **1.00** | **0.0191** |     **-** |     **-** |      **40 B** |
|                        Linq | 1000 |    10 |  2.879 μs | 0.0044 μs | 0.0041 μs |  0.99 | 0.0992 |     - |     - |     208 B |
|                      LinqAF | 1000 |    10 |  3.859 μs | 0.0097 μs | 0.0091 μs |  1.33 | 0.0153 |     - |     - |      40 B |
|                  StructLinq | 1000 |    10 |  3.245 μs | 0.0080 μs | 0.0075 μs |  1.12 | 0.0610 |     - |     - |     128 B |
|        StructLinq_IFunction | 1000 |    10 |  2.942 μs | 0.0060 μs | 0.0053 μs |  1.02 | 0.0191 |     - |     - |      40 B |
|           Hyperlinq_Foreach | 1000 |    10 |  2.487 μs | 0.0077 μs | 0.0064 μs |  0.86 | 0.0191 |     - |     - |      40 B |
| Hyperlinq_Foreach_IFunction | 1000 |    10 |  2.464 μs | 0.0151 μs | 0.0118 μs |  0.85 | 0.0191 |     - |     - |      40 B |
|                             |      |       |           |           |           |       |        |       |       |           |
|                 **ForeachLoop** | **1000** |  **1000** |  **4.666 μs** | **0.0121 μs** | **0.0101 μs** |  **1.00** | **0.0153** |     **-** |     **-** |      **40 B** |
|                        Linq | 1000 |  1000 | 17.034 μs | 0.0432 μs | 0.0383 μs |  3.65 | 0.0916 |     - |     - |     208 B |
|                      LinqAF | 1000 |  1000 | 15.456 μs | 0.0471 μs | 0.0393 μs |  3.31 |      - |     - |     - |      40 B |
|                  StructLinq | 1000 |  1000 |  9.424 μs | 0.0278 μs | 0.0232 μs |  2.02 | 0.0610 |     - |     - |     128 B |
|        StructLinq_IFunction | 1000 |  1000 |  7.840 μs | 0.0201 μs | 0.0168 μs |  1.68 | 0.0153 |     - |     - |      40 B |
|           Hyperlinq_Foreach | 1000 |  1000 | 10.118 μs | 0.0174 μs | 0.0136 μs |  2.17 | 0.0153 |     - |     - |      40 B |
| Hyperlinq_Foreach_IFunction | 1000 |  1000 |  8.346 μs | 0.0303 μs | 0.0269 μs |  1.79 | 0.0153 |     - |     - |      40 B |
