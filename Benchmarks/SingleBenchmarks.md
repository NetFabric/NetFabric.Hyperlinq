## SingleBenchmarks

### Source
[SingleBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/SingleBenchmarks.cs)

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
|                              Method |                Categories | Count |      Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------ |-------------------------- |------ |----------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|                          Linq_Array |                     Array |     1 | 11.396 ns | 0.0524 ns | 0.0409 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|                     Hyperlinq_Array |                     Array |     1 | 14.567 ns | 0.0387 ns | 0.0302 ns |  1.28 |    0.01 |      - |     - |     - |         - |
|                      Hyperlinq_Span |                     Array |     1 | 13.811 ns | 0.0382 ns | 0.0357 ns |  1.21 |    0.01 |      - |     - |     - |         - |
|                    Hyperlinq_Memory |                     Array |     1 | 16.058 ns | 0.0490 ns | 0.0435 ns |  1.41 |    0.01 |      - |     - |     - |         - |
|                                     |                           |       |           |           |           |       |         |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |     1 | 22.696 ns | 0.1515 ns | 0.1343 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |     1 | 20.032 ns | 0.1338 ns | 0.1252 ns |  0.88 |    0.01 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |           |           |           |       |         |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |     1 | 23.944 ns | 0.0916 ns | 0.0765 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Collection_Value |          Collection_Value |     1 | 19.577 ns | 0.1096 ns | 0.0972 ns |  0.82 |    0.01 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |           |           |           |       |         |        |       |       |           |
|                     Linq_List_Value |                List_Value |     1 |  7.322 ns | 0.0691 ns | 0.0577 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|                Hyperlinq_List_Value |                List_Value |     1 | 21.310 ns | 0.0896 ns | 0.0699 ns |  2.91 |    0.02 |      - |     - |     - |         - |
|                                     |                           |       |           |           |           |       |         |        |       |       |           |
|          Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |     1 | 89.281 ns | 0.4970 ns | 0.4406 ns |  1.00 |    0.00 | 0.0191 |     - |     - |      40 B |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |     1 |        NA |        NA |        NA |     ? |       ? |      - |     - |     - |         - |
|                                     |                           |       |           |           |           |       |         |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |     1 | 18.266 ns | 0.0741 ns | 0.0694 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |     1 | 16.620 ns | 0.1081 ns | 0.0903 ns |  0.91 |    0.01 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |           |           |           |       |         |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |     1 | 18.745 ns | 0.1457 ns | 0.1363 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Collection_Reference |      Collection_Reference |     1 | 16.057 ns | 0.1084 ns | 0.0961 ns |  0.86 |    0.01 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |           |           |           |       |         |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |     1 |  7.284 ns | 0.0382 ns | 0.0357 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq_List_Reference |            List_Reference |     1 | 21.337 ns | 0.0682 ns | 0.0605 ns |  2.93 |    0.01 |      - |     - |     - |         - |
|                                     |                           |       |           |           |           |       |         |        |       |       |           |
|      Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |     1 | 85.565 ns | 0.3658 ns | 0.3243 ns |  1.00 |    0.00 | 0.0191 |     - |     - |      40 B |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |     1 |        NA |        NA |        NA |     ? |       ? |      - |     - |     - |         - |

Benchmarks with issues:
  SingleBenchmarks.Hyperlinq_AsyncEnumerable_Value: .NET Core 5.0(Runtime=.NET Core 5.0) [Count=1]
  SingleBenchmarks.Hyperlinq_AsyncEnumerable_Reference: .NET Core 5.0(Runtime=.NET Core 5.0) [Count=1]
