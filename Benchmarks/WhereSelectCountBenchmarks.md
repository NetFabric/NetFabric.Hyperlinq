## WhereSelectCountBenchmarks

### Source
[WhereSelectCountBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/WhereSelectCountBenchmarks.cs)

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
|                              Method |                Categories | Count |       Mean |    Error |   StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------ |-------------------------- |------ |-----------:|---------:|---------:|------:|-------:|------:|------:|----------:|
|                          Linq_Array |                     Array |   100 |   322.4 ns |  1.34 ns |  1.18 ns |  1.00 | 0.0496 |     - |     - |     104 B |
|                     Hyperlinq_Array |                     Array |   100 |   183.4 ns |  0.57 ns |  0.53 ns |  0.57 |      - |     - |     - |         - |
|                      Hyperlinq_Span |                     Array |   100 |   205.1 ns |  0.66 ns |  0.58 ns |  0.64 |      - |     - |     - |         - |
|                    Hyperlinq_Memory |                     Array |   100 |   231.7 ns |  0.54 ns |  0.45 ns |  0.72 |      - |     - |     - |         - |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |   100 | 1,255.1 ns |  6.26 ns |  5.86 ns |  1.00 | 0.0725 |     - |     - |     152 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 |   795.3 ns |  3.14 ns |  2.79 ns |  0.63 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |   100 | 1,240.2 ns |  4.01 ns |  3.75 ns |  1.00 | 0.0725 |     - |     - |     152 B |
|          Hyperlinq_Collection_Value |          Collection_Value |   100 |   774.8 ns |  3.09 ns |  2.58 ns |  0.62 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|                     Linq_List_Value |                List_Value |   100 | 1,284.5 ns |  5.61 ns |  5.24 ns |  1.00 | 0.0725 |     - |     - |     152 B |
|                Hyperlinq_List_Value |                List_Value |   100 |   725.1 ns |  2.69 ns |  2.39 ns |  0.56 |      - |     - |     - |         - |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|          Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 5,925.3 ns | 18.58 ns | 16.47 ns |  1.00 | 0.0839 |     - |     - |     176 B |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 6,340.8 ns | 23.69 ns | 21.00 ns |  1.07 | 0.1068 |     - |     - |     224 B |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |   100 |   837.8 ns |  3.44 ns |  3.05 ns |  1.00 | 0.0725 |     - |     - |     152 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 |   579.8 ns |  4.91 ns |  4.36 ns |  0.69 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |   100 |   841.5 ns |  3.66 ns |  3.42 ns |  1.00 | 0.0725 |     - |     - |     152 B |
|      Hyperlinq_Collection_Reference |      Collection_Reference |   100 |   586.5 ns |  3.40 ns |  3.01 ns |  0.70 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |   100 |   844.5 ns |  5.50 ns |  5.15 ns |  1.00 | 0.0725 |     - |     - |     152 B |
|            Hyperlinq_List_Reference |            List_Reference |   100 |   680.1 ns |  3.30 ns |  2.93 ns |  0.81 |      - |     - |     - |         - |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|      Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 5,865.8 ns | 16.61 ns | 15.54 ns |  1.00 | 0.0839 |     - |     - |     176 B |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 6,088.6 ns | 23.30 ns | 20.65 ns |  1.04 | 0.1068 |     - |     - |     224 B |
