## AnyPredicateBenchmarks

### Source
[AnyPredicateBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/AnyPredicateBenchmarks.cs)

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
|                              Method |                Categories | Count |        Mean |    Error |   StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------ |-------------------------- |------ |------------:|---------:|---------:|------:|-------:|------:|------:|----------:|
|                          Linq_Array |                     Array |   100 |   543.31 ns | 2.697 ns | 2.522 ns |  1.00 | 0.0153 |     - |     - |      32 B |
|                     Hyperlinq_Array |                     Array |   100 |   168.72 ns | 0.710 ns | 0.630 ns |  0.31 |      - |     - |     - |         - |
|                                     |                           |       |             |          |          |       |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |   100 |   786.29 ns | 5.005 ns | 4.437 ns |  1.00 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 |   252.75 ns | 1.126 ns | 1.053 ns |  0.32 |      - |     - |     - |         - |
|                                     |                           |       |             |          |          |       |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |   100 |   781.50 ns | 5.224 ns | 4.362 ns |  1.00 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Collection_Value |          Collection_Value |   100 |   255.94 ns | 1.076 ns | 1.006 ns |  0.33 |      - |     - |     - |         - |
|                                     |                           |       |             |          |          |       |        |       |       |           |
|                     Linq_List_Value |                List_Value |   100 |   781.62 ns | 6.332 ns | 5.287 ns |  1.00 | 0.0153 |     - |     - |      32 B |
|                Hyperlinq_List_Value |                List_Value |   100 |   782.55 ns | 2.793 ns | 2.476 ns |  1.00 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |             |          |          |       |        |       |       |           |
|          Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 1,715.16 ns | 3.292 ns | 2.918 ns |  1.00 | 0.0153 |     - |     - |      32 B |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 |    76.40 ns | 0.203 ns | 0.180 ns |  0.04 |      - |     - |     - |         - |
|                                     |                           |       |             |          |          |       |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |   100 |   782.33 ns | 5.113 ns | 4.270 ns |  1.00 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 |   739.43 ns | 3.734 ns | 3.310 ns |  0.95 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |             |          |          |       |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |   100 |   732.78 ns | 3.178 ns | 2.654 ns |  1.00 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Collection_Reference |      Collection_Reference |   100 |   781.34 ns | 2.436 ns | 2.159 ns |  1.07 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |             |          |          |       |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |   100 |   734.11 ns | 2.595 ns | 2.300 ns |  1.00 | 0.0153 |     - |     - |      32 B |
|            Hyperlinq_List_Reference |            List_Reference |   100 |   740.49 ns | 3.347 ns | 2.967 ns |  1.01 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |             |          |          |       |        |       |       |           |
|      Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 1,716.97 ns | 4.259 ns | 3.776 ns |  1.00 | 0.0153 |     - |     - |      32 B |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 |    77.91 ns | 0.321 ns | 0.284 ns |  0.05 | 0.0153 |     - |     - |      32 B |
