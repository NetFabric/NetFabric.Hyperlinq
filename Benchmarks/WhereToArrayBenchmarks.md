## WhereToArrayBenchmarks

### Source
[WhereToArrayBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/WhereToArrayBenchmarks.cs)

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
|                          Linq_Array |                     Array |   100 |   427.1 ns |  1.44 ns |  1.20 ns |  1.00 | 0.3519 |     - |     - |     736 B |
|                    StructLinq_Array |                     Array |   100 |   403.1 ns |  1.33 ns |  1.11 ns |  0.94 | 0.1144 |     - |     - |     240 B |
|                     Hyperlinq_Array |                     Array |   100 |   508.5 ns |  2.19 ns |  1.94 ns |  1.19 | 0.1144 |     - |     - |     240 B |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |   100 | 1,196.0 ns |  7.47 ns |  6.63 ns |  1.00 | 0.3700 |     - |     - |     776 B |
|         StructLinq_Enumerable_Value |          Enumerable_Value |   100 | 1,231.8 ns |  2.70 ns |  2.10 ns |  1.03 | 0.1297 |     - |     - |     272 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 |   550.9 ns |  3.57 ns |  3.16 ns |  0.46 | 0.1144 |     - |     - |     240 B |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |   100 | 1,205.4 ns |  3.50 ns |  2.92 ns |  1.00 | 0.3700 |     - |     - |     776 B |
|         StructLinq_Collection_Value |          Collection_Value |   100 | 1,257.0 ns |  6.59 ns |  5.84 ns |  1.04 | 0.1297 |     - |     - |     272 B |
|          Hyperlinq_Collection_Value |          Collection_Value |   100 |   521.4 ns |  1.31 ns |  1.03 ns |  0.43 | 0.1144 |     - |     - |     240 B |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|                     Linq_List_Value |                List_Value |   100 | 1,208.0 ns |  3.79 ns |  3.36 ns |  1.00 | 0.3700 |     - |     - |     776 B |
|               StructLinq_List_Value |                List_Value |   100 |   806.1 ns |  3.44 ns |  3.05 ns |  0.67 | 0.1144 |     - |     - |     240 B |
|                Hyperlinq_List_Value |                List_Value |   100 | 1,147.2 ns |  2.94 ns |  2.45 ns |  0.95 | 0.1144 |     - |     - |     240 B |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|          Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 5,377.3 ns | 32.86 ns | 29.13 ns |  1.00 | 0.4501 |     - |     - |     952 B |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 3,278.9 ns | 11.69 ns | 10.94 ns |  0.61 | 0.3433 |     - |     - |     720 B |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |   100 | 1,241.1 ns |  5.44 ns |  4.82 ns |  1.00 | 0.3700 |     - |     - |     776 B |
|     StructLinq_Enumerable_Reference |      Enumerable_Reference |   100 | 1,250.7 ns |  4.35 ns |  3.85 ns |  1.01 | 0.1297 |     - |     - |     272 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 | 1,347.2 ns |  5.68 ns |  4.74 ns |  1.09 | 0.1297 |     - |     - |     272 B |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |   100 | 1,233.7 ns |  3.62 ns |  3.21 ns |  1.00 | 0.3700 |     - |     - |     776 B |
|     StructLinq_Collection_Reference |      Collection_Reference |   100 | 1,240.4 ns |  3.89 ns |  3.25 ns |  1.01 | 0.1297 |     - |     - |     272 B |
|      Hyperlinq_Collection_Reference |      Collection_Reference |   100 | 1,373.4 ns |  2.59 ns |  2.16 ns |  1.11 | 0.1297 |     - |     - |     272 B |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |   100 | 1,267.2 ns |  6.20 ns |  5.50 ns |  1.00 | 0.3700 |     - |     - |     776 B |
|           StructLinq_List_Reference |            List_Reference |   100 | 1,245.2 ns |  3.72 ns |  3.29 ns |  0.98 | 0.1297 |     - |     - |     272 B |
|            Hyperlinq_List_Reference |            List_Reference |   100 | 1,184.4 ns |  2.50 ns |  1.95 ns |  0.94 | 0.1144 |     - |     - |     240 B |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|      Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 5,438.5 ns | 40.03 ns | 37.45 ns |  1.00 | 0.4501 |     - |     - |     952 B |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 4,029.0 ns |  9.78 ns |  9.15 ns |  0.74 | 0.3586 |     - |     - |     752 B |
