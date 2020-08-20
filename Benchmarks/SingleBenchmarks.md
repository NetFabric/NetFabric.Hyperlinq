## SingleBenchmarks

### Source
[SingleBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/SingleBenchmarks.cs)

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
|                              Method |                Categories | Count |      Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------ |-------------------------- |------ |----------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|                          Linq_Array |                     Array |     1 | 12.122 ns | 0.1403 ns | 0.1313 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|                     Hyperlinq_Array |                     Array |     1 |  4.217 ns | 0.0360 ns | 0.0337 ns |  0.35 |    0.00 |      - |     - |     - |         - |
|                      Hyperlinq_Span |                     Array |     1 |  6.426 ns | 0.0366 ns | 0.0324 ns |  0.53 |    0.01 |      - |     - |     - |         - |
|                    Hyperlinq_Memory |                     Array |     1 |  8.223 ns | 0.0378 ns | 0.0335 ns |  0.68 |    0.01 |      - |     - |     - |         - |
|                                     |                           |       |           |           |           |       |         |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |     1 | 22.876 ns | 0.2125 ns | 0.1987 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |     1 | 11.605 ns | 0.0566 ns | 0.0502 ns |  0.51 |    0.00 |      - |     - |     - |         - |
|                                     |                           |       |           |           |           |       |         |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |     1 | 23.281 ns | 0.2148 ns | 0.2009 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Collection_Value |          Collection_Value |     1 | 13.422 ns | 0.0811 ns | 0.0759 ns |  0.58 |    0.01 |      - |     - |     - |         - |
|                                     |                           |       |           |           |           |       |         |        |       |       |           |
|                     Linq_List_Value |                List_Value |     1 |  6.868 ns | 0.1021 ns | 0.0853 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|                Hyperlinq_List_Value |                List_Value |     1 |  7.779 ns | 0.0551 ns | 0.0515 ns |  1.13 |    0.01 |      - |     - |     - |         - |
|                                     |                           |       |           |           |           |       |         |        |       |       |           |
|          Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |     1 | 90.521 ns | 0.5091 ns | 0.4513 ns |  1.00 |    0.00 | 0.0191 |     - |     - |      40 B |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |     1 |        NA |        NA |        NA |     ? |       ? |      - |     - |     - |         - |
|                                     |                           |       |           |           |           |       |         |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |     1 | 17.826 ns | 0.1628 ns | 0.1522 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |     1 | 16.616 ns | 0.1700 ns | 0.1419 ns |  0.93 |    0.01 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |           |           |           |       |         |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |     1 | 18.627 ns | 0.2188 ns | 0.1940 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Collection_Reference |      Collection_Reference |     1 | 18.101 ns | 0.1504 ns | 0.1256 ns |  0.97 |    0.01 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |           |           |           |       |         |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |     1 |  6.842 ns | 0.0269 ns | 0.0225 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq_List_Reference |            List_Reference |     1 |  7.791 ns | 0.0872 ns | 0.0773 ns |  1.14 |    0.01 |      - |     - |     - |         - |
|                                     |                           |       |           |           |           |       |         |        |       |       |           |
|      Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |     1 | 88.124 ns | 0.4533 ns | 0.4240 ns |  1.00 |    0.00 | 0.0191 |     - |     - |      40 B |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |     1 |        NA |        NA |        NA |     ? |       ? |      - |     - |     - |         - |

Benchmarks with issues:
  SingleBenchmarks.Hyperlinq_AsyncEnumerable_Value: .NET Core 5.0(Runtime=.NET Core 5.0) [Count=1]
  SingleBenchmarks.Hyperlinq_AsyncEnumerable_Reference: .NET Core 5.0(Runtime=.NET Core 5.0) [Count=1]
