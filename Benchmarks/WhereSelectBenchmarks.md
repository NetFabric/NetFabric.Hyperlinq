## WhereSelectBenchmarks

### Source
[WhereSelectBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/WhereSelectBenchmarks.cs)

### References:
- Linq: 6.0.0-preview.2.21154.6
- System.Linq.Async: [5.0.0](https://www.nuget.org/packages/System.Linq.Async/5.0.0)
- System.Interactive: [5.0.0](https://www.nuget.org/packages/System.Interactive/5.0.0)
- System.Interactive.Async: [5.0.0](https://www.nuget.org/packages/System.Interactive.Async/5.0.0)
- StructLinq: [0.25.3](https://www.nuget.org/packages/StructLinq/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)

### Results:
``` ini

BenchmarkDotNet=v0.12.1.1521-nightly, OS=Windows 10.0.19043
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.2.21155.3
  [Host]     : .NET 6.0.0 (6.0.21.15406), X64 RyuJIT
  Job-XHOKQA : .NET 6.0.0 (6.0.21.15406), X64 RyuJIT

Runtime=.NET 6.0  

```
|                              Method |                Categories | Count |       Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------ |-------------------------- |------ |-----------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|                          Linq_Array |                     Array |   100 |   699.0 ns |   8.31 ns |   7.37 ns |  1.00 |    0.00 | 0.0496 |     - |     - |     104 B |
|                    StructLinq_Array |                     Array |   100 |   354.4 ns |   1.18 ns |   1.05 ns |  0.51 |    0.01 |      - |     - |     - |         - |
|                     Hyperlinq_Array |                     Array |   100 |   376.4 ns |   2.92 ns |   2.58 ns |  0.54 |    0.01 |      - |     - |     - |         - |
|                      Hyperlinq_Span |                     Array |   100 |   370.5 ns |   2.20 ns |   1.95 ns |  0.53 |    0.01 |      - |     - |     - |         - |
|                    Hyperlinq_Memory |                     Array |   100 |   389.2 ns |   1.10 ns |   0.97 ns |  0.56 |    0.01 |      - |     - |     - |         - |
|                                     |                           |       |            |           |           |       |         |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |   100 | 1,565.5 ns |   5.14 ns |   4.02 ns |  1.00 |    0.00 | 0.0725 |     - |     - |     152 B |
|         StructLinq_Enumerable_Value |          Enumerable_Value |   100 | 1,397.1 ns |   7.10 ns |   6.29 ns |  0.89 |    0.00 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 |   360.3 ns |   0.96 ns |   0.75 ns |  0.23 |    0.00 |      - |     - |     - |         - |
|                                     |                           |       |            |           |           |       |         |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |   100 | 1,606.3 ns |  24.27 ns |  18.95 ns |  1.00 |    0.00 | 0.0725 |     - |     - |     152 B |
|         StructLinq_Collection_Value |          Collection_Value |   100 | 1,331.4 ns |   7.65 ns |   6.78 ns |  0.83 |    0.01 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Collection_Value |          Collection_Value |   100 |   388.9 ns |   7.71 ns |  14.85 ns |  0.24 |    0.01 |      - |     - |     - |         - |
|                                     |                           |       |            |           |           |       |         |        |       |       |           |
|                     Linq_List_Value |                List_Value |   100 | 1,587.1 ns |  28.89 ns |  22.56 ns |  1.00 |    0.00 | 0.0725 |     - |     - |     152 B |
|               StructLinq_List_Value |                List_Value |   100 |   805.4 ns |   3.80 ns |   2.97 ns |  0.51 |    0.01 |      - |     - |     - |         - |
|                Hyperlinq_List_Value |                List_Value |   100 |   777.0 ns |  11.53 ns |  14.15 ns |  0.49 |    0.01 |      - |     - |     - |         - |
|                                     |                           |       |            |           |           |       |         |        |       |       |           |
|          Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 4,871.2 ns |  62.58 ns |  55.47 ns |  1.00 |    0.00 | 0.0763 |     - |     - |     168 B |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 5,789.1 ns |  51.25 ns |  47.94 ns |  1.19 |    0.01 |      - |     - |     - |         - |
|                                     |                           |       |            |           |           |       |         |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |   100 | 1,565.6 ns |   6.76 ns |   5.99 ns |  1.00 |    0.00 | 0.0725 |     - |     - |     152 B |
|     StructLinq_Enumerable_Reference |      Enumerable_Reference |   100 | 1,345.7 ns |  17.99 ns |  25.80 ns |  0.86 |    0.02 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 | 1,301.5 ns |  25.08 ns |  31.72 ns |  0.83 |    0.02 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |            |           |           |       |         |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |   100 | 1,561.5 ns |   5.99 ns |   5.31 ns |  1.00 |    0.00 | 0.0725 |     - |     - |     152 B |
|     StructLinq_Collection_Reference |      Collection_Reference |   100 | 1,395.4 ns |   4.25 ns |   3.98 ns |  0.89 |    0.00 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Collection_Reference |      Collection_Reference |   100 | 1,278.9 ns |   5.40 ns |   5.05 ns |  0.82 |    0.00 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |            |           |           |       |         |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |   100 | 1,556.2 ns |  15.73 ns |  12.28 ns |  1.00 |    0.00 | 0.0725 |     - |     - |     152 B |
|           StructLinq_List_Reference |            List_Reference |   100 | 1,327.4 ns |   5.37 ns |   4.48 ns |  0.85 |    0.01 | 0.0153 |     - |     - |      32 B |
|            Hyperlinq_List_Reference |            List_Reference |   100 |   783.5 ns |   3.26 ns |   3.05 ns |  0.50 |    0.00 |      - |     - |     - |         - |
|                                     |                           |       |            |           |           |       |         |        |       |       |           |
|      Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 5,026.8 ns | 100.49 ns | 181.20 ns |  1.00 |    0.00 | 0.0763 |     - |     - |     168 B |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 5,829.7 ns |  16.69 ns |  14.80 ns |  1.13 |    0.05 | 0.0153 |     - |     - |      32 B |
