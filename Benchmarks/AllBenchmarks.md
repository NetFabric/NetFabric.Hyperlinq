## AllBenchmarks

### Source
[AllBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/AllBenchmarks.cs)

### References:
- Linq: 6.0.0-preview.4.21253.7
- System.Linq.Async: [5.0.0](https://www.nuget.org/packages/System.Linq.Async/5.0.0)
- System.Interactive: [5.0.0](https://www.nuget.org/packages/System.Interactive/5.0.0)
- System.Interactive.Async: [5.0.0](https://www.nuget.org/packages/System.Interactive.Async/5.0.0)
- StructLinq: [0.26.0](https://www.nuget.org/packages/StructLinq/0.26.0)
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)

### Results:
``` ini

BenchmarkDotNet=v0.13.0.1555-nightly, OS=Windows 10.0.19043.1023 (21H1/May2021Update)
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.4.21255.9
  [Host]     : .NET 6.0.0 (6.0.21.25307), X64 RyuJIT
  Job-FXRHUT : .NET 6.0.0 (6.0.21.25307), X64 RyuJIT

Runtime=.NET 6.0  

```
|                              Method |                Categories | Count |       Mean |   Error |  StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------ |-------------------------- |------ |-----------:|--------:|--------:|------:|-------:|------:|------:|----------:|
|                          Linq_Array |                     Array |   100 |   572.2 ns | 1.87 ns | 1.75 ns |  1.00 | 0.0153 |     - |     - |      32 B |
|                     Hyperlinq_Array |                     Array |   100 |   192.5 ns | 0.42 ns | 0.32 ns |  0.34 |      - |     - |     - |         - |
|                                     |                           |       |            |         |         |       |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |   100 |   747.7 ns | 3.46 ns | 3.23 ns |  1.00 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 |   251.7 ns | 2.46 ns | 2.06 ns |  0.34 |      - |     - |     - |         - |
|                                     |                           |       |            |         |         |       |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |   100 |   718.6 ns | 2.04 ns | 1.70 ns |  1.00 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Collection_Value |          Collection_Value |   100 |   227.8 ns | 1.26 ns | 0.98 ns |  0.32 |      - |     - |     - |         - |
|                                     |                           |       |            |         |         |       |        |       |       |           |
|                     Linq_List_Value |                List_Value |   100 |   748.4 ns | 2.83 ns | 2.65 ns |  1.00 | 0.0153 |     - |     - |      32 B |
|                Hyperlinq_List_Value |                List_Value |   100 |   800.2 ns | 3.46 ns | 3.06 ns |  1.07 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |            |         |         |       |        |       |       |           |
|          Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 1,704.2 ns | 4.02 ns | 3.76 ns |  1.00 | 0.0153 |     - |     - |      32 B |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 |   246.4 ns | 0.99 ns | 0.93 ns |  0.14 |      - |     - |     - |         - |
|                                     |                           |       |            |         |         |       |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |   100 |   796.2 ns | 4.19 ns | 3.27 ns |  1.00 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 |   752.0 ns | 3.58 ns | 2.80 ns |  0.94 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |            |         |         |       |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |   100 |   769.8 ns | 2.45 ns | 2.29 ns |  1.00 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Collection_Reference |      Collection_Reference |   100 |   777.8 ns | 2.36 ns | 2.21 ns |  1.01 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |            |         |         |       |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |   100 |   768.8 ns | 2.81 ns | 2.63 ns |  1.00 | 0.0153 |     - |     - |      32 B |
|            Hyperlinq_List_Reference |            List_Reference |   100 |   727.3 ns | 2.27 ns | 1.89 ns |  0.95 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |            |         |         |       |        |       |       |           |
|      Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 1,706.0 ns | 6.93 ns | 5.79 ns |  1.00 | 0.0153 |     - |     - |      32 B |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 |   278.3 ns | 4.39 ns | 3.43 ns |  0.16 | 0.0153 |     - |     - |      32 B |
