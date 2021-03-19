## WhereCountBenchmarks

### Source
[WhereCountBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/WhereCountBenchmarks.cs)

### References:
- Linq: 6.0.0-preview.2.21154.6
- System.Linq.Async: [5.0.0](https://www.nuget.org/packages/System.Linq.Async/5.0.0)
- System.Interactive: [5.0.0](https://www.nuget.org/packages/System.Interactive/5.0.0)
- System.Interactive.Async: [5.0.0](https://www.nuget.org/packages/System.Interactive.Async/5.0.0)
- StructLinq: [0.25.3](https://www.nuget.org/packages/StructLinq/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)

### Results:
``` ini

BenchmarkDotNet=v0.12.1.1521-nightly, OS=Windows 10.0.19043
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.2.21155.3
  [Host]     : .NET 6.0.0 (6.0.21.15406), X64 RyuJIT
  Job-XHOKQA : .NET 6.0.0 (6.0.21.15406), X64 RyuJIT

Runtime=.NET 6.0  

```
|                              Method |                Categories | Count |       Mean |   Error |  StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------ |-------------------------- |------ |-----------:|--------:|--------:|------:|-------:|------:|------:|----------:|
|                          Linq_Array |                     Array |   100 |   683.0 ns | 3.38 ns | 2.82 ns |  1.00 | 0.0153 |     - |     - |      32 B |
|                    StructLinq_Array |                     Array |   100 |   242.0 ns | 2.34 ns | 2.07 ns |  0.35 |      - |     - |     - |         - |
|                     Hyperlinq_Array |                     Array |   100 |   175.4 ns | 0.35 ns | 0.27 ns |  0.26 |      - |     - |     - |         - |
|                      Hyperlinq_Span |                     Array |   100 |   197.9 ns | 0.64 ns | 0.54 ns |  0.29 |      - |     - |     - |         - |
|                    Hyperlinq_Memory |                     Array |   100 |   201.8 ns | 0.50 ns | 0.41 ns |  0.30 |      - |     - |     - |         - |
|                                     |                           |       |            |         |         |       |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |   100 | 1,173.3 ns | 7.26 ns | 6.79 ns |  1.00 | 0.0153 |     - |     - |      32 B |
|         StructLinq_Enumerable_Value |          Enumerable_Value |   100 | 1,117.3 ns | 4.93 ns | 4.37 ns |  0.95 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 |   206.0 ns | 1.31 ns | 1.02 ns |  0.18 |      - |     - |     - |         - |
|                                     |                           |       |            |         |         |       |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |   100 | 1,187.3 ns | 9.07 ns | 7.57 ns |  1.00 | 0.0153 |     - |     - |      32 B |
|         StructLinq_Collection_Value |          Collection_Value |   100 | 1,139.5 ns | 5.64 ns | 5.00 ns |  0.96 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Collection_Value |          Collection_Value |   100 |   213.0 ns | 0.73 ns | 0.64 ns |  0.18 |      - |     - |     - |         - |
|                                     |                           |       |            |         |         |       |        |       |       |           |
|                     Linq_List_Value |                List_Value |   100 | 1,168.6 ns | 4.37 ns | 3.65 ns |  1.00 | 0.0153 |     - |     - |      32 B |
|               StructLinq_List_Value |                List_Value |   100 |   498.9 ns | 2.41 ns | 2.13 ns |  0.43 |      - |     - |     - |         - |
|                Hyperlinq_List_Value |                List_Value |   100 |   702.5 ns | 2.26 ns | 2.11 ns |  0.60 |      - |     - |     - |         - |
|                                     |                           |       |            |         |         |       |        |       |       |           |
|          Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 1,849.7 ns | 5.54 ns | 4.91 ns |  1.00 | 0.0153 |     - |     - |      32 B |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 2,816.1 ns | 3.11 ns | 2.42 ns |  1.52 |      - |     - |     - |         - |
|                                     |                           |       |            |         |         |       |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |   100 | 1,165.7 ns | 6.51 ns | 5.77 ns |  1.00 | 0.0153 |     - |     - |      32 B |
|     StructLinq_Enumerable_Reference |      Enumerable_Reference |   100 | 1,139.5 ns | 4.77 ns | 4.47 ns |  0.98 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 |   769.7 ns | 3.39 ns | 3.01 ns |  0.66 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |            |         |         |       |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |   100 | 1,165.7 ns | 6.68 ns | 6.25 ns |  1.00 | 0.0153 |     - |     - |      32 B |
|     StructLinq_Collection_Reference |      Collection_Reference |   100 | 1,099.9 ns | 2.64 ns | 2.47 ns |  0.94 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Collection_Reference |      Collection_Reference |   100 |   804.9 ns | 2.60 ns | 2.30 ns |  0.69 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |            |         |         |       |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |   100 | 1,162.3 ns | 4.96 ns | 4.64 ns |  1.00 | 0.0153 |     - |     - |      32 B |
|           StructLinq_List_Reference |            List_Reference |   100 | 1,100.8 ns | 4.93 ns | 4.61 ns |  0.95 | 0.0153 |     - |     - |      32 B |
|            Hyperlinq_List_Reference |            List_Reference |   100 |   688.8 ns | 3.99 ns | 3.54 ns |  0.59 |      - |     - |     - |         - |
|                                     |                           |       |            |         |         |       |        |       |       |           |
|      Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 1,849.7 ns | 4.99 ns | 4.42 ns |  1.00 | 0.0153 |     - |     - |      32 B |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 3,148.6 ns | 7.67 ns | 6.80 ns |  1.70 | 0.0153 |     - |     - |      32 B |
