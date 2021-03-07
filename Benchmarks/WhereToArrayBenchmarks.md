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
|                          Linq_Array |                     Array |   100 |   421.4 ns |  1.05 ns |  0.93 ns |  1.00 | 0.3519 |     - |     - |     736 B |
|                    StructLinq_Array |                     Array |   100 |   408.2 ns |  1.56 ns |  1.38 ns |  0.97 | 0.1144 |     - |     - |     240 B |
|                     Hyperlinq_Array |                     Array |   100 |   468.4 ns |  1.53 ns |  1.43 ns |  1.11 | 0.1144 |     - |     - |     240 B |
|                      Hyperlinq_Span |                     Array |   100 |   447.7 ns |  2.24 ns |  1.99 ns |  1.06 | 0.1144 |     - |     - |     240 B |
|                    Hyperlinq_Memory |                     Array |   100 |   487.0 ns |  1.39 ns |  1.16 ns |  1.16 | 0.1144 |     - |     - |     240 B |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |   100 | 1,205.2 ns |  5.07 ns |  4.49 ns |  1.00 | 0.3700 |     - |     - |     776 B |
|         StructLinq_Enumerable_Value |          Enumerable_Value |   100 | 1,192.5 ns |  4.86 ns |  4.06 ns |  0.99 | 0.1297 |     - |     - |     272 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 |   499.6 ns |  2.27 ns |  2.12 ns |  0.41 | 0.1144 |     - |     - |     240 B |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |   100 | 1,217.5 ns |  7.57 ns |  6.71 ns |  1.00 | 0.3700 |     - |     - |     776 B |
|         StructLinq_Collection_Value |          Collection_Value |   100 | 1,230.8 ns |  4.90 ns |  4.59 ns |  1.01 | 0.1297 |     - |     - |     272 B |
|          Hyperlinq_Collection_Value |          Collection_Value |   100 |   553.5 ns |  2.11 ns |  1.76 ns |  0.45 | 0.1144 |     - |     - |     240 B |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|                     Linq_List_Value |                List_Value |   100 | 1,271.3 ns |  5.94 ns |  5.56 ns |  1.00 | 0.3681 |     - |     - |     776 B |
|               StructLinq_List_Value |                List_Value |   100 |   816.3 ns |  2.10 ns |  1.86 ns |  0.64 | 0.1144 |     - |     - |     240 B |
|                Hyperlinq_List_Value |                List_Value |   100 | 1,194.0 ns |  1.94 ns |  1.82 ns |  0.94 | 0.1144 |     - |     - |     240 B |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|          Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 6,142.0 ns | 19.97 ns | 16.68 ns |  1.00 | 0.4578 |     - |     - |     960 B |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 6,246.3 ns | 16.04 ns | 14.22 ns |  1.02 | 0.4730 |     - |     - |     992 B |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |   100 |   829.6 ns |  2.34 ns |  2.07 ns |  1.00 | 0.3710 |     - |     - |     776 B |
|     StructLinq_Enumerable_Reference |      Enumerable_Reference |   100 |   787.4 ns |  3.24 ns |  2.53 ns |  0.95 | 0.1297 |     - |     - |     272 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 |   884.2 ns |  2.34 ns |  1.95 ns |  1.07 | 0.1297 |     - |     - |     272 B |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |   100 |   809.0 ns |  2.88 ns |  2.55 ns |  1.00 | 0.3710 |     - |     - |     776 B |
|     StructLinq_Collection_Reference |      Collection_Reference |   100 |   854.7 ns |  2.53 ns |  2.24 ns |  1.06 | 0.1297 |     - |     - |     272 B |
|      Hyperlinq_Collection_Reference |      Collection_Reference |   100 |   928.9 ns |  3.74 ns |  3.32 ns |  1.15 | 0.1297 |     - |     - |     272 B |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |   100 |   815.1 ns |  4.22 ns |  3.74 ns |  1.00 | 0.3710 |     - |     - |     776 B |
|           StructLinq_List_Reference |            List_Reference |   100 |   849.7 ns |  2.36 ns |  2.21 ns |  1.04 | 0.1297 |     - |     - |     272 B |
|            Hyperlinq_List_Reference |            List_Reference |   100 | 1,234.8 ns |  3.27 ns |  2.90 ns |  1.52 | 0.1144 |     - |     - |     240 B |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|      Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 6,057.1 ns | 13.82 ns | 12.25 ns |  1.00 | 0.4578 |     - |     - |     960 B |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 6,093.1 ns | 16.58 ns | 14.69 ns |  1.01 | 0.4807 |     - |     - |    1008 B |
