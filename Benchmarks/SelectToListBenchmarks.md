## SelectToListBenchmarks

### Source
[SelectToListBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/SelectToListBenchmarks.cs)

### References:
- Linq: 5.0.0-preview.7.20364.11
- System.Linq.Async: [4.1.1](https://www.nuget.org/packages/System.Linq.Async/4.1.1)
- System.Interactive: [4.1.1](https://www.nuget.org/packages/System.Interactive/4.1.1)
- System.Interactive.Async: [4.1.1](https://www.nuget.org/packages/System.Interactive.Async/4.1.1)
- StructLinq: [0.19.2](https://www.nuget.org/packages/StructLinq/0.19.2)
- NetFabric.Hyperlinq: [3.0.0-beta26](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta26)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.100-preview.7.20366.6
  [Host]        : .NET Core 5.0.0 (CoreCLR 5.0.20.36411, CoreFX 5.0.20.36411), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.0 (CoreCLR 5.0.20.36411, CoreFX 5.0.20.36411), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|                              Method |                Categories | Count |       Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------ |-------------------------- |------ |-----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|                           Linq_List |                     Array |   100 |   320.1 ns |  1.85 ns |  1.64 ns |  1.00 |    0.00 | 0.2408 |     - |     - |     504 B |
|                     StructLinq_List |                     Array |   100 |   453.1 ns |  1.97 ns |  1.74 ns |  1.42 |    0.01 | 0.2179 |     - |     - |     456 B |
|                      Hyperlinq_List |                     Array |   100 |   268.5 ns |  1.86 ns |  1.65 ns |  0.84 |    0.01 | 0.2408 |     - |     - |     504 B |
|                      Hyperlinq_Span |                     Array |   100 |   233.2 ns |  1.33 ns |  1.18 ns |  0.73 |    0.01 | 0.2179 |     - |     - |     456 B |
|                    Hyperlinq_Memory |                     Array |   100 |   270.3 ns |  2.53 ns |  2.36 ns |  0.84 |    0.01 | 0.2408 |     - |     - |     504 B |
|                                     |                           |       |            |          |          |       |         |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |   100 | 1,095.7 ns | 10.55 ns |  9.36 ns |  1.00 |    0.00 | 0.6065 |     - |     - |    1272 B |
|         StructLinq_Enumerable_Value |          Enumerable_Value |   100 | 1,161.4 ns |  9.03 ns |  8.00 ns |  1.06 |    0.01 | 0.2327 |     - |     - |     488 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 |   628.1 ns |  3.15 ns |  2.63 ns |  0.57 |    0.00 | 0.2518 |     - |     - |     528 B |
|                                     |                           |       |            |          |          |       |         |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |   100 | 1,102.0 ns |  8.26 ns |  7.32 ns |  1.00 |    0.00 | 0.6065 |     - |     - |    1272 B |
|         StructLinq_Collection_Value |          Collection_Value |   100 | 1,089.2 ns | 10.39 ns |  8.11 ns |  0.99 |    0.01 | 0.2327 |     - |     - |     488 B |
|          Hyperlinq_Collection_Value |          Collection_Value |   100 |   282.1 ns |  1.72 ns |  1.61 ns |  0.26 |    0.00 | 0.2408 |     - |     - |     504 B |
|                                     |                           |       |            |          |          |       |         |        |       |       |           |
|                     Linq_List_Value |                List_Value |   100 |   497.9 ns |  2.42 ns |  2.14 ns |  1.00 |    0.00 | 0.2441 |     - |     - |     512 B |
|               StructLinq_List_Value |                List_Value |   100 | 1,121.3 ns |  7.82 ns |  6.93 ns |  2.25 |    0.02 | 0.2327 |     - |     - |     488 B |
|                Hyperlinq_List_Value |                List_Value |   100 |   485.5 ns |  3.20 ns |  2.84 ns |  0.98 |    0.01 | 0.2403 |     - |     - |     504 B |
|                                     |                           |       |            |          |          |       |         |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |   100 |   859.7 ns |  4.49 ns |  3.98 ns |  1.00 |    0.00 | 0.6075 |     - |     - |    1272 B |
|     StructLinq_Enumerable_Reference |      Enumerable_Reference |   100 |   937.3 ns |  5.56 ns |  5.20 ns |  1.09 |    0.01 | 0.2327 |     - |     - |     488 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 | 1,003.1 ns |  6.57 ns |  6.14 ns |  1.17 |    0.01 | 0.2670 |     - |     - |     560 B |
|                                     |                           |       |            |          |          |       |         |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |   100 |   859.6 ns |  8.64 ns |  7.66 ns |  1.00 |    0.00 | 0.6075 |     - |     - |    1272 B |
|     StructLinq_Collection_Reference |      Collection_Reference |   100 |   936.8 ns |  4.39 ns |  3.89 ns |  1.09 |    0.01 | 0.2327 |     - |     - |     488 B |
|      Hyperlinq_Collection_Reference |      Collection_Reference |   100 |   616.2 ns |  2.69 ns |  2.38 ns |  0.72 |    0.01 | 0.2518 |     - |     - |     528 B |
|                                     |                           |       |            |          |          |       |         |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |   100 |   509.0 ns |  3.94 ns |  3.49 ns |  1.00 |    0.00 | 0.2441 |     - |     - |     512 B |
|           StructLinq_List_Reference |            List_Reference |   100 |   912.4 ns |  4.55 ns |  3.80 ns |  1.79 |    0.01 | 0.2327 |     - |     - |     488 B |
|            Hyperlinq_List_Reference |            List_Reference |   100 |   436.2 ns |  1.87 ns |  1.65 ns |  0.86 |    0.01 | 0.2408 |     - |     - |     504 B |
|                                     |                           |       |            |          |          |       |         |        |       |       |           |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 9,735.0 ns | 41.39 ns | 38.72 ns |     ? |       ? | 0.6256 |     - |     - |    1320 B |
|                                     |                           |       |            |          |          |       |         |        |       |       |           |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 9,598.9 ns | 68.79 ns | 64.35 ns |     ? |       ? | 0.6256 |     - |     - |    1336 B |
