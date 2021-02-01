## ToListBenchmarks

### Source
[ToListBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/ToListBenchmarks.cs)

### References:
- Linq: 4.8.4300.0
- System.Linq.Async: [5.0.0](https://www.nuget.org/packages/System.Linq.Async/5.0.0)
- System.Interactive: [5.0.0](https://www.nuget.org/packages/System.Interactive/5.0.0)
- System.Interactive.Async: [5.0.0](https://www.nuget.org/packages/System.Interactive.Async/5.0.0)
- StructLinq: [0.25.3](https://www.nuget.org/packages/StructLinq/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta29](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta29)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
  [Host]        : .NET Framework 4.8 (4.8.4300.0), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|                              Method |                Categories | Count |        Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------ |-------------------------- |------ |------------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|                          Linq_Array |                     Array |   100 |    58.20 ns | 0.494 ns | 0.438 ns |  1.00 |    0.00 | 0.2180 |     - |     - |     456 B |
|                    StructLinq_Array |                     Array |   100 |   114.10 ns | 0.325 ns | 0.272 ns |  1.96 |    0.01 | 0.2180 |     - |     - |     456 B |
|                     Hyperlinq_Array |                     Array |   100 |    49.57 ns | 0.138 ns | 0.122 ns |  0.85 |    0.01 | 0.2334 |     - |     - |     488 B |
|                      Hyperlinq_Span |                     Array |   100 |   160.62 ns | 0.449 ns | 0.420 ns |  2.76 |    0.02 | 0.2179 |     - |     - |     456 B |
|                    Hyperlinq_Memory |                     Array |   100 |    40.54 ns | 0.383 ns | 0.340 ns |  0.70 |    0.01 | 0.2180 |     - |     - |     456 B |
|                                     |                           |       |             |          |          |       |         |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |   100 |   893.89 ns | 2.555 ns | 2.390 ns |  1.00 |    0.00 | 0.5808 |     - |     - |    1216 B |
|         StructLinq_Enumerable_Value |          Enumerable_Value |   100 |   934.53 ns | 2.676 ns | 2.372 ns |  1.05 |    0.00 | 0.2327 |     - |     - |     488 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 |   578.02 ns | 1.782 ns | 1.580 ns |  0.65 |    0.00 | 0.2327 |     - |     - |     488 B |
|                                     |                           |       |             |          |          |       |         |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |   100 |    47.13 ns | 0.536 ns | 0.475 ns |  1.00 |    0.00 | 0.2180 |     - |     - |     456 B |
|         StructLinq_Collection_Value |          Collection_Value |   100 |   937.11 ns | 2.386 ns | 2.115 ns | 19.89 |    0.23 | 0.2327 |     - |     - |     488 B |
|          Hyperlinq_Collection_Value |          Collection_Value |   100 |    73.03 ns | 0.555 ns | 0.492 ns |  1.55 |    0.02 | 0.2333 |     - |     - |     488 B |
|                                     |                           |       |             |          |          |       |         |        |       |       |           |
|                     Linq_List_Value |                List_Value |   100 |    48.27 ns | 0.462 ns | 0.409 ns |  1.00 |    0.00 | 0.2180 |     - |     - |     456 B |
|               StructLinq_List_Value |                List_Value |   100 |   249.82 ns | 2.383 ns | 2.230 ns |  5.18 |    0.05 | 0.2179 |     - |     - |     456 B |
|                Hyperlinq_List_Value |                List_Value |   100 |    50.51 ns | 0.480 ns | 0.426 ns |  1.05 |    0.02 | 0.2180 |     - |     - |     456 B |
|                                     |                           |       |             |          |          |       |         |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |   100 |   647.78 ns | 1.861 ns | 1.650 ns |  1.00 |    0.00 | 0.5808 |     - |     - |    1216 B |
|     StructLinq_Enumerable_Reference |      Enumerable_Reference |   100 |   736.91 ns | 1.475 ns | 1.380 ns |  1.14 |    0.00 | 0.2327 |     - |     - |     488 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 |   781.32 ns | 2.815 ns | 2.198 ns |  1.21 |    0.01 | 0.2327 |     - |     - |     488 B |
|                                     |                           |       |             |          |          |       |         |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |   100 |    48.58 ns | 0.450 ns | 0.399 ns |  1.00 |    0.00 | 0.2180 |     - |     - |     456 B |
|     StructLinq_Collection_Reference |      Collection_Reference |   100 |   727.74 ns | 1.335 ns | 1.183 ns | 14.98 |    0.12 | 0.2327 |     - |     - |     488 B |
|      Hyperlinq_Collection_Reference |      Collection_Reference |   100 |    97.13 ns | 0.461 ns | 0.432 ns |  2.00 |    0.02 | 0.2295 |     - |     - |     480 B |
|                                     |                           |       |             |          |          |       |         |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |   100 |    48.85 ns | 0.489 ns | 0.434 ns |  1.00 |    0.00 | 0.2180 |     - |     - |     456 B |
|           StructLinq_List_Reference |            List_Reference |   100 |   675.21 ns | 2.616 ns | 2.319 ns | 13.82 |    0.13 | 0.2327 |     - |     - |     488 B |
|            Hyperlinq_List_Reference |            List_Reference |   100 |    50.82 ns | 0.335 ns | 0.297 ns |  1.04 |    0.01 | 0.2180 |     - |     - |     456 B |
|                                     |                           |       |             |          |          |       |         |        |       |       |           |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 1,688.26 ns | 3.145 ns | 2.788 ns |     ? |       ? | 0.5798 |     - |     - |    1216 B |
|                                     |                           |       |             |          |          |       |         |        |       |       |           |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 2,370.42 ns | 3.392 ns | 2.833 ns |     ? |       ? | 0.5989 |     - |     - |    1256 B |
