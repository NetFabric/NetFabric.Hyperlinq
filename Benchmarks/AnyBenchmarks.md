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
  Job-SUCOWF : .NET 6.0.0 (6.0.21.25307), X64 RyuJIT

Runtime=.NET 6.0  

```
|                              Method |                Categories | Count |      Mean |     Error |    StdDev |    Median | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------ |-------------------------- |------ |----------:|----------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|                          Linq_Array |                     Array |   100 |  8.436 ns | 0.1408 ns | 0.1176 ns |  8.406 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|                     Hyperlinq_Array |                     Array |   100 |  7.380 ns | 0.0238 ns | 0.0223 ns |  7.380 ns |  0.88 |    0.01 |      - |     - |     - |         - |
|                                     |                           |       |           |           |           |           |       |         |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |   100 | 22.024 ns | 0.1236 ns | 0.1156 ns | 22.052 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 | 10.720 ns | 0.0205 ns | 0.0181 ns | 10.720 ns |  0.49 |    0.00 |      - |     - |     - |         - |
|                                     |                           |       |           |           |           |           |       |         |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |   100 |  4.119 ns | 0.0185 ns | 0.0173 ns |  4.116 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          Hyperlinq_Collection_Value |          Collection_Value |   100 |  8.241 ns | 0.0261 ns | 0.0245 ns |  8.247 ns |  2.00 |    0.01 |      - |     - |     - |         - |
|                                     |                           |       |           |           |           |           |       |         |        |       |       |           |
|                     Linq_List_Value |                List_Value |   100 |  5.525 ns | 0.0291 ns | 0.0258 ns |  5.520 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|                Hyperlinq_List_Value |                List_Value |   100 |  1.823 ns | 0.0178 ns | 0.0158 ns |  1.820 ns |  0.33 |    0.00 |      - |     - |     - |         - |
|                                     |                           |       |           |           |           |           |       |         |        |       |       |           |
|          Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 56.994 ns | 0.1735 ns | 0.1623 ns | 57.011 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 50.052 ns | 0.2120 ns | 0.1983 ns | 49.988 ns |  0.88 |    0.00 |      - |     - |     - |         - |
|                                     |                           |       |           |           |           |           |       |         |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |   100 | 20.335 ns | 0.2451 ns | 0.1914 ns | 20.339 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 | 13.766 ns | 0.0889 ns | 0.0788 ns | 13.778 ns |  0.68 |    0.01 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |           |           |           |           |       |         |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |   100 |  4.552 ns | 0.0522 ns | 0.0463 ns |  4.535 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|      Hyperlinq_Collection_Reference |      Collection_Reference |   100 |  1.825 ns | 0.0144 ns | 0.0135 ns |  1.830 ns |  0.40 |    0.00 |      - |     - |     - |         - |
|                                     |                           |       |           |           |           |           |       |         |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |   100 |  5.502 ns | 0.0440 ns | 0.0343 ns |  5.515 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq_List_Reference |            List_Reference |   100 |  1.567 ns | 0.0071 ns | 0.0063 ns |  1.568 ns |  0.28 |    0.00 |      - |     - |     - |         - |
|                                     |                           |       |           |           |           |           |       |         |        |       |       |           |
|      Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 58.054 ns | 0.6036 ns | 0.5646 ns | 57.922 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 55.955 ns | 1.1523 ns | 1.4983 ns | 56.983 ns |  0.95 |    0.02 | 0.0153 |     - |     - |      32 B |
