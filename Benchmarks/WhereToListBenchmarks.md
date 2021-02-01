## WhereToListBenchmarks

### Source
[WhereToListBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/WhereToListBenchmarks.cs)

### References:
- Linq: 4.8.4300.0
- System.Linq.Async: [5.0.0](https://www.nuget.org/packages/System.Linq.Async/5.0.0)
- System.Interactive: [5.0.0](https://www.nuget.org/packages/System.Interactive/5.0.0)
- System.Interactive.Async: [5.0.0](https://www.nuget.org/packages/System.Interactive.Async/5.0.0)
- StructLinq: [0.25.3](https://www.nuget.org/packages/StructLinq/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta29](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta29)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
  [Host]        : .NET Framework 4.8 (4.8.4300.0), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|                              Method |                Categories | Count |       Mean |    Error |   StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------ |-------------------------- |------ |-----------:|---------:|---------:|------:|-------:|------:|------:|----------:|
|                          Linq_Array |                     Array |   100 |   373.4 ns |  1.72 ns |  1.61 ns |  1.00 | 0.3328 |     - |     - |     696 B |
|                    StructLinq_Array |                     Array |   100 |   406.3 ns |  1.10 ns |  0.98 ns |  1.09 | 0.1297 |     - |     - |     272 B |
|                     Hyperlinq_Array |                     Array |   100 |   487.0 ns |  1.44 ns |  1.27 ns |  1.30 | 0.1297 |     - |     - |     272 B |
|                      Hyperlinq_Span |                     Array |   100 |   494.5 ns |  1.70 ns |  1.51 ns |  1.32 | 0.1297 |     - |     - |     272 B |
|                    Hyperlinq_Memory |                     Array |   100 |   483.2 ns |  1.55 ns |  1.37 ns |  1.29 | 0.1297 |     - |     - |     272 B |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |   100 | 1,189.3 ns |  3.81 ns |  3.38 ns |  1.00 | 0.3510 |     - |     - |     736 B |
|         StructLinq_Enumerable_Value |          Enumerable_Value |   100 | 1,222.3 ns |  3.13 ns |  2.44 ns |  1.03 | 0.1450 |     - |     - |     304 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 |   554.7 ns |  1.10 ns |  0.92 ns |  0.47 | 0.1297 |     - |     - |     272 B |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |   100 | 1,197.2 ns |  5.13 ns |  4.55 ns |  1.00 | 0.3510 |     - |     - |     736 B |
|         StructLinq_Collection_Value |          Collection_Value |   100 | 1,216.2 ns |  3.80 ns |  3.17 ns |  1.02 | 0.1450 |     - |     - |     304 B |
|          Hyperlinq_Collection_Value |          Collection_Value |   100 |   513.6 ns |  1.13 ns |  1.00 ns |  0.43 | 0.1297 |     - |     - |     272 B |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|                     Linq_List_Value |                List_Value |   100 | 1,192.6 ns |  5.32 ns |  4.44 ns |  1.00 | 0.3510 |     - |     - |     736 B |
|               StructLinq_List_Value |                List_Value |   100 |   784.4 ns |  1.41 ns |  1.32 ns |  0.66 | 0.1297 |     - |     - |     272 B |
|                Hyperlinq_List_Value |                List_Value |   100 |   895.8 ns |  3.13 ns |  2.77 ns |  0.75 | 0.1297 |     - |     - |     272 B |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|          Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 5,958.2 ns | 28.08 ns | 24.89 ns |  1.00 | 0.3586 |     - |     - |     752 B |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 6,080.4 ns | 13.50 ns | 11.97 ns |  1.02 | 0.3738 |     - |     - |     784 B |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |   100 |   867.9 ns |  3.91 ns |  3.46 ns |  1.00 | 0.3519 |     - |     - |     736 B |
|     StructLinq_Enumerable_Reference |      Enumerable_Reference |   100 |   780.4 ns |  2.18 ns |  2.04 ns |  0.90 | 0.1450 |     - |     - |     304 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 |   906.2 ns |  2.77 ns |  2.46 ns |  1.04 | 0.1450 |     - |     - |     304 B |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |   100 |   867.4 ns |  3.43 ns |  2.87 ns |  1.00 | 0.3519 |     - |     - |     736 B |
|     StructLinq_Collection_Reference |      Collection_Reference |   100 |   782.7 ns |  1.36 ns |  1.13 ns |  0.90 | 0.1450 |     - |     - |     304 B |
|      Hyperlinq_Collection_Reference |      Collection_Reference |   100 |   908.6 ns |  3.56 ns |  3.16 ns |  1.05 | 0.1450 |     - |     - |     304 B |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |   100 |   833.1 ns |  3.27 ns |  2.73 ns |  1.00 | 0.3519 |     - |     - |     736 B |
|           StructLinq_List_Reference |            List_Reference |   100 |   779.9 ns |  1.64 ns |  1.45 ns |  0.94 | 0.1450 |     - |     - |     304 B |
|            Hyperlinq_List_Reference |            List_Reference |   100 |   896.6 ns |  2.71 ns |  2.53 ns |  1.08 | 0.1297 |     - |     - |     272 B |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|      Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 5,883.1 ns | 21.11 ns | 17.62 ns |  1.00 | 0.3586 |     - |     - |     752 B |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 6,152.3 ns |  8.57 ns |  8.02 ns |  1.05 | 0.3815 |     - |     - |     800 B |
