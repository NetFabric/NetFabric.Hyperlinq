## WhereToListBenchmarks

### Source
[WhereToListBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/WhereToListBenchmarks.cs)

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
|                          Linq_Array |                     Array |   100 |   381.6 ns |  2.39 ns |  2.00 ns |  1.00 | 0.3328 |     - |     - |     696 B |
|                    StructLinq_Array |                     Array |   100 |   398.2 ns |  4.28 ns |  4.01 ns |  1.04 | 0.1297 |     - |     - |     272 B |
|                     Hyperlinq_Array |                     Array |   100 |   501.1 ns |  3.06 ns |  2.71 ns |  1.31 | 0.1297 |     - |     - |     272 B |
|                      Hyperlinq_Span |                     Array |   100 |   471.7 ns |  1.55 ns |  1.37 ns |  1.24 | 0.1297 |     - |     - |     272 B |
|                    Hyperlinq_Memory |                     Array |   100 |   479.7 ns |  3.70 ns |  3.09 ns |  1.26 | 0.1297 |     - |     - |     272 B |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |   100 | 1,186.2 ns |  6.89 ns |  6.11 ns |  1.00 | 0.3510 |     - |     - |     736 B |
|         StructLinq_Enumerable_Value |          Enumerable_Value |   100 | 1,256.2 ns |  3.84 ns |  3.00 ns |  1.06 | 0.1450 |     - |     - |     304 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 | 1,365.7 ns |  7.02 ns |  6.22 ns |  1.15 | 0.1450 |     - |     - |     304 B |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |   100 | 1,223.2 ns |  4.28 ns |  3.57 ns |  1.00 | 0.3510 |     - |     - |     736 B |
|         StructLinq_Collection_Value |          Collection_Value |   100 | 1,251.0 ns |  5.89 ns |  4.92 ns |  1.02 | 0.1450 |     - |     - |     304 B |
|          Hyperlinq_Collection_Value |          Collection_Value |   100 | 1,401.8 ns |  5.25 ns |  4.65 ns |  1.15 | 0.1450 |     - |     - |     304 B |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|                     Linq_List_Value |                List_Value |   100 | 1,230.3 ns |  7.54 ns |  6.68 ns |  1.00 | 0.3510 |     - |     - |     736 B |
|               StructLinq_List_Value |                List_Value |   100 |   776.0 ns |  1.76 ns |  1.37 ns |  0.63 | 0.1297 |     - |     - |     272 B |
|                Hyperlinq_List_Value |                List_Value |   100 | 1,209.5 ns |  6.86 ns |  6.42 ns |  0.98 | 0.1297 |     - |     - |     272 B |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|          Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 5,977.9 ns | 24.91 ns | 23.30 ns |  1.00 | 0.3586 |     - |     - |     752 B |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 6,202.6 ns | 19.74 ns | 18.46 ns |  1.04 | 0.3815 |     - |     - |     800 B |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |   100 |   793.0 ns |  3.19 ns |  2.83 ns |  1.00 | 0.3519 |     - |     - |     736 B |
|     StructLinq_Enumerable_Reference |      Enumerable_Reference |   100 |   803.3 ns |  4.08 ns |  3.62 ns |  1.01 | 0.1450 |     - |     - |     304 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 |   936.4 ns |  4.42 ns |  4.13 ns |  1.18 | 0.1450 |     - |     - |     304 B |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |   100 |   794.8 ns |  3.98 ns |  3.33 ns |  1.00 | 0.3519 |     - |     - |     736 B |
|     StructLinq_Collection_Reference |      Collection_Reference |   100 |   879.1 ns |  3.33 ns |  3.11 ns |  1.11 | 0.1450 |     - |     - |     304 B |
|      Hyperlinq_Collection_Reference |      Collection_Reference |   100 |   961.1 ns |  7.31 ns |  6.48 ns |  1.21 | 0.1450 |     - |     - |     304 B |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |   100 |   884.6 ns |  4.59 ns |  4.07 ns |  1.00 | 0.3519 |     - |     - |     736 B |
|           StructLinq_List_Reference |            List_Reference |   100 |   808.7 ns |  2.45 ns |  2.17 ns |  0.91 | 0.1450 |     - |     - |     304 B |
|            Hyperlinq_List_Reference |            List_Reference |   100 | 1,219.1 ns |  6.57 ns |  5.83 ns |  1.38 | 0.1297 |     - |     - |     272 B |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|      Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 6,023.2 ns | 26.64 ns | 24.92 ns |  1.00 | 0.3586 |     - |     - |     752 B |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 6,156.9 ns | 24.54 ns | 22.95 ns |  1.02 | 0.3815 |     - |     - |     800 B |
