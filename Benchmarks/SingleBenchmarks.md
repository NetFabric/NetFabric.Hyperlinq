## SingleBenchmarks

### Source
[SingleBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/SingleBenchmarks.cs)

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
|                         Method |                Categories |      Mean |     Error |    StdDev |    Median | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------- |-------------------------- |----------:|----------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|                     Linq_Array |                     Array | 12.902 ns | 0.0570 ns | 0.0505 ns | 12.905 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|                Hyperlinq_Array |                     Array | 14.553 ns | 0.0493 ns | 0.0412 ns | 14.552 ns |  1.13 |    0.01 |      - |     - |     - |         - |
|                                |                           |           |           |           |           |       |         |        |       |       |           |
|          Linq_Enumerable_Value |          Enumerable_Value | 26.178 ns | 0.1226 ns | 0.1024 ns | 26.166 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
|     Hyperlinq_Enumerable_Value |          Enumerable_Value | 16.540 ns | 0.0497 ns | 0.0441 ns | 16.537 ns |  0.63 |    0.00 |      - |     - |     - |         - |
|                                |                           |           |           |           |           |       |         |        |       |       |           |
|          Linq_Collection_Value |          Collection_Value | 25.996 ns | 0.1079 ns | 0.0901 ns | 26.006 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
|     Hyperlinq_Collection_Value |          Collection_Value | 19.269 ns | 0.0717 ns | 0.0671 ns | 19.274 ns |  0.74 |    0.00 |      - |     - |     - |         - |
|                                |                           |           |           |           |           |       |         |        |       |       |           |
|                Linq_List_Value |                List_Value |  8.465 ns | 0.0502 ns | 0.0445 ns |  8.468 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|           Hyperlinq_List_Value |                List_Value | 21.993 ns | 0.1262 ns | 0.1054 ns | 21.981 ns |  2.60 |    0.02 | 0.0153 |     - |     - |      32 B |
|                                |                           |           |           |           |           |       |         |        |       |       |           |
|     Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value | 76.277 ns | 0.2799 ns | 0.2481 ns | 76.248 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
|                                |                           |           |           |           |           |       |         |        |       |       |           |
|      Linq_Enumerable_Reference |      Enumerable_Reference | 26.102 ns | 0.1026 ns | 0.0910 ns | 26.136 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
| Hyperlinq_Enumerable_Reference |      Enumerable_Reference | 21.601 ns | 0.4574 ns | 0.6560 ns | 21.870 ns |  0.81 |    0.03 | 0.0153 |     - |     - |      32 B |
|                                |                           |           |           |           |           |       |         |        |       |       |           |
|      Linq_Collection_Reference |      Collection_Reference | 27.082 ns | 0.5695 ns | 0.9975 ns | 27.757 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
| Hyperlinq_Collection_Reference |      Collection_Reference | 18.833 ns | 0.1737 ns | 0.1625 ns | 18.805 ns |  0.69 |    0.02 | 0.0153 |     - |     - |      32 B |
|                                |                           |           |           |           |           |       |         |        |       |       |           |
|            Linq_List_Reference |            List_Reference |  8.446 ns | 0.0465 ns | 0.0413 ns |  8.435 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|       Hyperlinq_List_Reference |            List_Reference | 22.542 ns | 0.1073 ns | 0.0951 ns | 22.514 ns |  2.67 |    0.02 | 0.0153 |     - |     - |      32 B |
|                                |                           |           |           |           |           |       |         |        |       |       |           |
| Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference | 76.279 ns | 1.5123 ns | 1.6810 ns | 76.028 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
