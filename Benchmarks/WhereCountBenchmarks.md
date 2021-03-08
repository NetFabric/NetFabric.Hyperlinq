## WhereCountBenchmarks

### Source
[WhereCountBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/WhereCountBenchmarks.cs)

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
|                              Method |                Categories | Count |       Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------ |-------------------------- |------ |-----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|                          Linq_Array |                     Array |   100 |   708.1 ns |  3.07 ns |  2.73 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
|                    StructLinq_Array |                     Array |   100 |   241.5 ns |  2.91 ns |  2.58 ns |  0.34 |    0.00 |      - |     - |     - |         - |
|                     Hyperlinq_Array |                     Array |   100 |   206.9 ns |  1.03 ns |  0.96 ns |  0.29 |    0.00 |      - |     - |     - |         - |
|                      Hyperlinq_Span |                     Array |   100 |   202.3 ns |  0.46 ns |  0.43 ns |  0.29 |    0.00 |      - |     - |     - |         - |
|                    Hyperlinq_Memory |                     Array |   100 |   182.5 ns |  0.53 ns |  0.44 ns |  0.26 |    0.00 |      - |     - |     - |         - |
|                                     |                           |       |            |          |          |       |         |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |   100 | 1,190.8 ns |  5.91 ns |  5.24 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
|         StructLinq_Enumerable_Value |          Enumerable_Value |   100 | 1,193.9 ns |  6.87 ns |  6.09 ns |  1.00 |    0.01 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 |   268.4 ns |  2.72 ns |  2.41 ns |  0.23 |    0.00 |      - |     - |     - |         - |
|                                     |                           |       |            |          |          |       |         |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |   100 | 1,210.5 ns |  6.57 ns |  5.83 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
|         StructLinq_Collection_Value |          Collection_Value |   100 | 1,163.0 ns |  5.17 ns |  4.58 ns |  0.96 |    0.01 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Collection_Value |          Collection_Value |   100 |   274.8 ns |  1.05 ns |  0.82 ns |  0.23 |    0.00 |      - |     - |     - |         - |
|                                     |                           |       |            |          |          |       |         |        |       |       |           |
|                     Linq_List_Value |                List_Value |   100 | 1,206.0 ns |  2.63 ns |  2.19 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
|               StructLinq_List_Value |                List_Value |   100 |   474.2 ns |  3.28 ns |  2.91 ns |  0.39 |    0.00 |      - |     - |     - |         - |
|                Hyperlinq_List_Value |                List_Value |   100 |   618.5 ns |  2.87 ns |  2.40 ns |  0.51 |    0.00 |      - |     - |     - |         - |
|                                     |                           |       |            |          |          |       |         |        |       |       |           |
|          Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 2,268.0 ns | 14.41 ns | 12.78 ns |  1.00 |    0.00 | 0.0191 |     - |     - |      40 B |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 5,953.1 ns | 24.09 ns | 21.36 ns |  2.62 |    0.02 | 0.0687 |     - |     - |     144 B |
|                                     |                           |       |            |          |          |       |         |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |   100 |   814.8 ns |  4.93 ns |  4.37 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
|     StructLinq_Enumerable_Reference |      Enumerable_Reference |   100 |   703.6 ns |  5.15 ns |  4.82 ns |  0.86 |    0.01 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 |   596.8 ns |  4.06 ns |  3.80 ns |  0.73 |    0.01 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |            |          |          |       |         |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |   100 |   812.2 ns |  3.22 ns |  2.85 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
|     StructLinq_Collection_Reference |      Collection_Reference |   100 |   662.1 ns |  2.94 ns |  2.30 ns |  0.82 |    0.00 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Collection_Reference |      Collection_Reference |   100 |   606.5 ns |  2.91 ns |  2.43 ns |  0.75 |    0.00 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |            |          |          |       |         |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |   100 |   803.1 ns |  4.77 ns |  4.23 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
|           StructLinq_List_Reference |            List_Reference |   100 |   709.9 ns |  4.29 ns |  4.01 ns |  0.88 |    0.01 | 0.0153 |     - |     - |      32 B |
|            Hyperlinq_List_Reference |            List_Reference |   100 |   641.7 ns |  3.03 ns |  2.69 ns |  0.80 |    0.00 |      - |     - |     - |         - |
|                                     |                           |       |            |          |          |       |         |        |       |       |           |
|      Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 2,134.6 ns |  7.28 ns |  6.81 ns |  1.00 |    0.00 | 0.0191 |     - |     - |      40 B |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 6,145.6 ns | 26.59 ns | 24.87 ns |  2.88 |    0.02 | 0.0687 |     - |     - |     152 B |
