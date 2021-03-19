## WhereSelectCountBenchmarks

### Source
[WhereSelectCountBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/WhereSelectCountBenchmarks.cs)

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
|                              Method |                Categories | Count |       Mean |    Error |   StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------ |-------------------------- |------ |-----------:|---------:|---------:|------:|-------:|------:|------:|----------:|
|                          Linq_Array |                     Array |   100 |   345.9 ns |  0.90 ns |  0.84 ns |  1.00 | 0.0496 |     - |     - |     104 B |
|                     Hyperlinq_Array |                     Array |   100 |   209.4 ns |  1.38 ns |  1.15 ns |  0.61 |      - |     - |     - |         - |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |   100 | 1,264.3 ns |  4.34 ns |  4.06 ns |  1.00 | 0.0725 |     - |     - |     152 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 |   214.1 ns |  0.76 ns |  0.67 ns |  0.17 |      - |     - |     - |         - |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |   100 | 1,279.1 ns |  4.00 ns |  3.34 ns |  1.00 | 0.0725 |     - |     - |     152 B |
|          Hyperlinq_Collection_Value |          Collection_Value |   100 |   221.3 ns |  1.91 ns |  1.69 ns |  0.17 |      - |     - |     - |         - |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|                     Linq_List_Value |                List_Value |   100 | 1,246.3 ns |  4.13 ns |  3.44 ns |  1.00 | 0.0725 |     - |     - |     152 B |
|                Hyperlinq_List_Value |                List_Value |   100 |   630.4 ns |  2.49 ns |  2.21 ns |  0.51 |      - |     - |     - |         - |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|          Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 5,311.0 ns | 22.90 ns | 21.42 ns |  1.00 | 0.0763 |     - |     - |     168 B |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 2,826.6 ns |  7.29 ns |  6.47 ns |  0.53 |      - |     - |     - |         - |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |   100 | 1,274.2 ns |  5.65 ns |  5.00 ns |  1.00 | 0.0725 |     - |     - |     152 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 |   775.7 ns |  3.07 ns |  2.88 ns |  0.61 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |   100 | 1,261.5 ns |  4.05 ns |  3.59 ns |  1.00 | 0.0725 |     - |     - |     152 B |
|      Hyperlinq_Collection_Reference |      Collection_Reference |   100 |   799.5 ns |  3.15 ns |  2.79 ns |  0.63 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |   100 | 1,265.8 ns |  2.83 ns |  2.36 ns |  1.00 | 0.0725 |     - |     - |     152 B |
|            Hyperlinq_List_Reference |            List_Reference |   100 |   649.8 ns |  2.98 ns |  2.49 ns |  0.51 |      - |     - |     - |         - |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|      Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 5,174.8 ns | 38.53 ns | 30.08 ns |  1.00 | 0.0763 |     - |     - |     168 B |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 3,162.1 ns |  9.40 ns |  8.80 ns |  0.61 | 0.0153 |     - |     - |      32 B |
