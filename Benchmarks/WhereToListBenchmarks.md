## WhereToListBenchmarks

### Source
[WhereToListBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/WhereToListBenchmarks.cs)

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
|                          Linq_Array |                     Array |   100 |   360.4 ns |  0.78 ns |  0.65 ns |  1.00 | 0.3328 |     - |     - |     696 B |
|                    StructLinq_Array |                     Array |   100 |   413.7 ns |  2.24 ns |  1.99 ns |  1.15 | 0.1297 |     - |     - |     272 B |
|                     Hyperlinq_Array |                     Array |   100 |   506.2 ns |  4.85 ns |  4.05 ns |  1.40 | 0.1297 |     - |     - |     272 B |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |   100 | 1,223.5 ns |  4.30 ns |  3.59 ns |  1.00 | 0.3510 |     - |     - |     736 B |
|         StructLinq_Enumerable_Value |          Enumerable_Value |   100 | 1,261.3 ns |  6.69 ns |  6.25 ns |  1.03 | 0.1450 |     - |     - |     304 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 |   521.5 ns |  3.36 ns |  3.14 ns |  0.43 | 0.1297 |     - |     - |     272 B |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |   100 | 1,232.6 ns | 11.34 ns |  9.47 ns |  1.00 | 0.3510 |     - |     - |     736 B |
|         StructLinq_Collection_Value |          Collection_Value |   100 | 1,253.2 ns |  2.26 ns |  1.89 ns |  1.02 | 0.1450 |     - |     - |     304 B |
|          Hyperlinq_Collection_Value |          Collection_Value |   100 |   532.1 ns |  3.83 ns |  3.59 ns |  0.43 | 0.1297 |     - |     - |     272 B |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|                     Linq_List_Value |                List_Value |   100 | 1,227.6 ns |  3.87 ns |  3.23 ns |  1.00 | 0.3510 |     - |     - |     736 B |
|               StructLinq_List_Value |                List_Value |   100 |   812.6 ns |  5.19 ns |  4.05 ns |  0.66 | 0.1297 |     - |     - |     272 B |
|                Hyperlinq_List_Value |                List_Value |   100 | 1,228.8 ns |  8.43 ns |  7.89 ns |  1.00 | 0.1297 |     - |     - |     272 B |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|          Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 5,264.3 ns | 14.12 ns | 13.21 ns |  1.00 | 0.3510 |     - |     - |     744 B |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 3,278.2 ns |  9.48 ns |  8.40 ns |  0.62 | 0.3586 |     - |     - |     752 B |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |   100 | 1,225.8 ns |  2.45 ns |  1.91 ns |  1.00 | 0.3510 |     - |     - |     736 B |
|     StructLinq_Enumerable_Reference |      Enumerable_Reference |   100 | 1,258.7 ns |  3.44 ns |  3.05 ns |  1.03 | 0.1450 |     - |     - |     304 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 | 1,319.2 ns |  5.28 ns |  4.41 ns |  1.08 | 0.1450 |     - |     - |     304 B |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |   100 | 1,226.7 ns |  3.26 ns |  2.89 ns |  1.00 | 0.3510 |     - |     - |     736 B |
|     StructLinq_Collection_Reference |      Collection_Reference |   100 | 1,247.0 ns |  4.48 ns |  3.97 ns |  1.02 | 0.1450 |     - |     - |     304 B |
|      Hyperlinq_Collection_Reference |      Collection_Reference |   100 | 1,370.6 ns |  5.58 ns |  4.66 ns |  1.12 | 0.1450 |     - |     - |     304 B |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |   100 | 1,231.1 ns |  7.91 ns |  7.01 ns |  1.00 | 0.3510 |     - |     - |     736 B |
|           StructLinq_List_Reference |            List_Reference |   100 | 1,242.9 ns |  4.32 ns |  3.37 ns |  1.01 | 0.1450 |     - |     - |     304 B |
|            Hyperlinq_List_Reference |            List_Reference |   100 | 1,210.8 ns |  5.63 ns |  5.27 ns |  0.98 | 0.1297 |     - |     - |     272 B |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|      Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 5,347.5 ns | 15.41 ns | 13.66 ns |  1.00 | 0.3510 |     - |     - |     744 B |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 3,975.5 ns |  9.77 ns |  9.14 ns |  0.74 | 0.3738 |     - |     - |     784 B |
