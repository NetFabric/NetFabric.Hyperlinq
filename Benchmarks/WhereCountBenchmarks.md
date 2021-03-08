## WhereCountBenchmarks

### Source
[WhereCountBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/WhereCountBenchmarks.cs)

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
|                          Linq_Array |                     Array |   100 |   692.3 ns |  3.38 ns |  3.00 ns |  1.00 | 0.0153 |     - |     - |      32 B |
|                    StructLinq_Array |                     Array |   100 |   229.7 ns |  1.46 ns |  1.22 ns |  0.33 |      - |     - |     - |         - |
|                     Hyperlinq_Array |                     Array |   100 |   201.6 ns |  0.66 ns |  1.22 ns |  0.29 |      - |     - |     - |         - |
|                      Hyperlinq_Span |                     Array |   100 |   196.9 ns |  1.06 ns |  0.99 ns |  0.28 |      - |     - |     - |         - |
|                    Hyperlinq_Memory |                     Array |   100 |   177.5 ns |  1.05 ns |  0.93 ns |  0.26 |      - |     - |     - |         - |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |   100 | 1,155.1 ns |  5.01 ns |  4.45 ns |  1.00 | 0.0153 |     - |     - |      32 B |
|         StructLinq_Enumerable_Value |          Enumerable_Value |   100 | 1,136.8 ns |  7.25 ns |  6.05 ns |  0.98 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 |   772.3 ns |  3.08 ns |  2.73 ns |  0.67 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |   100 | 1,152.0 ns |  5.05 ns |  4.48 ns |  1.00 | 0.0153 |     - |     - |      32 B |
|         StructLinq_Collection_Value |          Collection_Value |   100 | 1,087.1 ns |  6.26 ns |  5.55 ns |  0.94 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Collection_Value |          Collection_Value |   100 |   775.3 ns |  4.38 ns |  3.88 ns |  0.67 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|                     Linq_List_Value |                List_Value |   100 | 1,160.6 ns |  5.14 ns |  4.56 ns |  1.00 | 0.0153 |     - |     - |      32 B |
|               StructLinq_List_Value |                List_Value |   100 |   492.1 ns |  3.15 ns |  2.79 ns |  0.42 |      - |     - |     - |         - |
|                Hyperlinq_List_Value |                List_Value |   100 |   649.8 ns |  5.17 ns |  4.58 ns |  0.56 |      - |     - |     - |         - |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|          Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 2,205.3 ns |  5.32 ns |  4.98 ns |  1.00 | 0.0191 |     - |     - |      40 B |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 6,058.6 ns | 24.23 ns | 21.48 ns |  2.75 | 0.0687 |     - |     - |     152 B |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |   100 |   783.3 ns |  4.47 ns |  3.96 ns |  1.00 | 0.0153 |     - |     - |      32 B |
|     StructLinq_Enumerable_Reference |      Enumerable_Reference |   100 |   664.2 ns |  5.49 ns |  5.13 ns |  0.85 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 |   578.6 ns |  2.38 ns |  2.11 ns |  0.74 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |   100 |   783.9 ns |  4.20 ns |  3.72 ns |  1.00 | 0.0153 |     - |     - |      32 B |
|     StructLinq_Collection_Reference |      Collection_Reference |   100 |   643.2 ns |  5.19 ns |  4.34 ns |  0.82 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Collection_Reference |      Collection_Reference |   100 |   583.7 ns |  3.13 ns |  2.93 ns |  0.74 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |   100 |   785.7 ns |  5.62 ns |  4.69 ns |  1.00 | 0.0153 |     - |     - |      32 B |
|           StructLinq_List_Reference |            List_Reference |   100 |   664.6 ns |  3.75 ns |  3.13 ns |  0.85 | 0.0153 |     - |     - |      32 B |
|            Hyperlinq_List_Reference |            List_Reference |   100 |   622.1 ns |  3.74 ns |  3.50 ns |  0.79 |      - |     - |     - |         - |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|      Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 2,062.2 ns |  4.83 ns |  4.52 ns |  1.00 | 0.0191 |     - |     - |      40 B |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 5,941.6 ns | 29.60 ns | 26.24 ns |  2.88 | 0.0687 |     - |     - |     152 B |
