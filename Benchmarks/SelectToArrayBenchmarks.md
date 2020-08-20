## SelectToArrayBenchmarks

### Source
[SelectToArrayBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/SelectToArrayBenchmarks.cs)

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
|                          Linq_Array |                     Array |   100 |   251.3 ns |  2.86 ns |  2.39 ns |  1.00 |    0.00 | 0.2255 |     - |     - |     472 B |
|                    StructLinq_Array |                     Array |   100 |   415.6 ns |  3.12 ns |  2.92 ns |  1.66 |    0.02 | 0.2027 |     - |     - |     424 B |
|                     Hyperlinq_Array |                     Array |   100 |   224.9 ns |  2.06 ns |  1.83 ns |  0.90 |    0.01 | 0.2027 |     - |     - |     424 B |
|                      Hyperlinq_Span |                     Array |   100 |   251.0 ns |  2.14 ns |  1.90 ns |  1.00 |    0.01 | 0.2027 |     - |     - |     424 B |
|                    Hyperlinq_Memory |                     Array |   100 |   254.1 ns |  2.92 ns |  2.59 ns |  1.01 |    0.02 | 0.2027 |     - |     - |     424 B |
|                                     |                           |       |            |          |          |       |         |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |   100 | 1,078.9 ns |  7.82 ns |  6.94 ns |  1.00 |    0.00 | 0.5913 |     - |     - |    1240 B |
|         StructLinq_Enumerable_Value |          Enumerable_Value |   100 | 1,122.2 ns |  7.73 ns |  6.86 ns |  1.04 |    0.01 | 0.2174 |     - |     - |     456 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 |   593.3 ns |  3.21 ns |  2.68 ns |  0.55 |    0.00 | 0.2022 |     - |     - |     424 B |
|                                     |                           |       |            |          |          |       |         |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |   100 | 1,121.5 ns |  8.46 ns |  7.50 ns |  1.00 |    0.00 | 0.5913 |     - |     - |    1240 B |
|         StructLinq_Collection_Value |          Collection_Value |   100 | 1,115.1 ns |  8.03 ns |  7.12 ns |  0.99 |    0.01 | 0.2174 |     - |     - |     456 B |
|          Hyperlinq_Collection_Value |          Collection_Value |   100 |   245.1 ns |  2.12 ns |  1.88 ns |  0.22 |    0.00 | 0.2027 |     - |     - |     424 B |
|                                     |                           |       |            |          |          |       |         |        |       |       |           |
|                     Linq_List_Value |                List_Value |   100 |   421.1 ns |  4.16 ns |  3.25 ns |  1.00 |    0.00 | 0.2294 |     - |     - |     480 B |
|               StructLinq_List_Value |                List_Value |   100 | 1,117.7 ns |  8.88 ns |  8.31 ns |  2.65 |    0.02 | 0.2174 |     - |     - |     456 B |
|                Hyperlinq_List_Value |                List_Value |   100 |   419.5 ns |  6.46 ns |  5.72 ns |  1.00 |    0.01 | 0.2027 |     - |     - |     424 B |
|                                     |                           |       |            |          |          |       |         |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |   100 |   893.4 ns |  7.26 ns |  6.79 ns |  1.00 |    0.00 | 0.5913 |     - |     - |    1240 B |
|     StructLinq_Enumerable_Reference |      Enumerable_Reference |   100 |   886.1 ns |  4.14 ns |  3.67 ns |  0.99 |    0.01 | 0.2174 |     - |     - |     456 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 |   915.4 ns |  7.15 ns |  6.34 ns |  1.03 |    0.01 | 0.2174 |     - |     - |     456 B |
|                                     |                           |       |            |          |          |       |         |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |   100 |   894.1 ns |  5.53 ns |  4.90 ns |  1.00 |    0.00 | 0.5922 |     - |     - |    1240 B |
|     StructLinq_Collection_Reference |      Collection_Reference |   100 |   903.0 ns |  8.20 ns |  7.27 ns |  1.01 |    0.01 | 0.2174 |     - |     - |     456 B |
|      Hyperlinq_Collection_Reference |      Collection_Reference |   100 |   589.8 ns |  4.20 ns |  3.73 ns |  0.66 |    0.01 | 0.2174 |     - |     - |     456 B |
|                                     |                           |       |            |          |          |       |         |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |   100 |   451.5 ns |  1.77 ns |  1.57 ns |  1.00 |    0.00 | 0.2294 |     - |     - |     480 B |
|           StructLinq_List_Reference |            List_Reference |   100 |   893.7 ns |  3.59 ns |  2.99 ns |  1.98 |    0.01 | 0.2174 |     - |     - |     456 B |
|            Hyperlinq_List_Reference |            List_Reference |   100 |   468.0 ns |  2.59 ns |  2.16 ns |  1.04 |    0.01 | 0.2027 |     - |     - |     424 B |
|                                     |                           |       |            |          |          |       |         |        |       |       |           |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 9,381.5 ns | 46.31 ns | 43.32 ns |     ? |       ? | 0.8087 |     - |     - |    1712 B |
|                                     |                           |       |            |          |          |       |         |        |       |       |           |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 9,247.8 ns | 60.87 ns | 53.96 ns |     ? |       ? | 0.8240 |     - |     - |    1728 B |
