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
|                          Linq_Array |                     Array |     1 | 13.324 ns | 0.0786 ns | 0.0697 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|                     Hyperlinq_Array |                     Array |     1 | 14.424 ns | 0.0405 ns | 0.0379 ns |  1.08 |    0.01 |      - |     - |     - |         - |
|                      Hyperlinq_Span |                     Array |     1 | 14.342 ns | 0.0325 ns | 0.0304 ns |  1.08 |    0.01 |      - |     - |     - |         - |
|                    Hyperlinq_Memory |                     Array |     1 | 16.502 ns | 0.0583 ns | 0.0545 ns |  1.24 |    0.01 |      - |     - |     - |         - |
|                                     |                           |       |           |           |           |       |         |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |     1 | 24.683 ns | 0.1570 ns | 0.1469 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |     1 | 17.087 ns | 0.0393 ns | 0.0367 ns |  0.69 |    0.00 |      - |     - |     - |         - |
|                                     |                           |       |           |           |           |       |         |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |     1 | 24.917 ns | 0.1347 ns | 0.1194 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Collection_Value |          Collection_Value |     1 | 19.338 ns | 0.0630 ns | 0.0590 ns |  0.78 |    0.01 |      - |     - |     - |         - |
|                                     |                           |       |           |           |           |       |         |        |       |       |           |
|                     Linq_List_Value |                List_Value |     1 |  7.591 ns | 0.0447 ns | 0.0396 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|                Hyperlinq_List_Value |                List_Value |     1 | 21.610 ns | 0.0552 ns | 0.0461 ns |  2.85 |    0.01 |      - |     - |     - |         - |
|                                     |                           |       |           |           |           |       |         |        |       |       |           |
|          Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |     1 | 92.081 ns | 0.4684 ns | 0.4382 ns |  1.00 |    0.00 | 0.0191 |     - |     - |      40 B |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |     1 |        NA |        NA |        NA |     ? |       ? |      - |     - |     - |         - |
|                                     |                           |       |           |           |           |       |         |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |     1 | 19.069 ns | 0.0655 ns | 0.0547 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |     1 | 18.624 ns | 0.1026 ns | 0.0856 ns |  0.98 |    0.00 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |           |           |           |       |         |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |     1 | 19.588 ns | 0.1720 ns | 0.1436 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Collection_Reference |      Collection_Reference |     1 | 16.822 ns | 0.0927 ns | 0.0822 ns |  0.86 |    0.01 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |           |           |           |       |         |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |     1 |  7.599 ns | 0.0596 ns | 0.0498 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq_List_Reference |            List_Reference |     1 | 22.047 ns | 0.0516 ns | 0.0458 ns |  2.90 |    0.02 |      - |     - |     - |         - |
|                                     |                           |       |           |           |           |       |         |        |       |       |           |
|      Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |     1 | 88.891 ns | 0.2663 ns | 0.2361 ns |  1.00 |    0.00 | 0.0191 |     - |     - |      40 B |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |     1 |        NA |        NA |        NA |     ? |       ? |      - |     - |     - |         - |

Benchmarks with issues:
  SingleBenchmarks.Hyperlinq_AsyncEnumerable_Value: .NET Core 5.0(Runtime=.NET Core 5.0) [Count=1]
  SingleBenchmarks.Hyperlinq_AsyncEnumerable_Reference: .NET Core 5.0(Runtime=.NET Core 5.0) [Count=1]
