## ElementAtBenchmarks

### Source
[ElementAtBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/ElementAtBenchmarks.cs)

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
|                              Method |                Categories | Count |         Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------ |-------------------------- |------ |-------------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|                          Linq_Array |                     Array |   100 |    15.961 ns | 0.0914 ns | 0.0763 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|                     Hyperlinq_Array |                     Array |   100 |    12.948 ns | 0.0370 ns | 0.0328 ns |  0.81 |    0.01 |      - |     - |     - |         - |
|                                     |                           |       |              |           |           |       |         |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |   100 |   321.713 ns | 2.1199 ns | 1.8792 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 |   131.208 ns | 0.4962 ns | 0.4399 ns |  0.41 |    0.00 |      - |     - |     - |         - |
|                                     |                           |       |              |           |           |       |         |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |   100 |   316.246 ns | 0.8984 ns | 0.7014 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Collection_Value |          Collection_Value |   100 |   136.082 ns | 0.6140 ns | 0.5443 ns |  0.43 |    0.00 |      - |     - |     - |         - |
|                                     |                           |       |              |           |           |       |         |        |       |       |           |
|                     Linq_List_Value |                List_Value |   100 |     9.747 ns | 0.0391 ns | 0.0347 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|                Hyperlinq_List_Value |                List_Value |   100 |   341.010 ns | 1.4219 ns | 1.1874 ns | 34.98 |    0.16 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |              |           |           |       |         |        |       |       |           |
|          Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 1,617.668 ns | 4.8676 ns | 4.3150 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 |   804.608 ns | 3.9449 ns | 3.4970 ns |  0.50 |    0.00 |      - |     - |     - |         - |
|                                     |                           |       |              |           |           |       |         |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |   100 |   315.847 ns | 1.1479 ns | 1.0176 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 |   336.160 ns | 3.1605 ns | 2.9564 ns |  1.07 |    0.01 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |              |           |           |       |         |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |   100 |   316.810 ns | 1.5474 ns | 1.3718 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Collection_Reference |      Collection_Reference |   100 |   361.737 ns | 1.0627 ns | 0.9421 ns |  1.14 |    0.00 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |              |           |           |       |         |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |   100 |     9.761 ns | 0.0949 ns | 0.0842 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq_List_Reference |            List_Reference |   100 |   368.868 ns | 3.0067 ns | 2.6654 ns | 37.79 |    0.44 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |              |           |           |       |         |        |       |       |           |
|      Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 1,617.709 ns | 5.9396 ns | 4.9599 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 1,435.386 ns | 5.2823 ns | 4.6827 ns |  0.89 |    0.00 | 0.0153 |     - |     - |      32 B |
