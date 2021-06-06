## WhereSelectBenchmarks

### Source
[WhereSelectBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/WhereSelectBenchmarks.cs)

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
  Job-FXRHUT : .NET 6.0.0 (6.0.21.25307), X64 RyuJIT

Runtime=.NET 6.0  

```
|                              Method |                Categories | Count |       Mean |    Error |   StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------ |-------------------------- |------ |-----------:|---------:|---------:|------:|-------:|------:|------:|----------:|
|                          Linq_Array |                     Array |   100 |   692.8 ns |  5.17 ns |  4.84 ns |  1.00 | 0.0496 |     - |     - |     104 B |
|                    StructLinq_Array |                     Array |   100 |   370.8 ns |  2.77 ns |  2.59 ns |  0.54 |      - |     - |     - |         - |
|                     Hyperlinq_Array |                     Array |   100 |   358.4 ns |  1.84 ns |  1.53 ns |  0.52 |      - |     - |     - |         - |
|                      Hyperlinq_Span |                     Array |   100 |   341.0 ns |  1.43 ns |  1.34 ns |  0.49 |      - |     - |     - |         - |
|                    Hyperlinq_Memory |                     Array |   100 |   336.9 ns |  1.61 ns |  1.35 ns |  0.49 |      - |     - |     - |         - |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |   100 | 1,486.0 ns |  6.89 ns |  5.38 ns |  1.00 | 0.0725 |     - |     - |     152 B |
|         StructLinq_Enumerable_Value |          Enumerable_Value |   100 | 1,265.8 ns |  6.77 ns |  6.00 ns |  0.85 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 |   342.3 ns |  1.31 ns |  1.16 ns |  0.23 |      - |     - |     - |         - |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |   100 | 1,485.4 ns |  2.99 ns |  2.49 ns |  1.00 | 0.0725 |     - |     - |     152 B |
|         StructLinq_Collection_Value |          Collection_Value |   100 | 1,291.8 ns |  3.76 ns |  3.14 ns |  0.87 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Collection_Value |          Collection_Value |   100 |   339.0 ns |  0.96 ns |  0.85 ns |  0.23 |      - |     - |     - |         - |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|                     Linq_List_Value |                List_Value |   100 | 1,519.6 ns | 24.52 ns | 21.73 ns |  1.00 | 0.0725 |     - |     - |     152 B |
|               StructLinq_List_Value |                List_Value |   100 |   696.3 ns |  3.43 ns |  3.04 ns |  0.46 |      - |     - |     - |         - |
|                Hyperlinq_List_Value |                List_Value |   100 | 1,317.8 ns |  4.96 ns |  4.39 ns |  0.87 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|          Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 4,629.5 ns | 23.72 ns | 21.03 ns |  1.00 | 0.0763 |     - |     - |     168 B |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 5,201.4 ns |  6.04 ns |  5.36 ns |  1.12 |      - |     - |     - |         - |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |   100 | 1,499.3 ns | 11.27 ns | 10.54 ns |  1.00 | 0.0725 |     - |     - |     152 B |
|     StructLinq_Enumerable_Reference |      Enumerable_Reference |   100 | 1,298.5 ns |  8.18 ns |  7.65 ns |  0.87 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 | 1,312.7 ns |  4.97 ns |  4.41 ns |  0.88 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |   100 | 1,504.2 ns |  7.78 ns |  6.50 ns |  1.00 | 0.0725 |     - |     - |     152 B |
|     StructLinq_Collection_Reference |      Collection_Reference |   100 | 1,292.6 ns |  5.53 ns |  4.90 ns |  0.86 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Collection_Reference |      Collection_Reference |   100 | 1,243.6 ns |  8.12 ns |  7.20 ns |  0.83 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |   100 | 1,506.1 ns |  3.78 ns |  3.35 ns |  1.00 | 0.0725 |     - |     - |     152 B |
|           StructLinq_List_Reference |            List_Reference |   100 | 1,289.9 ns |  4.44 ns |  3.71 ns |  0.86 | 0.0153 |     - |     - |      32 B |
|            Hyperlinq_List_Reference |            List_Reference |   100 | 1,249.5 ns |  6.35 ns |  5.63 ns |  0.83 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|      Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 4,572.8 ns |  8.97 ns |  7.95 ns |  1.00 | 0.0763 |     - |     - |     168 B |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 5,252.3 ns | 17.50 ns | 15.52 ns |  1.15 | 0.0153 |     - |     - |      32 B |
