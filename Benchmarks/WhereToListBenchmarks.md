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
|                          Linq_Array |                     Array |   100 |   375.1 ns |  5.55 ns |  9.28 ns |  1.00 |    0.00 | 0.3328 |     - |     - |     696 B |
|                    StructLinq_Array |                     Array |   100 |   410.1 ns |  1.43 ns |  1.27 ns |  1.09 |    0.03 | 0.1297 |     - |     - |     272 B |
|                     Hyperlinq_Array |                     Array |   100 |   456.5 ns |  2.38 ns |  1.99 ns |  1.22 |    0.03 | 0.1297 |     - |     - |     272 B |
|                                     |                           |       |            |          |          |       |         |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |   100 | 1,153.2 ns | 11.58 ns | 10.83 ns |  1.00 |    0.00 | 0.3510 |     - |     - |     736 B |
|         StructLinq_Enumerable_Value |          Enumerable_Value |   100 | 1,253.5 ns |  4.78 ns |  4.47 ns |  1.09 |    0.01 | 0.1450 |     - |     - |     304 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 |   498.4 ns |  1.37 ns |  1.14 ns |  0.43 |    0.00 | 0.1297 |     - |     - |     272 B |
|                                     |                           |       |            |          |          |       |         |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |   100 | 1,149.2 ns |  3.76 ns |  3.33 ns |  1.00 |    0.00 | 0.3510 |     - |     - |     736 B |
|         StructLinq_Collection_Value |          Collection_Value |   100 | 1,246.2 ns |  4.17 ns |  3.69 ns |  1.08 |    0.00 | 0.1450 |     - |     - |     304 B |
|          Hyperlinq_Collection_Value |          Collection_Value |   100 |   534.1 ns |  1.21 ns |  1.14 ns |  0.46 |    0.00 | 0.1297 |     - |     - |     272 B |
|                                     |                           |       |            |          |          |       |         |        |       |       |           |
|                     Linq_List_Value |                List_Value |   100 | 1,146.6 ns |  2.95 ns |  2.76 ns |  1.00 |    0.00 | 0.3510 |     - |     - |     736 B |
|               StructLinq_List_Value |                List_Value |   100 |   784.8 ns |  1.36 ns |  1.27 ns |  0.68 |    0.00 | 0.1297 |     - |     - |     272 B |
|                Hyperlinq_List_Value |                List_Value |   100 | 1,191.6 ns |  3.49 ns |  3.10 ns |  1.04 |    0.00 | 0.1297 |     - |     - |     272 B |
|                                     |                           |       |            |          |          |       |         |        |       |       |           |
|          Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 6,752.4 ns | 10.63 ns |  9.95 ns |  1.00 |    0.00 | 0.3586 |     - |     - |     752 B |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 3,836.1 ns |  5.23 ns |  4.37 ns |  0.57 |    0.00 | 0.3586 |     - |     - |     752 B |
|                                     |                           |       |            |          |          |       |         |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |   100 |   765.5 ns |  8.02 ns |  7.11 ns |  1.00 |    0.00 | 0.3519 |     - |     - |     736 B |
|     StructLinq_Enumerable_Reference |      Enumerable_Reference |   100 |   823.5 ns |  3.46 ns |  3.24 ns |  1.08 |    0.01 | 0.1450 |     - |     - |     304 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 |   882.2 ns |  2.51 ns |  2.35 ns |  1.15 |    0.01 | 0.1450 |     - |     - |     304 B |
|                                     |                           |       |            |          |          |       |         |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |   100 |   752.3 ns |  4.44 ns |  4.16 ns |  1.00 |    0.00 | 0.3519 |     - |     - |     736 B |
|     StructLinq_Collection_Reference |      Collection_Reference |   100 |   824.1 ns |  2.11 ns |  1.76 ns |  1.09 |    0.01 | 0.1450 |     - |     - |     304 B |
|      Hyperlinq_Collection_Reference |      Collection_Reference |   100 |   899.8 ns |  6.27 ns |  5.56 ns |  1.20 |    0.01 | 0.1450 |     - |     - |     304 B |
|                                     |                           |       |            |          |          |       |         |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |   100 |   859.6 ns |  3.99 ns |  3.74 ns |  1.00 |    0.00 | 0.3519 |     - |     - |     736 B |
|           StructLinq_List_Reference |            List_Reference |   100 |   818.0 ns |  2.88 ns |  2.56 ns |  0.95 |    0.00 | 0.1450 |     - |     - |     304 B |
|            Hyperlinq_List_Reference |            List_Reference |   100 | 1,178.0 ns |  2.29 ns |  2.03 ns |  1.37 |    0.01 | 0.1297 |     - |     - |     272 B |
|                                     |                           |       |            |          |          |       |         |        |       |       |           |
|      Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 5,754.1 ns | 27.70 ns | 25.91 ns |  1.00 |    0.00 | 0.3586 |     - |     - |     752 B |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 4,324.2 ns |  6.54 ns |  5.80 ns |  0.75 |    0.00 | 0.3738 |     - |     - |     792 B |
