## WhereSelectBenchmarks

### Source
[WhereSelectBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/WhereSelectBenchmarks.cs)

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
|                          Linq_Array |                     Array |   100 |   693.5 ns |  4.07 ns |  3.40 ns |  1.00 | 0.0496 |     - |     - |     104 B |
|                    StructLinq_Array |                     Array |   100 |   353.3 ns |  2.36 ns |  2.09 ns |  0.51 |      - |     - |     - |         - |
|                     Hyperlinq_Array |                     Array |   100 |   408.9 ns |  1.26 ns |  1.18 ns |  0.59 |      - |     - |     - |         - |
|                      Hyperlinq_Span |                     Array |   100 |   383.0 ns |  1.30 ns |  1.15 ns |  0.55 |      - |     - |     - |         - |
|                    Hyperlinq_Memory |                     Array |   100 |   366.0 ns |  2.13 ns |  1.89 ns |  0.53 |      - |     - |     - |         - |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |   100 | 1,500.9 ns |  6.83 ns |  6.06 ns |  1.00 | 0.0725 |     - |     - |     152 B |
|         StructLinq_Enumerable_Value |          Enumerable_Value |   100 | 1,376.3 ns |  4.19 ns |  3.71 ns |  0.92 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 |   355.8 ns |  1.54 ns |  1.29 ns |  0.24 |      - |     - |     - |         - |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |   100 | 1,488.5 ns |  7.56 ns |  6.70 ns |  1.00 | 0.0725 |     - |     - |     152 B |
|         StructLinq_Collection_Value |          Collection_Value |   100 | 1,286.4 ns |  4.83 ns |  4.52 ns |  0.86 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Collection_Value |          Collection_Value |   100 |   419.6 ns |  1.91 ns |  1.69 ns |  0.28 |      - |     - |     - |         - |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|                     Linq_List_Value |                List_Value |   100 | 1,484.4 ns |  4.60 ns |  3.84 ns |  1.00 | 0.0725 |     - |     - |     152 B |
|               StructLinq_List_Value |                List_Value |   100 |   796.7 ns |  3.14 ns |  2.79 ns |  0.54 |      - |     - |     - |         - |
|                Hyperlinq_List_Value |                List_Value |   100 |   826.0 ns |  2.44 ns |  2.16 ns |  0.56 |      - |     - |     - |         - |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|          Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 5,582.5 ns |  6.62 ns |  5.53 ns |  1.00 | 0.0839 |     - |     - |     176 B |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 5,826.4 ns | 17.85 ns | 15.83 ns |  1.04 | 0.1068 |     - |     - |     224 B |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |   100 | 1,227.3 ns |  3.61 ns |  3.20 ns |  1.00 | 0.0725 |     - |     - |     152 B |
|     StructLinq_Enumerable_Reference |      Enumerable_Reference |   100 |   857.0 ns |  2.35 ns |  1.96 ns |  0.70 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 |   838.1 ns |  2.28 ns |  1.90 ns |  0.68 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |   100 | 1,238.0 ns |  3.62 ns |  3.39 ns |  1.00 | 0.0725 |     - |     - |     152 B |
|     StructLinq_Collection_Reference |      Collection_Reference |   100 |   863.1 ns |  1.89 ns |  1.67 ns |  0.70 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Collection_Reference |      Collection_Reference |   100 |   889.6 ns |  1.42 ns |  1.26 ns |  0.72 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |   100 | 1,239.9 ns |  3.73 ns |  3.31 ns |  1.00 | 0.0725 |     - |     - |     152 B |
|           StructLinq_List_Reference |            List_Reference |   100 |   899.3 ns |  2.77 ns |  2.59 ns |  0.73 | 0.0153 |     - |     - |      32 B |
|            Hyperlinq_List_Reference |            List_Reference |   100 |   826.0 ns |  2.60 ns |  2.30 ns |  0.67 |      - |     - |     - |         - |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|      Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 5,258.2 ns | 20.80 ns | 19.46 ns |  1.00 | 0.0839 |     - |     - |     176 B |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 5,591.4 ns | 23.81 ns | 22.27 ns |  1.06 | 0.1068 |     - |     - |     224 B |
