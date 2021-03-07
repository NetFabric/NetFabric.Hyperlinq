## SelectSumBenchmarks

### Source
[SelectSumBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/SelectSumBenchmarks.cs)

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
|                              Method |                Categories | Count |         Mean |     Error |    StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------ |-------------------------- |------ |-------------:|----------:|----------:|------:|-------:|------:|------:|----------:|
|                          Linq_Array |                     Array |   100 |    651.35 ns |  2.301 ns |  1.922 ns |  1.00 | 0.0229 |     - |     - |      48 B |
|                    StructLinq_Array |                     Array |   100 |    205.20 ns |  0.496 ns |  0.464 ns |  0.31 |      - |     - |     - |         - |
|                     Hyperlinq_Array |                     Array |   100 |    198.47 ns |  0.531 ns |  0.496 ns |  0.30 |      - |     - |     - |         - |
|                      Hyperlinq_Span |                     Array |   100 |    173.40 ns |  0.372 ns |  0.311 ns |  0.27 |      - |     - |     - |         - |
|                 Hyperlinq_Span_SIMD |                     Array |   100 |     63.52 ns |  0.224 ns |  0.199 ns |  0.10 |      - |     - |     - |         - |
|                    Hyperlinq_Memory |                     Array |   100 |    199.95 ns |  0.380 ns |  0.337 ns |  0.31 |      - |     - |     - |         - |
|                                     |                           |       |              |           |           |       |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |   100 |  1,138.52 ns |  7.620 ns |  6.755 ns |  1.00 | 0.0420 |     - |     - |      88 B |
|         StructLinq_Enumerable_Value |          Enumerable_Value |   100 |    737.62 ns |  2.386 ns |  2.115 ns |  0.65 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 |    214.51 ns |  0.929 ns |  0.824 ns |  0.19 |      - |     - |     - |         - |
|                                     |                           |       |              |           |           |       |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |   100 |  1,162.57 ns |  3.912 ns |  3.468 ns |  1.00 | 0.0420 |     - |     - |      88 B |
|         StructLinq_Collection_Value |          Collection_Value |   100 |    764.66 ns |  2.651 ns |  2.214 ns |  0.66 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Collection_Value |          Collection_Value |   100 |    241.06 ns |  0.930 ns |  0.870 ns |  0.21 |      - |     - |     - |         - |
|                                     |                           |       |              |           |           |       |        |       |       |           |
|                     Linq_List_Value |                List_Value |   100 |  1,140.55 ns |  2.320 ns |  2.056 ns |  1.00 | 0.0420 |     - |     - |      88 B |
|               StructLinq_List_Value |                List_Value |   100 |    371.72 ns |  1.249 ns |  1.043 ns |  0.33 |      - |     - |     - |         - |
|                Hyperlinq_List_Value |                List_Value |   100 |    613.77 ns |  2.255 ns |  2.109 ns |  0.54 |      - |     - |     - |         - |
|                                     |                           |       |              |           |           |       |        |       |       |           |
|          Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 |  8,981.19 ns | 16.689 ns | 14.794 ns |  1.00 | 0.0458 |     - |     - |     104 B |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 |  9,600.95 ns | 17.255 ns | 13.471 ns |  1.07 | 0.0610 |     - |     - |     136 B |
|                                     |                           |       |              |           |           |       |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |   100 |    976.02 ns |  3.907 ns |  3.262 ns |  1.00 | 0.0420 |     - |     - |      88 B |
|     StructLinq_Enumerable_Reference |      Enumerable_Reference |   100 |    518.88 ns |  2.475 ns |  2.315 ns |  0.53 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 |    572.94 ns |  4.844 ns |  4.045 ns |  0.59 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |              |           |           |       |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |   100 |  1,025.54 ns |  3.889 ns |  3.448 ns |  1.00 | 0.0420 |     - |     - |      88 B |
|     StructLinq_Collection_Reference |      Collection_Reference |   100 |    568.49 ns |  2.361 ns |  1.971 ns |  0.55 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Collection_Reference |      Collection_Reference |   100 |    524.18 ns |  3.300 ns |  2.925 ns |  0.51 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |              |           |           |       |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |   100 |  1,026.60 ns |  3.302 ns |  2.927 ns |  1.00 | 0.0420 |     - |     - |      88 B |
|           StructLinq_List_Reference |            List_Reference |   100 |    518.74 ns |  1.947 ns |  1.821 ns |  0.51 | 0.0153 |     - |     - |      32 B |
|            Hyperlinq_List_Reference |            List_Reference |   100 |    662.87 ns |  1.891 ns |  1.676 ns |  0.65 |      - |     - |     - |         - |
|                                     |                           |       |              |           |           |       |        |       |       |           |
|      Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 10,199.54 ns | 16.376 ns | 13.674 ns |  1.00 | 0.0458 |     - |     - |     104 B |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 |  8,794.31 ns | 21.804 ns | 19.329 ns |  0.86 | 0.0610 |     - |     - |     152 B |
