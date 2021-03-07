## AnyBenchmarks

### Source
[AnyBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/AnyBenchmarks.cs)

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
|                              Method |                Categories | Count |      Mean |     Error |    StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------ |-------------------------- |------ |----------:|----------:|----------:|------:|-------:|------:|------:|----------:|
|                          Linq_Array |                     Array |   100 |  9.437 ns | 0.0517 ns | 0.0483 ns |  1.00 |      - |     - |     - |         - |
|                     Hyperlinq_Array |                     Array |   100 |  8.150 ns | 0.0172 ns | 0.0134 ns |  0.86 |      - |     - |     - |         - |
|                      Hyperlinq_Span |                     Array |   100 |  6.555 ns | 0.0123 ns | 0.0115 ns |  0.69 |      - |     - |     - |         - |
|                    Hyperlinq_Memory |                     Array |   100 |  9.220 ns | 0.0099 ns | 0.0093 ns |  0.98 |      - |     - |     - |         - |
|                                     |                           |       |           |           |           |       |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |   100 | 20.534 ns | 0.1004 ns | 0.0940 ns |  1.00 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 | 12.359 ns | 0.0510 ns | 0.0398 ns |  0.60 |      - |     - |     - |         - |
|                                     |                           |       |           |           |           |       |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |   100 |  4.819 ns | 0.0133 ns | 0.0118 ns |  1.00 |      - |     - |     - |         - |
|          Hyperlinq_Collection_Value |          Collection_Value |   100 |  4.624 ns | 0.0144 ns | 0.0135 ns |  0.96 |      - |     - |     - |         - |
|                                     |                           |       |           |           |           |       |        |       |       |           |
|                     Linq_List_Value |                List_Value |   100 |  5.722 ns | 0.0235 ns | 0.0220 ns |  1.00 |      - |     - |     - |         - |
|                Hyperlinq_List_Value |                List_Value |   100 |  1.805 ns | 0.0197 ns | 0.0165 ns |  0.32 |      - |     - |     - |         - |
|                                     |                           |       |           |           |           |       |        |       |       |           |
|          Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 66.221 ns | 0.2492 ns | 0.2081 ns |  1.00 | 0.0191 |     - |     - |      40 B |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 60.952 ns | 0.1109 ns | 0.0866 ns |  0.92 |      - |     - |     - |         - |
|                                     |                           |       |           |           |           |       |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |   100 | 18.194 ns | 0.0720 ns | 0.0673 ns |  1.00 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 | 10.028 ns | 0.0569 ns | 0.0532 ns |  0.55 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |           |           |           |       |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |   100 |  4.918 ns | 0.0158 ns | 0.0148 ns |  1.00 |      - |     - |     - |         - |
|      Hyperlinq_Collection_Reference |      Collection_Reference |   100 |  1.550 ns | 0.0071 ns | 0.0067 ns |  0.32 |      - |     - |     - |         - |
|                                     |                           |       |           |           |           |       |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |   100 |  5.615 ns | 0.0178 ns | 0.0166 ns |  1.00 |      - |     - |     - |         - |
|            Hyperlinq_List_Reference |            List_Reference |   100 |  1.778 ns | 0.0079 ns | 0.0074 ns |  0.32 |      - |     - |     - |         - |
|                                     |                           |       |           |           |           |       |        |       |       |           |
|      Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 64.021 ns | 0.1368 ns | 0.1212 ns |  1.00 | 0.0191 |     - |     - |      40 B |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 62.809 ns | 0.2885 ns | 0.2409 ns |  0.98 | 0.0191 |     - |     - |      40 B |
