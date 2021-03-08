## WhereToArrayBenchmarks

### Source
[WhereToArrayBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/WhereToArrayBenchmarks.cs)

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
|                          Linq_Array |                     Array |   100 |   421.6 ns |  2.03 ns |  1.90 ns |  1.00 |    0.00 | 0.3519 |     - |     - |     736 B |
|                    StructLinq_Array |                     Array |   100 |   388.5 ns |  1.46 ns |  1.29 ns |  0.92 |    0.00 | 0.1144 |     - |     - |     240 B |
|                     Hyperlinq_Array |                     Array |   100 |   501.5 ns |  1.89 ns |  1.68 ns |  1.19 |    0.01 | 0.1144 |     - |     - |     240 B |
|                      Hyperlinq_Span |                     Array |   100 |   534.8 ns |  2.64 ns |  2.47 ns |  1.27 |    0.01 | 0.1144 |     - |     - |     240 B |
|                    Hyperlinq_Memory |                     Array |   100 |   535.0 ns |  2.94 ns |  2.75 ns |  1.27 |    0.01 | 0.1144 |     - |     - |     240 B |
|                                     |                           |       |            |          |          |       |         |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |   100 | 1,239.6 ns |  8.83 ns |  7.83 ns |  1.00 |    0.00 | 0.3700 |     - |     - |     776 B |
|         StructLinq_Enumerable_Value |          Enumerable_Value |   100 | 1,228.0 ns |  7.26 ns |  6.43 ns |  0.99 |    0.01 | 0.1297 |     - |     - |     272 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 | 1,418.4 ns |  5.42 ns |  5.07 ns |  1.14 |    0.01 | 0.1297 |     - |     - |     272 B |
|                                     |                           |       |            |          |          |       |         |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |   100 | 1,257.2 ns |  4.58 ns |  4.06 ns |  1.00 |    0.00 | 0.3700 |     - |     - |     776 B |
|         StructLinq_Collection_Value |          Collection_Value |   100 | 1,238.9 ns |  6.93 ns |  6.14 ns |  0.99 |    0.01 | 0.1297 |     - |     - |     272 B |
|          Hyperlinq_Collection_Value |          Collection_Value |   100 | 1,377.3 ns |  6.68 ns |  5.58 ns |  1.10 |    0.01 | 0.1297 |     - |     - |     272 B |
|                                     |                           |       |            |          |          |       |         |        |       |       |           |
|                     Linq_List_Value |                List_Value |   100 | 1,238.3 ns | 11.36 ns |  9.49 ns |  1.00 |    0.00 | 0.3700 |     - |     - |     776 B |
|               StructLinq_List_Value |                List_Value |   100 |   765.3 ns |  2.77 ns |  2.59 ns |  0.62 |    0.00 | 0.1144 |     - |     - |     240 B |
|                Hyperlinq_List_Value |                List_Value |   100 | 1,209.7 ns |  6.22 ns |  5.51 ns |  0.98 |    0.01 | 0.1144 |     - |     - |     240 B |
|                                     |                           |       |            |          |          |       |         |        |       |       |           |
|          Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 6,057.4 ns | 22.16 ns | 18.50 ns |  1.00 |    0.00 | 0.4578 |     - |     - |     960 B |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 6,334.9 ns | 20.54 ns | 18.20 ns |  1.05 |    0.00 | 0.4807 |     - |     - |    1008 B |
|                                     |                           |       |            |          |          |       |         |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |   100 |   854.1 ns | 10.76 ns | 10.06 ns |  1.00 |    0.00 | 0.3710 |     - |     - |     776 B |
|     StructLinq_Enumerable_Reference |      Enumerable_Reference |   100 |   844.6 ns |  3.56 ns |  3.33 ns |  0.99 |    0.01 | 0.1297 |     - |     - |     272 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 |   994.6 ns | 19.30 ns | 22.98 ns |  1.16 |    0.03 | 0.1297 |     - |     - |     272 B |
|                                     |                           |       |            |          |          |       |         |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |   100 |   862.5 ns |  4.60 ns |  4.08 ns |  1.00 |    0.00 | 0.3710 |     - |     - |     776 B |
|     StructLinq_Collection_Reference |      Collection_Reference |   100 |   822.6 ns |  4.80 ns |  4.26 ns |  0.95 |    0.01 | 0.1297 |     - |     - |     272 B |
|      Hyperlinq_Collection_Reference |      Collection_Reference |   100 | 1,040.0 ns | 20.67 ns | 44.50 ns |  1.24 |    0.06 | 0.1297 |     - |     - |     272 B |
|                                     |                           |       |            |          |          |       |         |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |   100 |   802.1 ns |  4.30 ns |  3.81 ns |  1.00 |    0.00 | 0.3710 |     - |     - |     776 B |
|           StructLinq_List_Reference |            List_Reference |   100 |   819.1 ns |  2.61 ns |  2.18 ns |  1.02 |    0.00 | 0.1297 |     - |     - |     272 B |
|            Hyperlinq_List_Reference |            List_Reference |   100 | 1,228.9 ns | 23.91 ns | 27.54 ns |  1.54 |    0.04 | 0.1144 |     - |     - |     240 B |
|                                     |                           |       |            |          |          |       |         |        |       |       |           |
|      Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 5,987.0 ns | 18.95 ns | 17.72 ns |  1.00 |    0.00 | 0.4578 |     - |     - |     960 B |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 6,165.6 ns | 18.78 ns | 15.68 ns |  1.03 |    0.00 | 0.4807 |     - |     - |    1008 B |
