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
|                              Method |                Categories | Count |       Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------ |-------------------------- |------ |-----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|                          Linq_Array |                     Array |   100 |   386.6 ns |  2.73 ns |  2.28 ns |  1.00 |    0.00 | 0.3328 |     - |     - |     696 B |
|                    StructLinq_Array |                     Array |   100 |   425.1 ns |  6.30 ns |  5.58 ns |  1.10 |    0.01 | 0.1297 |     - |     - |     272 B |
|                     Hyperlinq_Array |                     Array |   100 |   503.6 ns |  3.06 ns |  2.86 ns |  1.30 |    0.01 | 0.1297 |     - |     - |     272 B |
|                      Hyperlinq_Span |                     Array |   100 |   475.4 ns |  2.73 ns |  2.56 ns |  1.23 |    0.01 | 0.1297 |     - |     - |     272 B |
|                    Hyperlinq_Memory |                     Array |   100 |   555.9 ns |  4.89 ns |  4.57 ns |  1.44 |    0.02 | 0.1297 |     - |     - |     272 B |
|                                     |                           |       |            |          |          |       |         |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |   100 | 1,189.7 ns |  7.51 ns |  7.02 ns |  1.00 |    0.00 | 0.3510 |     - |     - |     736 B |
|         StructLinq_Enumerable_Value |          Enumerable_Value |   100 | 1,279.9 ns |  4.43 ns |  4.14 ns |  1.08 |    0.01 | 0.1450 |     - |     - |     304 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 |   519.7 ns |  4.23 ns |  3.96 ns |  0.44 |    0.00 | 0.1297 |     - |     - |     272 B |
|                                     |                           |       |            |          |          |       |         |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |   100 | 1,230.9 ns |  5.08 ns |  4.50 ns |  1.00 |    0.00 | 0.3510 |     - |     - |     736 B |
|         StructLinq_Collection_Value |          Collection_Value |   100 | 1,250.4 ns |  6.27 ns |  5.87 ns |  1.02 |    0.01 | 0.1450 |     - |     - |     304 B |
|          Hyperlinq_Collection_Value |          Collection_Value |   100 |   519.4 ns |  2.68 ns |  2.51 ns |  0.42 |    0.00 | 0.1297 |     - |     - |     272 B |
|                                     |                           |       |            |          |          |       |         |        |       |       |           |
|                     Linq_List_Value |                List_Value |   100 | 1,185.0 ns |  5.55 ns |  5.20 ns |  1.00 |    0.00 | 0.3510 |     - |     - |     736 B |
|               StructLinq_List_Value |                List_Value |   100 |   789.1 ns |  3.41 ns |  2.84 ns |  0.67 |    0.00 | 0.1297 |     - |     - |     272 B |
|                Hyperlinq_List_Value |                List_Value |   100 | 1,203.9 ns |  4.29 ns |  4.01 ns |  1.02 |    0.01 | 0.1297 |     - |     - |     272 B |
|                                     |                           |       |            |          |          |       |         |        |       |       |           |
|          Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 6,205.9 ns | 19.43 ns | 18.17 ns |  1.00 |    0.00 | 0.3586 |     - |     - |     752 B |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 6,096.6 ns | 14.85 ns | 13.89 ns |  0.98 |    0.00 | 0.3738 |     - |     - |     792 B |
|                                     |                           |       |            |          |          |       |         |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |   100 |   804.5 ns |  4.42 ns |  4.14 ns |  1.00 |    0.00 | 0.3519 |     - |     - |     736 B |
|     StructLinq_Enumerable_Reference |      Enumerable_Reference |   100 |   817.8 ns |  5.93 ns |  5.55 ns |  1.02 |    0.01 | 0.1450 |     - |     - |     304 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 |   939.8 ns |  4.87 ns |  4.56 ns |  1.17 |    0.01 | 0.1450 |     - |     - |     304 B |
|                                     |                           |       |            |          |          |       |         |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |   100 |   803.9 ns |  5.58 ns |  4.66 ns |  1.00 |    0.00 | 0.3519 |     - |     - |     736 B |
|     StructLinq_Collection_Reference |      Collection_Reference |   100 |   859.1 ns |  5.44 ns |  4.82 ns |  1.07 |    0.01 | 0.1450 |     - |     - |     304 B |
|      Hyperlinq_Collection_Reference |      Collection_Reference |   100 |   966.0 ns |  7.81 ns |  7.31 ns |  1.20 |    0.01 | 0.1450 |     - |     - |     304 B |
|                                     |                           |       |            |          |          |       |         |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |   100 |   802.7 ns |  6.70 ns |  6.26 ns |  1.00 |    0.00 | 0.3519 |     - |     - |     736 B |
|           StructLinq_List_Reference |            List_Reference |   100 |   933.2 ns |  3.44 ns |  3.05 ns |  1.16 |    0.01 | 0.1450 |     - |     - |     304 B |
|            Hyperlinq_List_Reference |            List_Reference |   100 | 1,257.9 ns | 22.15 ns | 25.51 ns |  1.57 |    0.03 | 0.1297 |     - |     - |     272 B |
|                                     |                           |       |            |          |          |       |         |        |       |       |           |
|      Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 6,437.0 ns | 16.85 ns | 14.94 ns |  1.00 |    0.00 | 0.3586 |     - |     - |     752 B |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 6,324.1 ns | 22.46 ns | 19.91 ns |  0.98 |    0.00 | 0.3815 |     - |     - |     800 B |
