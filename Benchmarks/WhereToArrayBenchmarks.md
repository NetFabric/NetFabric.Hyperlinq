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
|                              Method |                Categories | Count |       Mean |    Error |   StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------ |-------------------------- |------ |-----------:|---------:|---------:|------:|-------:|------:|------:|----------:|
|                          Linq_Array |                     Array |   100 |   442.6 ns |  3.03 ns |  2.53 ns |  1.00 | 0.3519 |     - |     - |     736 B |
|                    StructLinq_Array |                     Array |   100 |   399.3 ns |  2.82 ns |  2.63 ns |  0.90 | 0.1144 |     - |     - |     240 B |
|                     Hyperlinq_Array |                     Array |   100 |   513.9 ns |  2.97 ns |  2.63 ns |  1.16 | 0.1144 |     - |     - |     240 B |
|                      Hyperlinq_Span |                     Array |   100 |   543.4 ns |  3.89 ns |  3.44 ns |  1.23 | 0.1144 |     - |     - |     240 B |
|                    Hyperlinq_Memory |                     Array |   100 |   473.3 ns |  3.42 ns |  3.03 ns |  1.07 | 0.1144 |     - |     - |     240 B |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |   100 | 1,269.0 ns |  5.50 ns |  4.87 ns |  1.00 | 0.3700 |     - |     - |     776 B |
|         StructLinq_Enumerable_Value |          Enumerable_Value |   100 | 1,259.4 ns |  4.88 ns |  4.57 ns |  0.99 | 0.1297 |     - |     - |     272 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 |   513.7 ns |  3.88 ns |  3.44 ns |  0.40 | 0.1144 |     - |     - |     240 B |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |   100 | 1,266.6 ns |  5.61 ns |  4.98 ns |  1.00 | 0.3700 |     - |     - |     776 B |
|         StructLinq_Collection_Value |          Collection_Value |   100 | 1,263.9 ns |  6.06 ns |  5.67 ns |  1.00 | 0.1297 |     - |     - |     272 B |
|          Hyperlinq_Collection_Value |          Collection_Value |   100 |   530.8 ns |  4.27 ns |  3.78 ns |  0.42 | 0.1144 |     - |     - |     240 B |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|                     Linq_List_Value |                List_Value |   100 | 1,274.9 ns |  5.72 ns |  5.07 ns |  1.00 | 0.3700 |     - |     - |     776 B |
|               StructLinq_List_Value |                List_Value |   100 |   786.8 ns |  4.29 ns |  3.58 ns |  0.62 | 0.1144 |     - |     - |     240 B |
|                Hyperlinq_List_Value |                List_Value |   100 | 1,220.3 ns |  4.46 ns |  3.95 ns |  0.96 | 0.1144 |     - |     - |     240 B |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|          Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 6,297.3 ns | 31.68 ns | 29.63 ns |  1.00 | 0.4578 |     - |     - |     960 B |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 6,126.6 ns | 18.72 ns | 14.62 ns |  0.97 | 0.4730 |     - |     - |    1000 B |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |   100 |   862.1 ns |  5.85 ns |  5.18 ns |  1.00 | 0.3710 |     - |     - |     776 B |
|     StructLinq_Enumerable_Reference |      Enumerable_Reference |   100 |   859.4 ns |  2.54 ns |  2.25 ns |  1.00 | 0.1297 |     - |     - |     272 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 |   926.9 ns |  3.09 ns |  2.74 ns |  1.08 | 0.1297 |     - |     - |     272 B |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |   100 |   873.8 ns |  4.45 ns |  3.94 ns |  1.00 | 0.3710 |     - |     - |     776 B |
|     StructLinq_Collection_Reference |      Collection_Reference |   100 |   817.3 ns |  3.80 ns |  3.37 ns |  0.94 | 0.1297 |     - |     - |     272 B |
|      Hyperlinq_Collection_Reference |      Collection_Reference |   100 |   934.2 ns |  3.26 ns |  2.89 ns |  1.07 | 0.1297 |     - |     - |     272 B |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |   100 |   836.2 ns |  4.73 ns |  4.20 ns |  1.00 | 0.3700 |     - |     - |     776 B |
|           StructLinq_List_Reference |            List_Reference |   100 |   813.2 ns |  4.00 ns |  3.54 ns |  0.97 | 0.1297 |     - |     - |     272 B |
|            Hyperlinq_List_Reference |            List_Reference |   100 | 1,179.2 ns |  4.94 ns |  4.62 ns |  1.41 | 0.1144 |     - |     - |     240 B |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|      Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 6,235.5 ns | 20.57 ns | 18.23 ns |  1.00 | 0.4578 |     - |     - |     960 B |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 6,180.0 ns | 12.25 ns | 11.46 ns |  0.99 | 0.4807 |     - |     - |    1008 B |
