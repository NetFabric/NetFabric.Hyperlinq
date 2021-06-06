## AnyBenchmarks

### Source
[AnyBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/AnyBenchmarks.cs)

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
|                              Method |                Categories | Count |      Mean |     Error |    StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------ |-------------------------- |------ |----------:|----------:|----------:|------:|-------:|------:|------:|----------:|
|                          Linq_Array |                     Array |   100 |  9.590 ns | 0.0432 ns | 0.0404 ns |  1.00 |      - |     - |     - |         - |
|                     Hyperlinq_Array |                     Array |   100 |  7.353 ns | 0.0171 ns | 0.0151 ns |  0.77 |      - |     - |     - |         - |
|                                     |                           |       |           |           |           |       |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |   100 | 21.520 ns | 0.0869 ns | 0.0770 ns |  1.00 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 | 10.790 ns | 0.0148 ns | 0.0131 ns |  0.50 |      - |     - |     - |         - |
|                                     |                           |       |           |           |           |       |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |   100 |  4.489 ns | 0.0273 ns | 0.0242 ns |  1.00 |      - |     - |     - |         - |
|          Hyperlinq_Collection_Value |          Collection_Value |   100 |  8.174 ns | 0.0188 ns | 0.0157 ns |  1.82 |      - |     - |     - |         - |
|                                     |                           |       |           |           |           |       |        |       |       |           |
|                     Linq_List_Value |                List_Value |   100 |  5.502 ns | 0.0280 ns | 0.0262 ns |  1.00 |      - |     - |     - |         - |
|                Hyperlinq_List_Value |                List_Value |   100 |  1.805 ns | 0.0116 ns | 0.0109 ns |  0.33 |      - |     - |     - |         - |
|                                     |                           |       |           |           |           |       |        |       |       |           |
|          Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 57.348 ns | 0.1576 ns | 0.1231 ns |  1.00 | 0.0153 |     - |     - |      32 B |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 49.700 ns | 0.1463 ns | 0.1368 ns |  0.87 |      - |     - |     - |         - |
|                                     |                           |       |           |           |           |       |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |   100 | 20.285 ns | 0.1133 ns | 0.1060 ns |  1.00 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 | 13.271 ns | 0.0641 ns | 0.0600 ns |  0.65 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |           |           |           |       |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |   100 |  4.150 ns | 0.0274 ns | 0.0256 ns |  1.00 |      - |     - |     - |         - |
|      Hyperlinq_Collection_Reference |      Collection_Reference |   100 |  1.805 ns | 0.0103 ns | 0.0086 ns |  0.44 |      - |     - |     - |         - |
|                                     |                           |       |           |           |           |       |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |   100 |  5.473 ns | 0.0289 ns | 0.0241 ns |  1.00 |      - |     - |     - |         - |
|            Hyperlinq_List_Reference |            List_Reference |   100 |  1.554 ns | 0.0097 ns | 0.0076 ns |  0.28 |      - |     - |     - |         - |
|                                     |                           |       |           |           |           |       |        |       |       |           |
|      Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 56.307 ns | 0.1674 ns | 0.1398 ns |  1.00 | 0.0153 |     - |     - |      32 B |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 53.848 ns | 0.1764 ns | 0.1650 ns |  0.96 | 0.0153 |     - |     - |      32 B |
