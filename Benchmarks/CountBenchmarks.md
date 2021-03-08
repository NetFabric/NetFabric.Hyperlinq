## CountBenchmarks

### Source
[CountBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/CountBenchmarks.cs)

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
|                              Method |                Categories | Count |          Mean |     Error |    StdDev |  Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------ |-------------------------- |------ |--------------:|----------:|----------:|-------:|--------:|-------:|------:|------:|----------:|
|                          Linq_Array |                     Array |   100 |    10.1518 ns | 0.0942 ns | 0.0835 ns |   1.00 |    0.00 |      - |     - |     - |         - |
|                    StructLinq_Array |                     Array |   100 |     0.5890 ns | 0.0131 ns | 0.0123 ns |   0.06 |    0.00 |      - |     - |     - |         - |
|                     Hyperlinq_Array |                     Array |   100 |     7.7152 ns | 0.0200 ns | 0.0187 ns |   0.76 |    0.01 |      - |     - |     - |         - |
|                      Hyperlinq_Span |                     Array |   100 |     7.9371 ns | 0.0230 ns | 0.0192 ns |   0.78 |    0.01 |      - |     - |     - |         - |
|                    Hyperlinq_Memory |                     Array |   100 |    10.3814 ns | 0.0363 ns | 0.0339 ns |   1.02 |    0.01 |      - |     - |     - |         - |
|                                     |                           |       |               |           |           |        |         |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |   100 |   392.1758 ns | 1.6536 ns | 1.4659 ns |   1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
|         StructLinq_Enumerable_Value |          Enumerable_Value |   100 |   635.4958 ns | 3.6217 ns | 3.2106 ns |   1.62 |    0.01 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 |   143.7120 ns | 0.4822 ns | 0.4511 ns |   0.37 |    0.00 |      - |     - |     - |         - |
|                                     |                           |       |               |           |           |        |         |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |   100 |     4.8035 ns | 0.0205 ns | 0.0181 ns |   1.00 |    0.00 |      - |     - |     - |         - |
|         StructLinq_Collection_Value |          Collection_Value |   100 |   627.8127 ns | 2.7517 ns | 2.4393 ns | 130.70 |    0.70 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Collection_Value |          Collection_Value |   100 |     7.8100 ns | 0.0517 ns | 0.0483 ns |   1.63 |    0.01 |      - |     - |     - |         - |
|                                     |                           |       |               |           |           |        |         |        |       |       |           |
|                     Linq_List_Value |                List_Value |   100 |     5.6294 ns | 0.0570 ns | 0.0533 ns |   1.00 |    0.00 |      - |     - |     - |         - |
|               StructLinq_List_Value |                List_Value |   100 |     2.9041 ns | 0.0176 ns | 0.0156 ns |   0.52 |    0.01 |      - |     - |     - |         - |
|                Hyperlinq_List_Value |                List_Value |   100 |     1.6461 ns | 0.0100 ns | 0.0083 ns |   0.29 |    0.00 |      - |     - |     - |         - |
|                                     |                           |       |               |           |           |        |         |        |       |       |           |
|          Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 2,171.3863 ns | 7.6878 ns | 6.8150 ns |   1.00 |    0.00 | 0.0191 |     - |     - |      40 B |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 1,235.9539 ns | 5.1267 ns | 4.7955 ns |   0.57 |    0.00 |      - |     - |     - |         - |
|                                     |                           |       |               |           |           |        |         |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |   100 |   280.0900 ns | 1.2554 ns | 1.1129 ns |   1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
|     StructLinq_Enumerable_Reference |      Enumerable_Reference |   100 |   412.1112 ns | 2.8171 ns | 2.6351 ns |   1.47 |    0.01 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 |   273.4495 ns | 1.6148 ns | 1.5105 ns |   0.98 |    0.00 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |               |           |           |        |         |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |   100 |     4.8175 ns | 0.0294 ns | 0.0275 ns |   1.00 |    0.00 |      - |     - |     - |         - |
|     StructLinq_Collection_Reference |      Collection_Reference |   100 |   411.6299 ns | 1.9597 ns | 1.7372 ns |  85.40 |    0.47 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Collection_Reference |      Collection_Reference |   100 |     1.7081 ns | 0.0049 ns | 0.0041 ns |   0.35 |    0.00 |      - |     - |     - |         - |
|                                     |                           |       |               |           |           |        |         |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |   100 |     5.5922 ns | 0.0365 ns | 0.0323 ns |   1.00 |    0.00 |      - |     - |     - |         - |
|           StructLinq_List_Reference |            List_Reference |   100 |   412.1295 ns | 1.9588 ns | 1.7364 ns |  73.70 |    0.48 | 0.0153 |     - |     - |      32 B |
|            Hyperlinq_List_Reference |            List_Reference |   100 |     1.8975 ns | 0.0071 ns | 0.0063 ns |   0.34 |    0.00 |      - |     - |     - |         - |
|                                     |                           |       |               |           |           |        |         |        |       |       |           |
|      Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 2,040.4357 ns | 6.0523 ns | 5.6613 ns |   1.00 |    0.00 | 0.0191 |     - |     - |      40 B |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 1,876.6563 ns | 6.1977 ns | 5.7973 ns |   0.92 |    0.00 | 0.0191 |     - |     - |      40 B |
