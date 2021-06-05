## WhereCountBenchmarks

### Source
[WhereCountBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/WhereCountBenchmarks.cs)

### References:
- Linq: 6.0.0-preview.4.21253.7
- System.Linq.Async: [5.0.0](https://www.nuget.org/packages/System.Linq.Async/5.0.0)
- System.Interactive: [5.0.0](https://www.nuget.org/packages/System.Interactive/5.0.0)
- System.Interactive.Async: [5.0.0](https://www.nuget.org/packages/System.Interactive.Async/5.0.0)
- StructLinq: [0.26.0](https://www.nuget.org/packages/StructLinq/0.26.0)
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)

### Results:
``` ini

BenchmarkDotNet=v0.13.0.1555-nightly, OS=Windows 10.0.19043.1023 (21H1/May2021Update)
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.4.21255.9
  [Host]     : .NET 6.0.0 (6.0.21.25307), X64 RyuJIT
  Job-SUCOWF : .NET 6.0.0 (6.0.21.25307), X64 RyuJIT

Runtime=.NET 6.0  

```
|                              Method |                Categories | Count |       Mean |   Error |  StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------ |-------------------------- |------ |-----------:|--------:|--------:|------:|-------:|------:|------:|----------:|
|                          Linq_Array |                     Array |   100 |   842.3 ns | 2.02 ns | 1.69 ns |  1.00 | 0.0153 |     - |     - |      32 B |
|                    StructLinq_Array |                     Array |   100 |   239.0 ns | 1.77 ns | 1.57 ns |  0.28 |      - |     - |     - |         - |
|                     Hyperlinq_Array |                     Array |   100 |   198.2 ns | 0.82 ns | 0.73 ns |  0.24 |      - |     - |     - |         - |
|                      Hyperlinq_Span |                     Array |   100 |   172.3 ns | 0.81 ns | 0.76 ns |  0.20 |      - |     - |     - |         - |
|                    Hyperlinq_Memory |                     Array |   100 |   199.3 ns | 0.45 ns | 0.40 ns |  0.24 |      - |     - |     - |         - |
|                                     |                           |       |            |         |         |       |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |   100 | 1,059.7 ns | 4.74 ns | 4.43 ns |  1.00 | 0.0153 |     - |     - |      32 B |
|         StructLinq_Enumerable_Value |          Enumerable_Value |   100 | 1,030.2 ns | 4.70 ns | 3.92 ns |  0.97 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 |   223.6 ns | 0.60 ns | 0.50 ns |  0.21 |      - |     - |     - |         - |
|                                     |                           |       |            |         |         |       |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |   100 | 1,075.4 ns | 4.71 ns | 4.17 ns |  1.00 | 0.0153 |     - |     - |      32 B |
|         StructLinq_Collection_Value |          Collection_Value |   100 | 1,057.9 ns | 4.87 ns | 4.56 ns |  0.98 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Collection_Value |          Collection_Value |   100 |   218.1 ns | 0.77 ns | 0.65 ns |  0.20 |      - |     - |     - |         - |
|                                     |                           |       |            |         |         |       |        |       |       |           |
|                     Linq_List_Value |                List_Value |   100 | 1,091.3 ns | 7.05 ns | 6.59 ns |  1.00 | 0.0153 |     - |     - |      32 B |
|               StructLinq_List_Value |                List_Value |   100 |   451.4 ns | 2.28 ns | 2.02 ns |  0.41 |      - |     - |     - |         - |
|                Hyperlinq_List_Value |                List_Value |   100 |   826.2 ns | 2.40 ns | 2.13 ns |  0.76 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |            |         |         |       |        |       |       |           |
|          Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 1,696.3 ns | 4.29 ns | 3.58 ns |  1.00 | 0.0153 |     - |     - |      32 B |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 2,488.0 ns | 3.12 ns | 2.77 ns |  1.47 |      - |     - |     - |         - |
|                                     |                           |       |            |         |         |       |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |   100 | 1,080.9 ns | 3.99 ns | 3.54 ns |  1.00 | 0.0153 |     - |     - |      32 B |
|     StructLinq_Enumerable_Reference |      Enumerable_Reference |   100 | 1,030.4 ns | 4.60 ns | 4.08 ns |  0.95 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 |   731.4 ns | 2.25 ns | 2.00 ns |  0.68 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |            |         |         |       |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |   100 | 1,083.8 ns | 6.26 ns | 5.85 ns |  1.00 | 0.0153 |     - |     - |      32 B |
|     StructLinq_Collection_Reference |      Collection_Reference |   100 | 1,053.2 ns | 3.79 ns | 3.36 ns |  0.97 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Collection_Reference |      Collection_Reference |   100 |   714.5 ns | 7.96 ns | 6.64 ns |  0.66 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |            |         |         |       |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |   100 | 1,068.2 ns | 4.53 ns | 4.01 ns |  1.00 | 0.0153 |     - |     - |      32 B |
|           StructLinq_List_Reference |            List_Reference |   100 | 1,045.3 ns | 6.44 ns | 5.71 ns |  0.98 | 0.0153 |     - |     - |      32 B |
|            Hyperlinq_List_Reference |            List_Reference |   100 |   781.7 ns | 4.09 ns | 3.62 ns |  0.73 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |            |         |         |       |        |       |       |           |
|      Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 1,689.9 ns | 3.43 ns | 3.04 ns |  1.00 | 0.0153 |     - |     - |      32 B |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 2,839.4 ns | 4.06 ns | 3.60 ns |  1.68 | 0.0153 |     - |     - |      32 B |
