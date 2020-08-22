## WhereToListBenchmarks

### Source
[WhereToListBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/WhereToListBenchmarks.cs)

### References:
- Linq: 5.0.0-preview.7.20364.11
- System.Linq.Async: [4.1.1](https://www.nuget.org/packages/System.Linq.Async/4.1.1)
- System.Interactive: [4.1.1](https://www.nuget.org/packages/System.Interactive/4.1.1)
- System.Interactive.Async: [4.1.1](https://www.nuget.org/packages/System.Interactive.Async/4.1.1)
- StructLinq: [0.19.2](https://www.nuget.org/packages/StructLinq/0.19.2)
- NetFabric.Hyperlinq: [3.0.0-beta26](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta26)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.100-preview.7.20366.6
  [Host]        : .NET Core 5.0.0 (CoreCLR 5.0.20.36411, CoreFX 5.0.20.36411), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.0 (CoreCLR 5.0.20.36411, CoreFX 5.0.20.36411), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|                              Method |                Categories | Count |       Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------ |-------------------------- |------ |-----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|                          Linq_Array |                     Array |   100 |   377.3 ns |  2.57 ns |  2.40 ns |  1.00 |    0.00 | 0.3328 |     - |     - |     696 B |
|                    StructLinq_Array |                     Array |   100 |   506.8 ns |  2.12 ns |  1.77 ns |  1.34 |    0.01 | 0.1297 |     - |     - |     272 B |
|                     Hyperlinq_Array |                     Array |   100 |   554.0 ns |  3.50 ns |  3.28 ns |  1.47 |    0.01 | 0.1640 |     - |     - |     344 B |
|                      Hyperlinq_Span |                     Array |   100 |   578.8 ns |  3.61 ns |  3.37 ns |  1.53 |    0.01 | 0.1640 |     - |     - |     344 B |
|                    Hyperlinq_Memory |                     Array |   100 |   532.5 ns |  3.10 ns |  2.90 ns |  1.41 |    0.01 | 0.1640 |     - |     - |     344 B |
|                                     |                           |       |            |          |          |       |         |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |   100 | 1,228.3 ns |  8.49 ns |  7.94 ns |  1.00 |    0.00 | 0.3510 |     - |     - |     736 B |
|         StructLinq_Enumerable_Value |          Enumerable_Value |   100 | 1,593.2 ns |  8.81 ns |  8.24 ns |  1.30 |    0.01 | 0.1450 |     - |     - |     304 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 |   626.8 ns |  4.65 ns |  4.12 ns |  0.51 |    0.00 | 0.1640 |     - |     - |     344 B |
|                                     |                           |       |            |          |          |       |         |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |   100 | 1,228.7 ns |  6.67 ns |  6.24 ns |  1.00 |    0.00 | 0.3510 |     - |     - |     736 B |
|         StructLinq_Collection_Value |          Collection_Value |   100 | 1,596.2 ns | 15.41 ns | 12.87 ns |  1.30 |    0.01 | 0.1450 |     - |     - |     304 B |
|          Hyperlinq_Collection_Value |          Collection_Value |   100 |   565.1 ns |  4.51 ns |  3.99 ns |  0.46 |    0.00 | 0.1640 |     - |     - |     344 B |
|                                     |                           |       |            |          |          |       |         |        |       |       |           |
|                     Linq_List_Value |                List_Value |   100 | 1,226.0 ns | 13.07 ns | 12.23 ns |  1.00 |    0.00 | 0.3510 |     - |     - |     736 B |
|               StructLinq_List_Value |                List_Value |   100 | 1,597.1 ns |  7.48 ns |  6.63 ns |  1.30 |    0.02 | 0.1450 |     - |     - |     304 B |
|                Hyperlinq_List_Value |                List_Value |   100 |   878.8 ns |  4.01 ns |  3.56 ns |  0.72 |    0.01 | 0.1640 |     - |     - |     344 B |
|                                     |                           |       |            |          |          |       |         |        |       |       |           |
|          Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 6,178.2 ns | 32.04 ns | 28.40 ns |  1.00 |    0.00 | 0.3586 |     - |     - |     752 B |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 6,157.7 ns | 43.34 ns | 40.54 ns |  1.00 |    0.01 | 0.3738 |     - |     - |     784 B |
|                                     |                           |       |            |          |          |       |         |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |   100 |   883.9 ns |  5.13 ns |  4.55 ns |  1.00 |    0.00 | 0.3519 |     - |     - |     736 B |
|     StructLinq_Enumerable_Reference |      Enumerable_Reference |   100 | 1,156.7 ns |  8.93 ns |  7.91 ns |  1.31 |    0.01 | 0.1450 |     - |     - |     304 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 | 1,009.0 ns |  8.42 ns |  7.88 ns |  1.14 |    0.01 | 0.1793 |     - |     - |     376 B |
|                                     |                           |       |            |          |          |       |         |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |   100 |   877.1 ns |  6.91 ns |  6.13 ns |  1.00 |    0.00 | 0.3519 |     - |     - |     736 B |
|     StructLinq_Collection_Reference |      Collection_Reference |   100 | 1,149.9 ns |  9.27 ns |  8.22 ns |  1.31 |    0.02 | 0.1450 |     - |     - |     304 B |
|      Hyperlinq_Collection_Reference |      Collection_Reference |   100 |   980.6 ns |  4.99 ns |  4.67 ns |  1.12 |    0.01 | 0.1793 |     - |     - |     376 B |
|                                     |                           |       |            |          |          |       |         |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |   100 |   886.4 ns |  8.67 ns |  8.11 ns |  1.00 |    0.00 | 0.3519 |     - |     - |     736 B |
|           StructLinq_List_Reference |            List_Reference |   100 | 1,158.5 ns | 10.71 ns |  9.49 ns |  1.31 |    0.01 | 0.1450 |     - |     - |     304 B |
|            Hyperlinq_List_Reference |            List_Reference |   100 |   911.0 ns |  6.12 ns |  5.72 ns |  1.03 |    0.01 | 0.1640 |     - |     - |     344 B |
|                                     |                           |       |            |          |          |       |         |        |       |       |           |
|      Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 6,102.6 ns | 32.77 ns | 30.65 ns |  1.00 |    0.00 | 0.3586 |     - |     - |     752 B |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 6,153.3 ns | 40.60 ns | 35.99 ns |  1.01 |    0.01 | 0.3815 |     - |     - |     800 B |
