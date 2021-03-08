## WhereToArrayBenchmarks

### Source
[WhereToArrayBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/WhereToArrayBenchmarks.cs)

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
|                          Linq_Array |                     Array |   100 |   422.3 ns |  1.36 ns |  1.20 ns |  1.00 | 0.3519 |     - |     - |     736 B |
|                    StructLinq_Array |                     Array |   100 |   382.9 ns |  1.39 ns |  1.30 ns |  0.91 | 0.1144 |     - |     - |     240 B |
|                     Hyperlinq_Array |                     Array |   100 |   493.0 ns |  3.14 ns |  2.78 ns |  1.17 | 0.1144 |     - |     - |     240 B |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |   100 | 1,224.2 ns |  8.59 ns |  7.17 ns |  1.00 | 0.3700 |     - |     - |     776 B |
|         StructLinq_Enumerable_Value |          Enumerable_Value |   100 | 1,209.0 ns |  2.97 ns |  2.32 ns |  0.99 | 0.1297 |     - |     - |     272 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 |   539.5 ns |  2.89 ns |  2.71 ns |  0.44 | 0.1144 |     - |     - |     240 B |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |   100 | 1,210.4 ns |  7.42 ns |  6.94 ns |  1.00 | 0.3700 |     - |     - |     776 B |
|         StructLinq_Collection_Value |          Collection_Value |   100 | 1,205.9 ns |  4.23 ns |  3.96 ns |  1.00 | 0.1297 |     - |     - |     272 B |
|          Hyperlinq_Collection_Value |          Collection_Value |   100 |   522.0 ns |  1.40 ns |  1.24 ns |  0.43 | 0.1144 |     - |     - |     240 B |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|                     Linq_List_Value |                List_Value |   100 | 1,234.6 ns |  2.62 ns |  2.19 ns |  1.00 | 0.3700 |     - |     - |     776 B |
|               StructLinq_List_Value |                List_Value |   100 |   746.1 ns |  1.91 ns |  1.59 ns |  0.60 | 0.1144 |     - |     - |     240 B |
|                Hyperlinq_List_Value |                List_Value |   100 | 1,187.8 ns |  2.97 ns |  2.48 ns |  0.96 | 0.1144 |     - |     - |     240 B |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|          Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 5,969.1 ns | 13.03 ns | 12.19 ns |  1.00 | 0.4578 |     - |     - |     960 B |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 3,744.0 ns |  6.22 ns |  5.82 ns |  0.63 | 0.3433 |     - |     - |     720 B |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |   100 |   799.8 ns |  7.74 ns |  6.86 ns |  1.00 | 0.3710 |     - |     - |     776 B |
|     StructLinq_Enumerable_Reference |      Enumerable_Reference |   100 |   820.6 ns |  4.80 ns |  4.01 ns |  1.03 | 0.1297 |     - |     - |     272 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 |   902.3 ns |  2.42 ns |  2.27 ns |  1.13 | 0.1297 |     - |     - |     272 B |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |   100 |   824.0 ns | 10.71 ns | 10.02 ns |  1.00 | 0.3710 |     - |     - |     776 B |
|     StructLinq_Collection_Reference |      Collection_Reference |   100 |   800.1 ns |  2.62 ns |  2.32 ns |  0.97 | 0.1297 |     - |     - |     272 B |
|      Hyperlinq_Collection_Reference |      Collection_Reference |   100 |   895.4 ns |  1.71 ns |  1.60 ns |  1.09 | 0.1297 |     - |     - |     272 B |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |   100 |   786.8 ns |  3.06 ns |  2.56 ns |  1.00 | 0.3710 |     - |     - |     776 B |
|           StructLinq_List_Reference |            List_Reference |   100 |   803.5 ns |  2.77 ns |  2.16 ns |  1.02 | 0.1297 |     - |     - |     272 B |
|            Hyperlinq_List_Reference |            List_Reference |   100 | 1,148.8 ns |  2.14 ns |  2.01 ns |  1.46 | 0.1144 |     - |     - |     240 B |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|      Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 5,849.0 ns | 16.69 ns | 15.61 ns |  1.00 | 0.4578 |     - |     - |     960 B |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 4,270.8 ns |  7.87 ns |  7.36 ns |  0.73 | 0.3586 |     - |     - |     760 B |
