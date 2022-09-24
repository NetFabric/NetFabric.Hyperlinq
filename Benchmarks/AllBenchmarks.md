﻿## AllBenchmarks

### Source
[AllBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/AllBenchmarks.cs)

### References:
- Linq: 6.0.0-preview.5.21301.5
- System.Linq.Async: [5.0.0](https://www.nuget.org/packages/System.Linq.Async/5.0.0)
- System.Interactive: [5.0.0](https://www.nuget.org/packages/System.Interactive/5.0.0)
- System.Interactive.Async: [5.0.0](https://www.nuget.org/packages/System.Interactive.Async/5.0.0)
- StructLinq: [0.26.0](https://www.nuget.org/packages/StructLinq/0.26.0)
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)

### Results:
``` ini

BenchmarkDotNet=v0.13.0.1555-nightly, OS=Windows 10.0.19043.1055 (21H1/May2021Update)
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.5.21302.13
  [Host]     : .NET 6.0.0 (6.0.21.30105), X64 RyuJIT
  Job-UNTOJZ : .NET 6.0.0 (6.0.21.30105), X64 RyuJIT

Runtime=.NET 6.0  

```
|                              Method |                Categories | Count |       Mean |   Error |  StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------ |-------------------------- |------ |-----------:|--------:|--------:|------:|-------:|------:|------:|----------:|
|                          Linq_Array |                     Array |   100 |   594.4 ns | 2.87 ns | 2.24 ns |  1.00 | 0.0153 |     - |     - |      32 B |
|                     Hyperlinq_Array |                     Array |   100 |   193.1 ns | 0.79 ns | 0.66 ns |  0.32 |      - |     - |     - |         - |
|                                     |                           |       |            |         |         |       |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |   100 |   778.5 ns | 2.27 ns | 1.77 ns |  1.00 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 |   226.0 ns | 1.07 ns | 0.95 ns |  0.29 |      - |     - |     - |         - |
|                                     |                           |       |            |         |         |       |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |   100 |   792.8 ns | 3.27 ns | 2.73 ns |  1.00 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Collection_Value |          Collection_Value |   100 |   228.5 ns | 1.08 ns | 1.01 ns |  0.29 |      - |     - |     - |         - |
|                                     |                           |       |            |         |         |       |        |       |       |           |
|                     Linq_List_Value |                List_Value |   100 |   795.6 ns | 3.95 ns | 3.69 ns |  1.00 | 0.0153 |     - |     - |      32 B |
|                Hyperlinq_List_Value |                List_Value |   100 |   783.9 ns | 8.51 ns | 7.10 ns |  0.99 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |            |         |         |       |        |       |       |           |
|          Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 1,713.6 ns | 7.04 ns | 5.88 ns |  1.00 | 0.0153 |     - |     - |      32 B |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 |   248.1 ns | 1.01 ns | 0.95 ns |  0.14 |      - |     - |     - |         - |
|                                     |                           |       |            |         |         |       |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |   100 |   787.9 ns | 3.26 ns | 2.89 ns |  1.00 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 |   779.3 ns | 6.61 ns | 5.86 ns |  0.99 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |            |         |         |       |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |   100 |   746.7 ns | 2.31 ns | 2.16 ns |  1.00 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Collection_Reference |      Collection_Reference |   100 |   806.8 ns | 3.82 ns | 3.19 ns |  1.08 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |            |         |         |       |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |   100 |   749.4 ns | 5.37 ns | 4.49 ns |  1.00 | 0.0153 |     - |     - |      32 B |
|            Hyperlinq_List_Reference |            List_Reference |   100 |   728.0 ns | 1.89 ns | 1.58 ns |  0.97 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |            |         |         |       |        |       |       |           |
|      Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 1,712.4 ns | 6.90 ns | 6.45 ns |  1.00 | 0.0153 |     - |     - |      32 B |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 |   296.8 ns | 5.57 ns | 4.94 ns |  0.17 | 0.0153 |     - |     - |      32 B |
